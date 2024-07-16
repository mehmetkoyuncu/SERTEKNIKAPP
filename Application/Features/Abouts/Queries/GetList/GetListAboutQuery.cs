using Application.Features.Abouts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;

using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Abouts.Constants.AboutsOperationClaims;

namespace Application.Features.Abouts.Queries.GetList;

public class GetListAboutQuery : IRequest<GetListResponse<GetListAboutListItemDto>>
{
    public class GetListAboutQueryHandler : IRequestHandler<GetListAboutQuery, GetListResponse<GetListAboutListItemDto>>
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;

        public GetListAboutQueryHandler(IAboutRepository aboutRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAboutListItemDto>> Handle(GetListAboutQuery request, CancellationToken cancellationToken)
        {
            IPaginate<About> abouts = await _aboutRepository.GetListAsync(
                index:0,
                size: 1, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAboutListItemDto> response = _mapper.Map<GetListResponse<GetListAboutListItemDto>>(abouts);
            return response;
        }
    }
}