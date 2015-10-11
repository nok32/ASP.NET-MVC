using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Data.Repositories;
using Twitter.Models;

namespace Twitter.Data.Data
{
    public class TwitterData : ITwitterData
    {
        private readonly IDictionary<Type, object> repositories;

        public TwitterData(TwitterEntity context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public TwitterEntity Context { get; private set; }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Tweet> Tweets
        {
            get { return this.GetRepository<Tweet>(); }
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var modelType = typeof (T);
            if (!this.repositories.ContainsKey(modelType))
            {
                var repositoryType = typeof (Repository<T>);
                this.repositories.Add(modelType, Activator.CreateInstance(repositoryType, this.Context));
            }

            return (IRepository<T>) this.repositories[modelType];
        }
    }
}
