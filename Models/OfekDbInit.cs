using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfekCore.Models
{
    public class OfekDbInit
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            try 
            {
                using (var db = new OfekDBContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<OfekDBContext>>()))
                {
                    if (db.Customers.Any())
                    {
                        return;   // DB has been created
                    }
                    //creating products:
                    List<string> lstProductIDs = new List<string>();
                    foreach (string strFinanceInstitue in new List<string>() { "פסגות", "אלטשולר שחם", "הלמן אלדובי" })
                    {
                        foreach (string strProductType in new List<string>() { "קרן השתלמות", "קופת גמל", "פוליסת חסכון" })
                        {
                            foreach (string strInvestType in new List<string>() { "מניות", "אג\"ח", "50% מניות" })
                            {
                                Product objProduct = new Product() { ProductID = Guid.NewGuid().ToString(), CreatedDate = DateTime.Now, FinanceInstitue = strFinanceInstitue, ProductType = strProductType, InvestType = strInvestType };
                                db.Products.Add(objProduct);

                                lstProductIDs.Add(objProduct.ProductID);
                            }
                        }
                        db.SaveChanges();
                        Customer objCustomer = null;
                        CustomerProduct objCustomerProduct = null;

                        objCustomer = new Customer() { CustomerID = Guid.NewGuid().ToString(), FirstName = "ישראל", LastName = "ישראלי", BirthDate = new DateTime(1986, 3, 1), City = "נתניה", Street = "האלון", HouseNumber = "44", PrivateEMail = "tsdfdsfest@gmail.com", CreatedDate = DateTime.Now };
                        db.Customers.Add(objCustomer);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[0], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "פעיל", Sum = 300000, AccountNumber = "12345"  };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[5], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "פעיל", Sum = 155000, AccountNumber = "56543" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[7], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "מוקפא", Sum = 250499, AccountNumber = "433434" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomer = new Customer() { CustomerID = Guid.NewGuid().ToString(), FirstName = "ישראלה", LastName = "ישראלי", BirthDate = new DateTime(1988, 2, 6), City = "נתניה", Street = "האלון", HouseNumber = "44", PrivateEMail = "tesdfsdfst@gmail.com", CreatedDate = DateTime.Now };
                        db.Customers.Add(objCustomer);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[3], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "פעיל", Sum = 230000, AccountNumber = "23232" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[6], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "פעיל", Sum = 60499, AccountNumber = "4545" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[8], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "מוקפא", Sum = 32456, AccountNumber = "787878" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomer = new Customer() { CustomerID = Guid.NewGuid().ToString(), FirstName = "שמריהו", LastName = "כהן", BirthDate = new DateTime(1975, 7, 8), City = "חיפה", Street = "הגליל", HouseNumber = "15", PrivateEMail = "tesdfdsfst@gmail.com", CreatedDate = DateTime.Now };
                        db.Customers.Add(objCustomer);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[1], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "פעיל", Sum = 265000, AccountNumber = "989898989" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[2], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "פעיל", Sum = 62399, AccountNumber = "343434" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[3], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "מוקפא", Sum = 37856, AccountNumber = "7347456" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomer = new Customer() { CustomerID = Guid.NewGuid().ToString(), FirstName = "מיאו", LastName = "כהן", BirthDate = new DateTime(1977, 4, 10), City = "באר שבע", Street = "הפרח", HouseNumber = "28", PrivateEMail = "tesadfsdfst@gmail.com", CreatedDate = DateTime.Now };
                        db.Customers.Add(objCustomer);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[7], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "פעיל", Sum = 450000, AccountNumber = "22222" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[8], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "פעיל", Sum = 46499, AccountNumber = "3333333" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        objCustomerProduct = new CustomerProduct() { CustomerProductID = Guid.NewGuid().ToString(), ProductID = lstProductIDs[0], CustomerID = objCustomer.CustomerID, CreatedDate = DateTime.Now, Status = "מוקפא", Sum = 12456, AccountNumber = "6666666" };
                        objCustomerProduct.product = (from p in db.Products where p.ProductID == objCustomerProduct.ProductID select p).First();
                        objCustomerProduct.customer = objCustomer;
                        db.CustomerProducts.Add(objCustomerProduct);

                        db.Customers.Add(objCustomer);

                        db.SaveChanges();

                    }
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
 
           
        }
    }
}
