using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hamburger.Models
{
    abstract public class BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}