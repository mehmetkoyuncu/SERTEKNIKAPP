using Application.Features.Offers.Commands.Create;
using Application.Features.Offers.Commands.Delete;
using Application.Features.Offers.Commands.Update;
using Application.Features.Offers.Queries.GetById;
using Application.Features.Offers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Offers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateOfferCommand, Offer>();
        CreateMap<Offer, CreatedOfferResponse>();

        CreateMap<UpdateOfferCommand, Offer>();
        CreateMap<Offer, UpdatedOfferResponse>();

        CreateMap<DeleteOfferCommand, Offer>();
        CreateMap<Offer, DeletedOfferResponse>();

        CreateMap<Offer, GetByIdOfferResponse>();

        CreateMap<Offer, GetListOfferListItemDto>();
        CreateMap<IPaginate<Offer>, GetListResponse<GetListOfferListItemDto>>();
    }
}