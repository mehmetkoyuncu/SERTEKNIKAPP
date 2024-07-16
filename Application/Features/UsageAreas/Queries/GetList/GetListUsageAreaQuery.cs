using Application.Features.UsageAreas.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.UsageAreas.Constants.UsageAreasOperationClaims;

namespace Application.Features.UsageAreas.Queries.GetList;

public class GetListUsageAreaQuery : IRequest<GetListResponse<GetListUsageAreaListItemDto>>/*,ISecuredRequest,ICachableRequest*/
{

    //public string[] Roles => [Admin, Read];

    //public bool BypassCache { get; }
    //public string? CacheKey => $"GetListUsageAreas({PageRequest.PageIndex},{PageRequest.PageSize})";
    //public string? CacheGroupKey => "GetUsageAreas";
    //public TimeSpan? SlidingExpiration { get; }

    public class GetListUsageAreaQueryHandler : IRequestHandler<GetListUsageAreaQuery, GetListResponse<GetListUsageAreaListItemDto>>
    {
        private readonly IUsageAreaRepository _usageAreaRepository;
        private readonly IMapper _mapper;

        public GetListUsageAreaQueryHandler(IUsageAreaRepository usageAreaRepository, IMapper mapper)
        {
            _usageAreaRepository = usageAreaRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUsageAreaListItemDto>> Handle(GetListUsageAreaQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UsageArea> usageAreas = await _usageAreaRepository.GetListAsync(
                index:0,
                size: 100, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUsageAreaListItemDto> response = _mapper.Map<GetListResponse<GetListUsageAreaListItemDto>>(usageAreas);
            return response;
        }
    }
}