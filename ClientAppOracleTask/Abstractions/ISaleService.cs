using ClientAppOracleTask.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Abstractions
{
    public interface ISaleService : IEntityService<Sale>
    {
        public Task<IActionResult> Add(Sale model);
    }
}
