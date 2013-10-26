using System;
using System.Data.OleDb;
using System.Linq;

namespace _06.ReadExcelFile
{
    class Program
    {
        private const string ExcelPath = @"..\..\NamesAndScores.xlsx";
        private const string ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelPath + ";Extended Properties=Excel 12.0;";

        static void Main(string[] args)
        {
            OleDbConnection excelConnection = new OleDbConnection(ConnStr);
            excelConnection.Open();
            using (excelConnection)
            {
                OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", excelConnection);
                OleDbDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("-----------------");
                Console.WriteLine("Name\t| Score\t|");
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];
                    Console.WriteLine("-----------------");
                    Console.WriteLine("{0}\t| {1}\t|", name, score);
                }
                Console.WriteLine("-----------------");
            }
        }
    }
}
