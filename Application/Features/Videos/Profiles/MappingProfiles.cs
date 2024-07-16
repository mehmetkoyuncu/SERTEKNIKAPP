using Application.Features.Videos.Commands.Create;
using Application.Features.Videos.Commands.Delete;
using Application.Features.Videos.Commands.Update;
using Application.Features.Videos.Queries.GetById;
using Application.Features.Videos.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Videos.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateVideoCommand, Video>();
        CreateMap<Video, CreatedVideoResponse>();

        CreateMap<UpdateVideoCommand, Video>();
        CreateMap<Video, UpdatedVideoResponse>();

        CreateMap<DeleteVideoCommand, Video>();
        CreateMap<Video, DeletedVideoResponse>();

        CreateMap<Video, GetByIdVideoResponse>();

        CreateMap<Video, GetListVideoListItemDto>();
        CreateMap<IPaginate<Video>, GetListResponse<GetListVideoListItemDto>>();
    }
}