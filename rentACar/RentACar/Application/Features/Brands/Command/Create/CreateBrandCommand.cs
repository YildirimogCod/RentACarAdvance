using MediatR;

namespace Application.Features.Brands.Command.Create
{
    public class CreateBrandCommand:IRequest<CreatedBrandResponse>
    {
        public string Name { get; set; }
    }
}
