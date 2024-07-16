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

namespace Application.Features.Contacts.Commands.Create;

public class CreateContactCommand : IRequest<CreatedContactResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Mail { get; set; }
    public required string PhoneNumber { get; set; }
    public required string PhoneNumber1 { get; set; }
    public required string Address { get; set; }
    public required float MapsLat { get; set; }
    public required float MapsLen { get; set; }

    public string[] Roles => [Admin, Write, ContactsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetContacts"];

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreatedContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly ContactBusinessRules _contactBusinessRules;

        public CreateContactCommandHandler(IMapper mapper, IContactRepository contactRepository,
                                         ContactBusinessRules contactBusinessRules)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _contactBusinessRules = contactBusinessRules;
        }

        public async Task<CreatedContactResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            Contact contact = _mapper.Map<Contact>(request);

            await _contactRepository.AddAsync(contact);

            CreatedContactResponse response = _mapper.Map<CreatedContactResponse>(contact);
            return response;
        }
    }
}