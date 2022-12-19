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
    public class OrderController : Controller
    {
        // GET: Order
        DataContext db=new DataContext();
        public ActionResult Index()
        {
            OrderMultiModel orderMulti = new OrderMultiModel();
            orderMulti.Products = db.Product.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            orderMulti.Customers = db.Customer.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            orderMulti.Orders = db.Order.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            
            return View(orderMulti);
        }
        [HttpGet]
        public  ActionResult Create()
        {
            OrderMultiModel orderMulti= new OrderMultiModel();
            orderMulti.Products = db.Product.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            orderMulti.Customers = db.Customer.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            return View(orderMulti);
        }
        [HttpPost]
        public ActionResult Create(Order order)
        {
            Order newOrder = new Order();
            newOrder = order;
            Product p=db.Product.FirstOrDefault(x=> x.Id== newOrder.ProductId);
            newOrder.TotalPrice = order.Quantity * p.UnitPrice;
            db.Order.Add(newOrder);
            db.SaveChanges();
           return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            OrderMultiModel om = new OrderMultiModel();
            om.order=db.Order.FirstOrDefault(x=> x.Id==Id);
            om.Products= db.Product.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            om.Customers= db.Customer.Where(x => x.IsDelete == false && x.IsActive == true).ToList();

            return View(om);
        
        }
        [HttpPost]
        public ActionResult Edit(Order order) {
        
        Order neworder=db.Order.FirstOrDefault(x=> x.Id==order.Id);
            neworder.CustomerId=order.CustomerId;
            neworder.ProductId =order.ProductId;
            neworder.Quantity=order.Quantity;
            neworder.IsActive=order.IsActive;
            Product p=db.Product.FirstOrDefault(X=> X.Id==order.ProductId);
            neworder.TotalPrice=p.UnitPrice*order.Quantity;
            db.SaveChanges();
            return RedirectToAction("Index");
        
        }
        [HttpGet]
        public ActionResult Delete(int Id) 
        {
            OrderMultiModel om = new OrderMultiModel();
            om.order = db.Order.FirstOrDefault(x => x.Id == Id);
            om.Products = db.Product.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            om.Customers = db.Customer.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            ViewBag.mesaj = "silmek istediğine emin misin?";
            return View(om);

        }
        [HttpPost]
        public  ActionResult Delete(Order order)
        {
            Order delOrder=db.Order.FirstOrDefault(s=> s.Id==order.Id);
            delOrder.IsDelete = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}