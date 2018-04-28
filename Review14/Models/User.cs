using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Review14.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserNameFirst { get; set; }
        public string UserNameLast { get; set; }
        public string ProfileName { get; set;  }
        public string UserEmail { get; set; }
        public string UserImg { get; set; }
        public string UserImgAlt { get; set; }
        public virtual ICollection<Review> UserReviews { get; set; }

        public override bool Equals(System.Object otherUser)
        {
            if (!(otherUser is User))
            {
                return false;
            }
            else
            {
                User newUser = (User)otherUser;
                return this.UserId.Equals(newUser.UserId);
            }
        }

        public override int GetHashCode()
        {
            return this.UserId.GetHashCode();
        }

    }
}
