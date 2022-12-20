using ClientAppOracleTask.Abstractions;
using ClientAppOracleTask.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Services
{
    public class ProductService : IProductService
    {
        const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Database = ShopDB;User ID=dbshop;Password= PASSWORD;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Task<Product> Add(Product model)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Product>> GetInfoAsync()
        {
            return (await _repository.GetAsync()).ToList();
        }

        public async Task<ActionResult<int>> GetPrice(string productName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                var query = "SELECT dbo.GetPrice(@product_name)";
                var command = new SqlCommand(query, connection);
                var productNameParameter = new SqlParameter("@product_name", productName);

                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Add(productNameParameter);

                try
                {
                    var price = (Int32)await command.ExecuteScalarAsync();
                    return price;
                }
                catch
                {
                    return new BadRequestResult();
                }
            }
        }
    }
}
