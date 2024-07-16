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

namespace Application.Features.ServiceSummaries.Commands.Create;

public class CreateServiceSummaryCommand : IRequest<CreatedServiceSummaryResponse>/*, ISecuredRequest, ICacheRemoverRequest*/, ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }

    //public string[] Roles => [Admin, Write, ServiceSummariesOperationClaims.Create];

    //public bool BypassCache { get; }
    //public string? CacheKey { get; }
    //public string[]? CacheGroupKey => ["GetServiceSummaries"];

    public class CreateServiceSummaryCommandHandler : IRequestHandler<CreateServiceSummaryCommand, CreatedServiceSummaryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServiceSummaryRepository _serviceSummaryRepository;
        private readonly ServiceSummaryBusinessRules _serviceSummaryBusinessRules;

        public CreateServiceSummaryCommandHandler(IMapper mapper, IServiceSummaryRepository serviceSummaryRepository,
                                         ServiceSummaryBusinessRules serviceSummaryBusinessRules)
        {
            _mapper = mapper;
            _serviceSummaryRepository = serviceSummaryRepository;
            _serviceSummaryBusinessRules = serviceSummaryBusinessRules;
        }

        public async Task<CreatedServiceSummaryResponse> Handle(CreateServiceSummaryCommand request, CancellationToken cancellationToken)
        {
            ServiceSummary serviceSummary = _mapper.Map<ServiceSummary>(request);

            await _serviceSummaryRepository.AddAsync(serviceSummary);

            CreatedServiceSummaryResponse response = _mapper.Map<CreatedServiceSummaryResponse>(serviceSummary);
            return response;
        }
    }
}