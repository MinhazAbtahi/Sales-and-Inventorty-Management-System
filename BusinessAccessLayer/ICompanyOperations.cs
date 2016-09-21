using BusinessEntityLayer;
using System.Data;

namespace BusinessAccessLayer
{
    interface ICompanyOperations
    {
        int InsertCompany(CompanyEntity company);
        int UpdateCompany(CompanyEntity company);
        int DeleteCompany(CompanyEntity company);
        DataTable SearchCompany(CompanyEntity company);
        DataTable GetCompanyList();
    }
}
