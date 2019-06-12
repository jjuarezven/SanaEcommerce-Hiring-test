using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SanaEcommerce.Model.ServicesInterfaces
{
	public interface IProductService
	{
		IEnumerable<Product> GetAll();
		IEnumerable<Product> GetWhere(Expression<Func<Product, bool>> predicate);
		Product GetById(int id);
		bool Save(IEnumerable<Product> products);
		bool Save(Product product);
	}
}
