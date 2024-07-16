using Application.Features.CompanyInfoes.Constants;
using Application.Features.CompanyInfoes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CompanyInfoes.Constants.CompanyInfoesOperationClaims;

namespace Application.Features.CompanyInfoes.Queries.GetById;

public class GetByIdCompanyInfoQuery : IRequest<GetByIdCompanyInfoResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCompanyInfoQueryHandler : IRequestHandler<GetByIdCompanyInfoQuery, GetByIdCompanyInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly CompanyInfoBusinessRules _companyInfoBusinessRules;

        public GetByIdCompanyInfoQueryHandler(IMapper mapper, ICompanyInfoRepository companyInfoRepository, CompanyInfoBusinessRules companyInfoBusinessRules)
        {
            _mapper = mapper;
            _companyInfoRepository = companyInfoRepository;
            _companyInfoBusinessRules = companyInfoBusinessRules;
        }

        public async Task<GetByIdCompanyInfoResponse> Handle(GetByIdCompanyInfoQuery request, CancellationToken cancellationToken)
        {
            CompanyInfo? companyInfo = await _companyInfoRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _companyInfoBusinessRules.CompanyInfoShouldExistWhenSelected(companyInfo);

            GetByIdCompanyInfoResponse response = _mapper.Map<GetByIdCompanyInfoResponse>(companyInfo);
            return response;
        }
    }
}