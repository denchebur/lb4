using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Entities
{
    public class Department : Entity
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public List<Product> Products { get; set; }
    }
}
