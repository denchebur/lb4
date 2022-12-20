namespace ClientAppOracleTask.Entities
{
    public class Product : Entity
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Producer { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
