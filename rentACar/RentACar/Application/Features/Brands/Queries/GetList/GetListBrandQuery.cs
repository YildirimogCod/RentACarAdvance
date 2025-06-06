using Core.Application;
using Core.Application.Pipelines.Caching;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Brands.Queries.GetList
{
    public class GetListBrandQuery:IRequest<GetListResponse<GetListBrandListItemDto>>,ICachableRequest
    {
        public PageRequest PageRequest { get; set; }
        public string CacheKey => $"GetListBrandQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

        public string CacheGroupKey => "GetBrands";
        public bool ByPass { get; }
        public TimeSpan? SlidingExpiration { get; }
    }
}
