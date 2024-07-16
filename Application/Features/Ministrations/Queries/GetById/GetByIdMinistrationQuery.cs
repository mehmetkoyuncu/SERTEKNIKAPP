using Application.Features.Ministrations.Constants;
using Application.Features.Ministrations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Ministrations.Constants.MinistrationsOperationClaims;

namespace Application.Features.Ministrations.Queries.GetById;

public class GetByIdMinistrationQuery : IRequest<GetByIdMinistrationResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMinistrationQueryHandler : IRequestHandler<GetByIdMinistrationQuery, GetByIdMinistrationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMinistrationRepository _ministrationRepository;
        private readonly MinistrationBusinessRules _ministrationBusinessRules;

        public GetByIdMinistrationQueryHandler(IMapper mapper, IMinistrationRepository ministrationRepository, MinistrationBusinessRules ministrationBusinessRules)
        {
            _mapper = mapper;
            _ministrationRepository = ministrationRepository;
            _ministrationBusinessRules = ministrationBusinessRules;
        }

        public async Task<GetByIdMinistrationResponse> Handle(GetByIdMinistrationQuery request, CancellationToken cancellationToken)
        {
            Ministration? ministration = await _ministrationRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _ministrationBusinessRules.MinistrationShouldExistWhenSelected(ministration);

            GetByIdMinistrationResponse response = _mapper.Map<GetByIdMinistrationResponse>(ministration);
            return response;
        }
    }
}