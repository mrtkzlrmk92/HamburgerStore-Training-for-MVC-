﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hamburger.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Product product { get; set; }
        public Customer customer { get; set; }
    }
}