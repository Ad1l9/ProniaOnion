using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;

namespace ProniaOnion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {


            return Ok(await _service.GetAllPaginatedAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

            return StatusCode(StatusCodes.Status200OK, await _service.GetByIdAsync(id));
        }
    }
}
