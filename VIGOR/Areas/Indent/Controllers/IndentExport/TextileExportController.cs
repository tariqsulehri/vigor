using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers.IndentExport
{
    public class TextileExportController : Controller
    {
        // GET: Indent/TextileExport
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/TextileExport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/TextileExport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/TextileExport/Create
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

        // GET: Indent/TextileExport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indent/TextileExport/Edit/5
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

        // GET: Indent/TextileExport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/TextileExport/Delete/5
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
