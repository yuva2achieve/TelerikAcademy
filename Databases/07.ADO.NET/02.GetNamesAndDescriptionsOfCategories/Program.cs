using System;
using System.Data.SqlClient;
using System.Linq;

namespace _02.GetNamesAndDescriptionsOfCategories
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server = HOME-LAPTOP;Database = Northwind;Integrated Security = true";
            string commandText = @"SELECT CategoryName, Description FROM Categories";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand cmd = new SqlCommand(commandText, dbConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string categoryDescription = (string)reader["Description"];
                    Console.WriteLine("{0} - {1}", categoryName, categoryDescription);
                }
            }
        }
    }
}
