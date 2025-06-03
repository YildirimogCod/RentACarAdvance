using Application.Features.Models.Query.GetList;
using Application.Features.Models.Query.GetListByDynamic;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profile
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Model,GetListModelListItemDto>().ReverseMap();
            CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();

            CreateMap<Model, GetListByDynamicModelListItemDto>().ReverseMap();
            CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();

        }
    }
}
