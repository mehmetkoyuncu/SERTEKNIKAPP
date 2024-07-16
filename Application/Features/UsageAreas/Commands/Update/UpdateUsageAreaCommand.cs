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

namespace Application.Features.UsageAreas.Commands.Update;

public class UpdateUsageAreaCommand : IRequest<UpdatedUsageAreaResponse>,/* ISecuredRequest, ICacheRemoverRequest, */ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string LogoUrl { get; set; }

    //public string[] Roles => [Admin, Write, UsageAreasOperationClaims.Update];

    //public bool BypassCache { get; }
    //public string? CacheKey { get; }
    //public string[]? CacheGroupKey => ["GetUsageAreas"];

    public class UpdateUsageAreaCommandHandler : IRequestHandler<UpdateUsageAreaCommand, UpdatedUsageAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsageAreaRepository _usageAreaRepository;
        private readonly UsageAreaBusinessRules _usageAreaBusinessRules;

        public UpdateUsageAreaCommandHandler(IMapper mapper, IUsageAreaRepository usageAreaRepository,
                                         UsageAreaBusinessRules usageAreaBusinessRules)
        {
            _mapper = mapper;
            _usageAreaRepository = usageAreaRepository;
            _usageAreaBusinessRules = usageAreaBusinessRules;
        }

        public async Task<UpdatedUsageAreaResponse> Handle(UpdateUsageAreaCommand request, CancellationToken cancellationToken)
        {
            UsageArea? usageArea = await _usageAreaRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _usageAreaBusinessRules.UsageAreaShouldExistWhenSelected(usageArea);
            usageArea = _mapper.Map(request, usageArea);

            await _usageAreaRepository.UpdateAsync(usageArea!);

            UpdatedUsageAreaResponse response = _mapper.Map<UpdatedUsageAreaResponse>(usageArea);
            return response;
        }
    }
}