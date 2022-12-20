using ClientAppOracleTask.Abstractions;
using ClientAppOracleTask.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var sales = await _saleService.GetInfoAsync();
            return View(sales);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Sale model)
        {
            model.DateSale = DateTime.Now;
            if (ModelState.IsValid)
            {
                var addSaleResult = await _saleService.Add(model);
                if (addSaleResult.GetType().Equals(typeof(OkResult)))
                    return RedirectToAction(nameof(Index));
                else
                {
                    var result = addSaleResult as BadRequestObjectResult;
                    ModelState.AddModelError(string.Empty, result.Value.ToString());
                }   
            }
            return View(model);
        }
    }
}
