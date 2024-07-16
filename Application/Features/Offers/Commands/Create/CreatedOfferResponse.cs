using NArchitecture.Core.Application.Responses;

namespace Application.Features.Offers.Commands.Create;

public class CreatedOfferResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ProjectName { get; set; }
    public string Message { get; set; }
}