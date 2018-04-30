﻿using System;
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
        public string Rating { get; set; }
        public virtual ICollection<Review> ProductReviews { get; set; }

        private GummyKingdomDbContext db = new GummyKingdomDbContext();

        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                return this.ProductId.Equals(newProduct.ProductId);
            }
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }

        public string SetRating(List<Review> reviews)
        {
            var ratingList = new List<int>{ } ;
            foreach(Review r in reviews.Where(p => p.ProductId == this.ProductId))
            {
              ratingList.Add(r.Rating);
            }
            var rNums = ratingList.Count();
            if (rNums > 5)
            {
            this.Rating = ((ratingList.Sum()) / rNums).ToString();
            return this.Rating.ToString();
            }
            else
            {
                this.Rating = $"This product has {rNums.ToString()} user reviews";
                return this.Rating;
            }
        }

        public IEnumerable<Product> GetFeatured(List<Review> reviews)
        {
            var products = db.Products.ToList();
            var productsList = new List<Product> { };
                foreach (Product p in products) { p.SetRating(reviews); productsList.Add(p); }
            var SortedList = productsList.OrderByDescending(product => product.Rating).ToList().Take(4);
            
                return SortedList;
        }
}
}
