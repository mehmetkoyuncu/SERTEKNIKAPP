using Application.Features.Videos.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Videos.Rules;

public class VideoBusinessRules : BaseBusinessRules
{
    private readonly IVideoRepository _videoRepository;
    private readonly ILocalizationService _localizationService;

    public VideoBusinessRules(IVideoRepository videoRepository, ILocalizationService localizationService)
    {
        _videoRepository = videoRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, VideosBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task VideoShouldExistWhenSelected(Video? video)
    {
        if (video == null)
            await throwBusinessException(VideosBusinessMessages.VideoNotExists);
    }

    public async Task VideoIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Video? video = await _videoRepository.GetAsync(
            predicate: v => v.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await VideoShouldExistWhenSelected(video);
    }
}