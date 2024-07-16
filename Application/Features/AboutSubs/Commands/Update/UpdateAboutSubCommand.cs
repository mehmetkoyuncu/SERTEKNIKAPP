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

namespace Application.Features.AboutSubs.Commands.Update;

public class UpdateAboutSubCommand : IRequest<UpdatedAboutSubResponse>,ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    public class UpdateAboutSubCommandHandler : IRequestHandler<UpdateAboutSubCommand, UpdatedAboutSubResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutSubRepository _aboutSubRepository;
        private readonly AboutSubBusinessRules _aboutSubBusinessRules;

        public UpdateAboutSubCommandHandler(IMapper mapper, IAboutSubRepository aboutSubRepository,
                                         AboutSubBusinessRules aboutSubBusinessRules)
        {
            _mapper = mapper;
            _aboutSubRepository = aboutSubRepository;
            _aboutSubBusinessRules = aboutSubBusinessRules;
        }

        public async Task<UpdatedAboutSubResponse> Handle(UpdateAboutSubCommand request, CancellationToken cancellationToken)
        {
            AboutSub? aboutSub = await _aboutSubRepository.GetAsync(predicate: ass => ass.Id == request.Id, cancellationToken: cancellationToken);
            await _aboutSubBusinessRules.AboutSubShouldExistWhenSelected(aboutSub);
            aboutSub = _mapper.Map(request, aboutSub);

            await _aboutSubRepository.UpdateAsync(aboutSub!);

            UpdatedAboutSubResponse response = _mapper.Map<UpdatedAboutSubResponse>(aboutSub);
            return response;
        }
    }
}