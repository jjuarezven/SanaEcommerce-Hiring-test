namespace SanaEcommerce.Data
{
	using SanaEcommerce.Model;
	using System.Data.Entity;

	public partial class SanaContext : DbContext
	{
		public SanaContext()
			: base("name=SanaModel")
		{
		}

		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<OrderDetail> OrderDetails { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<ProductCategory> ProductCategories { get; set; }
		public virtual DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
