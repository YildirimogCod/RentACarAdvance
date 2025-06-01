using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetById
{
    public class GetByIdQueryHandler:IRequestHandler<GetByIdQuery,GetByIdResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public GetByIdQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
           Brand? brand =  await _brandRepository.GetAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);
           GetByIdResponse response = _mapper.Map<GetByIdResponse>(brand); 
           return response;
        }
    }
}
