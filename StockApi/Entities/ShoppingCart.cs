using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApi.Entities
{
    public class ShoppingCart : EntityBase
    {               
        public bool CheckedOut { get; set; }
        public int Amount { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}

