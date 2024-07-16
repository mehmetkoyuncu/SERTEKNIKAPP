

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class PortfolioCategory : Entity<int> //Portföy Kısmı
{
    public PortfolioCategory()
    {
        Text = string.Empty;
    }

    public PortfolioCategory(string text,ICollection<Portfolio> portfolios)
    {
        Text = text;
        Portfolios=portfolios;
    }

    public string Text { get; set; }
    public virtual ICollection<Portfolio>? Portfolios { get; set; }
}
