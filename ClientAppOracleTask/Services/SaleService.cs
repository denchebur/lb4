using ClientAppOracleTask.Abstractions;
using ClientAppOracleTask.Entities;
using ClientAppOracleTask.Specefications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Services
{
    public class SaleService : ISaleService
    {
        const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Database = ShopDB;User ID=dbshop;Password=PASSWORD;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly IRepository<Sale> _repository;

        public SaleService(IRepository<Sale> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Sale>> GetInfoAsync()
        {
            return (await _repository.GetAsync()).ToList();
        }

        public async Task<IActionResult> Add(Sale model)
        {
            var checkNumber = model.CheckNo;
            var productId = model.ProductId;
            var dateSale = model.DateSale;
            var quantity = model.Quantity;

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                var query = "EXEC [dbo].AddSale @check_no, @product_id, @date_sale, @quantity";

                connection.Open();
                connection.FireInfoMessageEventOnUserErrors = true;

                SqlCommand command = new SqlCommand(query, connection);

                command.CommandType = System.Data.CommandType.Text;

                var check_Number = new SqlParameter
                {
                    ParameterName = "@check_no",
                    Value = checkNumber
                };

                var product_Id = new SqlParameter
                {
                    ParameterName = "@product_id",
                    Value = productId
                };

                var date_sale = new SqlParameter
                {
                    ParameterName = "@date_sale",
                    Value = dateSale
                };

                var product_quantity = new SqlParameter
                {
                    ParameterName = "@quantity",
                    Value = quantity
                };

                command.Parameters.Add(check_Number);
                command.Parameters.Add(product_Id);
                command.Parameters.Add(date_sale);
                command.Parameters.Add(product_quantity);

                try
                {
                    var result = await command.ExecuteNonQueryAsync();
                    if ((int)result == -1)
                        throw new Exception("Сheck if the data is correct");

                    var specification = new Specification<Sale>(s => s.CheckNo == checkNumber);

                    var sale = await _repository.FindAsync(specification);
                    return new OkResult();
                }
                catch (Exception ex)
                {   
                    return new BadRequestObjectResult(ex.Message);
                }
            }
        }
    }
}
