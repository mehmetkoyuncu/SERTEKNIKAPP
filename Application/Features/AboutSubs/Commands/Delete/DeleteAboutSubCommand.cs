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

namespace Application.Features.AboutSubs.Commands.Delete;

public class DeleteAboutSubCommand : IRequest<DeletedAboutSubResponse>, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }



    public class DeleteAboutSubCommandHandler : IRequestHandler<DeleteAboutSubCommand, DeletedAboutSubResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutSubRepository _aboutSubRepository;
        private readonly AboutSubBusinessRules _aboutSubBusinessRules;

        public DeleteAboutSubCommandHandler(IMapper mapper, IAboutSubRepository aboutSubRepository,
                                         AboutSubBusinessRules aboutSubBusinessRules)
        {
            _mapper = mapper;
            _aboutSubRepository = aboutSubRepository;
            _aboutSubBusinessRules = aboutSubBusinessRules;
        }

        public async Task<DeletedAboutSubResponse> Handle(DeleteAboutSubCommand request, CancellationToken cancellationToken)
        {
            AboutSub? aboutSub = await _aboutSubRepository.GetAsync(predicate: ass => ass.Id == request.Id, cancellationToken: cancellationToken);
            await _aboutSubBusinessRules.AboutSubShouldExistWhenSelected(aboutSub);

            await _aboutSubRepository.DeleteAsync(aboutSub!);

            DeletedAboutSubResponse response = _mapper.Map<DeletedAboutSubResponse>(aboutSub);
            return response;
        }
    }
}