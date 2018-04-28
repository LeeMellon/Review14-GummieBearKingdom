using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Review14.Models
{     
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Review> Reviews { get; }
        User Save(User user);
        User Edit(User user);
        void Remove(User user);
        void ClearAll();
    }
}
