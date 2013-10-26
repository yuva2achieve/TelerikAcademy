using System;
using System.Data.SqlClient;
using System.Linq;

namespace _01.GetNumberOfRowsInTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server = HOME-LAPTOP;Database = Northwind;Integrated Security = true";
            string commandText = @"SELECT COUNT(*) FROM Categories";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand cmd = new SqlCommand(commandText, dbConnection);
                int columnsCount = (int)cmd.ExecuteScalar();
                Console.WriteLine("Number of columns in Categories is: {0}", columnsCount);
            }
        }
    }
}
