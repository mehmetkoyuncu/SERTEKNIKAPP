using Application.Features.CompanyInfoes.Constants;
using Application.Features.CompanyInfoes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CompanyInfoes.Constants.CompanyInfoesOperationClaims;

namespace Application.Features.CompanyInfoes.Commands.Update;

public class UpdateCompanyInfoCommand : IRequest<UpdatedCompanyInfoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string LogoUrl { get; set; }
    public required string Mail { get; set; }
    public required string Phone1 { get; set; }
    public required string Phone2 { get; set; }
    public required string Address { get; set; }
    public required string GoogleMapAddress { get; set; }

    public string[] Roles => [Admin, Write, CompanyInfoesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyInfoes"];

    public class UpdateCompanyInfoCommandHandler : IRequestHandler<UpdateCompanyInfoCommand, UpdatedCompanyInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly CompanyInfoBusinessRules _companyInfoBusinessRules;

        public UpdateCompanyInfoCommandHandler(IMapper mapper, ICompanyInfoRepository companyInfoRepository,
                                         CompanyInfoBusinessRules companyInfoBusinessRules)
        {
            _mapper = mapper;
            _companyInfoRepository = companyInfoRepository;
            _companyInfoBusinessRules = companyInfoBusinessRules;
        }

        public async Task<UpdatedCompanyInfoResponse> Handle(UpdateCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            CompanyInfo? companyInfo = await _companyInfoRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _companyInfoBusinessRules.CompanyInfoShouldExistWhenSelected(companyInfo);
            companyInfo = _mapper.Map(request, companyInfo);

            await _companyInfoRepository.UpdateAsync(companyInfo!);

            UpdatedCompanyInfoResponse response = _mapper.Map<UpdatedCompanyInfoResponse>(companyInfo);
            return response;
        }
    }
}