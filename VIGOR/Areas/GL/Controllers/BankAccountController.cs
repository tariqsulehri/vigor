using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.GL.Controllers
{
    public class BankAccountController : Controller
    {
        // GET: GL/BankAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: GL/BankAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GL/BankAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GL/BankAccount/Create
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

        // GET: GL/BankAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GL/BankAccount/Edit/5
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

        // GET: GL/BankAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GL/BankAccount/Delete/5
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
