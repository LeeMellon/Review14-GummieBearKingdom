﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Review14.Models;
using System.Dynamic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review14.Controllers
{
    public class UserController : Controller
    {
        private GummyKingdomDbContext db = new GummyKingdomDbContext();

        // GET: /<controller>/
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
        
            var thisUser = db.Users.FirstOrDefault(user => user.UserId == id);
            dynamic myModel = new ExpandoObject();
            myModel.User = thisUser;
            myModel.Reviews = db.Reviews.Where(r => r.UserId == id);

            return View(myModel);
        }
    }
}
