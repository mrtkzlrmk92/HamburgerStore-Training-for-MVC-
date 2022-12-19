using hamburger.Entity;
using hamburger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hamburger.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            List<Category> listc = db.Category.Where(x=> x.IsDelete==false).ToList();

            return View(listc);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Category cat)
        {
           
            db.Category.Add(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category cat = db.Category.Find(id);
            
            return View(cat);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Category NewCat=db.Category.Find(category.Id);
            NewCat.Name = category.Name;
          
            NewCat.IsActive = category.IsActive;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Category silCat=db.Category.Find(id);
            silCat.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        
    }
}