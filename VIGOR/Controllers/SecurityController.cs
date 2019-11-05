using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult UserRegistration()
        {
            return View();
        }
        public ActionResult RoleDefine()
        {
            return View();
        }
        public ActionResult AssignUserRole()
        {
            return View();
        }
        public ActionResult AssignIndividualPermission()
        {
            return View();
        }
    }
}