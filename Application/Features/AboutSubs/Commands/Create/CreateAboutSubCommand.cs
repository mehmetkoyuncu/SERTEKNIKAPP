using Application.Features.AboutSubs.Constants;
using Application.Features.AboutSubs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AboutSubs.Constants.AboutSubsOperationClaims;

namespace Application.Features.AboutSubs.Commands.Create;

public class CreateAboutSubCommand : IRequest<CreatedAboutSubResponse>,ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }


    public class CreateAboutSubCommandHandler : IRequestHandler<CreateAboutSubCommand, CreatedAboutSubResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutSubRepository _aboutSubRepository;
        private readonly AboutSubBusinessRules _aboutSubBusinessRules;

        public CreateAboutSubCommandHandler(IMapper mapper, IAboutSubRepository aboutSubRepository,
                                         AboutSubBusinessRules aboutSubBusinessRules)
        {
            _mapper = mapper;
            _aboutSubRepository = aboutSubRepository;
            _aboutSubBusinessRules = aboutSubBusinessRules;
        }

        public async Task<CreatedAboutSubResponse> Handle(CreateAboutSubCommand request, CancellationToken cancellationToken)
        {
            AboutSub aboutSub = _mapper.Map<AboutSub>(request);

            await _aboutSubRepository.AddAsync(aboutSub);

            CreatedAboutSubResponse response = _mapper.Map<CreatedAboutSubResponse>(aboutSub);
            return response;
        }
    }
}