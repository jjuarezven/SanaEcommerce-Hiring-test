using System;
using System.Collections.Generic;

namespace SanaEcommerce.Model
{
	public class InMemoryProducts	
	{
		public List<Product> InMemoryProductsList { get; set; }

		public InMemoryProducts()
		{
		
				InMemoryProductsList = new List<Product>();
				InMemoryProductsList.Add(new Product
				{
					CategoryId = 1,
					Code = "0025",
					Name = "DVD player",
					Price = 74,
					Stock = 7,
					CreationDate = DateTime.Today,
					ProductCategory = new ProductCategory { CategoryId = 1, CategoryName = "Electronics" }
				});
			
		}
	}
}
