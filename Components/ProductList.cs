using Microsoft.AspNetCore.Mvc;
using OfekCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfekCore.Components
{
    public class ProductList :  ViewComponent
     {
        private readonly OfekDBContext db;
        public ProductList( OfekDBContext context)
        {
            db = context;
        }
        public IViewComponentResult Invoke()
        {
            List<Product> productList =
                (from p in db.Products
                 select p).Distinct().OrderBy(f => f.FinanceInstitue).ThenBy(t => t.ProductType).ToList();
            return View( "ProductList", productList);
        }
    }
}
