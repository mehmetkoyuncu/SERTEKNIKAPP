using Application.Features.ServiceSummaries.Constants;
using Application.Features.ServiceSummaries.Constants;
using Application.Features.ServiceSummaries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ServiceSummaries.Constants.ServiceSummariesOperationClaims;

namespace Application.Features.ServiceSummaries.Commands.Delete;

public class DeleteServiceSummaryCommand : IRequest<DeletedServiceSummaryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ServiceSummariesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetServiceSummaries"];

    public class DeleteServiceSummaryCommandHandler : IRequestHandler<DeleteServiceSummaryCommand, DeletedServiceSummaryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServiceSummaryRepository _serviceSummaryRepository;
        private readonly ServiceSummaryBusinessRules _serviceSummaryBusinessRules;

        public DeleteServiceSummaryCommandHandler(IMapper mapper, IServiceSummaryRepository serviceSummaryRepository,
                                         ServiceSummaryBusinessRules serviceSummaryBusinessRules)
        {
            _mapper = mapper;
            _serviceSummaryRepository = serviceSummaryRepository;
            _serviceSummaryBusinessRules = serviceSummaryBusinessRules;
        }

        public async Task<DeletedServiceSummaryResponse> Handle(DeleteServiceSummaryCommand request, CancellationToken cancellationToken)
        {
            ServiceSummary? serviceSummary = await _serviceSummaryRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _serviceSummaryBusinessRules.ServiceSummaryShouldExistWhenSelected(serviceSummary);

            await _serviceSummaryRepository.DeleteAsync(serviceSummary!);

            DeletedServiceSummaryResponse response = _mapper.Map<DeletedServiceSummaryResponse>(serviceSummary);
            return response;
        }
    }
}