using Application.Features.Abouts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Abouts;

public class AboutManager : IAboutService
{
    private readonly IAboutRepository _aboutRepository;
    private readonly AboutBusinessRules _aboutBusinessRules;

    public AboutManager(IAboutRepository aboutRepository, AboutBusinessRules aboutBusinessRules)
    {
        _aboutRepository = aboutRepository;
        _aboutBusinessRules = aboutBusinessRules;
    }

    public async Task<About?> GetAsync(
        Expression<Func<About, bool>> predicate,
        Func<IQueryable<About>, IIncludableQueryable<About, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        About? about = await _aboutRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return about;
    }

    public async Task<IPaginate<About>?> GetListAsync(
        Expression<Func<About, bool>>? predicate = null,
        Func<IQueryable<About>, IOrderedQueryable<About>>? orderBy = null,
        Func<IQueryable<About>, IIncludableQueryable<About, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<About> aboutList = await _aboutRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return aboutList;
    }

    public async Task<About> AddAsync(About about)
    {
        About addedAbout = await _aboutRepository.AddAsync(about);

        return addedAbout;
    }

    public async Task<About> UpdateAsync(About about)
    {
        About updatedAbout = await _aboutRepository.UpdateAsync(about);

        return updatedAbout;
    }

    public async Task<About> DeleteAsync(About about, bool permanent = false)
    {
        About deletedAbout = await _aboutRepository.DeleteAsync(about);

        return deletedAbout;
    }
}
