using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class DegreeController : Controller
    {
        // GET: General/Degree
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/Degree/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/Degree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/Degree/Create
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

        // GET: General/Degree/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: General/Degree/Edit/5
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

        // GET: General/Degree/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: General/Degree/Delete/5
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
