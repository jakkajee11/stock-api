using System;
namespace StockApi.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Available { get; set; }
        public double UnitPrice { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public double TotalPrice {
            get
            {
                return Amount * UnitPrice;
            }
        }
    }
}

