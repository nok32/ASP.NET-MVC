using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Twitter.Data.Migrations;
using Twitter.Models;

namespace Twitter.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TwitterEntity : IdentityDbContext<User>
    {
        // Your context has been configured to use a 'TwitterEntity' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Twitter.Data.TwitterEntity' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TwitterEntity' 
        // connection string in the application configuration file.
        public TwitterEntity()
            : base("name=TwitterEntity")
        {
            Database.SetInitializer(
                     new MigrateDatabaseToLatestVersion<TwitterEntity, Configuration>());
        }
        public static TwitterEntity Create()
        {
            return new TwitterEntity();
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany(f => f.Followers)
                .WithMany(f1 => f1.Followings)
                .Map(m =>
                {
                    m.ToTable("FollowerWithFollowings");
                    m.MapLeftKey("FollowerId");
                    m.MapRightKey("FollowingId");
                });
            modelBuilder.Entity<User>()
                .HasMany(t => t.SharedTweets)
                .WithMany(s => s.UsersShared)
                .Map(m =>
                {
                    m.ToTable("SharedTweets");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("TweetId");
                });

            modelBuilder.Entity<User>()
                .HasMany(t => t.FavoritesTweets)
                .WithMany(s=> s.UsersFavorites)
                .Map(m =>
                {
                    m.ToTable("FavoritesTweets");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("TweetId");
                });

             modelBuilder.Entity<Tweet>()
                 .HasOptional(e => e.ParentTweet)
                 .WithMany()
                 .HasForeignKey(m => m.ParentTweetId);
            base.OnModelCreating(modelBuilder);
        }
    }

    
}