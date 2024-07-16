

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class InfoDTO:Entity<int>
{
    public InfoDTO(string title, string smallText, string content, string uRL)
    {
        Title = title;
        SmallText = smallText;
        Content = content;
        URL = uRL;
    }

    public InfoDTO()
    {
        Title = string.Empty;
        SmallText = string.Empty;
        Content = string.Empty;
        URL = string.Empty;
    }

    public string Title { get; set; }
    public string SmallText { get; set; }
    public string Content { get; set; }
    public string URL { get; set; }
}