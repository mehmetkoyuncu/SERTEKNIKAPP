using Application.Features.Ministrations.Constants;
using Application.Features.Ministrations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Ministrations.Constants.MinistrationsOperationClaims;

namespace Application.Features.Ministrations.Commands.Update;

public class UpdateMinistrationCommand : IRequest<UpdatedMinistrationResponse>,/* ISecuredRequest, ICacheRemoverRequest, */ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string LogoUrl { get; set; }

    //public string[] Roles => [Admin, Write, MinistrationsOperationClaims.Update];

    //public bool BypassCache { get; }
    //public string? CacheKey { get; }
    //public string[]? CacheGroupKey => ["GetMinistrations"];

    public class UpdateMinistrationCommandHandler : IRequestHandler<UpdateMinistrationCommand, UpdatedMinistrationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMinistrationRepository _ministrationRepository;
        private readonly MinistrationBusinessRules _ministrationBusinessRules;

        public UpdateMinistrationCommandHandler(IMapper mapper, IMinistrationRepository ministrationRepository,
                                         MinistrationBusinessRules ministrationBusinessRules)
        {
            _mapper = mapper;
            _ministrationRepository = ministrationRepository;
            _ministrationBusinessRules = ministrationBusinessRules;
        }

        public async Task<UpdatedMinistrationResponse> Handle(UpdateMinistrationCommand request, CancellationToken cancellationToken)
        {
            Ministration? ministration = await _ministrationRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _ministrationBusinessRules.MinistrationShouldExistWhenSelected(ministration);
            ministration = _mapper.Map(request, ministration);

            await _ministrationRepository.UpdateAsync(ministration!);

            UpdatedMinistrationResponse response = _mapper.Map<UpdatedMinistrationResponse>(ministration);
            return response;
        }
    }
}