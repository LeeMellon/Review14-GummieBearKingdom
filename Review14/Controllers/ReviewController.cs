using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Review14.Models;


namespace Review14.Controllers
{

    public class ReviewController : Controller
    {
        private IReviewRepository ReviewRepo;

        public ReviewController(IReviewRepository repo = null)
        {
            if (repo == null)
            {
                this.ReviewRepo = new EFReviewRepository();
            }
            else
            {
                this.ReviewRepo = repo;
            }
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var reviewsList = ReviewRepo.Reviews.Include(r => r.User).Include(r => r.Product);
         
            return View(reviewsList);
        }

        public ActionResult Delete(int id)
        {
            var thisReview = ReviewRepo.Reviews.FirstOrDefault(review => review.ReviewId == id);

            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisReview = ReviewRepo.Reviews.FirstOrDefault(review => review.ReviewId == id);
            ReviewRepo.Remove(thisReview);
 
            return RedirectToAction("ReviewIndex", "Admin");
        }
    }
}
