using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hamburger.Models.ViewsModel
{
    public class ProductMultiModel
    {
        public List<Product> products { get; set; }
        public List<Category> categories { get; set; }
        public Product product { get; set; }
    }
}