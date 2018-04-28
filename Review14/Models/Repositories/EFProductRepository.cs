using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Review14.Models;

namespace Review14.Models
{
    public class EFProductRepository : IProductRepository
    {
        GummyKingdomDbContext db;
        public EFProductRepository()
        {
            db = new GummyKingdomDbContext();
        }
        public EFProductRepository(GummyKingdomDbContext thisDb)
        {
            db = thisDb;
        }


        public IQueryable<Product> Products
        { get { return db.Products; } }


        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public Product Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        public void ClearAll()
        {
            db.Products.RemoveRange(db.Products);
            db.SaveChanges();
        }
    }
}
