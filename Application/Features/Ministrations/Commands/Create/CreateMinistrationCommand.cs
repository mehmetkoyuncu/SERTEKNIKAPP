using Application.Features.Ministrations.Constants;
using Application.Features.Ministrations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Ministrations.Constants.MinistrationsOperationClaims;
using Microsoft.AspNetCore.Http;
using Application.Services.ImageService;

namespace Application.Features.Ministrations.Commands.Create;

public class CreateMinistrationCommand : IRequest<CreatedMinistrationResponse>,/* ISecuredRequest, ICacheRemoverRequest,*/ ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required IFormFile ImagePath { get; set; }


    //public string[] Roles => [Admin, Write, MinistrationsOperationClaims.Create];

    //public bool BypassCache { get; }
    //public string? CacheKey { get; }
    //public string[]? CacheGroupKey => ["GetMinistrations"];

    public class CreateMinistrationCommandHandler : IRequestHandler<CreateMinistrationCommand, CreatedMinistrationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMinistrationRepository _ministrationRepository;
        private readonly MinistrationBusinessRules _ministrationBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public CreateMinistrationCommandHandler(IMapper mapper, IMinistrationRepository ministrationRepository,
                                         MinistrationBusinessRules ministrationBusinessRules, ImageServiceBase imageServiceBase)
        {
            _mapper = mapper;
            _ministrationRepository = ministrationRepository;
            _ministrationBusinessRules = ministrationBusinessRules;
            _imageServiceBase = imageServiceBase;
        }

        public async Task<CreatedMinistrationResponse> Handle(CreateMinistrationCommand request, CancellationToken cancellationToken)
        {
            Ministration ministration = _mapper.Map<Ministration>(request);

            ministration.LogoUrl = await _imageServiceBase.UploadAsync(request.ImagePath);

            await _ministrationRepository.AddAsync(ministration);

            CreatedMinistrationResponse response = _mapper.Map<CreatedMinistrationResponse>(ministration);
            return response;
        }
    }
}