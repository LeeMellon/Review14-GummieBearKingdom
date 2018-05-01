using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review14.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Review14.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository ProductRepo;
        private IReviewRepository ReviewRepo;

        public HomeController(IProductRepository repo = null)
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
            var newProduct = new Product();
            var products = ProductRepo.Products.ToList();
            var sortedList = newProduct.GetFeatured(products);
            return View(sortedList);
        }

        public IActionResult About()
        {
           

            return View();
        }

        public IActionResult Contact()
        {
         

            return View();
        }


    }
}
