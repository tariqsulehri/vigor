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
    public class EmpLoanAdvApplicationController : Controller
    {
        private HR_LoanAdvanceApplicationRepository _HR_LoanAdvanceApplicationRepository;
        HrEmployeeRepository _hrEmployeeRepository;
        ErpDbContext _db;
        public EmpLoanAdvApplicationController()
        {
            _hrEmployeeRepository = new HrEmployeeRepository();
            _HR_LoanAdvanceApplicationRepository = new HR_LoanAdvanceApplicationRepository();
            _db = new ErpDbContext();
        }
        // GET: HR/EmpLoanAdvApplication
        public ActionResult Index(int EmplId)
        {
            ViewBag.ID = EmplId;
            return View();
        }

        // GET: HR/EmpLoanAdvApplication/Details/5
        public ActionResult Details()
        {
            return View();
        }
        // GET: HR/EmpLoanAdvApplication/DetailApprove/5
        public ActionResult DetailApprove(string id)
        {
            var data = _HR_LoanAdvanceApplicationRepository.FindById(id);
            LoanAdvanceApp_VM obj = new LoanAdvanceApp_VM()
            {
                LoanAdvanceID = data.LoanAdvanceID,
                ApplicationDate = data.ApplicationDate,
                EmployeeId = data.EmployeeId,
                EmployeeNo = data.EmployeeNo,
                Emp_Name = data.HrEmployee.Title,
                DeptName = data.HrEmployee.HrDepartment.Title,
                Designation = data.HrEmployee.HrDesignation.Description,
                companyID = data.companyID,
                CompanyKey = data.CompanyKey,
                Reason = data.Reason,
                Type = data.Type,
                RequiredAmount = data.RequiredAmount,
                LoanInstalment = data.LoanInstalment,
                ApprovedAmount = data.ApprovedAmount,
                ApprovedLoanInstalment = data.ApprovedLoanInstalment,
                isActive = data.isActive,
                UserId_as_CreatedBy = data.UserId_as_CreatedBy,
                CreatedOn = data.CreatedOn,
                Userid_as_ModifiedBy = data.Userid_as_ModifiedBy,
                ModifiedOn = data.ModifiedOn,
                UserId_as_ApprovedBy = data.UserId_as_ApprovedBy,
                ApprovedOn = data.ApprovedOn,
                IsPending = data.IsPending,
                IsApproved = data.IsApproved,
                IsPosted = data.IsPosted,
                PostedOn = data.PostedOn,
                UserId_as_PostedBy = data.UserId_as_PostedBy,
                oldAppId = data.oldAppId,
                Status = ""
            };
            return View(obj);
        }

        // POST: HR/EmpLoanAdvApplication/DetailApprove/5
        [HttpPost]
        public ActionResult DetailApprove(LoanAdvanceApp_VM loanAdvanceApp_VM)
        {
            try
            {
                if (loanAdvanceApp_VM.Status== "Approve")
                {
                    loanAdvanceApp_VM.IsPending = "f";
                    loanAdvanceApp_VM.IsApproved = "t";
                    loanAdvanceApp_VM.IsPosted = "t";
                }
                if (loanAdvanceApp_VM.Status == "UnApprove")
                {
                    loanAdvanceApp_VM.IsPending = "f";
                    loanAdvanceApp_VM.IsApproved = "f";
                    loanAdvanceApp_VM.IsPosted = "f";
                }
                HR_LoanAdvanceApplication obj = new HR_LoanAdvanceApplication()
                {
                    LoanAdvanceID = loanAdvanceApp_VM.LoanAdvanceID,
                    ApplicationDate = loanAdvanceApp_VM.ApplicationDate,
                    EmployeeId = loanAdvanceApp_VM.EmployeeId,
                    EmployeeNo = loanAdvanceApp_VM.EmployeeNo,
                    companyID = loanAdvanceApp_VM.companyID,
                    CompanyKey = loanAdvanceApp_VM.CompanyKey,
                    Reason = loanAdvanceApp_VM.Reason,
                    Type = loanAdvanceApp_VM.Type,
                    RequiredAmount = loanAdvanceApp_VM.RequiredAmount,
                    LoanInstalment = loanAdvanceApp_VM.LoanInstalment,
                    ApprovedAmount = loanAdvanceApp_VM.ApprovedAmount,
                    ApprovedLoanInstalment = loanAdvanceApp_VM.ApprovedLoanInstalment,
                    isActive = loanAdvanceApp_VM.isActive,
                    UserId_as_CreatedBy = loanAdvanceApp_VM.UserId_as_CreatedBy,
                    CreatedOn = loanAdvanceApp_VM.CreatedOn,
                    Userid_as_ModifiedBy = loanAdvanceApp_VM.Userid_as_ModifiedBy,
                    ModifiedOn = DateTime.Now,
                    UserId_as_ApprovedBy = loanAdvanceApp_VM.UserId_as_ApprovedBy,
                    ApprovedOn = loanAdvanceApp_VM.ApprovedOn,
                    IsPending = loanAdvanceApp_VM.IsPending,
                    IsApproved = loanAdvanceApp_VM.IsApproved,
                    IsPosted = loanAdvanceApp_VM.IsPosted,
                    PostedOn = loanAdvanceApp_VM.PostedOn,
                    UserId_as_PostedBy = loanAdvanceApp_VM.UserId_as_PostedBy,
                    oldAppId = loanAdvanceApp_VM.oldAppId
                };
                

                if (_HR_LoanAdvanceApplicationRepository.IsDuplicate(obj))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(loanAdvanceApp_VM);
                }
                else
                {
                    ModelState.Remove("IsPending");
                    ModelState.Remove("IsApproved");
                    ModelState.Remove("IsPosted");
                    if (ModelState.IsValid)
                    {
                        _HR_LoanAdvanceApplicationRepository.Edit(obj);
                        return null;
                    }
                    else
                    {
                        return View(loanAdvanceApp_VM);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
        // GET: HR/EmpLoanAdvApplication/Create
        public ActionResult Create(int EmplId)
        {
            LoanAdvanceApp_VM obj = new LoanAdvanceApp_VM();
            if(EmplId>0)
            {
                HrEmployee HrEmployee = new HrEmployeeRepository().FindById(EmplId);
                obj.EmployeeId = HrEmployee.Id;
                obj.EmployeeNo = HrEmployee.EmployeeID;
                obj.Emp_Name = HrEmployee.FirstName;
                obj.Designation = HrEmployee.HrDesignation.Description;
                obj.DeptName = HrEmployee.HrDepartment.Title;

                Company company = _db.Companies.FirstOrDefault();
                obj.companyID = company.Id;
                obj.CompanyKey = "-";
            }
            return View(obj);
        }

        // POST: HR/EmpLoanAdvApplication/Create
        [HttpPost]
        public ActionResult Create(LoanAdvanceApp_VM model)
        {
            try
            {
                if (model.Type=="A")
                {
                    model.LoanInstalment = 0;
                }
                HR_LoanAdvanceApplication obj = new HR_LoanAdvanceApplication()
                {
                    LoanAdvanceID = GetLoanAdvID(),
                    ApplicationDate = model.ApplicationDate,
                    EmployeeId = model.EmployeeId,
                    EmployeeNo = model.EmployeeNo,
                    companyID = model.companyID,
                    CompanyKey = model.CompanyKey,
                    Reason = model.Reason,
                    Type = model.Type,
                    RequiredAmount = model.RequiredAmount,
                    LoanInstalment = model.LoanInstalment,
                    ApprovedAmount = model.ApprovedAmount,
                    ApprovedLoanInstalment = model.ApprovedLoanInstalment,
                    isActive = "f",
                    UserId_as_CreatedBy = "0",
                    CreatedOn = DateTime.Now,
                    Userid_as_ModifiedBy = "0",
                    ModifiedOn = DateTime.Now,
                    UserId_as_ApprovedBy = "0",
                    ApprovedOn = DateTime.Now,
                    IsPending = "t",
                    IsApproved = "f",
                    IsPosted = "f",
                    PostedOn = DateTime.Now,
                    UserId_as_PostedBy = "0",
                    oldAppId = 1
                };
                ModelState.Remove("LoanAdvanceID");

                if (_HR_LoanAdvanceApplicationRepository.IsDuplicate(obj))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(model);
                }
                else
                {
                    ModelState.Remove("IsPending");
                    ModelState.Remove("IsApproved");
                    ModelState.Remove("IsPosted");
                    if (ModelState.IsValid)
                    {
                        _HR_LoanAdvanceApplicationRepository.Add(obj);
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

        // GET: HR/EmpLoanAdvApplication/Edit/5
        public ActionResult Edit(string id)
        {
            var data = _HR_LoanAdvanceApplicationRepository.FindById(id);
            LoanAdvanceApp_VM obj = new LoanAdvanceApp_VM()
            {
                LoanAdvanceID = data.LoanAdvanceID,
                ApplicationDate = data.ApplicationDate,
                EmployeeId = data.EmployeeId,
                EmployeeNo = data.EmployeeNo,
                Emp_Name = data.HrEmployee.Title,
                DeptName = data.HrEmployee.HrDepartment.Title,
                Designation = data.HrEmployee.HrDesignation.Description,
                companyID = data.companyID,
                CompanyKey = data.CompanyKey,
                Reason = data.Reason,
                Type = data.Type,
                RequiredAmount = data.RequiredAmount,
                LoanInstalment = data.LoanInstalment,
                ApprovedAmount = data.ApprovedAmount,
                ApprovedLoanInstalment = data.ApprovedLoanInstalment,
                isActive = data.isActive,
                UserId_as_CreatedBy = data.UserId_as_CreatedBy,
                CreatedOn = data.CreatedOn,
                Userid_as_ModifiedBy = data.Userid_as_ModifiedBy,
                ModifiedOn = data.ModifiedOn,
                UserId_as_ApprovedBy = data.UserId_as_ApprovedBy,
                ApprovedOn = data.ApprovedOn,
                IsPending = data.IsPending,
                IsApproved = data.IsApproved,
                IsPosted = data.IsPosted,
                PostedOn = data.PostedOn,
                UserId_as_PostedBy = data.UserId_as_PostedBy,
                oldAppId = data.oldAppId
            };
            return View(obj);
        }

        // POST: HR/EmpLoanAdvApplication/Edit/5
        [HttpPost]
        public ActionResult Edit(LoanAdvanceApp_VM data)
        {
            try
            {
                if (data.Type == "A")
                {
                    data.LoanInstalment = 0;
                }
                HR_LoanAdvanceApplication obj = new HR_LoanAdvanceApplication()
                {
                    LoanAdvanceID = data.LoanAdvanceID,
                    ApplicationDate = data.ApplicationDate,
                    EmployeeId = data.EmployeeId,
                    EmployeeNo = data.EmployeeNo,
                    companyID = data.companyID,
                    CompanyKey = data.CompanyKey,
                    Reason = data.Reason,
                    Type = data.Type,
                    RequiredAmount = data.RequiredAmount,
                    LoanInstalment = data.LoanInstalment,
                    ApprovedAmount = data.ApprovedAmount,
                    ApprovedLoanInstalment = data.ApprovedLoanInstalment,
                    isActive = data.isActive,
                    UserId_as_CreatedBy = data.UserId_as_CreatedBy,
                    CreatedOn = data.CreatedOn,
                    Userid_as_ModifiedBy = data.Userid_as_ModifiedBy,
                    ModifiedOn = DateTime.Now,
                    UserId_as_ApprovedBy = data.UserId_as_ApprovedBy,
                    ApprovedOn = data.ApprovedOn,
                    IsPending = data.IsPending,
                    IsApproved = data.IsApproved,
                    IsPosted = data.IsPosted,
                    PostedOn = data.PostedOn,
                    UserId_as_PostedBy = data.UserId_as_PostedBy,
                    oldAppId = data.oldAppId
                };


                if (_HR_LoanAdvanceApplicationRepository.IsDuplicate(obj))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(data);
                }
                else
                {
                    ModelState.Remove("IsPending");
                    ModelState.Remove("IsApproved");
                    ModelState.Remove("IsPosted");
                    if (ModelState.IsValid)
                    {
                        _HR_LoanAdvanceApplicationRepository.Edit(obj);
                        return null;
                    }
                    else
                    {
                        return View(data);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        // GET: HR/EmpLoanAdvApplication/Delete/5
        public ActionResult Delete(string id)
        {
            _HR_LoanAdvanceApplicationRepository.Remove(id);
            return null;
        }

        // POST: HR/EmpLoanAdvApplication/Delete/5
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
        public ActionResult GetLApplication( int empId)
        {
         
            var LoanAppData = _HR_LoanAdvanceApplicationRepository.GetAllHR_LoanAdvanceApplication().Where(x=> x.EmployeeId==empId).ToList();
            //var IntimationData = _db.HR_LeaveRequests.Where(x => x.EmployeeId == id);
            var collection = LoanAppData.Select(x => new
            {
                Id = x.LoanAdvanceID,
                Date = x.ApplicationDate.ToString(),
                type = x.Type,
                Amount = x.RequiredAmount,
                Instalment=x.LoanInstalment

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLoanApprovals()
        {

            var LoanAppData = _HR_LoanAdvanceApplicationRepository.GetAllHR_LoanAdvanceApplication().Where(x => x.IsPending == "t").ToList();
            //var IntimationData = _db.HR_LeaveRequests.Where(x => x.EmployeeId == id);
            var collection = LoanAppData.Select(x => new
            {
                Id = x.LoanAdvanceID,
                Date = x.ApplicationDate.ToString(),
                Name = x.HrEmployee.FirstName,
                ReqAmount = x.RequiredAmount,
                ReqInstallment = x.LoanInstalment,
                ApproveAmount = x.ApprovedAmount,
                ApproveLoan = x.ApprovedLoanInstalment

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public string GetLoanAdvID()
        {
            int maxno = _db.HR_LoanAdvanceApplication.Count();
            maxno = maxno + 1;
            string SerialID = DateTime.Today.Year + maxno.ToString().PadLeft(4, '0');
            return SerialID;
        }
    }
}
