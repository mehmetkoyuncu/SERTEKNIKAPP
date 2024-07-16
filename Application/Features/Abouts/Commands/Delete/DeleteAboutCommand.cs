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

namespace Application.Features.Abouts.Commands.Delete;

public class DeleteAboutCommand : IRequest<DeletedAboutResponse>, /*ISecuredRequest,*/ ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, AboutsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAbouts"];

    public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand, DeletedAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutRepository _aboutRepository;
        private readonly AboutBusinessRules _aboutBusinessRules;

        public DeleteAboutCommandHandler(IMapper mapper, IAboutRepository aboutRepository,
                                         AboutBusinessRules aboutBusinessRules)
        {
            _mapper = mapper;
            _aboutRepository = aboutRepository;
            _aboutBusinessRules = aboutBusinessRules;
        }

        public async Task<DeletedAboutResponse> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            About? about = await _aboutRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _aboutBusinessRules.AboutShouldExistWhenSelected(about);

            await _aboutRepository.DeleteAsync(about!);

            DeletedAboutResponse response = _mapper.Map<DeletedAboutResponse>(about);
            return response;
        }
    }
}