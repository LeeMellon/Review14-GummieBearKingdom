﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review14.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review14.Controllers
{
    public class ProductController : Controller
    {
        private GummyKingdomDbContext db = new GummyKingdomDbContext();
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: /<controller>/
        public IActionResult Details()
        {
            return View();
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
