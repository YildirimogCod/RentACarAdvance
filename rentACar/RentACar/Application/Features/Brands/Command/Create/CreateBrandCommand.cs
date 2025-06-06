using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transactional;
using MediatR;

namespace Application.Features.Brands.Command.Create
{
    public class CreateBrandCommand:IRequest<CreatedBrandResponse>,ITransactionalRequest,ICachableRemoveRequest
    {
        public string Name { get; set; }
        public string CacheKey { get; }
        public string CacheGroupKey => "GetBrands";
        public bool ByPass { get; }
    }
}
