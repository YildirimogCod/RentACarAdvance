﻿using Application.Features.Brands.Command.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse createdBrandResponse = await Mediator.Send(createBrandCommand);
            return Ok(createdBrandResponse);
        }
    }
}
