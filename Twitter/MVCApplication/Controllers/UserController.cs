using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;

namespace MVCApplication.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {

            return this.View();
        }
    }
}