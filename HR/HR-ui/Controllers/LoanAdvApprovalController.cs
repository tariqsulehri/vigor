using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class LoanAdvApprovalController : Controller
    {
        // GET: HR/LoanAdvApproval
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/LoanAdvApproval/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/LoanAdvApproval/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HR/LoanAdvApproval/Create
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

        // GET: HR/LoanAdvApproval/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/LoanAdvApproval/Edit/5
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

        // GET: HR/LoanAdvApproval/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/LoanAdvApproval/Delete/5
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
