using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hamburger.Models
{
    public class Product:BaseClass
    {
        public int CategoryId { get; set; }
        public double UnitPrice { get; set; }
        public Category category { get; set; }
        public List<Order> Order { get; set; }
    }
}