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

namespace Application.Features.Portfolios.Commands.Update;

public class UpdatePortfolioCommand : IRequest<UpdatedPortfolioResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Text { get; set; }
    public required int PortfolioCategoryId { get; set; }

    public string[] Roles => [Admin, Write, PortfoliosOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPortfolios"];

    public class UpdatePortfolioCommandHandler : IRequestHandler<UpdatePortfolioCommand, UpdatedPortfolioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly PortfolioBusinessRules _portfolioBusinessRules;

        public UpdatePortfolioCommandHandler(IMapper mapper, IPortfolioRepository portfolioRepository,
                                         PortfolioBusinessRules portfolioBusinessRules)
        {
            _mapper = mapper;
            _portfolioRepository = portfolioRepository;
            _portfolioBusinessRules = portfolioBusinessRules;
        }

        public async Task<UpdatedPortfolioResponse> Handle(UpdatePortfolioCommand request, CancellationToken cancellationToken)
        {
            Portfolio? portfolio = await _portfolioRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _portfolioBusinessRules.PortfolioShouldExistWhenSelected(portfolio);
            portfolio = _mapper.Map(request, portfolio);

            await _portfolioRepository.UpdateAsync(portfolio!);

            UpdatedPortfolioResponse response = _mapper.Map<UpdatedPortfolioResponse>(portfolio);
            return response;
        }
    }
}