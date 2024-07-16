using Application.Features.Abouts.Constants;
using Application.Features.Abouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Abouts.Constants.AboutsOperationClaims;

namespace Application.Features.Abouts.Queries.GetById;

public class GetByIdAboutQuery : IRequest<GetByIdAboutResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQuery, GetByIdAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutRepository _aboutRepository;
        private readonly AboutBusinessRules _aboutBusinessRules;

        public GetByIdAboutQueryHandler(IMapper mapper, IAboutRepository aboutRepository, AboutBusinessRules aboutBusinessRules)
        {
            _mapper = mapper;
            _aboutRepository = aboutRepository;
            _aboutBusinessRules = aboutBusinessRules;
        }

        public async Task<GetByIdAboutResponse> Handle(GetByIdAboutQuery request, CancellationToken cancellationToken)
        {
            About? about = await _aboutRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _aboutBusinessRules.AboutShouldExistWhenSelected(about);

            GetByIdAboutResponse response = _mapper.Map<GetByIdAboutResponse>(about);
            return response;
        }
    }
}