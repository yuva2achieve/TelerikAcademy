using System;
using System.Data.SqlClient;
using System.Linq;

namespace _03.JoinTables
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server = HOME-LAPTOP;Database = Northwind;Integrated Security = true";
            string commandText = @"
            SELECT 
	            c.CategoryName, p.ProductName
            FROM Categories c
            INNER JOIN Products p
            ON
	            c.CategoryId = p.CategoryId
            GROUP BY 
                c.CategoryName, p.ProductName";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand cmd = new SqlCommand(commandText, dbConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0} - {1}", categoryName, productName);
                }
            }
        }
    }
}
