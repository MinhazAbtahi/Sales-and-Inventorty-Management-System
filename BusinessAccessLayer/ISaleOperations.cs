using BusinessEntityLayer;
using System.Data;

namespace BusinessAccessLayer
{
    interface ISaleOperations
    {
        int InsertSale(SaleEntity sale);
        int UpdateSale(SaleEntity sale);
        int DeleteSale(SaleEntity sale);
        DataTable SearchSale(SaleEntity sale);
    }
}
