using Application.Features.Videos.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Videos.Constants.VideosOperationClaims;

namespace Application.Features.Videos.Queries.GetList;

public class GetListVideoQuery : IRequest<GetListResponse<GetListVideoListItemDto>>/*, ISecuredRequest, ICachableRequest*/
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListVideos({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetVideos";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListVideoQueryHandler : IRequestHandler<GetListVideoQuery, GetListResponse<GetListVideoListItemDto>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetListVideoQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListVideoListItemDto>> Handle(GetListVideoQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Video> videos = await _videoRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListVideoListItemDto> response = _mapper.Map<GetListResponse<GetListVideoListItemDto>>(videos);
            return response;
        }
    }
}