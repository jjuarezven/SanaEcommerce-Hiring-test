using SanaEcommerce.Data;
using SanaEcommerce.Model;
using SanaEcommerce.Model.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SanaEcommerceBusiness
{
	// This class is not only a wrapper to make data operations, you can add business logic/rules.
	public class ProductBusiness : IProductService
	{
		private readonly IUnitOfWork uow;

		public ProductBusiness(IUnitOfWork uow)
		{
			this.uow = uow;
		}

		public IEnumerable<Product> GetAll()
		{
			return uow.ProductRepository.GetAll();
		}

		public Product GetById(int id)
		{
			return uow.ProductRepository.GetById(id);
		}

		public IEnumerable<Product> GetWhere(Expression<Func<Product, bool>> predicate)
		{
			return uow.ProductRepository.Find(predicate);
		}

		public bool Save(Product product)
		{
			uow.ProductRepository.Add(product);
			return uow.Commit();
		}

		public bool Save(IEnumerable<Product> products)
		{
			foreach (var product in products)
			{
				uow.ProductRepository.Add(product);
			}
			return uow.Commit();
		}
	}
}
