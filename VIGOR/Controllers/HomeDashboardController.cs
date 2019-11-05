using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Controllers
{[Authorize]
    public class HomeDashboardController : Controller
    {
        // GET: HomeDashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}