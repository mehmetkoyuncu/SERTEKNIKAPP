using Application.Features.Videos.Constants;
using Application.Features.Videos.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Videos.Constants.VideosOperationClaims;

namespace Application.Features.Videos.Commands.Update;

public class UpdateVideoCommand : IRequest<UpdatedVideoResponse>,/* ISecuredRequest, ICacheRemoverRequest, */ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string VideoUrl { get; set; }
    public required string VideoType { get; set; }

    public string[] Roles => [Admin, Write, VideosOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetVideos"];

    public class UpdateVideoCommandHandler : IRequestHandler<UpdateVideoCommand, UpdatedVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepository;
        private readonly VideoBusinessRules _videoBusinessRules;

        public UpdateVideoCommandHandler(IMapper mapper, IVideoRepository videoRepository,
                                         VideoBusinessRules videoBusinessRules)
        {
            _mapper = mapper;
            _videoRepository = videoRepository;
            _videoBusinessRules = videoBusinessRules;
        }

        public async Task<UpdatedVideoResponse> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {
            Video? video = await _videoRepository.GetAsync(predicate: v => v.Id == request.Id, cancellationToken: cancellationToken);
            await _videoBusinessRules.VideoShouldExistWhenSelected(video);
            video = _mapper.Map(request, video);

            await _videoRepository.UpdateAsync(video!);

            UpdatedVideoResponse response = _mapper.Map<UpdatedVideoResponse>(video);
            return response;
        }
    }
}