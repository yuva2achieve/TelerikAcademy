using System;
using System.Data.SqlClient;
using System.Linq;

namespace _04.AddNewProductToTable
{
    class Program
    {
        private const string ConnectionString = @"Server = HOME-LAPTOP;Database = Northwind;Integrated Security = true";
        
        static void Main(string[] args)
        {
            AddProduct(
                "ADO.NET Product",
                1,
                1,
                "10 boxes x 20 bags",
                21m,
                10,
                5,
                0,
                true);
        }

        public static void AddProduct(
            string productName,
            int? supplierID,
            int? categoryID,
            string quantityPerUnit,
            decimal? unitPrice,
            int? unitsInStock,
            int? unitsOnOrder,
            int? reorderLevel,
            bool discontinued)
        {
            string addProductCommand = @"
            INSERT INTO 
                Products
                    (
                        ProductName,
                        SupplierID,
                        CategoryID,
                        QuantityPerUnit,
                        UnitPrice,
                        UnitsInStock,
                        UnitsOnOrder,
                        ReorderLevel,
                        Discontinued
                    )
                Values
                    (
                        @productName,
                        @supplierID,
                        @categoryID,
                        @quantityPerUnit,
                        @unitPrice,
                        @unitsInStock,
                        @UnitsOnOrder,
                        @reorderLevel,
                        @discontinued
                    )";

            SqlConnection dbConnection = new SqlConnection(ConnectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand cmd = new SqlCommand(addProductCommand, dbConnection);
                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@discontinued", discontinued);

                SqlParameter supplierIDParam = new SqlParameter("@supplierID", supplierID);
                SqlParameter categoryIDParam = new SqlParameter("@categoryID", categoryID);
                SqlParameter quantityPerUnitParam = new SqlParameter("@quantityPerUnit", quantityPerUnit);
                SqlParameter unitPriceParam = new SqlParameter("@unitPrice", unitPrice);
                SqlParameter unitsInStockParam = new SqlParameter("@unitsInStock", unitsInStock);
                SqlParameter unitsOnOrderParam = new SqlParameter("@UnitsOnOrder", unitsOnOrder);
                SqlParameter reorderLevelParam = new SqlParameter("@reorderLevel", reorderLevel);
                
                if (supplierID == null)
                {
                    supplierIDParam.Value = DBNull.Value;
                }

                if (categoryIDParam == null)
                {
                    categoryIDParam.Value = DBNull.Value;
                }

                if (quantityPerUnitParam == null)
                {
                    quantityPerUnitParam.Value = DBNull.Value;
                }

                if (unitPriceParam == null)
                {
                    unitPriceParam.Value = DBNull.Value;
                }

                if (unitsInStockParam == null)
                {
                    unitsInStockParam.Value = DBNull.Value;
                }

                if (unitsOnOrderParam == null)
                {
                    unitsOnOrderParam.Value = DBNull.Value;
                }

                if (reorderLevelParam == null)
                {
                    reorderLevelParam.Value = DBNull.Value;
                }

                cmd.Parameters.Add(supplierIDParam);
                cmd.Parameters.Add(categoryIDParam);
                cmd.Parameters.Add(quantityPerUnitParam);
                cmd.Parameters.Add(unitPriceParam);
                cmd.Parameters.Add(unitsInStockParam);
                cmd.Parameters.Add(unitsOnOrderParam);
                cmd.Parameters.Add(reorderLevelParam);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
