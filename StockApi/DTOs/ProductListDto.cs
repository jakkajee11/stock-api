using System;
namespace StockApi.DTOs
{
    public class ProductListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        
        public int Available { get; set; }
        public double UnitPrice { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }        
    }
}

