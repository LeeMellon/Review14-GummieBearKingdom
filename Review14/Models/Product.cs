using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Review14.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string ImgAlt { get; set; }
        public int Rating { get; set; } = 0;
        public virtual ICollection<Review> ProductReviews { get; set; }

        private GummyKingdomDbContext db = new GummyKingdomDbContext();

        public int SetRating()
        {
            var ratingList = new List<int>{ } ;
            foreach(Review r in db.Reviews.Where(p => p.ProductId == this.ProductId))
            {
              ratingList.Add(r.Rating);
            }
            var rNums = ratingList.Count();
            this.Rating = ((ratingList.Sum()) / rNums);
            return this.Rating;
        }
    }
}
