using ERP.Core.Models.HR;
using ERP.Infrastructure.Repositories.HR;
using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class EmpIntimationController : Controller
    {
        private HR_LeaveRequestRepository _HR_LeaveRequestRepository;
        HrEmployeeRepository _hrEmployeeRepository;
        ErpDbContext _db;
        public EmpIntimationController()
        {
            _hrEmployeeRepository = new HrEmployeeRepository();
            _HR_LeaveRequestRepository = new HR_LeaveRequestRepository();
            _db = new ErpDbContext();
        }
        // GET: HR/EmpIntimation
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/EmpIntimation/Details/5
        public ActionResult Details()
        {
            
            return View();
        }

        // GET: HR/EmpIntimation/Create
        public ActionResult Create(int EmplId)
        {
            //EmplId = 222;
            HR_LeaveRequest obj = new HR_LeaveRequest();
            if (EmplId > 0)
            {
                
                obj.HrEmployee = new HrEmployeeRepository().FindById(EmplId);
                obj.EmployeeNo = obj.HrEmployee.EmployeeID;
                obj.companyID = obj.HrEmployee.companyID;
                obj.CompanyKey = obj.HrEmployee.CompanyKey;
            }
           
            return View(obj);
        }
        // POST: HR/EmpIntimation/Create
        [HttpPost]
        public ActionResult Create(HR_LeaveRequest model)
        {
            try
            {
                HR_LeaveRequest obj = new HR_LeaveRequest()
                {
                    LeaveRequestMasterID = model.LeaveRequestMasterID,
                    LeaveRequiredFrom=model.LeaveRequiredFrom,
                    LeaveRequestedTo=model.LeaveRequestedTo,
                    EmployeeId = model.EmployeeId,
                    EmployeeNo=model.EmployeeNo,
                    ApplicationType=model.ApplicationType,
                    companyID=model.companyID,
                    CompanyKey=model.CompanyKey,
                    ApplicationDate = DateTime.Now,
                    Userid_as_ApprovedBy = 0,
                    ApprovedOn = DateTime.Now,
                    CreatedBy = 0,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = 0,
                    ModifiedOn = DateTime.Now,
                    IsActive=false,
                    IsApproved=false,
                    IsPending=false

                };
                
                
                if (_HR_LeaveRequestRepository.IsDuplicate(obj))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _HR_LeaveRequestRepository.Add(obj);
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

        // GET: HR/EmpIntimation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/EmpIntimation/Edit/5
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

        // GET: HR/EmpIntimation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/EmpIntimation/Delete/5
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
        public ActionResult GetEmpIntimation(int id)
        {
            var IntimationData = _HR_LeaveRequestRepository.GetAllHr_LeaveRequest().ToList();
            //var IntimationData = _db.HR_LeaveRequests.Where(x => x.EmployeeId == id);
            var collection = IntimationData.Select(x => new
            {
                Id = x.LeaveRequestMasterID,
                Employee = x.HrEmployee.Title,
                From=x.LeaveRequiredFrom,
                To=x.LeaveRequestedTo,
                Type=x.ApplicationType
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
    }
}
