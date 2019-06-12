using SanaEcommerce.Data;
using SanaEcommerce.Model.ServicesInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace SanaEcommerceBusiness
{
	public class ProductCategoryBusiness : IProductCategoriesService
	{
		private readonly IUnitOfWork uow;

		public ProductCategoryBusiness(IUnitOfWork uow)
		{
			this.uow = uow;
		}

		public Dictionary<int, string> GetProductCategories()
		{
			var categories = uow.ProductCategoryRepository.GetAll();
			return categories.Select(x => new { Id = x.CategoryId, Name = x.CategoryName }).ToDictionary(x => x.Id, x => x.Name);
		}
	}
}
