using NArchitecture.Core.Persistence.Repositories;


namespace Domain.Entities;
public class Offer:Entity<int>
{
    public Offer()
    {
        Name = string.Empty;
        CompanyName = string.Empty;
        Email = string.Empty;
        PhoneNumber = string.Empty;
        ProjectName = string.Empty;
        Message = string.Empty;
    }

    public Offer(string name, string companyName, string email, string phoneNumber, string projectName, string message)
    {
        Name = name;
        CompanyName = companyName;
        Email = email;
        PhoneNumber = phoneNumber;
        ProjectName = projectName;
        Message = message;
      
    }

    public string Name { get; set; }
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ProjectName { get; set; }
    public string Message { get; set; }
}
