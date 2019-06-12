using SanaEcommerce.Model;
using System;
using System.Collections.Generic;

namespace SanaEcommerce.Data
{
	public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SanaContext>
	{
		protected override void Seed(SanaContext context)
		{
			var categories = new List<ProductCategory>
			{
				new ProductCategory { CategoryId = 1, CategoryName = "Electronics" },
				new ProductCategory { CategoryId = 2, CategoryName = "Garden" },
				new ProductCategory { CategoryId = 3, CategoryName = "Groceries" }
			};

			categories.ForEach(s => context.ProductCategories.Add(s));
			context.SaveChanges();

			var products = new List<Product>
			{
			new Product { CategoryId = 1, Code = "001", Name = "Laptop", Price = 500, Stock = 66, CreationDate = DateTime.Today},
			new Product { CategoryId = 1, Code = "002", Name = "TV", Price = 300, Stock = 20, CreationDate = DateTime.Today}
			};
			products.ForEach(s => context.Products.Add(s));
			context.SaveChanges();
		}
	}
}
