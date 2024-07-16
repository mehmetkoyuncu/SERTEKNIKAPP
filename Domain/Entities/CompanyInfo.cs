

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class CompanyInfo:Entity<int>
{
   
    public CompanyInfo()
    {
        LogoUrl = string.Empty;
        Mail = string.Empty;
        Phone1 = string.Empty;
        Phone2 = string.Empty;
        Address = string.Empty;
        GoogleMapAddress = string.Empty;
    }

    public CompanyInfo(string logoUrl, string mail, string phone1, string phone2, string address, string googleMapAddress)
    {
        LogoUrl = logoUrl;
        Mail = mail;
        Phone1 = phone1;
        Phone2 = phone2;
        Address = address;
        GoogleMapAddress = googleMapAddress;
    }

    public string LogoUrl { get; set; }
    public string Mail { get; set; }
    public string Phone1 { get; set; }
    public string Phone2 { get; set; }
    public string Address { get; set; }
    public string GoogleMapAddress { get; set; }//cursor: url("https://maps.gstatic.com/mapfiles/openhand_8_8.cur")
}
