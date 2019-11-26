using ERP.Core.Models.HR;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class EmpTransferController : Controller
    {
        private HrEmployeeRepository _hrEmployeeRepository;
        private HR_HistoryRepository _hrHistoryRepository;
        private HR_EmployeeAllowancesRepository _hrEmployeeAllowancesRepository;
        private HR_HistoryDetailsRepository _hrHistoryDetailsRepository;
        private ErpDbContext _dbContext;
        public EmpTransferController()
        {
            _dbContext = new ErpDbContext();
            _hrHistoryDetailsRepository = new HR_HistoryDetailsRepository();
            _hrEmployeeRepository = new HrEmployeeRepository();
            _hrHistoryRepository = new HR_HistoryRepository();
            _hrEmployeeAllowancesRepository = new HR_EmployeeAllowancesRepository();
        }
        // GET: HR/EmpTransfer
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/EmpTransfer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/EmpTransfer/Create
        public ActionResult Create(int EmplId)
        {
            var list = _hrEmployeeRepository.FindById(EmplId);
            HR_History model = new HR_History();
            model.PreviousDepartment = list.HrDepartment.id.ToString();
            model.PreviousDesignation = list.HrDesignation.DesignationId;
            model.EmployeeId = list.Id;
            model.EmployeeNo = list.EmployeeID;
            model.companyID = list.companyID;
            model.CompanyKey = list.CompanyKey;
            return View(model);
        }

        // POST: HR/EmpTransfer/Create
        [HttpPost]
        public ActionResult Create(HR_History model)
        {
            try
            {
                model.PromotionType = "T";
                model.CreatedBy = 0;
                model.ModifiedBy = 0;
                model.CreatedOn = DateTime.Now;
                model.ModifiedOn = DateTime.Now;
                model.HistoryID = GetHistoryID();
                ModelState.Remove("PromotionType");
                if (ModelState.IsValid)
                {
                    var empid = model.EmployeeId;

                    var list = _hrEmployeeRepository.FindById(empid);

                    //list.CurrentBasicSalary = Convert.ToDecimal(model.nsBasic);
                    //list.CurrentAllowances = Convert.ToDecimal(model.nsAllowance);
                    //list.CurrentGrossSalary = Convert.ToDecimal(model.nsCurrent);

                    list.DeptId = Convert.ToInt32(model.PreviousDepartment);
                    list.Designation = model.PreviousDesignation;
                    
                    _hrEmployeeRepository.Edit(list);
                    _hrHistoryRepository.Add(model);
                    return null;
                }
                else
                {
                    return View(model);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HR/EmpTransfer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/EmpTransfer/Edit/5
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

        // GET: HR/EmpTransfer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/EmpTransfer/Delete/5
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
        public string GetHistoryID()
        {
            int maxno = _dbContext.HR_History.Count();
            maxno = maxno + 1;
            string SerialID = DateTime.Today.Year + maxno.ToString().PadLeft(4, '0');
            return SerialID;
        }
    }
}
