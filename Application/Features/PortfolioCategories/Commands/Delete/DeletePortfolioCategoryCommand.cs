using Application.Features.PortfolioCategories.Constants;
using Application.Features.PortfolioCategories.Constants;
using Application.Features.PortfolioCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.PortfolioCategories.Constants.PortfolioCategoriesOperationClaims;

namespace Application.Features.PortfolioCategories.Commands.Delete;

public class DeletePortfolioCategoryCommand : IRequest<DeletedPortfolioCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, PortfolioCategoriesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPortfolioCategories"];

    public class DeletePortfolioCategoryCommandHandler : IRequestHandler<DeletePortfolioCategoryCommand, DeletedPortfolioCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioCategoryRepository _portfolioCategoryRepository;
        private readonly PortfolioCategoryBusinessRules _portfolioCategoryBusinessRules;

        public DeletePortfolioCategoryCommandHandler(IMapper mapper, IPortfolioCategoryRepository portfolioCategoryRepository,
                                         PortfolioCategoryBusinessRules portfolioCategoryBusinessRules)
        {
            _mapper = mapper;
            _portfolioCategoryRepository = portfolioCategoryRepository;
            _portfolioCategoryBusinessRules = portfolioCategoryBusinessRules;
        }

        public async Task<DeletedPortfolioCategoryResponse> Handle(DeletePortfolioCategoryCommand request, CancellationToken cancellationToken)
        {
            PortfolioCategory? portfolioCategory = await _portfolioCategoryRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _portfolioCategoryBusinessRules.PortfolioCategoryShouldExistWhenSelected(portfolioCategory);

            await _portfolioCategoryRepository.DeleteAsync(portfolioCategory!);

            DeletedPortfolioCategoryResponse response = _mapper.Map<DeletedPortfolioCategoryResponse>(portfolioCategory);
            return response;
        }
    }
}