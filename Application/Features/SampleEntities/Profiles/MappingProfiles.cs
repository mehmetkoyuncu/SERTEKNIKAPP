using Application.Features.SampleEntities.Commands.Create;
using Application.Features.SampleEntities.Commands.Delete;
using Application.Features.SampleEntities.Commands.Update;
using Application.Features.SampleEntities.Queries.GetById;
using Application.Features.SampleEntities.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SampleEntities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSampleEntityCommand, SampleEntity>();
        CreateMap<SampleEntity, CreatedSampleEntityResponse>();

        CreateMap<UpdateSampleEntityCommand, SampleEntity>();
        CreateMap<SampleEntity, UpdatedSampleEntityResponse>();

        CreateMap<DeleteSampleEntityCommand, SampleEntity>();
        CreateMap<SampleEntity, DeletedSampleEntityResponse>();

        CreateMap<SampleEntity, GetByIdSampleEntityResponse>();

        CreateMap<SampleEntity, GetListSampleEntityListItemDto>();
        CreateMap<IPaginate<SampleEntity>, GetListResponse<GetListSampleEntityListItemDto>>();
    }
}