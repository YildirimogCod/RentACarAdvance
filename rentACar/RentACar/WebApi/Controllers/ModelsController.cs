using Application.Features.Models.Query.GetList;
using Application.Features.Models.Query.GetListByDynamic;
using Core.Application;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListModelListItemDto> response = await Mediator.Send(getListModelQuery);
            return Ok(response);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromRoute] DynamicQuery? dynamicQuery=null)
        {
            GetListByDynamicModelQuery getListModelQuery = new() { PageRequest = pageRequest,DynamicQuery = dynamicQuery};
            GetListResponse<GetListByDynamicModelListItemDto> response = await Mediator.Send(getListModelQuery);
            return Ok(response);
        }
    }
}
