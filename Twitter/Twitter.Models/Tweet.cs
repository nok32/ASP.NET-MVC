using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Tweet
    {
        public ICollection<User> usersShared;
        public ICollection<User> usersFavorites; 
        public Tweet()
        {
            this.usersShared=new HashSet<User>();
            this.usersFavorites=new HashSet<User>();
            this.PublishDate=DateTime.Now;
            this.isReported = false;
        }
        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(150)]
        [Required]
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public bool isReported { get; set; }
        [Required]
        public string URL { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public int? ParentTweetId { get; set; }
        public Tweet ParentTweet { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<User> UsersShared
        {
            get { return this.usersShared; }
            set { this.usersShared = value; }
        }

        public virtual ICollection<User> UsersFavorites
        {
            get { return this.usersFavorites; }
            set { this.usersFavorites = value; }
        } 

    }
}
