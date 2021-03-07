using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfekCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace OfekCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OfekDBContext db;
        private const string  STATUS_NEW= "פעיל";
        public HomeController(ILogger<HomeController> logger, OfekDBContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        [HttpGet]
        public PartialViewResult GetAddCustomerProductPartial()
        {
            List<Product> productList =
                (from p in db.Products
                 select p).ToList();
            return PartialView("AddCustomerProductPartial", productList);
        }      [HttpGet]
        public IActionResult GetCustomerProducts(string id)
        {
            try
            {
                Customer customer = (from c in db.Customers
                                     where c.CustomerID == id
                                     select c).FirstOrDefault(); 
                List<CustomerProduct> customerProductList = 
                    (from cp in db.CustomerProducts.Include(p => p.product).Include(c => c.customer)
                            where cp.CustomerID == id
                            select cp).ToList();
                var objects = new { Customer = customer, CustomerProducts = customerProductList };
                return Ok( JsonSerializer.Serialize(objects));

            }
            catch (Exception ex)
            {
                //TODO
                string msg = ex.Message;
                return BadRequest(ex);
            }
            
        }
 
        [HttpGet]
        public IActionResult AddCustomerProduct(string id)
        {
 //           string productId = HttpContext.Request.Query["productid"];
            Customer customer = (from c in db.Customers
                                 where c.CustomerID== id
                                 select c).FirstOrDefault();
            ViewBag.customer = customer;
            List<Product> productList =
                (from p in db.Products
                 select p).ToList();
            return View("AddCustomerProduct", productList);
        }

        [HttpPost]
        public IActionResult PostSaveCustomerProduct([FromBody] CustomerProduct customerProduct)
        {
            Customer customer = null;
            Product product = null;
            try 
            {
                bool b = ModelState.IsValid;
                if (ModelState.IsValid)
                {
                    customer = (from c in db.Customers
                                where c.CustomerID == customerProduct.CustomerID
                                select c).FirstOrDefault();
                    if (customer == null)
                    {
                        ModelState.AddModelError(ValidationResult.CustomerNotFound.ToString(), ValidationResult.CustomerNotFound.GetDisplayName());
                    }
                }

                if (ModelState.IsValid)
                {
                    product = (from p in db.Products
                                         where p.ProductID == customerProduct.ProductID
                                         select p).FirstOrDefault();
                    if (product == null)
                    {
                        ModelState.AddModelError(ValidationResult.ProductNotFound.ToString(), ValidationResult.ProductNotFound.GetDisplayName());
                    }
                }
                if (ModelState.IsValid)
                {
                    customerProduct.CustomerProductID = Guid.NewGuid().ToString();
                    customerProduct.Status = STATUS_NEW;
                    customerProduct.CreatedDate = DateTime.Now;
                    customerProduct.customer = customer;
                    customerProduct.product = product;
                    if (ModelState.IsValid)
                    {
                        db.CustomerProducts.Add(customerProduct);
                        db.SaveChanges();
                    }
                }
                var objects = new { CustomerProductNew = customerProduct, ValidationResult = ModelState.Values };
                return Ok(JsonSerializer.Serialize(objects));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
 
        //SingleOrDefault

        public IActionResult Privacy()
        {
            return View();
        }
 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
