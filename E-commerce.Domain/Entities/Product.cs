using E_commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Domain.Entities
{
    public class Product : BaseModel
    {
        public string? Name { get; set; }
        public string? Descrption { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int StockQuantity { get; set; }

        // Foreign key to Category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
