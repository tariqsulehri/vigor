﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.HR;

namespace VIGOR.Areas.HR.Controllers
{
    public class EmpIncrementController : Controller
    {
        // GET: HR/EmpIncrement
        private HrEmployeeRepository _hrEmployeeRepository;

        public EmpIncrementController()
        {
            _hrEmployeeRepository=new HrEmployeeRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/EmpIncrement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/EmpIncrement/Create
        public ActionResult Create(int EmplId)
        {
            return View(_hrEmployeeRepository.FindById(EmplId));
        }

        // POST: HR/EmpIncrement/Create
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

        // GET: HR/EmpIncrement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/EmpIncrement/Edit/5
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

        // GET: HR/EmpIncrement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/EmpIncrement/Delete/5
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
