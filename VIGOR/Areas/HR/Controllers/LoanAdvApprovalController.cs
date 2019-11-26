using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class LoanAdvApprovalController : Controller
    {
        private HR_LoanAdvanceApplicationRepository _HR_LoanAdvanceApplicationRepository;
        HrEmployeeRepository _hrEmployeeRepository;
        ErpDbContext _db;
        public LoanAdvApprovalController()
        {
            _hrEmployeeRepository = new HrEmployeeRepository();
            _HR_LoanAdvanceApplicationRepository = new HR_LoanAdvanceApplicationRepository();
            _db = new ErpDbContext();
        }
        // GET: HR/LoanAdvApproval
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/LoanAdvApproval/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/LoanAdvApproval/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HR/LoanAdvApproval/Create
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

        // GET: HR/LoanAdvApproval/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/LoanAdvApproval/Edit/5
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

        // GET: HR/LoanAdvApproval/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/LoanAdvApproval/Delete/5
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
        public ActionResult GetLoanApprovals()
        {

            var LoanAppData = _HR_LoanAdvanceApplicationRepository.GetAllHR_LoanAdvanceApplication().Where(x => x.IsPending == "t").ToList();
            //var IntimationData = _db.HR_LeaveRequests.Where(x => x.EmployeeId == id);
            var collection = LoanAppData.Select(x => new
            {
                Id = x.LoanAdvanceID,
                Date = x.ApplicationDate.ToString(),
                Name=x.HrEmployee.FirstName,
                ReqAmount = x.RequiredAmount,
                ReqInstallment = x.LoanInstalment,
                ApproveAmount = x.ApprovedAmount,
                ApproveLoan=x.ApprovedLoanInstalment

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
    }
}
