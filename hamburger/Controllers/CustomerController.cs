using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hamburger.Models;
using hamburger.Entity;

namespace hamburger.Controllers
{
    public class CustomerController : Controller
    {
        DataContext db = new DataContext();
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> list = 
                db.Customer.Where(x => x.IsDelete == false).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer) {
        db.Customer.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Customer.Find(id));

        }
        [HttpPost]
        public ActionResult Edit(Customer customer) 
        {
            Customer newCust = db.Customer.Find(customer.Id);
            newCust.Name= customer.Name;
            newCust.Surname= customer.Surname;
            newCust.Balance= customer.Balance;
            newCust.IsActive= customer.IsActive;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Customer customer)
        {
            Customer delCustomer = db.Customer.Find(customer.Id);
            delCustomer.IsDelete = true;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}