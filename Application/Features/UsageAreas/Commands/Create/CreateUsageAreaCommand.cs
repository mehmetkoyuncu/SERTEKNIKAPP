using Application.Features.UsageAreas.Constants;
using Application.Features.UsageAreas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.UsageAreas.Constants.UsageAreasOperationClaims;
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;

namespace Application.Features.UsageAreas.Commands.Create;

public class CreateUsageAreaCommand : IRequest<CreatedUsageAreaResponse>,/* ISecuredRequest, ICacheRemoverRequest,*/ ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required IFormFile ImagePath { get; set; }
    public string[] Roles => [Admin, Write, UsageAreasOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUsageAreas"];

    public class CreateUsageAreaCommandHandler : IRequestHandler<CreateUsageAreaCommand, CreatedUsageAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsageAreaRepository _usageAreaRepository;
        private readonly UsageAreaBusinessRules _usageAreaBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public CreateUsageAreaCommandHandler(IMapper mapper, IUsageAreaRepository usageAreaRepository,
                                         UsageAreaBusinessRules usageAreaBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _usageAreaRepository = usageAreaRepository;
            _usageAreaBusinessRules = usageAreaBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<CreatedUsageAreaResponse> Handle(CreateUsageAreaCommand request, CancellationToken cancellationToken)
        {
            UsageArea usageArea = _mapper.Map<UsageArea>(request);
            usageArea.LogoUrl = await _imageServiceBase.UploadAsync(request.ImagePath);

            await _usageAreaRepository.AddAsync(usageArea);

            CreatedUsageAreaResponse response = _mapper.Map<CreatedUsageAreaResponse>(usageArea);
            return response;
        }
    }
}