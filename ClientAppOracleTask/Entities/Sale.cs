using System;

namespace ClientAppOracleTask.Entities
{
    public class Sale : Entity
    {
        public int CheckNo { get; set; }
        public int ProductId { get; set; }
        public DateTime DateSale { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
