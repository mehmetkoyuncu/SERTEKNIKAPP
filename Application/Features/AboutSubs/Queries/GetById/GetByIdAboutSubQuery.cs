using Application.Features.AboutSubs.Constants;
using Application.Features.AboutSubs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AboutSubs.Constants.AboutSubsOperationClaims;

namespace Application.Features.AboutSubs.Queries.GetById;

public class GetByIdAboutSubQuery : IRequest<GetByIdAboutSubResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAboutSubQueryHandler : IRequestHandler<GetByIdAboutSubQuery, GetByIdAboutSubResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutSubRepository _aboutSubRepository;
        private readonly AboutSubBusinessRules _aboutSubBusinessRules;

        public GetByIdAboutSubQueryHandler(IMapper mapper, IAboutSubRepository aboutSubRepository, AboutSubBusinessRules aboutSubBusinessRules)
        {
            _mapper = mapper;
            _aboutSubRepository = aboutSubRepository;
            _aboutSubBusinessRules = aboutSubBusinessRules;
        }

        public async Task<GetByIdAboutSubResponse> Handle(GetByIdAboutSubQuery request, CancellationToken cancellationToken)
        {
            AboutSub? aboutSub = await _aboutSubRepository.GetAsync(predicate: ass => ass.Id == request.Id, cancellationToken: cancellationToken);
            await _aboutSubBusinessRules.AboutSubShouldExistWhenSelected(aboutSub);

            GetByIdAboutSubResponse response = _mapper.Map<GetByIdAboutSubResponse>(aboutSub);
            return response;
        }
    }
}