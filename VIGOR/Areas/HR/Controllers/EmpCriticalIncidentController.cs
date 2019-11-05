using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;
using ERP.Infrastructure.Repositories.HR;

namespace VIGOR.Areas.HR.Controllers
{
    public class EmpCriticalIncidentController : Controller
    {
        private HR_CINCRRepository _HR_CINCRRepository;
        HrEmployeeRepository _hrEmployeeRepository;
        public EmpCriticalIncidentController()
        {
            _hrEmployeeRepository = new HrEmployeeRepository();
            _HR_CINCRRepository =  new HR_CINCRRepository();
        }
        // GET: HR/EmpCriticalIncident
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/EmpCriticalIncident/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/EmpCriticalIncident/Create
        public ActionResult Create(int EmplId)
        {

            HR_CINCR obj = new HR_CINCR();
            
            if (EmplId > 0)
            {
                obj.HrEmployee = _hrEmployeeRepository.FindById(EmplId);
                if(obj.HrEmployee != null)
                {
                    obj.EmpDept = obj.HrEmployee.HrDepartment.DeptDescription;
                    obj.EmployeeNo = obj.HrEmployee.EmployeeID;
                    
                }

            }
            
            return View(obj);
        }

        // POST: HR/EmpCriticalIncident/Create
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
                model.TypeOfIncident = "CI";
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
            catch
            {
                return View();
            }
        }

        // GET: HR/EmpCriticalIncident/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/EmpCriticalIncident/Edit/5
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

        // GET: HR/EmpCriticalIncident/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/EmpCriticalIncident/Delete/5
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
