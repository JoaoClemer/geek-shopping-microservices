using GeekShopping.ProductAPI.Data.DataTransferObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest();

            var product = await _repository.Create(productDTO);

            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest();

            var product = await _repository.Update(productDTO);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            
            if (!status)
                return BadRequest();

            return Ok(status);
        }
    }
}
