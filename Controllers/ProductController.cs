using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Session6_BoilerPlate.Repository;

namespace Session6_BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetProducts();
            if (products == null)
            {
                return NotFound("No products found.");
            }



            return Ok(products);


        }






    }
}
