using Application.Features.ServiceSummaries.Commands.Create;
using Application.Features.ServiceSummaries.Commands.Delete;
using Application.Features.ServiceSummaries.Commands.Update;
using Application.Features.ServiceSummaries.Queries.GetById;
using Application.Features.ServiceSummaries.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ServiceSummaries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateServiceSummaryCommand, ServiceSummary>();
        CreateMap<ServiceSummary, CreatedServiceSummaryResponse>();

        CreateMap<UpdateServiceSummaryCommand, ServiceSummary>();
        CreateMap<ServiceSummary, UpdatedServiceSummaryResponse>();

        CreateMap<DeleteServiceSummaryCommand, ServiceSummary>();
        CreateMap<ServiceSummary, DeletedServiceSummaryResponse>();

        CreateMap<ServiceSummary, GetByIdServiceSummaryResponse>();

        CreateMap<ServiceSummary, GetListServiceSummaryListItemDto>();
        CreateMap<IPaginate<ServiceSummary>, GetListResponse<GetListServiceSummaryListItemDto>>();
    }
}