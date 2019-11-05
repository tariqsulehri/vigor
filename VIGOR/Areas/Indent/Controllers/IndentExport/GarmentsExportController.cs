using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers.IndentExport
{
    public class GarmentsExportController : Controller
    {
        // GET: Indent/GarmentsExport
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/GarmentsExport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/GarmentsExport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/GarmentsExport/Create
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

        // GET: Indent/GarmentsExport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indent/GarmentsExport/Edit/5
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

        // GET: Indent/GarmentsExport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/GarmentsExport/Delete/5
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
