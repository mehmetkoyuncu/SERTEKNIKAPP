using Application.Features.PortfolioCategories.Constants;
using Application.Features.PortfolioCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.PortfolioCategories.Constants.PortfolioCategoriesOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PortfolioCategories.Queries.GetById;

public class GetByIdPortfolioCategoryQuery : IRequest<GetByIdPortfolioCategoryResponse>/*, ISecuredRequest*/
{
    public int Id { get; set; }

    //public string[] Roles => [Admin, Read];

    public class GetByIdPortfolioCategoryQueryHandler : IRequestHandler<GetByIdPortfolioCategoryQuery, GetByIdPortfolioCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioCategoryRepository _portfolioCategoryRepository;
        private readonly PortfolioCategoryBusinessRules _portfolioCategoryBusinessRules;

        public GetByIdPortfolioCategoryQueryHandler(IMapper mapper, IPortfolioCategoryRepository portfolioCategoryRepository, PortfolioCategoryBusinessRules portfolioCategoryBusinessRules)
        {
            _mapper = mapper;
            _portfolioCategoryRepository = portfolioCategoryRepository;
            _portfolioCategoryBusinessRules = portfolioCategoryBusinessRules;
        }

        public async Task<GetByIdPortfolioCategoryResponse> Handle(GetByIdPortfolioCategoryQuery request, CancellationToken cancellationToken)
        {
            PortfolioCategory? portfolioCategory = await _portfolioCategoryRepository.GetAsync(
                predicate: pc => pc.Id == request.Id, 
                include : pc =>pc.Include(pc=> pc.Portfolios),
                cancellationToken: cancellationToken);
            await _portfolioCategoryBusinessRules.PortfolioCategoryShouldExistWhenSelected(portfolioCategory);

            GetByIdPortfolioCategoryResponse response = _mapper.Map<GetByIdPortfolioCategoryResponse>(portfolioCategory);
            return response;
        }
    }
}