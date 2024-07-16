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

namespace Application.Features.PortfolioCategories.Commands.Update;

public class UpdatePortfolioCategoryCommand : IRequest<UpdatedPortfolioCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Text { get; set; }

    public string[] Roles => [Admin, Write, PortfolioCategoriesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPortfolioCategories"];

    public class UpdatePortfolioCategoryCommandHandler : IRequestHandler<UpdatePortfolioCategoryCommand, UpdatedPortfolioCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioCategoryRepository _portfolioCategoryRepository;
        private readonly PortfolioCategoryBusinessRules _portfolioCategoryBusinessRules;

        public UpdatePortfolioCategoryCommandHandler(IMapper mapper, IPortfolioCategoryRepository portfolioCategoryRepository,
                                         PortfolioCategoryBusinessRules portfolioCategoryBusinessRules)
        {
            _mapper = mapper;
            _portfolioCategoryRepository = portfolioCategoryRepository;
            _portfolioCategoryBusinessRules = portfolioCategoryBusinessRules;
        }

        public async Task<UpdatedPortfolioCategoryResponse> Handle(UpdatePortfolioCategoryCommand request, CancellationToken cancellationToken)
        {
            PortfolioCategory? portfolioCategory = await _portfolioCategoryRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _portfolioCategoryBusinessRules.PortfolioCategoryShouldExistWhenSelected(portfolioCategory);
            portfolioCategory = _mapper.Map(request, portfolioCategory);

            await _portfolioCategoryRepository.UpdateAsync(portfolioCategory!);

            UpdatedPortfolioCategoryResponse response = _mapper.Map<UpdatedPortfolioCategoryResponse>(portfolioCategory);
            return response;
        }
    }
}