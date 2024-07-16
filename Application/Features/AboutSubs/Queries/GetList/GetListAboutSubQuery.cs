using Application.Features.AboutSubs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.AboutSubs.Queries.GetList;

public class GetListAboutSubQuery : IRequest<GetListResponse<GetListAboutSubListItemDto>>
{

    public class GetListAboutSubQueryHandler : IRequestHandler<GetListAboutSubQuery, GetListResponse<GetListAboutSubListItemDto>>
    {
        private readonly IAboutSubRepository _aboutSubRepository;
        private readonly IMapper _mapper;

        public GetListAboutSubQueryHandler(IAboutSubRepository aboutSubRepository, IMapper mapper)
        {
            _aboutSubRepository = aboutSubRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAboutSubListItemDto>> Handle(GetListAboutSubQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AboutSub> aboutSubs = await _aboutSubRepository.GetListAsync(
                index: 0,
                size: 10, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAboutSubListItemDto> response = _mapper.Map<GetListResponse<GetListAboutSubListItemDto>>(aboutSubs);
            return response;
        }
    }
}