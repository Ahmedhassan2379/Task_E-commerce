using E_commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_commerce.Domain.Entities
{
    public class Category : BaseModel
    {
        public string? Name { get; set; }       
        public string? Description { get; set; }

        // Navigation property to represent the relationship
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; } 
    }
}
