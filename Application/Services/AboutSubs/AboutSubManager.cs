using Application.Features.AboutSubs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AboutSubs;

public class AboutSubManager : IAboutSubService
{
    private readonly IAboutSubRepository _aboutSubRepository;
    private readonly AboutSubBusinessRules _aboutSubBusinessRules;

    public AboutSubManager(IAboutSubRepository aboutSubRepository, AboutSubBusinessRules aboutSubBusinessRules)
    {
        _aboutSubRepository = aboutSubRepository;
        _aboutSubBusinessRules = aboutSubBusinessRules;
    }

    public async Task<AboutSub?> GetAsync(
        Expression<Func<AboutSub, bool>> predicate,
        Func<IQueryable<AboutSub>, IIncludableQueryable<AboutSub, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AboutSub? aboutSub = await _aboutSubRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return aboutSub;
    }

    public async Task<IPaginate<AboutSub>?> GetListAsync(
        Expression<Func<AboutSub, bool>>? predicate = null,
        Func<IQueryable<AboutSub>, IOrderedQueryable<AboutSub>>? orderBy = null,
        Func<IQueryable<AboutSub>, IIncludableQueryable<AboutSub, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AboutSub> aboutSubList = await _aboutSubRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return aboutSubList;
    }

    public async Task<AboutSub> AddAsync(AboutSub aboutSub)
    {
        AboutSub addedAboutSub = await _aboutSubRepository.AddAsync(aboutSub);

        return addedAboutSub;
    }

    public async Task<AboutSub> UpdateAsync(AboutSub aboutSub)
    {
        AboutSub updatedAboutSub = await _aboutSubRepository.UpdateAsync(aboutSub);

        return updatedAboutSub;
    }

    public async Task<AboutSub> DeleteAsync(AboutSub aboutSub, bool permanent = false)
    {
        AboutSub deletedAboutSub = await _aboutSubRepository.DeleteAsync(aboutSub);

        return deletedAboutSub;
    }
}
