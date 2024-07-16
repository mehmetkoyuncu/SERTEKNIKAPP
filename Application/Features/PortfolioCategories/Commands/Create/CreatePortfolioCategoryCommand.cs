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

namespace Application.Features.PortfolioCategories.Commands.Create;

public class CreatePortfolioCategoryCommand : IRequest<CreatedPortfolioCategoryResponse>,/* ISecuredRequest, ICacheRemoverRequest,*/ ILoggableRequest, ITransactionalRequest
{
    public required string Text { get; set; }

    //public string[] Roles => [Admin, Write, PortfolioCategoriesOperationClaims.Create];

    //public bool BypassCache { get; }
    //public string? CacheKey { get; }
    //public string[]? CacheGroupKey => ["GetPortfolioCategories"];

    public class CreatePortfolioCategoryCommandHandler : IRequestHandler<CreatePortfolioCategoryCommand, CreatedPortfolioCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioCategoryRepository _portfolioCategoryRepository;
        private readonly PortfolioCategoryBusinessRules _portfolioCategoryBusinessRules;

        public CreatePortfolioCategoryCommandHandler(IMapper mapper, IPortfolioCategoryRepository portfolioCategoryRepository,
                                         PortfolioCategoryBusinessRules portfolioCategoryBusinessRules)
        {
            _mapper = mapper;
            _portfolioCategoryRepository = portfolioCategoryRepository;
            _portfolioCategoryBusinessRules = portfolioCategoryBusinessRules;
        }

        public async Task<CreatedPortfolioCategoryResponse> Handle(CreatePortfolioCategoryCommand request, CancellationToken cancellationToken)
        {
            PortfolioCategory portfolioCategory = _mapper.Map<PortfolioCategory>(request);

            await _portfolioCategoryRepository.AddAsync(portfolioCategory);

            CreatedPortfolioCategoryResponse response = _mapper.Map<CreatedPortfolioCategoryResponse>(portfolioCategory);
            return response;
        }
    }
}