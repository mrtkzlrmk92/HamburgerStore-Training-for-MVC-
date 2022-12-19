using hamburger.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hamburger.Entity
{
    public class DataContext:DbContext
    {
       public DataContext (): base("hamburgerConnection"){}
        public DbSet<Category>  Category { get; set; }
        public DbSet<Customer>  Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

    }
}