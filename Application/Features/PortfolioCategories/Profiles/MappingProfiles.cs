using Application.Features.PortfolioCategories.Commands.Create;
using Application.Features.PortfolioCategories.Commands.Delete;
using Application.Features.PortfolioCategories.Commands.Update;
using Application.Features.PortfolioCategories.Queries.GetById;
using Application.Features.PortfolioCategories.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PortfolioCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePortfolioCategoryCommand, PortfolioCategory>();
        CreateMap<PortfolioCategory, CreatedPortfolioCategoryResponse>();

        CreateMap<UpdatePortfolioCategoryCommand, PortfolioCategory>();
        CreateMap<PortfolioCategory, UpdatedPortfolioCategoryResponse>();

        CreateMap<DeletePortfolioCategoryCommand, PortfolioCategory>();
        CreateMap<PortfolioCategory, DeletedPortfolioCategoryResponse>();

        CreateMap<PortfolioCategory, GetByIdPortfolioCategoryResponse>();

        CreateMap<PortfolioCategory, GetListPortfolioCategoryListItemDto>();
        CreateMap<IPaginate<PortfolioCategory>, GetListResponse<GetListPortfolioCategoryListItemDto>>();
    }
}