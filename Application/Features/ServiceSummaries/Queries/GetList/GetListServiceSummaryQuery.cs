using Application.Features.ServiceSummaries.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ServiceSummaries.Constants.ServiceSummariesOperationClaims;

namespace Application.Features.ServiceSummaries.Queries.GetList;

public class GetListServiceSummaryQuery : IRequest<GetListResponse<GetListServiceSummaryListItemDto>>/*, ISecuredRequest, ICachableRequest*/
{

    //public string[] Roles => [Admin, Read];

    //public bool BypassCache { get; }
    //public string? CacheKey => $"GetListServiceSummaries({PageRequest.PageIndex},{PageRequest.PageSize})";
    //public string? CacheGroupKey => "GetServiceSummaries";
    //public TimeSpan? SlidingExpiration { get; }

    public class GetListServiceSummaryQueryHandler : IRequestHandler<GetListServiceSummaryQuery, GetListResponse<GetListServiceSummaryListItemDto>>
    {
        private readonly IServiceSummaryRepository _serviceSummaryRepository;
        private readonly IMapper _mapper;

        public GetListServiceSummaryQueryHandler(IServiceSummaryRepository serviceSummaryRepository, IMapper mapper)
        {
            _serviceSummaryRepository = serviceSummaryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListServiceSummaryListItemDto>> Handle(GetListServiceSummaryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ServiceSummary> serviceSummaries = await _serviceSummaryRepository.GetListAsync(
                index:0,
                size: 10, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListServiceSummaryListItemDto> response = _mapper.Map<GetListResponse<GetListServiceSummaryListItemDto>>(serviceSummaries);
            return response;
        }
    }
}