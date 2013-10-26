using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.util;
using iTextSharp.text;
namespace PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the Directory path
            string DirectoryPath = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            //need a PDF to create/modify based on our requirement
            string sourcePath = @"D:\DBTeamProject\TestPDFSample.pdf";
            //Dataset will bring all the data for PDF
            ///DataTable DT = new DataTable();
           /// DT = fillData();
            using (Document doc = new Document(PageSize.A4, 30, 40, 40, 40))
            {

                //Create a new PDF from template
                var existingFileStream = new FileStream(sourcePath, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(doc, existingFileStream);
                doc.Open();
                //Create First Page
                // a table with five columns         
                PdfPTable table = new PdfPTable(5);
                table.TotalWidth = 540f;
                //fix the absolute width of the table
                table.LockedWidth = true;

                //relative col widths in proportions - 2/7, 1/7 and 3/7

                float[] widths = new float[] { 1.5f, 1f, 0.5f, 2.5f, 0.5f };

                table.SetWidths(widths);

                table.HorizontalAlignment = 0;


                //leave a gap before and after the table

                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                //Adjust the font size
                Font bodyFont = FontFactory.GetFont("Calibri", 12, Font.BOLD, BaseColor.BLACK);

                // Set the title of the table
                PdfPCell header = new PdfPCell(new Phrase("Aggregated Sales Report", bodyFont));

                header.Colspan = 5;

                //header.Border = 4;
                header.HorizontalAlignment = 1;
                header.PaddingTop = 10;
                header.PaddingBottom = 10;
                table.AddCell(header);

                PdfPCell dateHeader = new PdfPCell(new Phrase("Date: 20-Jul-2013", bodyFont));
                dateHeader.Colspan = 5;

                //header.Border = 4;
                dateHeader.HorizontalAlignment = 0;
                dateHeader.PaddingTop = 10;
                dateHeader.PaddingBottom = 10;
                //dateHeader.BackgroundColor.ToArgb();
                table.AddCell(dateHeader);





                string connectionString = @"Server=eb4e8aab-41d9-4bc8-a8d1-a20300ff48af.sqlserver.sequelizer.com; Database=dbeb4e8aab41d94bc8a8d1a20300ff48af; User ID=zoilfinkwugndyce; Password=NavPZEjDJghLK5XWL82ESn4BAaJqgd7XQeGxS7FxyWYgm4V67z4jfGAze3oY53wF";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    
                    //DateTime date = new DateTime(2013, 07, 20);
                    string query = "SELECT pro.ProductName " +
                                                "AS Product, " +
                                            "LTRIM(Str(sal.Quantity, 25, 2)) + ' ' + Measures.MeasureName " +
                                                "AS [Quantity], " +
                                            "sal.UnitPrice " +
                                                "AS [Unit Price], " +
                                            "sup.Name " +
                                                "AS Location, " +
                                            "sal.[Sum] " +
                                    "FROM SalesReports sal " +
                                    "INNER JOIN Products pro " +
                                         "ON sal.ProductId = pro.Id " +
                                         "INNER JOIN Measures " +
                                            "ON pro.MeasureId = Measures.ID " +
                                    "INNER JOIN Supermarkets sup " +
                                        "ON sal.SupermarketID = sup.Id "; /*+
                                    "WHERE sal.Date "; +
                                    "BETWEEN '{0}/{1}/2013 00:00:00.00' AND '{0}/{1}/2013 23:59:59.99'", month, day;*/

                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    try
                    {
                        conn.Open();

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {                                
                                table.AddCell(rdr[0].ToString());
                                table.AddCell(rdr[1].ToString());
                                table.AddCell(rdr[2].ToString());
                                table.AddCell(rdr[3].ToString());
                                table.AddCell(rdr[4].ToString());

                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    doc.Add(table);
                }
                
                
                /*
                Chunk testChunk = new Chunk(TestData, bodyFont);
                Phrase testPhrase = new Phrase(testChunk);
                PdfPCell cell;
                cell = new PdfPCell(testPhrase);
                //adjust Table cell padding
                cell.PaddingTop = 10;
                cell.PaddingBottom = 10;
                cell.PaddingLeft = 10;
                cell.PaddingRight = 10;
                cell.FixedHeight = 120f;
               // cell.Border = PdfPCell.NO_BORDER; //Adjust Border
                table.AddCell(cell);
                doc.Add(table);   */  
               doc.Close();
            }
        }
        /*
        public static void FindSalesByDate(int year, string country)
        {
            using (Supermarket database = new NorthwndEntities())
            {
                var specOrders = database.Orders
                    .Where(ord => ord.OrderDate.Value.Year == year && ord.ShipCountry == country)
                    .GroupBy(ord => ord.Customer.ContactName);

                int specOrderID = 1;

                foreach (var order in specOrders)
                {
                    Console.WriteLine("{0}. {1}", specOrderID, order.Key);
                    specOrderID++;
                }
            }
        }
        */



         //Fetch data from database.
        
 
        private static DataTable fillData()
        {
            //You need to provide correct Connection string to your Database
            string connectionString = @"Server=eb4e8aab-41d9-4bc8-a8d1-a20300ff48af.sqlserver.sequelizer.com; Database=dbeb4e8aab41d94bc8a8d1a20300ff48af; User ID=zoilfinkwugndyce; Password=NavPZEjDJghLK5XWL82ESn4BAaJqgd7XQeGxS7FxyWYgm4V67z4jfGAze3oY53wF";
            DataTable datatable;
            // Open connection
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                // Create new DataAdapter
                using (SqlDataAdapter adaptor = new SqlDataAdapter("SELECT * FROM Products", cn))
                {
                    // Use DataAdapter to fill DataTable
                    datatable = new DataTable();
                    adaptor.Fill(datatable);
                }
            }
            return datatable;
        }
    }
}
