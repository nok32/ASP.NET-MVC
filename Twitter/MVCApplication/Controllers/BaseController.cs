using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Data.Data;

namespace MVCApplication.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(ITwitterData data)
        {
            this.Data = data;
        }

        public BaseController()
            : this(new TwitterData(new TwitterEntity()))
        {
        }

        protected ITwitterData Data { get; set; }
    }
}
