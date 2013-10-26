using System;
using System.Data.OleDb;
using System.Linq;

namespace _07.AddRowToExcelTable
{
    class Program
    {
        private const string ExcelPath = @"..\..\NamesAndScores.xlsx";
        private const string ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelPath + ";Extended Properties=Excel 12.0;";
        private static OleDbConnection excelConnection = new OleDbConnection(ConnStr);
        static void Main(string[] args)
        {
            AddRow("Boris", 5.5);
        }

        public static void AddRow(string name, double score)
        {
            excelConnection.Open();

            using (excelConnection)
            {
                string cmdAddRow = @"
                INSERT INTO [Sheet1$](Name, Score)
                VALUES(@name, @score)";

                OleDbCommand cmd = new OleDbCommand(cmdAddRow, excelConnection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@score", score);

                cmd.ExecuteNonQuery();
            }

            excelConnection.Close();
        }
    }
}
