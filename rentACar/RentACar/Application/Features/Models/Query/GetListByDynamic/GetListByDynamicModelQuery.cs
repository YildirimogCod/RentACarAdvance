using Core.Application;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.Models.Query.GetListByDynamic
{
    public class GetListByDynamicModelQuery:IRequest<GetListResponse<GetListByDynamicModelListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

        public DynamicQuery DynamicQuery { get; set; }
    }
}
