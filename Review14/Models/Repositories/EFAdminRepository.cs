using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Review14.Models;

namespace Review14.Models
{
    public class EFAdminRepository : IAdminRepository
    {
        GummyKingdomDbContext db;
        public EFAdminRepository()
        {
            db = new GummyKingdomDbContext();
        }
        public EFAdminRepository(GummyKingdomDbContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Product> Products
        { get { return db.Products; } }


        public Product EditProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void RemoveProduct(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product SaveProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        public void ClearAllProducts()
        {
            db.Products.RemoveRange(db.Products);
            db.SaveChanges();
        }
        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public Review EditReview(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void RemoveReview(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public Review SaveReview(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public void ClearAllReviews()
        {
            db.Reviews.RemoveRange(db.Reviews);
            db.SaveChanges();
        }

        public IQueryable<User> Users
        { get { return db.Users; } }

        public User EditUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return user;
        }

        public void RemoveUser(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User SaveUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public void ClearAllUsers()
        {
            db.Users.RemoveRange(db.Users);
            db.SaveChanges();
        }

        
    }
}