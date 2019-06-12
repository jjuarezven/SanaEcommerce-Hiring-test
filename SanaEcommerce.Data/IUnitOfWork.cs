using SanaEcommerce.Model;

namespace SanaEcommerce.Data
{
	public interface IUnitOfWork
	{
		IGenericRepository<Product> ProductRepository { get; }
		IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
		void ExecuteSql(string sqlQuery, object parameter1, object parameter2);
		bool Commit();
	}
}
