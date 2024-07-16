using Application.Features.Abouts.Commands.Create;
using Application.Features.Abouts.Commands.Delete;
using Application.Features.Abouts.Commands.Update;
using Application.Features.Abouts.Queries.GetById;
using Application.Features.Abouts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Abouts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAboutCommand, About>();
        CreateMap<About, CreatedAboutResponse>();

        CreateMap<UpdateAboutCommand, About>();
        CreateMap<About, UpdatedAboutResponse>();

        CreateMap<DeleteAboutCommand, About>();
        CreateMap<About, DeletedAboutResponse>();

        CreateMap<About, GetByIdAboutResponse>();

        CreateMap<About, GetListAboutListItemDto>();
        CreateMap<IPaginate<About>, GetListResponse<GetListAboutListItemDto>>();
    }
}