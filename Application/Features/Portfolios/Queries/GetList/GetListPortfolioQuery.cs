using Application.Features.Portfolios.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Portfolios.Constants.PortfoliosOperationClaims;

namespace Application.Features.Portfolios.Queries.GetList;

public class GetListPortfolioQuery : IRequest<GetListResponse<GetListPortfolioListItemDto>>/*, ISecuredRequest, ICachableRequest*/
{
    //public PageRequest PageRequest { get; set; }

    //public string[] Roles => [Admin, Read];

    //public bool BypassCache { get; }
    //public string? CacheKey => $"GetListPortfolios({PageRequest.PageIndex},{PageRequest.PageSize})";
    //public string? CacheGroupKey => "GetPortfolios";
    //public TimeSpan? SlidingExpiration { get; }

    public class GetListPortfolioQueryHandler : IRequestHandler<GetListPortfolioQuery, GetListResponse<GetListPortfolioListItemDto>>
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public GetListPortfolioQueryHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPortfolioListItemDto>> Handle(GetListPortfolioQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Portfolio> portfolios = await _portfolioRepository.GetListAsync(
                index: 0,
                size: 1000, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPortfolioListItemDto> response = _mapper.Map<GetListResponse<GetListPortfolioListItemDto>>(portfolios);
            return response;
        }
    }
}