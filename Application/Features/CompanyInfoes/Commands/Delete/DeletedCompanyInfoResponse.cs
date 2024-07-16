using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyInfoes.Commands.Delete;

public class DeletedCompanyInfoResponse : IResponse
{
    public int Id { get; set; }
}