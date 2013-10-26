using System;
using System.Linq;

namespace _02.InsertModifyDeleteCustomers
{
    class DAO
    {
        public static void AddCustomer(string customerID, string companyName, string contactName = null, string contactTitle = null,
            string address = null, string city = null, string region = null, string postalCode = null, string country = null,
            string phone = null, string fax = null)
        {
            NorthwindEntities northwindDBContext = new NorthwindEntities();
            var customer = new Customer
            {
                CustomerID = customerID,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };

            using (northwindDBContext)
            {
                northwindDBContext.Customers.Add(customer);
                northwindDBContext.SaveChanges();
            }
        } 

        public static void ModifyCustomer(string customerID, string companyName, string contactName = null, string contactTitle = null,
            string address = null, string city = null, string region = null, string postalCode = null, string country = null,
            string phone = null, string fax = null)
        {
            NorthwindEntities northwindDBContext = new NorthwindEntities();
            using (northwindDBContext)
            {
                var customerToModify = northwindDBContext.Customers.FirstOrDefault(c => c.CustomerID == customerID);
                customerToModify.CompanyName = companyName;
                customerToModify.ContactName = contactName;
                customerToModify.ContactTitle = contactTitle;
                customerToModify.Address = address;
                customerToModify.City = city;
                customerToModify.Region = region;
                customerToModify.PostalCode = postalCode;
                customerToModify.Country = country;
                customerToModify.Phone = phone;
                customerToModify.Fax = fax;

                northwindDBContext.SaveChanges();
            }
        }

        public static void DeleteCustomer(string customerID)
        {
            NorthwindEntities northwindDBContext = new NorthwindEntities();
            using (northwindDBContext)
            {
                var customerToRemove = northwindDBContext.Customers.FirstOrDefault(c => c.CustomerID == customerID);
                northwindDBContext.Customers.Remove(customerToRemove);
                northwindDBContext.SaveChanges();
            }
        }

        public static void GetCustomers()
        {
            NorthwindEntities northwindDBContext = new NorthwindEntities();
            using (northwindDBContext)
            {
                var customers = northwindDBContext.Orders.Where(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada")
                                                    .Select(o => o.Customer);

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.ContactName);
                }

            }
        }

        public static void GetCustomersBySQLQuery()
        {
            NorthwindEntities northwindDBContext = new NorthwindEntities();

            string query = @"
            SELECT
	            *
            FROM Customers c
            INNER JOIN
	            Orders o
            ON o.CustomerID = c.CustomerID
            WHERE
	            YEAR(o.OrderDate) = 1997 
	            AND
	            o.ShipCountry = 'Canada'";

            using (northwindDBContext)
            {
                var customers = northwindDBContext.Database.SqlQuery<Customer>(query);

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }

        public static void GetOrdersByRegionAndTimePeriod(string region, DateTime startDate, DateTime endDate)
        {
            NorthwindEntities northwindDBContext = new NorthwindEntities();
            using (northwindDBContext)
            {
                var orders = northwindDBContext.Orders.Where(o => o.ShipRegion == region && o.OrderDate >= startDate && o.OrderDate <= endDate)
                                                             .Select(o => o);

                foreach (var order in orders)
                {
                    Console.WriteLine("Region: {0}\tOrderDate: {1}\t", order.ShipRegion, order.OrderDate);
                }
            }
        }
    }
}
