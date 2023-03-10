using System;
using StockApi.Entities;

namespace StockApi
{
    public static class FakeData
    {        
        public static List<Category> Categories()
        {
            return new List<Category>()
            {
                new Category{ Id = Guid.NewGuid(), }
            };
        }
    }
}

