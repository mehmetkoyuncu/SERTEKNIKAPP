using Application.Features.UsageAreas.Constants;
using Application.Features.UsageAreas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.UsageAreas.Constants.UsageAreasOperationClaims;

namespace Application.Features.UsageAreas.Queries.GetById;

public class GetByIdUsageAreaQuery : IRequest<GetByIdUsageAreaResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdUsageAreaQueryHandler : IRequestHandler<GetByIdUsageAreaQuery, GetByIdUsageAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsageAreaRepository _usageAreaRepository;
        private readonly UsageAreaBusinessRules _usageAreaBusinessRules;

        public GetByIdUsageAreaQueryHandler(IMapper mapper, IUsageAreaRepository usageAreaRepository, UsageAreaBusinessRules usageAreaBusinessRules)
        {
            _mapper = mapper;
            _usageAreaRepository = usageAreaRepository;
            _usageAreaBusinessRules = usageAreaBusinessRules;
        }

        public async Task<GetByIdUsageAreaResponse> Handle(GetByIdUsageAreaQuery request, CancellationToken cancellationToken)
        {
            UsageArea? usageArea = await _usageAreaRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _usageAreaBusinessRules.UsageAreaShouldExistWhenSelected(usageArea);

            GetByIdUsageAreaResponse response = _mapper.Map<GetByIdUsageAreaResponse>(usageArea);
            return response;
        }
    }
}