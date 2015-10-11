using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twitter.Models
{
    public class User : IdentityUser
    {
        private ICollection<Tweet> sharedTweets;
        private ICollection<Tweet> ownedTweets;
        private ICollection<User> followers;
        private ICollection<User> followings;
        private ICollection<Tweet> favoritesTweets;

        public User()
        {
            this.ownedTweets = new HashSet<Tweet>();
            this.sharedTweets = new HashSet<Tweet>();
            this.followers = new HashSet<User>();
            this.favoritesTweets = new HashSet<Tweet>();

        }

        public virtual ICollection<Tweet> OwnedTweets
        {
            get { return this.ownedTweets; }
            set { this.ownedTweets = value; }
        }

        public virtual ICollection<Tweet> SharedTweets
        {
            get { return this.sharedTweets; }
            set { this.sharedTweets = value; }
        }

        public virtual ICollection<Tweet> FavoritesTweets
        {
            get { return this.favoritesTweets; }
            set { this.favoritesTweets = value; }
        }

        public virtual ICollection<User> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<User> Followings
        {
            get { return this.followings; }
            set { this.followings = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
