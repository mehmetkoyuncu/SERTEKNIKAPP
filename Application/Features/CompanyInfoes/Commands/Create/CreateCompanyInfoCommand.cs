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
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;

namespace Application.Features.CompanyInfoes.Commands.Create;

public class CreateCompanyInfoCommand : IRequest<CreatedCompanyInfoResponse>, /*ISecuredRequest, ICacheRemoverRequest,*/ ILoggableRequest, ITransactionalRequest
{
    public required IFormFile FormFile { get; set; }
    public required string Mail { get; set; }
    public required string Phone1 { get; set; }
    public required string Phone2 { get; set; }
    public required string Address { get; set; }
    public required string GoogleMapAddress { get; set; }

    public string[] Roles => [Admin, Write, CompanyInfoesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCompanyInfoes"];

    public class CreateCompanyInfoCommandHandler : IRequestHandler<CreateCompanyInfoCommand, CreatedCompanyInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly CompanyInfoBusinessRules _companyInfoBusinessRules;
        private readonly ImageServiceBase _imageService;
        public CreateCompanyInfoCommandHandler(IMapper mapper, ICompanyInfoRepository companyInfoRepository,
                                         CompanyInfoBusinessRules companyInfoBusinessRules, ImageServiceBase imageService = null)
        {
            _mapper = mapper;
            _companyInfoRepository = companyInfoRepository;
            _companyInfoBusinessRules = companyInfoBusinessRules;
            _imageService = imageService;
        }

        public async Task<CreatedCompanyInfoResponse> Handle(CreateCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            CompanyInfo companyInfo = _mapper.Map<CompanyInfo>(request);

            companyInfo.LogoUrl = await _imageService.UploadAsync(request.FormFile);

            await _companyInfoRepository.AddAsync(companyInfo);

            CreatedCompanyInfoResponse response = _mapper.Map<CreatedCompanyInfoResponse>(companyInfo);
            return response;
        }
    }
}