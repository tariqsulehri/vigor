using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.HR;
using ERP.Core.Models.HR.ViewModels;

namespace VIGOR.Areas.HR.Controllers
{
    public class EmpCriticalIncidentController : Controller
    {
        private HR_CINCRRepository _HR_CINCRRepository;
        HrEmployeeRepository _hrEmployeeRepository;
        ErpDbContext _dbContext;
        public EmpCriticalIncidentController()
        {
            _hrEmployeeRepository = new HrEmployeeRepository();
            _HR_CINCRRepository =  new HR_CINCRRepository();
            _dbContext=new ErpDbContext();
        }
        // GET: HR/EmpCriticalIncident
        public ActionResult Index(int EmplId)
        {
            ViewBag.ID = EmplId;
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
            HR_CINCR_VM obj = new HR_CINCR_VM();
            if (EmplId > 0)
            {

                HrEmployee HrEmployee = new HrEmployeeRepository().FindById(EmplId);
                obj.EmployeeId = HrEmployee.Id;
                obj.EmpName = HrEmployee.FirstName;
                obj.Designation = HrEmployee.HrDesignation.Description;
                obj.EmployeeNo = HrEmployee.EmployeeID;
                obj.TypeOfIncident = "CI";
                HrDepartment dept = new HrDepartment();
                obj.Dep_id = dept.id;
                obj.EmpDept = dept.Title;

            }

            return View(obj);
        }

        // POST: HR/EmpCriticalIncident/Create
        [HttpPost]
        public ActionResult Create(HR_CINCR_VM model)
        {
            try
            {
                HR_CINCR obj = new HR_CINCR()
                {
                    id= GetCINCRID(),
                    EmployeeId=model.EmployeeId,
                    EmployeeNo=model.EmployeeNo,
                    EmpDept=model.EmpDept,
                    ReportedBy=model.ReportedBy,
                    ReportedDate=model.ReportedDate,
                    Incident=model.Incident,
                    TypeOfIncident=model.TypeOfIncident,
                    CreatedBy = 0,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = 0,
                    ModifiedOn = DateTime.Now

                };
                ModelState.Remove("id");

                if (_HR_CINCRRepository.IsDuplicate(obj))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _HR_CINCRRepository.Add(obj);
                        return null;
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: HR/EmpCriticalIncident/Edit/5
        public ActionResult Edit(string id)
        {
            var data = _HR_CINCRRepository.FindById(id);
            HR_CINCR_VM obj = new HR_CINCR_VM()
            {
                id = data.id,
                EmployeeId = data.EmployeeId,
                EmployeeNo = data.EmployeeNo,
                EmpDept = data.EmpDept,
                Designation=data.HrEmployee.HrDesignation.Description,
                EmpName=data.HrEmployee.Title,
                ReportedBy = data.ReportedBy,
                ReportedDate = data.ReportedDate,
                Incident = data.Incident,
                TypeOfIncident = data.TypeOfIncident,
                CreatedBy = data.CreatedBy,
                CreatedOn = data.CreatedOn,
                ModifiedBy = data.ModifiedBy,
                ModifiedOn = data.ModifiedOn
            };

            return View(obj);
        }

        // POST: HR/EmpCriticalIncident/Edit/5
        [HttpPost]
        public ActionResult Edit(HR_CINCR_VM model)
        {
            try
            {
                HR_CINCR obj = new HR_CINCR()
                {
                    id = model.id,
                    EmployeeId = model.EmployeeId,
                    EmployeeNo = model.EmployeeNo,
                    EmpDept = model.EmpDept,
                    ReportedBy = model.ReportedBy,
                    ReportedDate = model.ReportedDate,
                    Incident = model.Incident,
                    TypeOfIncident = model.TypeOfIncident,
                    CreatedBy = 0,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = 0,
                    ModifiedOn = DateTime.Now

                };


                if (_HR_CINCRRepository.IsDuplicate(obj))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _HR_CINCRRepository.Edit(obj);
                        return null;
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: HR/EmpCriticalIncident/Delete/5
        public ActionResult Delete(string id)
        {
            _HR_CINCRRepository.Remove(id);
            return null;
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
        public ActionResult GetEmpCINCR(int empId)
        {
            var CINCRData = _HR_CINCRRepository.GetAllHR_CINCR().Where(x=>x.EmployeeId==empId && x.TypeOfIncident=="CI").ToList();
            //var IntimationData = _db.HR_LeaveRequests.Where(x => x.EmployeeId == id);
            var collection = CINCRData.Select(x => new
            {
                Id = x.id,
                Employee = x.HrEmployee.Id,
                EmpName=x.ReportedBy,
                Type=x.TypeOfIncident

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public string GetCINCRID()
        {
            int maxno = _dbContext.HR_CINCR.Count();
            maxno = maxno + 1;
            string SerialID = DateTime.Today.Year + maxno.ToString().PadLeft(4, '0');
            return SerialID;
        }
    }
}
