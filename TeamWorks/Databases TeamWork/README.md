Databases – Practical Teamwork Project:
==========================

Created By:
-----------
* Bojidar Penchev
* Borislav Jivkov
* Jordan Darakchiev
* Petar Ivanov

Assignment
----------
Your assignment is to design, develop and test a C# application for importing Excel sales reports from ZIP file and product data from MySQL into SQL Server, generate PDF aggregated reports and XML sales reports, create product reports as JSON documents and load them into MongoDB, load vendor expenses from XML file, read taxes from SQLite and calculate vendor's total results and write them into Excel file.

Technologies used:
------------------
* C#
* ADO.NET
* Microsoft SQL Server 2012
* MySQL
* MongoDB
* SQLite
* XML
* Entity Framework
* OpenAccess ORM
* TFS

Problem #1 – Load Excel Reports from ZIP File
---------------------------------------------
Suppose you have the MySQL database “Supermarket” holding information about the vendors and products and a set of Excel files (*.xls) holding information about the sales in the different super-markets.
Your task is to load the Excel reports in MS SQL Server. You will need preliminary to move design a database schema to hold all data about products (data from the MySQL database and data from the Excel files). You are not allowed to manually copy the MySQL tables (your C# program should do it).
The Excel files are given inside a ZIP archive holding subfolders named as the dates of the report in format dd-MMM-yyyy (see the example reports archive Sample-Sales-Reports.zip).
Note that ZIP file could contain few hundred dates (folders), each holding few hundreds Excel files, each holding thousands of products sold.

Problem #2 – Generate PDF Aggregated Sales Reports
--------------------------------------------------
Your task is to generate a PDF aggregated report summarizing the sales from all supermarkets for all available dates from the SQL Server.A sample PDF report is also available: Sample-Aggregated-Sales-Report.pdf.

Problem #3 – Generate XML Sales Report by Vendors
--------------------------------------------------
Your task is to create a C# program to generate aggregated sales report by dates in XML format.
Save the report in a file named “Sales-by-Vendors-report.xml”.

Problem #4 – Product Reports
-----------------------------
Your task is to write a program to create a product report for each product in JSON format and save all reports as JSON documents in MongoDB. All product reports should look like the sample below and should be saved in the MongoDB database as well as in the file system (in a folder called “Product-Reports”, in files named “XX.json” where XX is the product ID). 

Problem #5 – Load Vendor Expenses from XML
------------------------------------------
You are given an XML file Vendors-Expenses.xml holding the expenses of all vendors by months.
Your task is to read the expenses XML file, parse it and save the expenses in the MongoDB database and in the SQL Server. Please think how your database schema / document model will support expenses.

Problem #6 – Vendors Total Report
----------------------------------
You are given a SQLite database holding the taxes for each product.
Write a program to read the MongoDB database of product reports, load the products into SQLite and generate a single Excel file called “Products-Total-Report.xlsx” holding the following information for the current month (e.g. July 2013):
* Vendor 
* Incomes
* Expenses
* Taxes
* Financial Result

Additional Requirements
-----------------------
* Your main program logic should be a C# application.
* Use non-commercial framework to read the ZIP file.
* MySQL should be accessed through OpenAccess ORM.
* SQL Server should be accessed through Entity Framework.
* MongoDB should be accessed through the Official MongoDB C# Driver.
* The Excel files should be accessed through ADO.NET (without ORM or third-party libraries).
* For the PDF export use a non-commercial third party framework.
* The XML files should be read / written through the standard .NET parsers (by your choice).
* The SQLite embedded database should be accesses though its Entity Framework provider.
