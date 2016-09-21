using BusinessEntityLayer;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System;

namespace BusinessAccessLayer
{
    public class Operations : IUserOperations, ICustomerOperations, ICategoryOperations, ICompanyOperations, IProductOperations, IStockOperations, ISaleOperations
    {
        public AccessDB accessDB = new AccessDB();

        #region User Operations
        public int InsertUser(UserEntity user)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO [User] VALUES ('" + user.UserName + "', '" + user.Name + "', '" + user.Password + "', '" + user.Email + "', " + user.ContactNo + ")";

            return accessDB.ExecuteNonQuery(command);
        }

        public DataTable SearchUser(UserEntity user)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM [User] WHERE UserName='" + user.UserName + "'";

            return accessDB.ExecuteReader(command);
        }

        public DataTable ValidateUser(UserEntity user)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            //command.Parameters.AddWithValue("@un", user.UserName);
            //command.Parameters.AddWithValue("@pw", user.Password);
            command.CommandText = "SELECT * FROM [User] WHERE UserName='" + user.UserName + "' and Password='" + user.Password + "'";

            return accessDB.ExecuteReader(command);
        }
        #endregion

        #region Customer Operations
        public int InsertCustomer(CustomerEntity customer)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO [Customer] VALUES (" + customer.CustomerID + ", '" + customer.CustomerName + "', '" + customer.Address + "', " + customer.ContactNo + ", '" + customer.Email + "')";

            return accessDB.ExecuteNonQuery(command);
        }

        public int UpdateCustomer(CustomerEntity customer)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE [Customer] SET CustomerID='" + customer.CustomerID + "', Address = '" + customer.Address + "', ContactNo=" + customer.ContactNo + " WHERE ProductName=" + customer.CustomerID + ")";

            return accessDB.ExecuteNonQuery(command);
        }

        public int DeleteCustomer(CustomerEntity customer)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM [Customer] WHERE CustomerName=" + customer.CustomerName + "";

            return accessDB.ExecuteNonQuery(command);
        }

        public DataTable SearchCustomer(CustomerEntity customer)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM [Customer] WHERE CustomerName=" + customer.CustomerName + "";

            return accessDB.ExecuteReader(command);
        }

        public DataTable GetAllCustomer()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Category Operations
        public int InsertCategory(CategoryEntity category)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO [Category] VALUES ('" + category.Category + "')";

            return accessDB.ExecuteNonQuery(command);
        }

        public int UpdateCategory(CategoryEntity category)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE [Category] SET CategoryName = '" + category.Category + "' WHERE CategoryName = ";

            return accessDB.ExecuteNonQuery(command);
        }

        public int DeleteCategory(CategoryEntity category)
        {
            throw new NotImplementedException();
        }

        public DataTable SearchCategory(CategoryEntity category)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM [Category] WHERE CategoryName='" + category.Category + "'";

            return accessDB.ExecuteReader(command);
        }

        public DataTable GetCategoryList()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM [Category]";

            return accessDB.ExecuteReader(command);
        }
        #endregion

        #region Company Operations
        public int InsertCompany(CompanyEntity company)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO [Company] VALUES ('" + company.Company + "')";

            return accessDB.ExecuteNonQuery(command);
        }

        public int UpdateCompany(CompanyEntity company)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE [Company] SET CompanyName = '" + company.Company + "' WHERE CompanyName = ";

            return accessDB.ExecuteNonQuery(command);
        }

        public int DeleteCompany(CompanyEntity company)
        {
            throw new NotImplementedException();
        }

        public DataTable SearchCompany(CompanyEntity company)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM [Company] WHERE CompanyName='" + company.Company + "'";

            return accessDB.ExecuteReader(command);
        }

        public DataTable GetCompanyList()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM [Company]";

            return accessDB.ExecuteReader(command);
        }
        #endregion

        #region Product Operations
        public int InsertProduct(ProductEntity product)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO [Product] VALUES ('" + product.ProductName + "', '" + product.Category + "', '" + product.Company + "', '" + product.Features + "', " + product.Price + ")";

            return accessDB.ExecuteNonQuery(command);
        }

        public int UpdateProduct(ProductEntity product)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE [Product] SET Category='" + product.Category + "', Company='" + product.Company + "', Features = '" + product.Features + "', Price=" + product.Price + " WHERE ProductName='" + product.ProductName + "'";

            return accessDB.ExecuteNonQuery(command);
        }

        public int DeleteProduct(ProductEntity product)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM [Product] WHERE ProductName='" + product.ProductName + "'";

            return accessDB.ExecuteNonQuery(command);
        }

        public DataTable SearchProduct(ProductEntity product)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM [Product] WHERE ProductName='" + product.ProductName + "'";

            return accessDB.ExecuteReader(command);
        }

        public DataTable GetProductList()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT ProductName FROM [Product]";

            return accessDB.ExecuteReader(command);
        }
        #endregion

        #region Stock Operations
        public int InsertStock(StockEntity stock)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO [Stock] VALUES (" + stock.StockID + ", '" + stock.ProductName + "', " + stock.Quantity + ", '" + stock.StockDate + "', " + stock.TotalPrice + ")";

            return accessDB.ExecuteNonQuery(command);
        }

        public int UpdateStock(StockEntity stock)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE [Stock] SET StockID=" + stock.StockID + ", Quantity=" + stock.Quantity + ", StockDate = '" + stock.StockDate + "', TotalPrice=" + stock.TotalPrice + " WHERE ProductName='" + stock.ProductName + "'";

            return accessDB.ExecuteNonQuery(command);
        }

        public int DeleteStock(StockEntity stock)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM [Stock] WHERE ProductName='" + stock.ProductName + "'";

            return accessDB.ExecuteNonQuery(command);
        }

        public DataTable SearchStock(StockEntity stock)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM [Stock] WHERE ProductName='" + stock.ProductName + "'";

            return accessDB.ExecuteReader(command);
        }

        public DataTable GetStockIdList()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT StockID FROM [Stock]";

            return accessDB.ExecuteReader(command);
        }

        public DataTable GetProductStock()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT [Product].ProductName, [Stock].StockID, [Product].Features, [Product].Price, [Stock].Quantity, [Stock].TotalPrice from Product inner join Stock on [Product].ProductName = [Stock].ProductName";

            return accessDB.ExecuteReader(command);
        }

        public DataTable GetProductStock(StockEntity stock)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT [Product].ProductName, [Stock].StockID, [Product].Features, [Product].Price, [Stock].Quantity, [Stock].TotalPrice from Product inner join Stock on [Product].ProductName = '" + stock.ProductName + "'";

            return accessDB.ExecuteReader(command);
        }
        #endregion

        #region Sales Operations
        public int InsertSale(SaleEntity sale)
        {
            throw new NotImplementedException();
        }

        public int UpdateSale(SaleEntity sale)
        {
            throw new NotImplementedException();
        }

        public int DeleteSale(SaleEntity sale)
        {
            throw new NotImplementedException();
        }

        public DataTable SearchSale(SaleEntity sale)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
