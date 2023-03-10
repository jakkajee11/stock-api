using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApi.Entities
{
    public class Category : EntityBase
    {                
        [MaxLength(100)]
        public string Name { get; set; }        

        public ICollection<Product> Products { get; set; }
    }
}

