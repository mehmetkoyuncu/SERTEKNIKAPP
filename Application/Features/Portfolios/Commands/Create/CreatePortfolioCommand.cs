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

namespace Application.Features.Portfolios.Commands.Create;

public class CreatePortfolioCommand : IRequest<CreatedPortfolioResponse>,/* ISecuredRequest, ICacheRemoverRequest,*/ ILoggableRequest, ITransactionalRequest
{
    public required string Text { get; set; }
    public required int PortfolioCategoryId { get; set; }

    //public string[] Roles => [Admin, Write, PortfoliosOperationClaims.Create];

    //public bool BypassCache { get; }
    //public string? CacheKey { get; }
    //public string[]? CacheGroupKey => ["GetPortfolios"];

    public class CreatePortfolioCommandHandler : IRequestHandler<CreatePortfolioCommand, CreatedPortfolioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly PortfolioBusinessRules _portfolioBusinessRules;

        public CreatePortfolioCommandHandler(IMapper mapper, IPortfolioRepository portfolioRepository,
                                         PortfolioBusinessRules portfolioBusinessRules)
        {
            _mapper = mapper;
            _portfolioRepository = portfolioRepository;
            _portfolioBusinessRules = portfolioBusinessRules;
        }

        public async Task<CreatedPortfolioResponse> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
        {
            Portfolio portfolio = _mapper.Map<Portfolio>(request);

            await _portfolioRepository.AddAsync(portfolio);

            CreatedPortfolioResponse response = _mapper.Map<CreatedPortfolioResponse>(portfolio);
            return response;
        }
    }
}