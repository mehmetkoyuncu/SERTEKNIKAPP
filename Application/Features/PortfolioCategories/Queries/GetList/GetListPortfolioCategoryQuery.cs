using Application.Features.PortfolioCategories.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.PortfolioCategories.Constants.PortfolioCategoriesOperationClaims;

namespace Application.Features.PortfolioCategories.Queries.GetList;

public class GetListPortfolioCategoryQuery : IRequest<GetListResponse<GetListPortfolioCategoryListItemDto>>/*,ISecuredRequest,ICachableRequest*/
{

    //public string[] Roles => [Admin, Read];

    //public bool BypassCache { get; }
    //public string? CacheKey => $"GetListPortfolioCategories({PageRequest.PageIndex},{PageRequest.PageSize})";
    //public string? CacheGroupKey => "GetPortfolioCategories";
    //public TimeSpan? SlidingExpiration { get; }

    public class GetListPortfolioCategoryQueryHandler : IRequestHandler<GetListPortfolioCategoryQuery, GetListResponse<GetListPortfolioCategoryListItemDto>>
    {
        private readonly IPortfolioCategoryRepository _portfolioCategoryRepository;
        private readonly IMapper _mapper;

        public GetListPortfolioCategoryQueryHandler(IPortfolioCategoryRepository portfolioCategoryRepository, IMapper mapper)
        {
            _portfolioCategoryRepository = portfolioCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPortfolioCategoryListItemDto>> Handle(GetListPortfolioCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PortfolioCategory> portfolioCategories = await _portfolioCategoryRepository.GetListAsync(
                index: 0,
                size: 100, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPortfolioCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListPortfolioCategoryListItemDto>>(portfolioCategories);
            return response;
        }
    }
}