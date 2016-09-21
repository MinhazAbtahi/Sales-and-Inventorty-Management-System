using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class AccessDB
    {
        public SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N8KNMLD\\SQLEXPRESS;Initial Catalog=INVENTORY_DB;Integrated Security=False;User ID=sa;Password=12345678;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public AccessDB()
        {

        }

        /// <summary>
        /// Opens a DB connection
        /// </summary>
        /// <returns>SqlConnection object</returns>
        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }

        /// <summary>
        /// Executes non query commands for insert, update, delete
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Number of rows affected</returns>
        public int ExecuteNonQuery(SqlCommand command)
        {
            command.Connection = this.GetConnection();

            int rowsAffected = 0;
            try
            {
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

            connection.Close();
            return rowsAffected;
        }

        /// <summary>
        /// Retrives single value from the DB
        /// </summary>
        /// <param name="command"></param>
        /// <returns>First column of the first row</returns>
        public object ExeceuteScalar(SqlCommand command)
        {
            command.Connection = this.GetConnection();

            object obj = 0;
            try
            {
                obj = command.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }

            connection.Close();
            return obj;
        }

        /// <summary>
        /// Executes sql command and builds a data table
        /// </summary>
        /// <param name="command"></param>
        /// <returns>DataTable consisting retrived data</returns>
        public DataTable ExecuteReader(SqlCommand command)
        {
            command.Connection = this.GetConnection();

            SqlDataReader sqlDataReader;
            try
            {
                sqlDataReader = command.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);

            connection.Close();
            return dataTable;
        }

        /// <summary>
        /// Executes sql command and builds a reader
        /// </summary>
        /// <param name="command"></param>
        /// <returns>SqlDataReader Object</returns>
        public SqlDataReader ExecuteDataReader(SqlCommand command)
        {
            command.Connection = this.GetConnection();

            SqlDataReader sqlDataReader;
            try
            {
                sqlDataReader = command.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }

            connection.Close();
            return sqlDataReader;
        }
    }
}
