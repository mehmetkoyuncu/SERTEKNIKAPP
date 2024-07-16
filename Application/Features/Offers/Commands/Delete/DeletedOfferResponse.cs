using NArchitecture.Core.Application.Responses;

namespace Application.Features.Offers.Commands.Delete;

public class DeletedOfferResponse : IResponse
{
    public int Id { get; set; }
}