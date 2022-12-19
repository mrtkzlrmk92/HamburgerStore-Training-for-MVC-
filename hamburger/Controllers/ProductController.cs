using hamburger.Entity;
using hamburger.Models;
using hamburger.Models.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hamburger.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DataContext db = new DataContext();
        
        public ActionResult Index()
        {
            ProductMultiModel model = new ProductMultiModel();
            model.products = db.Product.Where(x => x.IsDelete == false).ToList();
            model.categories = db.Category.Where(x => x.IsDelete == false).ToList();

                return View(model);
        }
        [HttpGet]
        public  ActionResult Create()
        {
            return View(db.Category.Where(x=> x.IsDelete==false).ToList());
        }
        [HttpPost]
        public ActionResult Create(Product product) {
        
            db.Product.Add(product);
            db.SaveChanges();
       return RedirectToAction("Index");
        
        }
        [HttpGet]   
        public ActionResult Edit(int Id)

        {
            ProductMultiModel pm = new ProductMultiModel();
            pm.product=db.Product.FirstOrDefault(x=> x.Id==Id);
            pm.categories = db.Category.Where(x => x.IsDelete == false).ToList();
            return View(pm);

        }
        [HttpPost]  
        public ActionResult Edit(Product product)

        {Product newProduct=db.Product.FirstOrDefault(x=> x.Id==product.Id);
            newProduct.Name= product.Name;
            newProduct.CategoryId= product.CategoryId;
            newProduct.UnitPrice= product.UnitPrice;
            newProduct.IsActive= product.IsActive;
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Delete(int Id)
        {
            Product delProduct=db.Product.FirstOrDefault(x=> x.Id==Id);
            delProduct.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}