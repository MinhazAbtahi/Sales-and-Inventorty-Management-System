using BusinessEntityLayer;
using System.Data;

namespace BusinessAccessLayer
{
    interface IProductOperations
    {
        int InsertProduct(ProductEntity product);
        int UpdateProduct(ProductEntity product);
        int DeleteProduct(ProductEntity product);
        DataTable SearchProduct(ProductEntity product);
        DataTable GetProductList();
    }
}
