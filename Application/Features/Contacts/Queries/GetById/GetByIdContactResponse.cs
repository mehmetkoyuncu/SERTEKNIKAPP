using NArchitecture.Core.Application.Responses;

namespace Application.Features.Contacts.Queries.GetById;

public class GetByIdContactResponse : IResponse
{
    public int Id { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneNumber1 { get; set; }
    public string Address { get; set; }
    public float MapsLat { get; set; }
    public float MapsLen { get; set; }
}