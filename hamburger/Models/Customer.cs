using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hamburger.Models
{
    public class Customer : BaseClass
    {
        public string Surname { get; set; }
        public double Balance { get; set; }

        public List<Order> Order { get; set; }
    }
}