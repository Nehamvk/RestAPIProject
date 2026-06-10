using Microsoft.AspNetCore.Mvc;
using RestAPIProject.DTOs;
using RestAPIProject.Services;

namespace RestAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController:ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _service.GetByIdAsync(id);
            return product == null
           ? NotFound()
           : Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(Get),
                new { id = product.Id },
                product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
        int id,
        UpdateProductDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}
