using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaitEstate.View.Controllers.System
{
    [RoutePrefix("Dashboard/System/Users")]
    public class UserController : Controller
    {
        // GET: User
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}