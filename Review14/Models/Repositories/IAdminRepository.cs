using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Review14.Models
{
    public interface IAdminRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Product> Products { get; }
        IQueryable<Review> Reviews { get; }
        User SaveUser(User user);
        User EditUser(User user);
        void RemoveUser(User user);
        Product SaveProduct(Product product);
        Product EditProduct(Product product);
        void RemoveProduct(Product product);
        Review SaveReview(Review review);
        Review EditReview(Review review);
        void RemoveReview(Review review);
        void ClearAllUsers();
        void ClearAllProducts();
        void ClearAllReviews();

    }
}
