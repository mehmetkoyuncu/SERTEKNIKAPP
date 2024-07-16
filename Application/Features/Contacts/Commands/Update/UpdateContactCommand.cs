using Application.Features.Contacts.Constants;
using Application.Features.Contacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Contacts.Constants.ContactsOperationClaims;

namespace Application.Features.Contacts.Commands.Update;

public class UpdateContactCommand : IRequest<UpdatedContactResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Mail { get; set; }
    public required string PhoneNumber { get; set; }
    public required string PhoneNumber1 { get; set; }
    public required string Address { get; set; }
    public required float MapsLat { get; set; }
    public required float MapsLen { get; set; }

    public string[] Roles => [Admin, Write, ContactsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetContacts"];

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdatedContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly ContactBusinessRules _contactBusinessRules;

        public UpdateContactCommandHandler(IMapper mapper, IContactRepository contactRepository,
                                         ContactBusinessRules contactBusinessRules)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _contactBusinessRules = contactBusinessRules;
        }

        public async Task<UpdatedContactResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            Contact? contact = await _contactRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _contactBusinessRules.ContactShouldExistWhenSelected(contact);
            contact = _mapper.Map(request, contact);

            await _contactRepository.UpdateAsync(contact!);

            UpdatedContactResponse response = _mapper.Map<UpdatedContactResponse>(contact);
            return response;
        }
    }
}