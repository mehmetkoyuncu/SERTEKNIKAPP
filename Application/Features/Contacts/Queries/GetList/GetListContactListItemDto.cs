using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Contacts.Queries.GetList;

public class GetListContactListItemDto : IDto
{
    public int Id { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneNumber1 { get; set; }
    public string Address { get; set; }
    public float MapsLat { get; set; }
    public float MapsLen { get; set; }
}