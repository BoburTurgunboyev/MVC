using FirstMvcProject.Application.Services.ProductServices;
using FirstMvcProject.Domain.Entities;
using FirstMvcProject.Infrastructure.Repositories.ProductRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwgController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;
        private readonly IProductRepository _productRepository;

        public SwgController(IProductService productService, UserManager<User> userManager, IProductRepository productRepository)
        {
            _productService = productService;
            _userManager = userManager;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProduct();
            return Ok(products);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateProduct(Product product)
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _productService.CreateProduct(product);
            await _productRepository.CreateAudit(product, null, "Create", user);
            return Ok(product);

        }
    }
}
