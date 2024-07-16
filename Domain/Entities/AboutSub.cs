

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class AboutSub:Entity<int> // Hakkımızda Alanının Hizmet anlayışımız politikamız olayı
{
    public AboutSub( string title, string description)
    {
        Title = title;
        Description = description;
    } 

    public string Title { get; set; }
    public string Description { get; set; }
}