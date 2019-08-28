using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnoopsAPI.Controllers
{
    public class AllController : Controller
    {
        // GET: All
        public ActionResult Index()
        {
            return View();
        }
    }
}