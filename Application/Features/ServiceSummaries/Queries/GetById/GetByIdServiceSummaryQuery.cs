using Application.Features.ServiceSummaries.Constants;
using Application.Features.ServiceSummaries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ServiceSummaries.Constants.ServiceSummariesOperationClaims;

namespace Application.Features.ServiceSummaries.Queries.GetById;

public class GetByIdServiceSummaryQuery : IRequest<GetByIdServiceSummaryResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdServiceSummaryQueryHandler : IRequestHandler<GetByIdServiceSummaryQuery, GetByIdServiceSummaryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServiceSummaryRepository _serviceSummaryRepository;
        private readonly ServiceSummaryBusinessRules _serviceSummaryBusinessRules;

        public GetByIdServiceSummaryQueryHandler(IMapper mapper, IServiceSummaryRepository serviceSummaryRepository, ServiceSummaryBusinessRules serviceSummaryBusinessRules)
        {
            _mapper = mapper;
            _serviceSummaryRepository = serviceSummaryRepository;
            _serviceSummaryBusinessRules = serviceSummaryBusinessRules;
        }

        public async Task<GetByIdServiceSummaryResponse> Handle(GetByIdServiceSummaryQuery request, CancellationToken cancellationToken)
        {
            ServiceSummary? serviceSummary = await _serviceSummaryRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _serviceSummaryBusinessRules.ServiceSummaryShouldExistWhenSelected(serviceSummary);

            GetByIdServiceSummaryResponse response = _mapper.Map<GetByIdServiceSummaryResponse>(serviceSummary);
            return response;
        }
    }
}