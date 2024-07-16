using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Offers.Queries.GetList;

public class GetListOfferListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ProjectName { get; set; }
    public string Message { get; set; }
}