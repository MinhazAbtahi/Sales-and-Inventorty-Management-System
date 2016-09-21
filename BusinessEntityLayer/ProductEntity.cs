using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class ProductEntity
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Company { get; set; }
        public string Features { get; set; }
        public double Price { get; set; }
    }
}
