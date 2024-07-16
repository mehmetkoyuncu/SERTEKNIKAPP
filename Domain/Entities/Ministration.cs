
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Ministration : Entity<int> //Servislerimiz kısmı
{

    public Ministration()
    {
        Title = string.Empty;
        Description = string.Empty;
        LogoUrl = string.Empty;
    }

    public Ministration(string title, string description, string logoUrl)
    {
        Title = title;
        Description = description;
        LogoUrl = logoUrl;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
}
