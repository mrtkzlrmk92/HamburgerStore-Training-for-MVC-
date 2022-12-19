using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hamburger.Models.ViewsModel
{
    public class OrderMultiModel
    {
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Order> Orders { get; set; }
        public Order order { get; set; }

    }
}