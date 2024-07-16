using Application.Features.CompanyInfoes.Commands.Create;
using Application.Features.CompanyInfoes.Commands.Delete;
using Application.Features.CompanyInfoes.Commands.Update;
using Application.Features.CompanyInfoes.Queries.GetById;
using Application.Features.CompanyInfoes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CompanyInfoes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyInfoCommand, CompanyInfo>();
        CreateMap<CompanyInfo, CreatedCompanyInfoResponse>();

        CreateMap<UpdateCompanyInfoCommand, CompanyInfo>();
        CreateMap<CompanyInfo, UpdatedCompanyInfoResponse>();

        CreateMap<DeleteCompanyInfoCommand, CompanyInfo>();
        CreateMap<CompanyInfo, DeletedCompanyInfoResponse>();

        CreateMap<CompanyInfo, GetByIdCompanyInfoResponse>();

        CreateMap<CompanyInfo, GetListCompanyInfoListItemDto>();
        CreateMap<IPaginate<CompanyInfo>, GetListResponse<GetListCompanyInfoListItemDto>>();
    }
}