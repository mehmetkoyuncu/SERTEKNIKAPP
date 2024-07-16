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
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;

namespace Application.Features.Videos.Commands.Create;

public class CreateVideoCommand : IRequest<CreatedVideoResponse>,/* ISecuredRequest, ICacheRemoverRequest,*/ ILoggableRequest, ITransactionalRequest
{
    public required IFormFile VideoFile { get; set; }
    public required string VideoType { get; set; }

    public string[] Roles => [Admin, Write, VideosOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetVideos"];

    public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand, CreatedVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepository;
        private readonly VideoBusinessRules _videoBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;
        public CreateVideoCommandHandler(IMapper mapper, IVideoRepository videoRepository,
                                         VideoBusinessRules videoBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _videoRepository = videoRepository;
            _videoBusinessRules = videoBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<CreatedVideoResponse> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            Video video = _mapper.Map<Video>(request);

            video.VideoUrl = await _imageServiceBase.UploadVideoAsync(request.VideoFile);

            await _videoRepository.AddAsync(video);

            CreatedVideoResponse response = _mapper.Map<CreatedVideoResponse>(video);
            return response;
        }
    }
}