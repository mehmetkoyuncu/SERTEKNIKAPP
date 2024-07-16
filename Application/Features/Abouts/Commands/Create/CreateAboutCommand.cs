using Application.Features.Abouts.Constants;
using Application.Features.Abouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Abouts.Constants.AboutsOperationClaims;
using Application.Services.ImageService;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Abouts.Commands.Create;

public class CreateAboutCommand : IRequest<CreatedAboutResponse>, /*ISecuredRequest, */ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required string SmallText { get; set; }
    public required IFormFile ImagePath { get; set; }


    //public string[] Roles => [Admin, Write, AboutsOperationClaims.Create];


    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, CreatedAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutRepository _aboutRepository;
        private readonly AboutBusinessRules _aboutBusinessRules;
        private readonly ImageServiceBase _imageServiceBase;

        public CreateAboutCommandHandler(IMapper mapper, IAboutRepository aboutRepository,
                                         AboutBusinessRules aboutBusinessRules,ImageServiceBase ýmageServiceBase)
        {
            _mapper = mapper;
            _aboutRepository = aboutRepository;
            _aboutBusinessRules = aboutBusinessRules;
            _imageServiceBase = ýmageServiceBase;

        }

        public async Task<CreatedAboutResponse> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            About about = _mapper.Map<About>(request);

            about.ImageURL = await _imageServiceBase.UploadAsync(request.ImagePath);

            await _aboutRepository.AddAsync(about);

            CreatedAboutResponse response = _mapper.Map<CreatedAboutResponse>(about);
            return response;
        }
    }
}