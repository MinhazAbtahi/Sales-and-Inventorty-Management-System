using BusinessEntityLayer;
using System.Data;

namespace BusinessAccessLayer
{
    interface ICustomerOperations
    {
        int InsertCustomer(CustomerEntity customer);
        int UpdateCustomer(CustomerEntity customer);
        int DeleteCustomer(CustomerEntity customer);
        DataTable SearchCustomer(CustomerEntity customer);
        DataTable GetAllCustomer();
    }
}
