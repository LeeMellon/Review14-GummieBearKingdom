using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Review14.Models;
using System.Dynamic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review14.Controllers
{
    public class ProductController : Controller
    {
        private GummyKingdomDbContext db = new GummyKingdomDbContext();
        public IActionResult Index()
        {
            var products = db.Products.ToList();
            var productsList = new List<Product> { };
            foreach (Product p in products) { p.SetRating(); productsList.Add(p); }

            return View(productsList);
        }

        // GET: /<controller>/
        public IActionResult Details(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
            dynamic myModel = new ExpandoObject();
            myModel.Product = thisProduct;
            myModel.Reviews = db.Reviews.Where(r => r.ProductId == id).Include(r => r.User);
            return View(myModel);
        }

        public ActionResult Delete(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
            db.Products.Remove(thisProduct);
            db.SaveChanges();
            return RedirectToAction("ProductIndex", "Admin");
        }
    }
}
