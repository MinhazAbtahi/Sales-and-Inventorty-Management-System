using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class ProductSoldEntity
    {
        public int ID { get; set; }
        public int ConfigID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float TotalAmount { get; set; }
        public int InvoiceNo { get; set; }
    }
}
