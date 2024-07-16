using Application.Features.Ministrations.Constants;
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

namespace Application.Features.Ministrations.Commands.Delete;

public class DeleteMinistrationCommand : IRequest<DeletedMinistrationResponse>,/* ISecuredRequest, ICacheRemoverRequest,*/ ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    //public string[] Roles => [Admin, Write, MinistrationsOperationClaims.Delete];

    //public bool BypassCache { get; }
    //public string? CacheKey { get; }
    //public string[]? CacheGroupKey => ["GetMinistrations"];

    public class DeleteMinistrationCommandHandler : IRequestHandler<DeleteMinistrationCommand, DeletedMinistrationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMinistrationRepository _ministrationRepository;
        private readonly MinistrationBusinessRules _ministrationBusinessRules;

        public DeleteMinistrationCommandHandler(IMapper mapper, IMinistrationRepository ministrationRepository,
                                         MinistrationBusinessRules ministrationBusinessRules)
        {
            _mapper = mapper;
            _ministrationRepository = ministrationRepository;
            _ministrationBusinessRules = ministrationBusinessRules;
        }

        public async Task<DeletedMinistrationResponse> Handle(DeleteMinistrationCommand request, CancellationToken cancellationToken)
        {
            Ministration? ministration = await _ministrationRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _ministrationBusinessRules.MinistrationShouldExistWhenSelected(ministration);

            await _ministrationRepository.DeleteAsync(ministration!);

            DeletedMinistrationResponse response = _mapper.Map<DeletedMinistrationResponse>(ministration);
            return response;
        }
    }
}