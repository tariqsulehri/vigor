using ERP.Core.Models.HR;
using ERP.Infrastructure.Repositories.HR;
using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR.ViewModels;
using ERP.Core.Models.Common;

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
        public ActionResult Index(int EmplId)
        {
            ViewBag.ID = EmplId;
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
            HR_LeaveRequestVM obj = new HR_LeaveRequestVM();
           
            if (EmplId > 0)
            {
                
               HrEmployee HrEmployee = new HrEmployeeRepository().FindById(EmplId);

                obj.EmployeeId = HrEmployee.Id;
                obj.EmployeeNo = HrEmployee.EmployeeID;
                obj.DeptName = HrEmployee.HrDepartment.Title;
                obj.Designation = HrEmployee.HrDesignation.Description;
                obj.Emp_Name = HrEmployee.FirstName;
                Company company = _db.Companies.FirstOrDefault();

                obj.companyID = company.Id;
                obj.CompanyKey = "-";
               
            }
           
            return View(obj);
        }
        // POST: HR/EmpIntimation/Create
        [HttpPost]
        public ActionResult Create(HR_LeaveRequestVM model)
        {
            try
            {
                HR_LeaveRequest obj = new HR_LeaveRequest()
                {
                    LeaveRequestMasterID = GetLeaveReqID(),
                    LeaveRequiredFrom=model.LeaveRequiredFrom,
                    LeaveRequestedTo=model.LeaveRequestedTo,
                    EmployeeId = model.EmployeeId,
                    EmployeeNo=model.EmployeeNo,
                    ApplicationType=model.ApplicationType,
                    companyID=model.companyID,
                    CompanyKey=model.CompanyKey,
                    Reason=model.Reason,
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

                ModelState.Remove("LeaveRequestMasterID");
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
            catch(Exception e)
            {
                return View(e);
            }
        }                                                                           

        // GET: HR/EmpIntimation/Edit/5
        public ActionResult Edit(string Id)
        {
            
            var data = _HR_LeaveRequestRepository.FindById(Id);
            //ViewBag.To = data.LeaveRequestedTo;
            //ViewBag.From = data.LeaveRequiredFrom;
            HR_LeaveRequestVM obj = new HR_LeaveRequestVM()
            {
                LeaveRequestMasterID = data.LeaveRequestMasterID,
                LeaveRequiredFrom = data.LeaveRequiredFrom,
                LeaveRequestedTo = data.LeaveRequestedTo,
                EmployeeId = data.EmployeeId,
                EmployeeNo = data.EmployeeNo,
                Emp_Name=data.HrEmployee.Title,
                DeptName=data.HrEmployee.HrDepartment.Title,
                Designation=data.HrEmployee.HrDesignation.Description,
                ApplicationType = data.ApplicationType,
                companyID = data.companyID,
                CompanyKey = data.CompanyKey,
                ApplicationDate = data.ApplicationDate,
                Userid_as_ApprovedBy = data.Userid_as_ApprovedBy,
                ApprovedOn = data.ApprovedOn,
                CreatedBy = data.CreatedBy,
                CreatedOn = data.CreatedOn,
                ModifiedBy = data.ModifiedBy,
                ModifiedOn = data.ModifiedOn,
                Reason=data.Reason,
                IsActive = false,
                IsApproved = false,
                IsPending = false

            };
            return View(obj);
        }

        // POST: HR/EmpIntimation/Edit/5
        [HttpPost]
        public ActionResult Edit(HR_LeaveRequestVM model)
        {
            
            try
            {
                HR_LeaveRequest obj = new HR_LeaveRequest()
                {
                    LeaveRequestMasterID = model.LeaveRequestMasterID,
                    LeaveRequiredFrom = model.LeaveRequiredFrom,
                    LeaveRequestedTo = model.LeaveRequestedTo,
                    EmployeeId = model.EmployeeId,
                    EmployeeNo = model.EmployeeNo,
                    ApplicationType = model.ApplicationType,
                    companyID = model.companyID,
                    CompanyKey = model.CompanyKey,
                    ApplicationDate = model.ApplicationDate,
                    Userid_as_ApprovedBy = 0,
                    ApprovedOn = model.ApprovedOn,
                    CreatedBy = model.CreatedBy,
                    CreatedOn = model.CreatedOn,
                    Reason=model.Reason,
                    ModifiedBy = 0,
                    ModifiedOn = DateTime.Now,
                    IsActive = false,
                    IsApproved = false,
                    IsPending = false

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
                        _HR_LeaveRequestRepository.Edit(obj);
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

        // GET: HR/EmpIntimation/Delete/5
        public ActionResult Delete(string id)
        {
            _HR_LeaveRequestRepository.Remove(id);
            return null;
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
        public ActionResult GetEmpIntimation(int empId)
        {
            var IntimationData = _HR_LeaveRequestRepository.GetAllHR_LeaveRequests().Where(x=>x.EmployeeId==empId).ToList();
            //var IntimationData = _db.HR_LeaveRequests.Where(x => x.EmployeeId == id);.Where(a => a.EmployeeId == EmplID)
            var collection = IntimationData.Select(x => new
            {
                Id = x.LeaveRequestMasterID,
                Employee = x.HrEmployee.Id,
                From=x.LeaveRequiredFrom.ToString(),
                To=x.LeaveRequestedTo.ToString(),
                Type=x.ApplicationType
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public string GetLeaveReqID()
        {
            int maxno = _db.HR_LeaveRequests.Count();
            maxno = maxno + 1;
            string SerialID = DateTime.Today.Year + maxno.ToString().PadLeft(4, '0');
            return SerialID;
        }
    }
}
