using Application.Features.SampleEntities.Constants;
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

namespace Application.Features.SampleEntities.Commands.Delete;

public class DeleteSampleEntityCommand : IRequest<DeletedSampleEntityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, SampleEntitiesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSampleEntities"];

    public class DeleteSampleEntityCommandHandler : IRequestHandler<DeleteSampleEntityCommand, DeletedSampleEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISampleEntityRepository _sampleEntityRepository;
        private readonly SampleEntityBusinessRules _sampleEntityBusinessRules;

        public DeleteSampleEntityCommandHandler(IMapper mapper, ISampleEntityRepository sampleEntityRepository,
                                         SampleEntityBusinessRules sampleEntityBusinessRules)
        {
            _mapper = mapper;
            _sampleEntityRepository = sampleEntityRepository;
            _sampleEntityBusinessRules = sampleEntityBusinessRules;
        }

        public async Task<DeletedSampleEntityResponse> Handle(DeleteSampleEntityCommand request, CancellationToken cancellationToken)
        {
            SampleEntity? sampleEntity = await _sampleEntityRepository.GetAsync(predicate: se => se.Id == request.Id, cancellationToken: cancellationToken);
            await _sampleEntityBusinessRules.SampleEntityShouldExistWhenSelected(sampleEntity);

            await _sampleEntityRepository.DeleteAsync(sampleEntity!);

            DeletedSampleEntityResponse response = _mapper.Map<DeletedSampleEntityResponse>(sampleEntity);
            return response;
        }
    }
}