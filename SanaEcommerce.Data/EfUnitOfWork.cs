using SanaEcommerce.Model;
using System;
using System.Data.SqlClient;

namespace SanaEcommerce.Data
{
	public class EfUnitOfWork : IUnitOfWork, IDisposable
	{
		private bool disposed = false;

		public SanaContext context;
		private readonly EfGenericRepository<Product> ProductRepo;
		private readonly EfGenericRepository<ProductCategory> ProductCategoryRepo;

		public EfUnitOfWork(SanaContext context)
		{
			this.context = context;
			ProductRepo = new EfGenericRepository<Product>(context.Products);
			ProductCategoryRepo = new EfGenericRepository<ProductCategory>(context.ProductCategories);
		}

		public IGenericRepository<Product> ProductRepository
		{
			get { return ProductRepo; }
		}

		public IGenericRepository<ProductCategory> ProductCategoryRepository
		{
			get { return ProductCategoryRepo; }
		}

		public bool Commit()
		{
			return context.SaveChanges() != 0;
		}

		#region IDisposable
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed && disposing)
			{
				context.Dispose();
			}

			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion

		public void ExecuteSql(string sqlQuery, object parameter1, object parameter2)
		{
			var p1 = parameter1 as SqlParameter;
			var p2 = parameter2 as SqlParameter;

			context.Database.ExecuteSqlCommand(sqlQuery, p1, p2);
		}
	}
}
