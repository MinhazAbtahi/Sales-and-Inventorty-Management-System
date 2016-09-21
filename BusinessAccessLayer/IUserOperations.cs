using BusinessEntityLayer;
using System.Data;

namespace BusinessAccessLayer
{
    interface IUserOperations
    {
        int InsertUser(UserEntity user);
        DataTable SearchUser(UserEntity user);
        DataTable ValidateUser(UserEntity user);
    }
}
