﻿using ERP.Infrastructure.Repositories.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class EmployeeController : Controller
    {
        HrEmployeeRepository _hrEmployeeRepository;
        public EmployeeController()
        {
            _hrEmployeeRepository = new HrEmployeeRepository();
        }
        // GET: General/Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/Employee/Create
        [HttpPost]
        public ActionResult Create(HrEmployee model)
        {
            model.CreatedBy = 0;
            model.ModifiedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedOn = DateTime.Now;
            try
            {
                //if (_hrEmployeeRepository.IsDuplicate(model))
                //{
                //    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                //    return View(model);
                //}
                if (ModelState.IsValid)
                {
                    _hrEmployeeRepository.Add(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View(model);
            }
        }

        // GET: General/Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_hrEmployeeRepository.FindById(id));
        }

        // POST: General/Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(HrEmployee model)
        {
            model.ModifiedOn = DateTime.Now;
            try
            {
                //if (_hrEmployeeRepository.IsDuplicate(model))
                //{
                //    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                //    return View(model);
                //}
                if (ModelState.IsValid)
                {
                    _hrEmployeeRepository.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View(model);
            }
        }

        // GET: General/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            _hrEmployeeRepository.Remove(id);
            return null;
        }

        // POST: General/Employee/Delete/5
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
        [HttpGet]
        public ActionResult GetEmployee()
        {
            var Year = _hrEmployeeRepository.GetAllEmployees().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintEmployee()
        {
            return View(_hrEmployeeRepository.GetAllEmployees());
        }
    }
}
