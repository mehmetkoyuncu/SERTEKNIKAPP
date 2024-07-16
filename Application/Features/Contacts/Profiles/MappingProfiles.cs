using Application.Features.Contacts.Commands.Create;
using Application.Features.Contacts.Commands.Delete;
using Application.Features.Contacts.Commands.Update;
using Application.Features.Contacts.Queries.GetById;
using Application.Features.Contacts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Contacts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateContactCommand, Contact>();
        CreateMap<Contact, CreatedContactResponse>();

        CreateMap<UpdateContactCommand, Contact>();
        CreateMap<Contact, UpdatedContactResponse>();

        CreateMap<DeleteContactCommand, Contact>();
        CreateMap<Contact, DeletedContactResponse>();

        CreateMap<Contact, GetByIdContactResponse>();

        CreateMap<Contact, GetListContactListItemDto>();
        CreateMap<IPaginate<Contact>, GetListResponse<GetListContactListItemDto>>();
    }
}