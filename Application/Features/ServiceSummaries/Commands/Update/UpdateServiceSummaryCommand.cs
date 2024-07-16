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

namespace Application.Features.ServiceSummaries.Commands.Update;

public class UpdateServiceSummaryCommand : IRequest<UpdatedServiceSummaryResponse>/*, ISecuredRequest, ICacheRemoverRequest*/, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    //public string[] Roles => [Admin, Write, ServiceSummariesOperationClaims.Update];

    //public bool BypassCache { get; }
    //public string? CacheKey { get; }
    //public string[]? CacheGroupKey => ["GetServiceSummaries"];

    public class UpdateServiceSummaryCommandHandler : IRequestHandler<UpdateServiceSummaryCommand, UpdatedServiceSummaryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServiceSummaryRepository _serviceSummaryRepository;
        private readonly ServiceSummaryBusinessRules _serviceSummaryBusinessRules;

        public UpdateServiceSummaryCommandHandler(IMapper mapper, IServiceSummaryRepository serviceSummaryRepository,
                                         ServiceSummaryBusinessRules serviceSummaryBusinessRules)
        {
            _mapper = mapper;
            _serviceSummaryRepository = serviceSummaryRepository;
            _serviceSummaryBusinessRules = serviceSummaryBusinessRules;
        }

        public async Task<UpdatedServiceSummaryResponse> Handle(UpdateServiceSummaryCommand request, CancellationToken cancellationToken)
        {
            ServiceSummary? serviceSummary = await _serviceSummaryRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _serviceSummaryBusinessRules.ServiceSummaryShouldExistWhenSelected(serviceSummary);
            serviceSummary = _mapper.Map(request, serviceSummary);

            await _serviceSummaryRepository.UpdateAsync(serviceSummary!);

            UpdatedServiceSummaryResponse response = _mapper.Map<UpdatedServiceSummaryResponse>(serviceSummary);
            return response;
        }
    }
}