using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Misc.Controllers
{
    public class TaskForAdminController : Controller
    {
        // GET: Misc/TaskForAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Misc/TaskForAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Misc/TaskForAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Misc/TaskForAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Misc/TaskForAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Misc/TaskForAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Misc/TaskForAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Misc/TaskForAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
