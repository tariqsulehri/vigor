using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Admin;

namespace VIGOR.Areas.Indent.Controllers
{
    public class ExpInspKnittedController : Controller
    {
        // GET: Indent/ExpInspKnitted
        public ActionResult Index()
        {
            ViewBag.FromDate = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.Todate = LoggedinUser.CurrentFiscalYear.EndDate;
            return View();
        }

        // GET: Indent/ExpInspKnitted/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/ExpInspKnitted/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/ExpInspKnitted/Create
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

        // GET: Indent/ExpInspKnitted/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indent/ExpInspKnitted/Edit/5
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

        // GET: Indent/ExpInspKnitted/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/ExpInspKnitted/Delete/5
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
