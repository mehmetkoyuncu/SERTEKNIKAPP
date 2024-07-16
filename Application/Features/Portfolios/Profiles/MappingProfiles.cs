using Application.Features.Portfolios.Commands.Create;
using Application.Features.Portfolios.Commands.Delete;
using Application.Features.Portfolios.Commands.Update;
using Application.Features.Portfolios.Queries.GetById;
using Application.Features.Portfolios.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Portfolios.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePortfolioCommand, Portfolio>();
        CreateMap<Portfolio, CreatedPortfolioResponse>();

        CreateMap<UpdatePortfolioCommand, Portfolio>();
        CreateMap<Portfolio, UpdatedPortfolioResponse>();

        CreateMap<DeletePortfolioCommand, Portfolio>();
        CreateMap<Portfolio, DeletedPortfolioResponse>();

        CreateMap<Portfolio, GetByIdPortfolioResponse>();

        CreateMap<Portfolio, GetListPortfolioListItemDto>();
        CreateMap<IPaginate<Portfolio>, GetListResponse<GetListPortfolioListItemDto>>();
    }
}