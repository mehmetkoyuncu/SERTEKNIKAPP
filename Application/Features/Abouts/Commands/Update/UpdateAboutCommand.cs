using Application.Features.Abouts.Constants;
using Application.Features.Abouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Abouts.Constants.AboutsOperationClaims;

namespace Application.Features.Abouts.Commands.Update;

public class UpdateAboutCommand : IRequest<UpdatedAboutResponse>, /*ISecuredRequest,*/ ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string SmallText { get; set; }
    public required string ImageURL { get; set; }

    public string[] Roles => [Admin, Write, AboutsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAbouts"];

    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, UpdatedAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutRepository _aboutRepository;
        private readonly AboutBusinessRules _aboutBusinessRules;

        public UpdateAboutCommandHandler(IMapper mapper, IAboutRepository aboutRepository,
                                         AboutBusinessRules aboutBusinessRules)
        {
            _mapper = mapper;
            _aboutRepository = aboutRepository;
            _aboutBusinessRules = aboutBusinessRules;
        }

        public async Task<UpdatedAboutResponse> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            About? about = await _aboutRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _aboutBusinessRules.AboutShouldExistWhenSelected(about);
            about = _mapper.Map(request, about);

            await _aboutRepository.UpdateAsync(about!);

            UpdatedAboutResponse response = _mapper.Map<UpdatedAboutResponse>(about);
            return response;
        }
    }
}