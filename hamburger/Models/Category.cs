using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hamburger.Models
{
    public class Category:BaseClass
    {
        public List<Product> Product { get; set; }
    }
}