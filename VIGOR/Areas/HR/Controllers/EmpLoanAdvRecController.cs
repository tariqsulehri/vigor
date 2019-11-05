using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class EmpLoanAdvRecController : Controller
    {
        // GET: HR/EmpLoanAdvRec
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/EmpLoanAdvRec/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/EmpLoanAdvRec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HR/EmpLoanAdvRec/Create
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

        // GET: HR/EmpLoanAdvRec/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/EmpLoanAdvRec/Edit/5
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

        // GET: HR/EmpLoanAdvRec/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/EmpLoanAdvRec/Delete/5
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
