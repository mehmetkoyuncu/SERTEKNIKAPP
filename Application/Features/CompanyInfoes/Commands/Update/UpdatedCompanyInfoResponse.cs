using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyInfoes.Commands.Update;

public class UpdatedCompanyInfoResponse : IResponse
{
    public int Id { get; set; }
    public string LogoUrl { get; set; }
    public string Mail { get; set; }
    public string Phone1 { get; set; }
    public string Phone2 { get; set; }
    public string Address { get; set; }
    public string GoogleMapAddress { get; set; }
}