using ASP.Net_API_06._04._2025.Abstract;
using ASP.Net_API_06._04._2025.DAL.Abstract;
using ASP.Net_API_06._04._2025.DAL.Entities;
using ASP.Net_API_06._04._2025.Model;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_API_06._04._2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IProductService _productService;
        public ProductsController(ILogger<WeatherForecastController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll ()
        {
            //var result = new List<ProductDto>
            //{
            //    new ProductDto
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Product 1",
            //        Price = 123
            //    },
            //    new ProductDto
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Product 2",
            //        Price = 456
            //    },
            //    new ProductDto
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Product 3",
            //        Price = 789
            //    }
            //};
            //return Ok(result);
            try
            {
                var products = await _productService.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetByName(string name)
        {
            try
            {
                var products = await _productService.GetByNameAsync(name);

                if (products == null || !products.Any())
                {
                    return NotFound("Products not found");
                }
                    
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody]CreateProductDto dto)
        {
            try
            {
                
                await _productService.AddAsync(dto);

                return Ok(true); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
