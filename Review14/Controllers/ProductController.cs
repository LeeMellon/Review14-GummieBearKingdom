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
        private IProductRepository ProductRepo;
        private IReviewRepository ReviewRepo;

        public ProductController(IProductRepository repo = null)
        {
            if (repo == null)
            {
                this.ProductRepo = new EFProductRepository();
            }
            else
            {
                this.ProductRepo = repo;
            }
        }
        public IActionResult Index()
        {
            var products = ProductRepo.Products.ToList();
            var reviews = ReviewRepo.Reviews.ToList();
            var productsList = new List<Product> { };
            foreach (Product p in products) { p.SetRating(reviews); productsList.Add(p); }

            return View(productsList);
        }

        // GET: /<controller>/
        public IActionResult Details(int id)
        {
            var thisProduct = ProductRepo.Products.FirstOrDefault(product => product.ProductId == id);
            dynamic myModel = new ExpandoObject();
            myModel.Product = thisProduct;
            myModel.Reviews = ProductRepo.Reviews.Where(r => r.ProductId == id).Include(r => r.User);
            return View(myModel);
        }

        public ActionResult Delete(int id)
        {
            var thisProduct = ProductRepo.Products.FirstOrDefault(product => product.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProduct = ProductRepo.Products.FirstOrDefault(product => product.ProductId == id);
            ProductRepo.Remove(thisProduct);
            return RedirectToAction("ProductIndex", "Admin");
        }
    }
}
