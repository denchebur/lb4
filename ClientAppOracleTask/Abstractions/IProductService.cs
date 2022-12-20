using ClientAppOracleTask.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Abstractions
{
    public interface IProductService : IEntityService<Product>
    {
        Task<ActionResult<int>> GetPrice(string productName);
    }
}
