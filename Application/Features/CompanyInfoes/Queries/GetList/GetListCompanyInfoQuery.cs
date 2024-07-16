using Application.Features.CompanyInfoes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CompanyInfoes.Constants.CompanyInfoesOperationClaims;

namespace Application.Features.CompanyInfoes.Queries.GetList;

public class GetListCompanyInfoQuery : IRequest<GetListResponse<GetListCompanyInfoListItemDto>>/*, ISecuredRequest, ICachableRequest*/
{

    //public string[] Roles => [Admin, Read];

    //public bool BypassCache { get; }
    //public string? CacheKey => $"GetListCompanyInfoes({PageRequest.PageIndex},{PageRequest.PageSize})";
    //public string? CacheGroupKey => "GetCompanyInfoes";
    //public TimeSpan? SlidingExpiration { get; }

    public class GetListCompanyInfoQueryHandler : IRequestHandler<GetListCompanyInfoQuery, GetListResponse<GetListCompanyInfoListItemDto>>
    {
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IMapper _mapper;

        public GetListCompanyInfoQueryHandler(ICompanyInfoRepository companyInfoRepository, IMapper mapper)
        {
            _companyInfoRepository = companyInfoRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCompanyInfoListItemDto>> Handle(GetListCompanyInfoQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CompanyInfo> companyInfoes = await _companyInfoRepository.GetListAsync(
                index: 0,
                size: 1, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCompanyInfoListItemDto> response = _mapper.Map<GetListResponse<GetListCompanyInfoListItemDto>>(companyInfoes);
            return response;
        }
    }
}