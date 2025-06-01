using MediatR;

namespace Application.Features.Brands.Command.Delete
{
   public class DeleteBrandCommand:IRequest<DeleteBrandCommandResponse>
    {
       public Guid Id { get; set; }
    }
}
