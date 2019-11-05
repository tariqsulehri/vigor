using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class EmpRevisionController : Controller
    {
        // GET: HR/EmpRevision
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/EmpRevision/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/EmpRevision/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HR/EmpRevision/Create
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

        // GET: HR/EmpRevision/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/EmpRevision/Edit/5
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

        // GET: HR/EmpRevision/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/EmpRevision/Delete/5
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
