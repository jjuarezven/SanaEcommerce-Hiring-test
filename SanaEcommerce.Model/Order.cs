namespace SanaEcommerce.Model
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class Order
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Order()
		{
			OrderDetails = new HashSet<OrderDetail>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public int UserId { get; set; }

		[Required]
		[StringLength(30)]
		public string ShippingCountry { get; set; }

		[Required]
		[StringLength(50)]
		public string ShippingState { get; set; }

		[Required]
		[StringLength(50)]
		public string ShippingCity { get; set; }

		[Required]
		[StringLength(15)]
		public string ShippingPostalCode { get; set; }

		[Required]
		[StringLength(10)]
		public string ShippingAddress { get; set; }

		[Required]
		[StringLength(50)]
		public string ShippingName { get; set; }

		[Required]
		[StringLength(100)]
		public string ShippingEmail { get; set; }

		[Required]
		[StringLength(20)]
		public string ShippingPhoneNumber { get; set; }

		public decimal ShippingCost { get; set; }

		public DateTime? ShippingEstimatedDate { get; set; }

		public DateTime? PurchaseDate { get; set; }

		public byte IsShipped { get; set; }

		public DateTime? ShipmentDate { get; set; }

		[StringLength(100)]
		public string TrackingId { get; set; }

		public decimal Amount { get; set; }

		public decimal? Tax { get; set; }

		public virtual Customer Customer { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
