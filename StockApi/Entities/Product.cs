using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApi.Entities
{
    public class Product : EntityBase
    {                   
        [MaxLength(100)]
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Available { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

