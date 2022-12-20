using ClientAppOracleTask.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var products = await _productService.GetInfoAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductPrice()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductPriceAsync(string productName)
        {
            var price = await _productService.GetPrice(productName);
          
            ViewBag.ProductName = productName;
            ViewBag.Price = price.Value;

            return View();
        }
    }
}
