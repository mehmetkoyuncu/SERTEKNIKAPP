

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Portfolio : Entity<int> //Hakkımızda Kısmı
{
    public Portfolio()
    {
        Text = string.Empty;
    }

    public Portfolio(string text)
    {
        Text = text;
    }

    public string Text { get; set; }
    public int PortfolioCategoryId { get; set; }
    public virtual PortfolioCategory? PortfolioCategory { get; set; }
}
