using Application.Features.CompanyInfoes.Constants;
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

namespace Application.Features.CompanyInfoes.Commands.Delete;

public class DeleteCompanyInfoCommand : IRequest<DeletedCompanyInfoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, CompanyInfoesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyInfoes"];

    public class DeleteCompanyInfoCommandHandler : IRequestHandler<DeleteCompanyInfoCommand, DeletedCompanyInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly CompanyInfoBusinessRules _companyInfoBusinessRules;

        public DeleteCompanyInfoCommandHandler(IMapper mapper, ICompanyInfoRepository companyInfoRepository,
                                         CompanyInfoBusinessRules companyInfoBusinessRules)
        {
            _mapper = mapper;
            _companyInfoRepository = companyInfoRepository;
            _companyInfoBusinessRules = companyInfoBusinessRules;
        }

        public async Task<DeletedCompanyInfoResponse> Handle(DeleteCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            CompanyInfo? companyInfo = await _companyInfoRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _companyInfoBusinessRules.CompanyInfoShouldExistWhenSelected(companyInfo);

            await _companyInfoRepository.DeleteAsync(companyInfo!);

            DeletedCompanyInfoResponse response = _mapper.Map<DeletedCompanyInfoResponse>(companyInfo);
            return response;
        }
    }
}