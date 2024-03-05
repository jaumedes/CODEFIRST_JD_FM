using CODEFIRST_JD_FM.MODEL;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CODEFIRST_JD_FM.DAO
{
    public class DAOManager: IDAOManager
    {
        private CompanyDBContext dbContext = null;
        public DAOManager(CompanyDBContext context)
        {
            this.dbContext = context;
        }

        //Mètodes per a importar les dades dels fitxers CSV a la base de dades
        public bool ImportCustomers()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/CUSTOMERS.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        int customerNumber = Convert.ToInt32(camps[0]);
                        string customerName = camps[1];
                        string contactLastName = camps[2];
                        string contactFirstName = camps[3];
                        string phone = camps[4];
                        string addressLine1 = camps[5];
                        string addressLine2 = camps[6];
                        string city = camps[7];
                        string state = camps[8];
                        string postalCode = camps[9];
                        string country = camps[10];
                        int? salesRepEmployeeNumber = (camps[11]).Equals("NULL") ? null : Convert.ToInt32(camps[11]);
                        double creditLimit = Convert.ToDouble(camps[12]);

                        var newCustomer = new Customers(customerNumber, customerName, contactLastName, contactLastName, phone, addressLine1, addressLine2,
                                                        city, state, postalCode, country, salesRepEmployeeNumber, creditLimit);

                        dbContext.Customers.Add(newCustomer);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar clients: " + ex.Message);
            }
            return done;
        }

        public bool ImportOffices()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/OFFICES.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        string officeCode = camps[0];
                        string city = camps[1];
                        string phone = camps[2];
                        string addressLine1 = camps[3];
                        string addressLine2 = camps[4];
                        string state = camps[5];
                        string country = camps[6];
                        string postalCode = camps[7];
                        string territory = camps[8];

                        var newOffice = new Offices(officeCode, city, phone, addressLine1, addressLine2,
                                                    state, country, postalCode, territory);

                        dbContext.Offices.Add(newOffice);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar oficines: " + ex.Message);
            }
            return done;
        }

        public bool ImportEmployees()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/EMPLOYEES.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        int employeeNumber = Convert.ToInt32(camps[0]);
                        string lastName = camps[1];
                        string firstName = camps[2];
                        string extension = camps[3];
                        string email = camps[4];
                        string officeCode = camps[5];
                        int? reportsTo = (camps[6]).Equals("NULL") ? null : Convert.ToInt32(camps[6]);
                        string jobTitle = camps[7];

                        var newEmployee = new Employees(employeeNumber, lastName, firstName, extension, email, officeCode, reportsTo, jobTitle);

                        dbContext.Employees.Add(newEmployee);
                        dbContext.SaveChanges();
                    }

                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar empleats: " + ex.Message);
            }
            return done;
        }

        public bool ImportPayments()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/PAYMENTS.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        int customerNumber = Convert.ToInt32(camps[0]);
                        string checkNumber = camps[1];
                        DateTime paymentDate;
                        DateTime.TryParse(camps[2], out paymentDate);
                        double amount = Convert.ToDouble(camps[3].Replace(".", ","));

                        var newPayment = new Payments(customerNumber, checkNumber, paymentDate, amount);

                        dbContext.Payments.Add(newPayment);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar payments: " + ex.Message);
            }
            return done;
        }

        public bool ImportOrders()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/ORDERS.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        int orderNumber = Convert.ToInt32(camps[0]);
                        DateTime orderDate;
                        DateTime.TryParse(camps[1], out orderDate);
                        DateTime requiredDate;
                        DateTime.TryParse(camps[2], out requiredDate);
                        DateTime shippedDate;
                        DateTime.TryParse(camps[3], out shippedDate);
                        string status = camps[4];
                        string? comments = ((camps[5]).Equals("NULL") ? null : camps[5]);
                        int? customerNumber = Convert.ToInt32(camps[6]);

                        var newOrder = new Orders(orderNumber, orderDate, requiredDate, shippedDate, status, comments, customerNumber);

                        dbContext.Orders.Add(newOrder);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar orders: " + ex.Message);
            }
            return done;
        }

        public bool ImportOrderDetails()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/ORDERDETAILS.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        int orderNumber = Convert.ToInt32(camps[0]);
                        string productCode = camps[1];
                        int quantityOrdered = Convert.ToInt32(camps[2]);
                        double priceEach = Convert.ToDouble(camps[3]);
                        int orderLineNumber = Convert.ToInt32(camps[4]);

                        var newOrderDetails = new OrderDetails(orderNumber, productCode, quantityOrdered, priceEach, orderLineNumber);

                        dbContext.OrderDetails.Add(newOrderDetails);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar orderDetails: " + ex.Message);
            }
            return done;
        }

        public bool ImportProductLines()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/PRODUCTLINES.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        string productLineName = camps[0];
                        string textDescription = camps[1];
                        string? htmlDescription = ((camps[2]).Equals("NULL") ? null : camps[2]);
                        byte[]? image = (camps[3]).Equals("NULL") ? null : Convert.FromBase64String(camps[3]);

                        var newProductLine = new ProductLines(productLineName, textDescription, htmlDescription, image);

                        dbContext.ProductLines.Add(newProductLine);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar productLines: " + ex.Message);
            }
            return done;
        }

        public bool ImportProducts()
        {
            bool done = false;
            try
            {
                using (TextFieldParser parser = new TextFieldParser("./DATA/PRODUCTS.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] camps = parser.ReadFields();

                    while (!parser.EndOfData)
                    {
                        camps = parser.ReadFields();

                        string productCode = camps[0];
                        string productName = camps[1];
                        string productLine = camps[2];
                        string productScale = camps[3];
                        string productVendor = camps[4];
                        string productDescription = camps[5];
                        int quantityStock = Convert.ToInt32(camps[6]);
                        double buyPrice = Convert.ToDouble(camps[7]);
                        double MSRP = Convert.ToDouble(camps[8]);

                        var newProduct = new Products(productCode, productName, productLine, productScale,
                                    productVendor, productDescription, quantityStock, buyPrice, MSRP);

                        dbContext.Products.Add(newProduct);
                        dbContext.SaveChanges();
                    }
                    done = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en importar products: " + ex.Message);
            }
            return done;
        }

        //Mètodes per a les consultes
        public List<Object> ListCustomers()
        {
            var customers = dbContext.Customers
                .Join(dbContext.Employees,
                    customer => customer.salesRepEmployeeNumber,
                    employee => employee.employeeNumber,
                    (customer, employee) => new
                    {
                        customerNumber = customer.customerNumber,
                        customerName = customer.customerName,
                        contactLastName = customer.contactLastName,
                        ContactFirstName = customer.ContactFirstName,
                        phone = customer.phone,
                        addressLine1 = customer.addressLine1,
                        addressLine2 = customer.addressLine2,
                        city = customer.city,
                        state = customer.state,
                        postalCode = customer.postalCode,
                        country = customer.country,
                        creditLimit = customer.creditLimit,
                        salesRepEmployee = employee.lastName + " " + employee.firstName
                    })
                .ToList<Object>(); // Convertimos la lista a tipo Object
            
            return customers;
        }

        public List<Object> ListCustomersPayments()
        {
            var query = dbContext.Payments
                    .Join(dbContext.Customers,
                        p => p.customerNumber,
                        c => c.customerNumber,
                        (p, c) => new
                        {
                            CustomerName = c.customerName,
                            ContactLastName = c.contactLastName,
                            Amount = p.amount,
                            PaymentDate = p.paymentDate
                        })
                    .Where(customerPayment => customerPayment.PaymentDate >= DateTime.ParseExact("2003/10/01", "yyyy/MM/dd", CultureInfo.InvariantCulture)
                                            && customerPayment.PaymentDate <= DateTime.ParseExact("2003/12/31", "yyyy/MM/dd", CultureInfo.InvariantCulture))
                    .GroupBy(customerPayment => new { customerPayment.CustomerName, customerPayment.ContactLastName })
                    .Select(group => new
                    {
                        CustomerName = group.Key.CustomerName,
                        ContactLastName = group.Key.ContactLastName,
                        TotalAmount = Math.Round( group.Sum(entry => entry.Amount), 2)
                    })
                    .ToList<Object>();

            return query;
        }

        public List<Object> ListEmployeesFranceOffice()
        {
            var query = dbContext.Employees
                .Join(dbContext.Offices,
                    e => e.officeCode,
                    o => o.officeCode,
                    (e, o) => new
                    {
                        LastName = e.lastName,
                        FirstName = e.firstName,
                        Email = e.email,
                        Country = o.country
                    })
                .Where(employeeOffice => employeeOffice.Country == "France")
                .Select(employeeOffice => new
                {
                    LastName = employeeOffice.LastName,
                    FirstName = employeeOffice.FirstName,
                    Email = employeeOffice.Email
                })
                .ToList<Object>();

            return query;
        }

        public List<Object> ListCustomersBought1969FordFalcon()
        {
            var query = dbContext.Customers
                .Join(dbContext.Orders,
                    c => c.customerNumber,
                    o => o.customerNumber,
                    (c, o) => new { Customer = c, Order = o })
                .Join(dbContext.OrderDetails,
                    o => o.Order.orderNumber,
                    od => od.orderNumber,
                    (o, od) => new { Customer = o.Customer, Order = o.Order, OrderDetail = od })
                .Join(dbContext.Products,
                    od => od.OrderDetail.productCode,
                    p => p.productCode,
                    (od, p) => new { Customer = od.Customer, Product = p })
                .Where(x => x.Product.productName == "1969 Ford Falcon")
                .Select(x => new
                {
                    CustomerNumber = x.Customer.customerNumber,
                    CustomerName = x.Customer.customerName
                })
                .Distinct()
                .ToList<Object>();

            return query;
        }

        public List<Object> ListCustomersCredit()
        {
            var query = dbContext.Customers
                .Where(c => c.creditLimit > 3000000)
                .Select(c => new
                {
                    CustomerName = c.customerName,
                    Country = c.country
                })
                .OrderBy(c => c.CustomerName)
                .ToList<Object>();

            return query;
        }

        public List<Object> ListEmployeesSoldHelicopters()
        {
            var query = dbContext.Employees
                .Join(dbContext.Customers,
                    e => e.employeeNumber,
                    c => c.salesRepEmployeeNumber,
                    (e, c) => new { Employee = e, Customer = c })
                .Join(dbContext.Orders,
                    c => c.Customer.customerNumber,
                    o => o.customerNumber,
                    (c, o) => new { Employee = c.Employee, Order = o })
                .Join(dbContext.OrderDetails,
                    o => o.Order.orderNumber,
                    od => od.orderNumber,
                    (o, od) => new { Employee = o.Employee, OrderDetail = od })
                .Join(dbContext.Products,
                    od => od.OrderDetail.productCode,
                    p => p.productCode,
                    (od, p) => new { Employee = od.Employee, Product = p })
                .Where(x => x.Product.productName.Contains("helicopter"))
                .GroupBy(x => new { x.Employee.employeeNumber, x.Employee.lastName, x.Employee.firstName })
                .Select(group => new
                {
                    EmployeeNumber = group.Key.employeeNumber,
                    LastName = group.Key.lastName,
                    FirstName = group.Key.firstName,
                    TotalHelicoptersSold = group.Count()
                })
                .OrderByDescending(x => x.TotalHelicoptersSold)
                .ToList<Object>();

            return query;
        }

        public List<Object> ListCustomersByEmployeeNumber(int employeeNumber)
        {
            var query = dbContext.Customers
                .Join(dbContext.Employees,
                    c => c.salesRepEmployeeNumber,
                    e => e.employeeNumber,
                    (c, e) => new { Customer = c, Employee = e })
                .Where(customersEmployee => customersEmployee.Employee.employeeNumber == employeeNumber)
                .Select(customersEmployee => new
                {
                    CustomerNumber = customersEmployee.Customer.customerNumber,
                    CustomerName = customersEmployee.Customer.customerName
                })
                .ToList<Object>();

            return query;
        }

        public List<Object> ListMostSoldProductLine()
        {
            var query = dbContext.Products
                .Join(dbContext.ProductLines,
                    p => p.productLine,
                    pl => pl.productLineName,
                    (p, pl) => new { Product = p, ProductLine = pl })
                .Join(dbContext.OrderDetails,
                    p => p.Product.productCode,
                    od => od.productCode,
                    (p, od) => new { ProductLine = p.ProductLine, QuantityOrdered = od.quantityOrdered })
                .GroupBy(x => x.ProductLine.productLineName)
                .Select(group => new
                {
                    ProductLineName = group.Key,
                    TotalQuantitySold = group.Sum(x => x.QuantityOrdered)
                })
                .OrderByDescending(x => x.TotalQuantitySold)
                .ToList<Object>();

            return query;
        }

        public List<Object> ListProductsByProductLine(string productLineName)
        {
            var query = dbContext.Products
                .Where(p => p.productLine == productLineName)
                .OrderBy(p => p.productName)
                .Select(p => new
                {
                    ProductName = p.productName
                })
                .ToList<Object>();

            return query;
        }

        public List<Object> ListTotalSalesByOffice()
        {
            var query = dbContext.Offices
                .Join(dbContext.Employees,
                    o => o.officeCode,
                    e => e.officeCode,
                    (o, e) => new { Office = o, Employee = e })
                .Join(dbContext.Customers,
                    e => e.Employee.employeeNumber,
                    c => c.salesRepEmployeeNumber,
                    (e, c) => new { Office = e.Office, Customer = c })
                .Join(dbContext.Orders,
                    c => c.Customer.customerNumber,
                    o => o.customerNumber,
                    (c, o) => new { Office = c.Office, Order = o })
                .Join(dbContext.OrderDetails,
                    o => o.Order.orderNumber,
                    od => od.orderNumber,
                    (o, od) => new { Office = o.Office, TotalSales = od.quantityOrdered * od.priceEach })
                .GroupBy(x => new { x.Office.officeCode, x.Office.city })
                .Select(group => new
                {
                    OfficeCode = group.Key.officeCode,
                    City = group.Key.city,
                    TotalSales = Math.Round(group.Sum(x => x.TotalSales), 2)
                })
                .OrderByDescending(x => x.TotalSales)
                .ToList<Object>();

            return query;
        }

        
        public List<Object> ListSellsPerProduct()
        {
            var query = dbContext.Products
                .Join(dbContext.OrderDetails,
                    product => product.productCode,
                    orderDetail => orderDetail.productCode,
                    (product, orderDetail) => new { Product = product, OrderDetail = orderDetail })
                .GroupBy(x => x.Product.productName)
                .Select(group => new
                {
                    ProductName = group.Key,
                    TotalQuantity = group.Sum(x => x.OrderDetail.quantityOrdered),
                    TotalSales = Math.Round(group.Sum(x => x.OrderDetail.quantityOrdered * x.OrderDetail.priceEach),2)
                })
                .ToList<Object>();

            return query;
        }


        public List<Object> ListInProcessORInPendingOrders()
        {
            var query = dbContext.Customers
                .Join(dbContext.Orders,
                    c => c.customerNumber,
                    o => o.customerNumber,
                    (c, o) => new { Customer = c, Order = o })
                .Join(dbContext.OrderDetails,
                    customerOrders => customerOrders.Order.orderNumber,
                    od => od.orderNumber,
                    (customerOrders, od) => new { customerOrders = customerOrders, OrderDetail = od })
                .Where(x => x.customerOrders.Order.status == "In Process" || x.customerOrders.Order.status == "Pending")
                .GroupBy(x => new { x.customerOrders.Customer.customerName, x.customerOrders.Order.orderNumber, x.customerOrders.Order.orderDate })
                .Select(group => new
                {
                    CustomerName = group.Key.customerName,
                    OrderNumber = group.Key.orderNumber,
                    OrderDate = group.Key.orderDate,
                    Amount = group.Sum(x => x.OrderDetail.quantityOrdered * x.OrderDetail.priceEach)
                })
                .ToList<Object>();

            return query;
        }

    }
}
