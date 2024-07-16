

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class About:Entity<int> //Hakkımızda Kısmı
{
    public About()
    {
        Title = string.Empty;
        SmallText = string.Empty;
        ImageURL = string.Empty;
    }

    public About(string title, string smallText, string ımageURL)
    {
        Title = title;
        SmallText = smallText;
        ImageURL = ımageURL;
    }

    public string Title { get; set; }
    public string SmallText { get; set; }
    public string ImageURL { get; set; }
}


