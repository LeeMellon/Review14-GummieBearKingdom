using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Review14.Models;
using System.Dynamic;


namespace Review14.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository UserRepo;
        public UserController(IUserRepository repo = null)
        {
            if (repo == null)
            {
                this.UserRepo = new EFUserRepository();
            }
            else
            {
                this.UserRepo = repo;
            }
        }

        // GET: /<controller>/
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
        
            var thisUser = UserRepo.Users.FirstOrDefault(user => user.UserId == id);
            dynamic myModel = new ExpandoObject();
            myModel.User = thisUser;
            myModel.Reviews = UserRepo.Reviews.Where(r => r.UserId == id);

            return View(myModel);
        }
    }
}
