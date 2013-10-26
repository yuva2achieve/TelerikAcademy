using System;
using System.Linq;
using Supermarket.Model;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
namespace SuperMarketReports.Client
{
    public class PdfReportCreator
    {
        public static void CreatePdf()
        {
            //need a PDF to create/modify based on our requirement
            string sourcePath = @"../../AggregatedSalesReport.pdf";

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

                float[] widths = new float[] { 1.2f, 0.8f, 0.7f, 2.3f, 0.7f };

                table.SetWidths(widths);

                table.HorizontalAlignment = 0;

                //leave a gap before and after the table

                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                BaseFont calibri = BaseFont.CreateFont("../../../fonts/calibri.ttf", BaseFont.CP1250, false);
                Font bodyFont = new Font(calibri, 12);
                Font boldFont = new Font(calibri, 12, Font.BOLD);

                // Set the title of the table
                PdfPCell header = new PdfPCell(new Phrase("Aggregated Sales Report", boldFont));
                header.Colspan = 5;
                //header.Border = 4;
                header.HorizontalAlignment = 1;
                header.PaddingTop = 10;
                header.PaddingBottom = 10;
                table.AddCell(header);

                using (var supermarket = new SupermarketContext())
                {
                    var groupedByDate = supermarket.SalesReports.Include("Products").Include("Measures").Include("Supermarkets").GroupBy(r => r.Date);
                    foreach (var group in groupedByDate.ToList())
                    {
                        DateTime date = group.First().Date;

                        PdfPCell dateHeader = new PdfPCell(new Phrase(string.Format("Date: {0:d-MMM-yyyy}", date), bodyFont));
                        dateHeader.Colspan = 5;
                        dateHeader.BackgroundColor = new BaseColor(200, 200, 200);
                        dateHeader.HorizontalAlignment = 0;
                        dateHeader.PaddingTop = 8;
                        dateHeader.PaddingBottom = 8;
                        table.AddCell(dateHeader);

                        table.AddCell(new PdfPCell(new Phrase("Product", boldFont)) { BackgroundColor = new BaseColor(200, 200, 200), Padding = 2 });
                        table.AddCell(new PdfPCell(new Phrase("Quantity", boldFont)) { BackgroundColor = new BaseColor(200, 200, 200), Padding = 2 });
                        table.AddCell(new PdfPCell(new Phrase("Unit Price", boldFont)) { BackgroundColor = new BaseColor(200, 200, 200), Padding = 2 });
                        table.AddCell(new PdfPCell(new Phrase("Location", boldFont)) { BackgroundColor = new BaseColor(200, 200, 200), Padding = 2 });
                        table.AddCell(new PdfPCell(new Phrase("Sum", boldFont)) { BackgroundColor = new BaseColor(200, 200, 200), Padding = 2 });

                        foreach (var row in group)
                        {
                            table.AddCell(new Phrase(row.Product.ProductName, bodyFont));
                            table.AddCell(new Phrase(row.Quantity + " " + row.Product.Measure.MeasureName, bodyFont));
                            table.AddCell(new Phrase(row.UnitPrice.ToString(), bodyFont));
                            table.AddCell(new Phrase(row.Supermarket.Name, bodyFont));
                            table.AddCell(new Phrase(row.Sum.ToString(), bodyFont));
                        }

                        PdfPCell dateFooter = new PdfPCell(new Phrase(string.Format("Total sum for {0:d-MMM-yyyy}", date), bodyFont));
                        dateFooter.Colspan = 4;
                        dateFooter.HorizontalAlignment = 2;
                        dateFooter.PaddingTop = 8;
                        dateFooter.PaddingBottom = 8;
                        table.AddCell(dateFooter);
                        table.AddCell(new PdfPCell(new Phrase(group.Sum(g => g.Sum).ToString(), boldFont)) { BackgroundColor = new BaseColor(200, 200, 200), PaddingTop = 8 });
                    }

                    doc.Add(table);
                }
  
                doc.Close();
            }
        }
    }
}