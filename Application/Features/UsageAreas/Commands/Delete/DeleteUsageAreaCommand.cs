using Application.Features.UsageAreas.Constants;
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

namespace Application.Features.UsageAreas.Commands.Delete;

public class DeleteUsageAreaCommand : IRequest<DeletedUsageAreaResponse>,/* ISecuredRequest, ICacheRemoverRequest, */ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    //public string[] Roles => [Admin, Write, UsageAreasOperationClaims.Delete];

    //public bool BypassCache { get; }
    //public string? CacheKey { get; }
    //public string[]? CacheGroupKey => ["GetUsageAreas"];

    public class DeleteUsageAreaCommandHandler : IRequestHandler<DeleteUsageAreaCommand, DeletedUsageAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsageAreaRepository _usageAreaRepository;
        private readonly UsageAreaBusinessRules _usageAreaBusinessRules;

        public DeleteUsageAreaCommandHandler(IMapper mapper, IUsageAreaRepository usageAreaRepository,
                                         UsageAreaBusinessRules usageAreaBusinessRules)
        {
            _mapper = mapper;
            _usageAreaRepository = usageAreaRepository;
            _usageAreaBusinessRules = usageAreaBusinessRules;
        }

        public async Task<DeletedUsageAreaResponse> Handle(DeleteUsageAreaCommand request, CancellationToken cancellationToken)
        {
            UsageArea? usageArea = await _usageAreaRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _usageAreaBusinessRules.UsageAreaShouldExistWhenSelected(usageArea);

            await _usageAreaRepository.DeleteAsync(usageArea!);

            DeletedUsageAreaResponse response = _mapper.Map<DeletedUsageAreaResponse>(usageArea);
            return response;
        }
    }
}