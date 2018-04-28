using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Review14.Models;

namespace Review14.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        GummyKingdomDbContext db;
        public EFReviewRepository()
        {
            db = new GummyKingdomDbContext();
        }
        public EFReviewRepository(GummyKingdomDbContext thisDb)
        {
            db = thisDb;
        }


        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }


        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Remove(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public void ClearAll()
        {
            db.Reviews.RemoveRange(db.Reviews);
            db.SaveChanges();
        }
    }
}
