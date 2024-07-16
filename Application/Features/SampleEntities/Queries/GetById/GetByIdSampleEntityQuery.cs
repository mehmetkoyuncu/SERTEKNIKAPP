using Application.Features.SampleEntities.Constants;
using Application.Features.SampleEntities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SampleEntities.Constants.SampleEntitiesOperationClaims;

namespace Application.Features.SampleEntities.Queries.GetById;

public class GetByIdSampleEntityQuery : IRequest<GetByIdSampleEntityResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdSampleEntityQueryHandler : IRequestHandler<GetByIdSampleEntityQuery, GetByIdSampleEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISampleEntityRepository _sampleEntityRepository;
        private readonly SampleEntityBusinessRules _sampleEntityBusinessRules;

        public GetByIdSampleEntityQueryHandler(IMapper mapper, ISampleEntityRepository sampleEntityRepository, SampleEntityBusinessRules sampleEntityBusinessRules)
        {
            _mapper = mapper;
            _sampleEntityRepository = sampleEntityRepository;
            _sampleEntityBusinessRules = sampleEntityBusinessRules;
        }

        public async Task<GetByIdSampleEntityResponse> Handle(GetByIdSampleEntityQuery request, CancellationToken cancellationToken)
        {
            SampleEntity? sampleEntity = await _sampleEntityRepository.GetAsync(predicate: se => se.Id == request.Id, cancellationToken: cancellationToken);
            await _sampleEntityBusinessRules.SampleEntityShouldExistWhenSelected(sampleEntity);

            GetByIdSampleEntityResponse response = _mapper.Map<GetByIdSampleEntityResponse>(sampleEntity);
            return response;
        }
    }
}