using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Misc.Controllers
{
    public class ManageCPAsController : Controller
    {
        // GET: Misc/ManageCPAs
        public ActionResult Index()
        {
            return View();
        }

        // GET: Misc/ManageCPAs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Misc/ManageCPAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Misc/ManageCPAs/Create
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

        // GET: Misc/ManageCPAs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Misc/ManageCPAs/Edit/5
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

        // GET: Misc/ManageCPAs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Misc/ManageCPAs/Delete/5
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
