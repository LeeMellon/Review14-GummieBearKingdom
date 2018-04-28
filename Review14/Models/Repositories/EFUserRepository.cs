using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Review14.Models;

namespace Review14.Models
{
    public class EFUserRepository : IUserRepository
    {
        GummyKingdomDbContext db;
        public EFUserRepository()
        {
            db = new GummyKingdomDbContext();
        }
        public EFUserRepository(GummyKingdomDbContext thisDb)
        {
            db = thisDb;
        }


        public IQueryable<User> User
        { get { return db.Users; } }

        public IQueryable<User> Users => throw new NotImplementedException();

        public IQueryable<Review> Reviews => throw new NotImplementedException();

        public User Edit(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return user;
        }

        public void Remove(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User Save(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public void ClearAll()
        {
            db.Users.RemoveRange(db.Users);
            db.SaveChanges();
        }
    }
}
