using System.Collections.Generic;

namespace SanaEcommerce.Model.ServicesInterfaces
{
	public interface IProductCategoriesService
	{
		Dictionary<int, string> GetProductCategories();
	}
}
