

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ServiceSummary : Entity<int> //Hakkımızda Kısmı
{
    public ServiceSummary()
    {
        Title = string.Empty;
        Description = string.Empty;
    }

    public ServiceSummary(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; set; }
    public string Description { get; set; }
}

