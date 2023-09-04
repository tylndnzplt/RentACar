using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse response = await Mediator.Send(createBrandCommand);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListBrandListItemDto> getListResponse = await Mediator.Send(getListBrandQuery);

            return Ok(getListResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdBrandQuery getByIdBrandQuery = new() { Id = id};
            GetByIdBrandResponse response = await Mediator.Send(getByIdBrandQuery);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updatedBrandCommand)
        {
            UpdatedBrandResponse response = await Mediator.Send(updatedBrandCommand);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand)
        {
            DeletedBrandResponse response = await Mediator.Send(deleteBrandCommand);

            return Ok(response);
        }
    }
}
