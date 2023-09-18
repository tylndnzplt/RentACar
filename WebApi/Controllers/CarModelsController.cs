using Application.Features.Brands.Queries.GetList;
using Application.Features.CarModels.Queries.GetList;
using Application.Features.CarModels.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            GetListCarModelQuery getListCarModelQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListCarModelListItemDto> getListResponse = await Mediator.Send(getListCarModelQuery);

            return Ok(getListResponse);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
        {
            GetListByDynamicCarModelQuery getListByDynamicCarModelQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            GetListResponse<GetListByDynamicCarModelListItemDto> getListResponse = await Mediator.Send(getListByDynamicCarModelQuery);

            return Ok(getListResponse);
        }
    }
}
