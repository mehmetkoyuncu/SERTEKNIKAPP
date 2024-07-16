using Application.Features.SampleEntities.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.SampleEntities.Constants.SampleEntitiesOperationClaims;

namespace Application.Features.SampleEntities.Queries.GetList;

public class GetListSampleEntityQuery : IRequest<GetListResponse<GetListSampleEntityListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSampleEntities({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSampleEntities";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSampleEntityQueryHandler : IRequestHandler<GetListSampleEntityQuery, GetListResponse<GetListSampleEntityListItemDto>>
    {
        private readonly ISampleEntityRepository _sampleEntityRepository;
        private readonly IMapper _mapper;

        public GetListSampleEntityQueryHandler(ISampleEntityRepository sampleEntityRepository, IMapper mapper)
        {
            _sampleEntityRepository = sampleEntityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSampleEntityListItemDto>> Handle(GetListSampleEntityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SampleEntity> sampleEntities = await _sampleEntityRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSampleEntityListItemDto> response = _mapper.Map<GetListResponse<GetListSampleEntityListItemDto>>(sampleEntities);
            return response;
        }
    }
}