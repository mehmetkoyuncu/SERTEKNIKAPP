using Application.Features.Ministrations.Commands.Create;
using Application.Features.Ministrations.Commands.Delete;
using Application.Features.Ministrations.Commands.Update;
using Application.Features.Ministrations.Queries.GetById;
using Application.Features.Ministrations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Ministrations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateMinistrationCommand, Ministration>();
        CreateMap<Ministration, CreatedMinistrationResponse>();

        CreateMap<UpdateMinistrationCommand, Ministration>();
        CreateMap<Ministration, UpdatedMinistrationResponse>();

        CreateMap<DeleteMinistrationCommand, Ministration>();
        CreateMap<Ministration, DeletedMinistrationResponse>();

        CreateMap<Ministration, GetByIdMinistrationResponse>();

        CreateMap<Ministration, GetListMinistrationListItemDto>();
        CreateMap<IPaginate<Ministration>, GetListResponse<GetListMinistrationListItemDto>>();
    }
}