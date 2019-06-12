using SanaEcommerce.Model;
using SanaEcommerce.Model.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SanaEcommerce.Web.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductService productService;
		private readonly IProductCategoriesService productCategoriesService;

		/// <summary>
		/// This constrcutor receives services instnaces by dependency injection configured in UnityConfig.cs
		/// </summary>
		/// <param name="productService"></param>
		/// <param name="productCategoriesService"></param>
		public ProductsController(IProductService productService, IProductCategoriesService productCategoriesService)
		{
			this.productService = productService;
			this.productCategoriesService = productCategoriesService;
		}

		// GET: Products
		public ActionResult Index(string storageMode)
		{
			if (!string.IsNullOrEmpty(storageMode) && storageMode == "memory")
			{
				Session["database"] = false;
				if (Session["Products"] == null)
				{
					Session["Products"] = new InMemoryProducts().InMemoryProductsList;
				}
				return View((IEnumerable<Product>)Session["Products"]);
			}

			Session["database"] = true;
			return View(productService.GetAll());
		}

		// GET: Products/Create
		public ActionResult Create()
		{
			var categories = productCategoriesService.GetProductCategories();
			ViewBag.productCategories = new SelectList(categories, "Key", "Value");
			return View();
		}

		// POST: Products/Create
		[HttpPost]
		public ActionResult Create(Product product)
		{
			try
			{
				if (ModelState.IsValid)
				{
					product.CreationDate = DateTime.Today;
					if ((bool)Session["database"])
					{
						productService.Save(product);
					}
					else
					{
						var list = (Session["Products"]) as List<Product>;
						var categoryName = productCategoriesService.GetProductCategories().FirstOrDefault(x => x.Key == product.CategoryId).Value;
						product.ProductCategory = new ProductCategory { CategoryId = product.CategoryId, CategoryName = categoryName };
						list.Add(product);
						Session["Products"] = list;
					}
					var storageMode = (bool)Session["database"] ? "database" : "memory";
					return RedirectToAction("Index", new { storageMode = storageMode } );
				}
				else
				{
					return View();
				}
			}
			catch
			{
				return View();
			}
		}		
	}
}
