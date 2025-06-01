using MediatR;

namespace Application.Features.Brands.Queries.GetById
{
    public class GetByIdQuery:IRequest<GetByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
