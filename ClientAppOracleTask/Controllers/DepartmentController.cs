using ClientAppOracleTask.Abstractions;
using ClientAppOracleTask.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IEntityService<Department> _entityService;

        public DepartmentController(IEntityService<Department> entityService)
        {
            _entityService = entityService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var departments = await _entityService.GetInfoAsync();
            return View(departments);
        }
    }
}
