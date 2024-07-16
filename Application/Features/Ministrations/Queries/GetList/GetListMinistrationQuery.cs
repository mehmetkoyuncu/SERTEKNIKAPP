using Application.Features.Ministrations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Ministrations.Constants.MinistrationsOperationClaims;

namespace Application.Features.Ministrations.Queries.GetList;

public class GetListMinistrationQuery : IRequest<GetListResponse<GetListMinistrationListItemDto>>/*, ISecuredRequest, ICachableRequest*/
{

    //public string[] Roles => [Admin, Read];

    //public bool BypassCache { get; }
    //public string? CacheKey => $"GetListMinistrations({PageRequest.PageIndex},{PageRequest.PageSize})";
    //public string? CacheGroupKey => "GetMinistrations";
    //public TimeSpan? SlidingExpiration { get; }

    public class GetListMinistrationQueryHandler : IRequestHandler<GetListMinistrationQuery, GetListResponse<GetListMinistrationListItemDto>>
    {
        private readonly IMinistrationRepository _ministrationRepository;
        private readonly IMapper _mapper;

        public GetListMinistrationQueryHandler(IMinistrationRepository ministrationRepository, IMapper mapper)
        {
            _ministrationRepository = ministrationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMinistrationListItemDto>> Handle(GetListMinistrationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Ministration> ministrations = await _ministrationRepository.GetListAsync(
                index: 0,
                size: 100, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMinistrationListItemDto> response = _mapper.Map<GetListResponse<GetListMinistrationListItemDto>>(ministrations);
            return response;
        }
    }
}