using System;
namespace StockApi.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public int Available { get; set; }
        public double UnitPrice { get; set; }
    }
}

