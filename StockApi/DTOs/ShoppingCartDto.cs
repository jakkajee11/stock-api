using System;
using StockApi.Entities;

namespace StockApi.DTOs
{
    public class ShoppingCartDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }

        public List<ProductDto> Products { get; set; }

        public double TotalPrice {
            get
            {
                return Products == null || Products.Count == 0 ? 0 : Products.Sum(p => p.TotalPrice);
            }
        }

        public int TotalItems {
            get
            {
                return Products == null || Products.Count == 0 ? 0 : Products.Sum(p => p.Amount);
            }

        }
    }
}

