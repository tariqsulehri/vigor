using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class GroupController : Controller
    {
        // GET: General/Group
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/Group/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/Group/Create
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

        // GET: General/Group/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: General/Group/Edit/5
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

        // GET: General/Group/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: General/Group/Delete/5
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
