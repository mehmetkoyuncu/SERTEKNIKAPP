

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Service:Entity<int>
{
    public Service(string title, string content, string ıcon)
    {
        Title = title;
        Content = content;
        Icon = ıcon;
    }
    public Service()
    {
        Title = string.Empty;
        Content = string.Empty;
        Icon = string.Empty;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public string Icon { get; set; }
}