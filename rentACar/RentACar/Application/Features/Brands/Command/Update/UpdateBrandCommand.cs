using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Brands.Command.Update
{
    public class UpdateBrandCommand:IRequest<UpdateBrandResponse>,ICachableRemoveRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string CacheKey => "";
        public string? CacheGroupKey => "GetBrands";
        public bool ByPass => false;
    }
}
