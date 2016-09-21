using BusinessEntityLayer;
using System.Data;

namespace BusinessAccessLayer
{
    interface IStockOperations
    {
        int InsertStock(StockEntity stock);
        int UpdateStock(StockEntity stock);
        int DeleteStock(StockEntity stock);
        DataTable SearchStock(StockEntity stock);
        DataTable GetStockIdList();
        DataTable GetProductStock();
        DataTable GetProductStock(StockEntity stock);
    }
}
