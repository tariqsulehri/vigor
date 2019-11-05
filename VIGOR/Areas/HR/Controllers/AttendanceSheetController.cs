using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class AttendanceSheetController : Controller
    {
        // GET: General/AttendanceSheet
        public ActionResult Index()
        {
            return View();
        }
        //Attendance Time In & Time Out Data Update
        public ActionResult TimeInOutUpdate()
        {
            return View();
        }
        // GET: General/AttendanceSheet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/AttendanceSheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/AttendanceSheet/Create
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

        // GET: General/AttendanceSheet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: General/AttendanceSheet/Edit/5
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

        // GET: General/AttendanceSheet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: General/AttendanceSheet/Delete/5
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
