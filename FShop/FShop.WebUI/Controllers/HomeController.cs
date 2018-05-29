using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FShop.Core.Contracts;
using FShop.Core.Models;
using FShop.Core.ViewModels;

namespace FShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;
        private int pageSize = 6;

        public HomeController(IRepository<Product> productContext,IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }

        public ActionResult Index(string category = null, int page = 1)
        {
            int allProductsCount;
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();
            if (category == null)
            {
                products = context.Collection().OrderBy(i=>i.Name).ToList();
                
            }
            else
            {
                products = context.Collection().Where(i => i.Category.Equals(category)).OrderBy(i => i.Name).ToList();
            }
            allProductsCount = products.Count;
            products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ProductListViewModel model = new ProductListViewModel();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = allProductsCount };
            model.PageInfo = pageInfo;
            model.ProductCategories = categories;
            model.Products = products;
            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}