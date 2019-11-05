using ERP.Core.Models.HR;
using ERP.Infrastructure.Repositories.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class EmpNonConfirmityController : Controller
    {
        private HR_CINCRRepository _HR_CINCRRepository;
        HrEmployeeRepository _hrEmployeeRepository;
        public EmpNonConfirmityController()
        {
            _hrEmployeeRepository = new HrEmployeeRepository();
            _HR_CINCRRepository = new HR_CINCRRepository();
        }
        // GET: HR/EmpNonConfirmity
        public ActionResult Index(int EmplId)
        {
            ViewBag.ID = EmplId;
            return View();
        }

        // GET: HR/EmpNonConfirmity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/EmpNonConfirmity/Create
        public ActionResult Create(int EmplId)
        {
            HR_CINCR obj = new HR_CINCR();
            if (EmplId > 0)
            {
                HrEmployee employee = new HrEmployeeRepository().FindById(Convert.ToInt32(EmplId));
                if (employee != null)
                {
                    obj.EmpDept = employee.HrDepartment.Title;
                    obj.EmployeeNo = employee.FirstName;

                }

            }
            //var result = _hrEmployeeRepository.FindById(id);
            //ViewBag.EmpTitle = result.Title;

            return View(obj);
        }

        // POST: HR/EmpNonConfirmity/Create
        [HttpPost]
        public ActionResult Create(HR_CINCR model)
        {
            try
            {
                model.ReportedDate = DateTime.Now;
                model.CreatedBy = 0;
                model.CreatedOn = DateTime.Now;
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                model.TypeOfIncident = "NC";
                if (_HR_CINCRRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _HR_CINCRRepository.Add(model);
                        return null;
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            catch(Exception e)
            {
                return View(e);
            }
        }

        // GET: HR/EmpNonConfirmity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/EmpNonConfirmity/Edit/5
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

        // GET: HR/EmpNonConfirmity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/EmpNonConfirmity/Delete/5
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
