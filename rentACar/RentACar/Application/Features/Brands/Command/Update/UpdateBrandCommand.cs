using MediatR;

namespace Application.Features.Brands.Command.Update
{
    public class UpdateBrandCommand:IRequest<UpdateBrandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
    }
}
