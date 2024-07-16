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

namespace Application.Features.SampleEntities.Commands.Update;

public class UpdateSampleEntityCommand : IRequest<UpdatedSampleEntityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int X { get; set; }

    public string[] Roles => [Admin, Write, SampleEntitiesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSampleEntities"];

    public class UpdateSampleEntityCommandHandler : IRequestHandler<UpdateSampleEntityCommand, UpdatedSampleEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISampleEntityRepository _sampleEntityRepository;
        private readonly SampleEntityBusinessRules _sampleEntityBusinessRules;

        public UpdateSampleEntityCommandHandler(IMapper mapper, ISampleEntityRepository sampleEntityRepository,
                                         SampleEntityBusinessRules sampleEntityBusinessRules)
        {
            _mapper = mapper;
            _sampleEntityRepository = sampleEntityRepository;
            _sampleEntityBusinessRules = sampleEntityBusinessRules;
        }

        public async Task<UpdatedSampleEntityResponse> Handle(UpdateSampleEntityCommand request, CancellationToken cancellationToken)
        {
            SampleEntity? sampleEntity = await _sampleEntityRepository.GetAsync(predicate: se => se.Id == request.Id, cancellationToken: cancellationToken);
            await _sampleEntityBusinessRules.SampleEntityShouldExistWhenSelected(sampleEntity);
            sampleEntity = _mapper.Map(request, sampleEntity);

            await _sampleEntityRepository.UpdateAsync(sampleEntity!);

            UpdatedSampleEntityResponse response = _mapper.Map<UpdatedSampleEntityResponse>(sampleEntity);
            return response;
        }
    }
}