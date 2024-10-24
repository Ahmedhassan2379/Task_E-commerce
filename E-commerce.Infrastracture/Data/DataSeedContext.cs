using E_commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerce.Infrastracture.Data
{
    public static class DataSeedContext
    {
        public static async Task SeedAsync(ApplicationDbContext DbContext)
        {
            if (!DbContext.Categories.Any())
            {
                var category = File.ReadAllText("../../E-commerce.Infrastracture/JsonDataExamples/Categories.json");
                var json = JsonSerializer.Deserialize<List<Category>>(category);

                if (json?.Count > 0)
                {
                    foreach (var brand in json)
                    {
                        await DbContext.Set<Category>().AddAsync(brand);
                    }
                    await DbContext.SaveChangesAsync();
                }
            }

            if (!DbContext.Products.Any())
            {
                var ProductsData = File.ReadAllText("../../E-commerce.Infrastracture/JsonDataExamples/Products.json");
                var ProductsJson = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                if (ProductsJson?.Count > 0)
                {
                    foreach (var Product in ProductsJson)
                    {
                        await DbContext.Set<Product>().AddAsync(Product);
                    }
                    await DbContext.SaveChangesAsync();
                }
            }
        }
    }
}
