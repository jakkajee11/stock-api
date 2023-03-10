using System;
namespace StockApi.DTOs
{
    public class AddToShoppingCartDto
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
    }
}

