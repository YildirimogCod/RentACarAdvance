using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Brands.Command.Delete
{
   public class DeleteBrandCommand:IRequest<DeleteBrandCommandResponse>, ICachableRemoveRequest
    {
       public Guid Id { get; set; }
       public string CacheKey => "";
       public string? CacheGroupKey => "GetBrands";
       public bool ByPass => false;
    }
}
