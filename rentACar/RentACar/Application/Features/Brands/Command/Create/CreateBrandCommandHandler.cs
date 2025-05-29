using MediatR;

namespace Application.Features.Brands.Command.Create
{
    public class CreateBrandCommandHandler: IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        public Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            CreatedBrandResponse response = new CreatedBrandResponse();
            response.Id = Guid.NewGuid(); // Simulating ID generation
            response.Name = request.Name; // Assigning the name from the command
            return Task.FromResult(response);
        }
    }
}
