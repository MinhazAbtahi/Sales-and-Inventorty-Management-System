using BusinessEntityLayer;
using System.Data;

namespace BusinessAccessLayer
{
    interface ICategoryOperations
    {
        int InsertCategory(CategoryEntity category);
        int UpdateCategory(CategoryEntity category);
        int DeleteCategory(CategoryEntity category);
        DataTable SearchCategory(CategoryEntity category);
        DataTable GetCategoryList();
    }
}
