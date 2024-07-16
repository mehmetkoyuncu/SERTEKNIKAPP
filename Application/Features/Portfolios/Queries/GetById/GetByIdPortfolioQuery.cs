using Application.Features.Portfolios.Constants;
using Application.Features.Portfolios.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Portfolios.Constants.PortfoliosOperationClaims;

namespace Application.Features.Portfolios.Queries.GetById;

public class GetByIdPortfolioQuery : IRequest<GetByIdPortfolioResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPortfolioQueryHandler : IRequestHandler<GetByIdPortfolioQuery, GetByIdPortfolioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly PortfolioBusinessRules _portfolioBusinessRules;

        public GetByIdPortfolioQueryHandler(IMapper mapper, IPortfolioRepository portfolioRepository, PortfolioBusinessRules portfolioBusinessRules)
        {
            _mapper = mapper;
            _portfolioRepository = portfolioRepository;
            _portfolioBusinessRules = portfolioBusinessRules;
        }

        public async Task<GetByIdPortfolioResponse> Handle(GetByIdPortfolioQuery request, CancellationToken cancellationToken)
        {
            Portfolio? portfolio = await _portfolioRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _portfolioBusinessRules.PortfolioShouldExistWhenSelected(portfolio);

            GetByIdPortfolioResponse response = _mapper.Map<GetByIdPortfolioResponse>(portfolio);
            return response;
        }
    }
}