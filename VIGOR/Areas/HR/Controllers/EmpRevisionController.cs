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
    public class EmpRevisionController : Controller
    {
        private HrEmployeeRepository _hrEmployeeRepository;
        private HR_HistoryRepository _hrHistoryRepository;
        private HR_EmployeeAllowancesRepository _hrEmployeeAllowancesRepository;
        private HR_HistoryDetailsRepository _hrHistoryDetailsRepository;
        private ErpDbContext _dbContext;
        public EmpRevisionController()
        {
            _dbContext = new ErpDbContext();
            _hrHistoryDetailsRepository = new HR_HistoryDetailsRepository();
            _hrEmployeeRepository = new HrEmployeeRepository();
            _hrHistoryRepository = new HR_HistoryRepository();
            _hrEmployeeAllowancesRepository = new HR_EmployeeAllowancesRepository();
        }
        // GET: HR/EmpRevision
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/EmpRevision/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/EmpRevision/Create
        public ActionResult Create(int EmplId)
        {
            var list = _hrEmployeeRepository.FindById(EmplId);
            HR_History model = new HR_History();
            model.psBasic = Convert.ToDouble(list.CurrentBasicSalary);
            model.psAllowance = Convert.ToDouble(list.CurrentAllowances);
            model.psCurrent = Convert.ToDouble(list.CurrentGrossSalary);
            model.PreviousDepartment = list.HrDepartment.id.ToString();
            model.PreviousDesignation = list.HrDesignation.DesignationId;
            model.EmployeeId = list.Id;
            model.EmployeeNo = list.EmployeeID;
            model.companyID = list.companyID;
            model.CompanyKey = list.CompanyKey;
            return View(model);
        }

        // POST: HR/EmpRevision/Create
        [HttpPost]
        public ActionResult Create(HR_History model)
        {
            try
            {
                model.PromotionType = "R";
                model.CreatedBy = 0;
                model.ModifiedBy = 0;
                model.CreatedOn = DateTime.Now;
                model.ModifiedOn = DateTime.Now;
                model.HistoryID = GetHistoryID();
                ModelState.Remove("PromotionType");
                if (_hrHistoryRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicate Data is Not Allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var empid = model.EmployeeId;

                        var list = _hrEmployeeRepository.FindById(empid);

                        list.CurrentBasicSalary = Convert.ToDecimal(model.nsBasic);
                        list.CurrentAllowances = Convert.ToDecimal(model.nsAllowance);
                        list.CurrentGrossSalary = Convert.ToDecimal(model.nsCurrent);
                        list.DeptId = Convert.ToInt32(model.NewDepartment);
                        list.Designation = model.NewDesignation;

                        list = GetAllowanceDetails(list);

                        _hrEmployeeRepository.Edit(list);
                        _hrHistoryRepository.Add(model);

                        return null;
                    }
                    else
                    {
                        return View(model);
                    }

                }
            }
            catch (Exception exception)
            {
                return View(exception);
            }
        }

        // GET: HR/EmpRevision/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HR/EmpRevision/Edit/5
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

        // GET: HR/EmpRevision/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/EmpRevision/Delete/5
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
        private HrEmployee GetAllowanceDetails(HrEmployee hrEmployee)
        {

            HR_EmployeeAllowances _hrEmployeeAllowances;
            HR_HistoryDetails _historyDetails;
            var empAllownaceList = new List<string>();


            foreach (var k in Request.Form.Keys)
            {

                // Employee Allowance Tables data
                if (k.ToString().Contains("AllowanceID"))
                    empAllownaceList.Add(k.ToString());
                if (k.ToString().Contains("Amount"))
                    empAllownaceList.Add(k.ToString());
                if (k.ToString().Contains("Mode"))
                    empAllownaceList.Add(k.ToString());

            }

            try
            {
                foreach (var Key in empAllownaceList)
                {
                    var index = "0";
                    index = Key.Replace("][AllowanceID]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][AllowanceID]"))
                    {
                        _hrEmployeeAllowances = new HR_EmployeeAllowances();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][AllowanceID]"]))
                        {
                            _hrEmployeeAllowances.AllowanceID = Request.Form["det[" + index + "][AllowanceID]"];
                            _hrEmployeeAllowances.Amount = Convert.ToDecimal(Request.Form["det[" + index + "][Amount]"]);
                            _hrEmployeeAllowances.Mode = ((Request.Form["det[" + index + "][Mode]"]));
                            _hrEmployeeAllowances.CreatedOn = DateTime.Now;
                            _hrEmployeeAllowances.ModifiedOn = DateTime.Now;
                            _hrEmployeeAllowances.ModifiedBy = 0;
                            _hrEmployeeAllowances.EmployeeId = hrEmployee.Id;
                            _hrEmployeeAllowances.EmployeeNo = hrEmployee.EmployeeID;

                            try
                            {
                                _hrEmployeeAllowancesRepository.Add(_hrEmployeeAllowances);
                            }
                            catch (Exception e)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var Key in empAllownaceList)
                {
                    var index = "0";
                    index = Key.Replace("][AllowanceID]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][AllowanceID]"))
                    {
                        _historyDetails = new HR_HistoryDetails();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][AllowanceID]"]))
                        {
                            _historyDetails.HistoryID = GetHistoryDetailID();
                            _historyDetails.AllowanceID = Request.Form["det[" + index + "][AllowanceID]"];
                            _historyDetails.Amount = Convert.ToDecimal(Request.Form["det[" + index + "][Amount]"]);
                            _historyDetails.Mode = ((Request.Form["det[" + index + "][Mode]"]));
                            _historyDetails.EmployeeId = hrEmployee.Id;
                            _historyDetails.EmployeeNo = hrEmployee.EmployeeID;

                            try
                            {
                                _hrHistoryDetailsRepository.Add(_historyDetails);
                            }
                            catch (Exception e)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }


            return hrEmployee;
        }
        public string GetHistoryDetailID()
        {
            int maxno = _dbContext.HR_HistoryDetails.Count();
            maxno = maxno + 1;
            string SerialID = DateTime.Today.Year + maxno.ToString().PadLeft(4, '0');
            //string SerialID = LoggedinUser.Company.Id.ToString().PadLeft(3, '0') +LoggedinUser.CurrentFiscalYear.YearKey  + maxno.ToString().PadLeft(5, '0');
            return SerialID;
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
