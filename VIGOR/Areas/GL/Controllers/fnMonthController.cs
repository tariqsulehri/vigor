using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ERP.Infrastructure.Repositories.FinRepository;

namespace VIGOR.Areas.GL.Controllers
{
    public class fnMonthController : Controller
    {
        FinFescalYearDetailRepository detailMonth;
        public fnMonthController()
        {
            detailMonth = new FinFescalYearDetailRepository();
        }
        // GET: GL/fnMonth
        public ActionResult Index()
        {
            return View();
        }

        // GET: GL/fnMonth/Details/5

        [HttpGet]
        public ActionResult Details(int? Id)
        {
            var Month = detailMonth.GetAllFescalYearDetails((int)Id);
            var collection = Month.Select(x => new
            {
                Id = x.Id,
                Title = x.Title,
                StartDate = x.StartDate.ToString("dd/MM/yyyy"),
                EndDate = x.EndDate.ToString("dd/MM/yyyy"),
                Active = x.Active == true ? "Active" : "InActive"

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }

        // GET: GL/fnMonth/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GL/fnMonth/Create
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

        // GET: GL/fnMonth/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GL/fnMonth/Edit/5
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

        // GET: GL/fnMonth/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GL/fnMonth/Delete/5
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
