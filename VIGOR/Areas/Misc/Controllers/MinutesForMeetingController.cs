using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Misc.Controllers
{
    public class MinutesForMeetingController : Controller
    {
        // GET: Misc/MinutesForMeeting
        public ActionResult Index()
        {
            return View();
        }

        // GET: Misc/MinutesForMeeting/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Misc/MinutesForMeeting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Misc/MinutesForMeeting/Create
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

        // GET: Misc/MinutesForMeeting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Misc/MinutesForMeeting/Edit/5
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

        // GET: Misc/MinutesForMeeting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Misc/MinutesForMeeting/Delete/5
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
