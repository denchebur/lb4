using ClientAppOracleTask.Abstractions;
using ClientAppOracleTask.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Services
{
    public class DepartmentService : IEntityService<Department>
    {
        private readonly IRepository<Department> _repository;

        public DepartmentService (IRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Department>> GetInfoAsync()
        {
            return (await _repository.GetAsync()).ToList();
        }
    }
}
