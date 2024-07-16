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

namespace Application.Features.Offers.Commands.Update;

public class UpdateOfferCommand : IRequest<UpdatedOfferResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string CompanyName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string ProjectName { get; set; }
    public required string Message { get; set; }

    public string[] Roles => [Admin, Write, OffersOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOffers"];

    public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, UpdatedOfferResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly OfferBusinessRules _offerBusinessRules;

        public UpdateOfferCommandHandler(IMapper mapper, IOfferRepository offerRepository,
                                         OfferBusinessRules offerBusinessRules)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
            _offerBusinessRules = offerBusinessRules;
        }

        public async Task<UpdatedOfferResponse> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            Offer? offer = await _offerRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _offerBusinessRules.OfferShouldExistWhenSelected(offer);
            offer = _mapper.Map(request, offer);

            await _offerRepository.UpdateAsync(offer!);

            UpdatedOfferResponse response = _mapper.Map<UpdatedOfferResponse>(offer);
            return response;
        }
    }
}