using Application.Features.SampleEntities.Constants;
using Application.Features.SampleEntities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SampleEntities.Constants.SampleEntitiesOperationClaims;

namespace Application.Features.SampleEntities.Commands.Create;

public class CreateSampleEntityCommand : IRequest<CreatedSampleEntityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int X { get; set; }

    public string[] Roles => [Admin, Write, SampleEntitiesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSampleEntities"];

    public class CreateSampleEntityCommandHandler : IRequestHandler<CreateSampleEntityCommand, CreatedSampleEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISampleEntityRepository _sampleEntityRepository;
        private readonly SampleEntityBusinessRules _sampleEntityBusinessRules;

        public CreateSampleEntityCommandHandler(IMapper mapper, ISampleEntityRepository sampleEntityRepository,
                                         SampleEntityBusinessRules sampleEntityBusinessRules)
        {
            _mapper = mapper;
            _sampleEntityRepository = sampleEntityRepository;
            _sampleEntityBusinessRules = sampleEntityBusinessRules;
        }

        public async Task<CreatedSampleEntityResponse> Handle(CreateSampleEntityCommand request, CancellationToken cancellationToken)
        {
            SampleEntity sampleEntity = _mapper.Map<SampleEntity>(request);

            await _sampleEntityRepository.AddAsync(sampleEntity);

            CreatedSampleEntityResponse response = _mapper.Map<CreatedSampleEntityResponse>(sampleEntity);
            return response;
        }
    }
}