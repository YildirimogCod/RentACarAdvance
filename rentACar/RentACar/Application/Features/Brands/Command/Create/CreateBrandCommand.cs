using Core.Application.Pipelines.Transactional;
using MediatR;

namespace Application.Features.Brands.Command.Create
{
    public class CreateBrandCommand:IRequest<CreatedBrandResponse>,ITransactionalRequest
    {
        public string Name { get; set; }
    }
}
