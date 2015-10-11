using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Data.Repositories;
using Twitter.Models;

namespace Twitter.Data.Data
{
    public interface ITwitterData
    {
        IRepository<User> Users { get; }
        IRepository<Tweet> Tweets { get; }
        int SaveChanges();
    }
}
