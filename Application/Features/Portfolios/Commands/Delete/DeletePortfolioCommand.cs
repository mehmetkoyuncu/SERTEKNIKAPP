using Application.Features.Portfolios.Constants;
using Application.Features.Portfolios.Constants;
using Application.Features.Portfolios.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Portfolios.Constants.PortfoliosOperationClaims;

namespace Application.Features.Portfolios.Commands.Delete;

public class DeletePortfolioCommand : IRequest<DeletedPortfolioResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, PortfoliosOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPortfolios"];

    public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand, DeletedPortfolioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly PortfolioBusinessRules _portfolioBusinessRules;

        public DeletePortfolioCommandHandler(IMapper mapper, IPortfolioRepository portfolioRepository,
                                         PortfolioBusinessRules portfolioBusinessRules)
        {
            _mapper = mapper;
            _portfolioRepository = portfolioRepository;
            _portfolioBusinessRules = portfolioBusinessRules;
        }

        public async Task<DeletedPortfolioResponse> Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
        {
            Portfolio? portfolio = await _portfolioRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _portfolioBusinessRules.PortfolioShouldExistWhenSelected(portfolio);

            await _portfolioRepository.DeleteAsync(portfolio!);

            DeletedPortfolioResponse response = _mapper.Map<DeletedPortfolioResponse>(portfolio);
            return response;
        }
    }
}