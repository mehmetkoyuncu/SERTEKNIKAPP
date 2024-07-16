using Application.Features.AboutSubs.Commands.Create;
using Application.Features.AboutSubs.Commands.Delete;
using Application.Features.AboutSubs.Commands.Update;
using Application.Features.AboutSubs.Queries.GetById;
using Application.Features.AboutSubs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AboutSubs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAboutSubCommand, AboutSub>();
        CreateMap<AboutSub, CreatedAboutSubResponse>();

        CreateMap<UpdateAboutSubCommand, AboutSub>();
        CreateMap<AboutSub, UpdatedAboutSubResponse>();

        CreateMap<DeleteAboutSubCommand, AboutSub>();
        CreateMap<AboutSub, DeletedAboutSubResponse>();

        CreateMap<AboutSub, GetByIdAboutSubResponse>();

        CreateMap<AboutSub, GetListAboutSubListItemDto>();
        CreateMap<IPaginate<AboutSub>, GetListResponse<GetListAboutSubListItemDto>>();
    }
}