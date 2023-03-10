using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApi.Entities
{
    public class User : EntityBase
    {                
        [MaxLength(50)]
        public string Username { get; set; }
    }
}

