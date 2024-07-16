using Application.Features.Offers.Constants;
using Application.Features.Offers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Offers.Constants.OffersOperationClaims;

namespace Application.Features.Offers.Commands.Create;

public class CreateOfferCommand : IRequest<CreatedOfferResponse>, /*ISecuredRequest, ICacheRemoverRequest, */ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required string CompanyName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string ProjectName { get; set; }
    public required string Message { get; set; }

    //public string[] Roles => [Admin, Write, OffersOperationClaims.Create];

    //public bool BypassCache { get; }
    //public string? CacheKey { get; }
    //public string[]? CacheGroupKey => ["GetOffers"];

    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, CreatedOfferResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly OfferBusinessRules _offerBusinessRules;

        public CreateOfferCommandHandler(IMapper mapper, IOfferRepository offerRepository,
                                         OfferBusinessRules offerBusinessRules)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
            _offerBusinessRules = offerBusinessRules;
        }

        public async Task<CreatedOfferResponse> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            Offer offer = _mapper.Map<Offer>(request);

            await _offerRepository.AddAsync(offer);

            CreatedOfferResponse response = _mapper.Map<CreatedOfferResponse>(offer);
            return response;
        }
    }
}