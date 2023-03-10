using System;
using Microsoft.AspNetCore.Mvc;
using StockApi.Entities;

namespace StockApi.Controllers
{
    public class AppControllerBase : ControllerBase
    {
        //private readonly StockApiContext _context;

        public AppControllerBase()
        {
            //_context = context;
        }

        protected void SetInsertProperties<T>(T entity) where T : EntityBase
        {
            if (entity.Id == Guid.Empty) entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            
        }

        protected void SetUpdateProperties<T>(T entity) where T : EntityBase
        {
            entity.UpdatedAt = DateTime.UtcNow;            
        }
    }
}

