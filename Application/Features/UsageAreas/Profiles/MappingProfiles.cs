using Application.Features.UsageAreas.Commands.Create;
using Application.Features.UsageAreas.Commands.Delete;
using Application.Features.UsageAreas.Commands.Update;
using Application.Features.UsageAreas.Queries.GetById;
using Application.Features.UsageAreas.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UsageAreas.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUsageAreaCommand, UsageArea>();
        CreateMap<UsageArea, CreatedUsageAreaResponse>();

        CreateMap<UpdateUsageAreaCommand, UsageArea>();
        CreateMap<UsageArea, UpdatedUsageAreaResponse>();

        CreateMap<DeleteUsageAreaCommand, UsageArea>();
        CreateMap<UsageArea, DeletedUsageAreaResponse>();

        CreateMap<UsageArea, GetByIdUsageAreaResponse>();

        CreateMap<UsageArea, GetListUsageAreaListItemDto>();
        CreateMap<IPaginate<UsageArea>, GetListResponse<GetListUsageAreaListItemDto>>();
    }
}