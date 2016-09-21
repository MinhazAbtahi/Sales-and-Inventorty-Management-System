using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class StockEntity
    {
        public int StockID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string StockDate { get; set; }
        public double TotalPrice { get; set; }
     }
}
