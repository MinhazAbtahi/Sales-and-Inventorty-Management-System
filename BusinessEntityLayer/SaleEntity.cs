using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class SaleEntity
    {
        public int InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public int CustomerID { get; set; }
        public float SubTotal { get; set; }
        public float VATpercentage { get; set; }
        public float VATAmount { get; set; }
        public float GrandTotal { get; set; }
        public float TotalPayment { get; set; }
        public float PaymentDue { get; set; }
        public string Remarks { get; set; }
    }
}
