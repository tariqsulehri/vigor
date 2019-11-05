using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Indent/Supplier
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/Supplier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/Supplier/Create
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

        // GET: Indent/Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indent/Supplier/Edit/5
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

        // GET: Indent/Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/Supplier/Delete/5
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
