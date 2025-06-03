using Core.Application;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Models.Query.GetList
{
    public class GetListModelQuery:IRequest<GetListResponse<GetListModelListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

    }
}
