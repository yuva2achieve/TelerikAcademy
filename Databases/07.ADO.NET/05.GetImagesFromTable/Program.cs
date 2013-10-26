using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace _05.GetImagesFromTable
{
    public class Program
    {
        private const string ConnectionString = @"Server = HOME-LAPTOP;Database = Northwind;Integrated Security = true";
        private const string FilePath = @"..\..\";
        private const string FileExtension = @".jpg";
        
        public static void Main(string[] args)
        {
            GetImages();
        }

        public static void GetImages()
        {
            string getImagesCommand = @"
                SELECT Picture, CategoryID FROM Categories";
            SqlConnection dbConnection = new SqlConnection(ConnectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand cmd = new SqlCommand(getImagesCommand, dbConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    byte[] image = (byte[])reader["Picture"];
                    int categoryID = (int)reader["CategoryID"];
                    SaveImage(image, FilePath + categoryID + FileExtension);
                }
            }
        }

        private static void SaveImage(byte[] image, string nameAndLocation)
        {
            FileStream fs = new FileStream(nameAndLocation, FileMode.Create);
            using (fs)
            {
                fs.Write(image, 0, image.Length);
            }
        }
    }
}
