using ERP.Infrastructure.Repositories.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.Common;

namespace VIGOR.Areas.HR.Controllers.Settings
{
    public class EmployeeController : Controller
    {
        HrEmployeeRepository _hrEmployeeRepository;
        private CompanyRepository _companyRepository;
        private ErpDbContext _dbContext;
        public EmployeeController()
        {
            _dbContext = new ErpDbContext();
            _companyRepository = new CompanyRepository();
            _hrEmployeeRepository = new HrEmployeeRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/Employee/Create
        public ActionResult Create()
        {
            HrEmployee model = new HrEmployee();
            model.Title = "-";
            model.PermanentCityIdKey = "-";
            model.TemporaryCityKey = "-";
            model.CompanyKey = "-";
            model.Department = "-";
            return View(model);
        }
        // POST: HR/Employee/Create
        [HttpPost]
        public ActionResult Create(HrEmployee model)
        {
            model.CreatedBy = 0;
            model.ModifiedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedOn = DateTime.Now;
            model.Title = model.FirstName;

            try
            {
                if (_hrEmployeeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicate Data is Not Allowed");
                    return View(model);
                }
                else
                {
                    model = GetCustomerDetails(model);
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

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        // GET: HR/Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var list = _hrEmployeeRepository.FindById(id);
            HR_History model=new HR_History();
            model.psBasic = Convert.ToDouble(list.CurrentBasicSalary);
            model.psAllowance = Convert.ToDouble(list.CurrentAllowances);
            model.psCurrent = Convert.ToDouble(list.CurrentGrossSalary);
            model.PreviousDepartment = list.HrDepartment.Title;
            model.PreviousDesignation = list.HrDesignation.DesignationId;
            
            return View(model);
        }

        // POST: HR/Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(HrEmployee model)
        {
            model.ModifiedOn = DateTime.Now;
            model.Title = model.FirstName;

            try
            {
                model = GetCustomerDetails(model);
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // GET: HR/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/Employee/Delete/5
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
                FirstName = x.FirstName,
                FatherHusbandName = x.FatherHusbandName
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        private HrEmployee GetCustomerDetails(HrEmployee hrEmployee)
        {
            HR_EmployeeQualification _hrEmployeeQualification;
            HR_EmployeeExperience _hrEmployeeExperience;
            HR_EmployeeAllowances _hrEmployeeAllowances;

            var employeeQualificationList = new List<string>();
            var empExperienceList = new List<string>();
            var empAllownaceList = new List<string>();


            foreach (var k in Request.Form.Keys)
            {

                //Qualification Tables Data
                if (k.ToString().Contains("DegreeId"))
                    employeeQualificationList.Add(k.ToString());
                if (k.ToString().Contains("Institution"))
                    employeeQualificationList.Add(k.ToString());
                if (k.ToString().Contains("Grade"))
                    employeeQualificationList.Add(k.ToString());
                if (k.ToString().Contains("Division"))
                    employeeQualificationList.Add(k.ToString());
                if (k.ToString().Contains("DegreeSession"))
                    employeeQualificationList.Add(k.ToString());

                //Experience Tables data
                if (k.ToString().Contains("Organization"))
                    empExperienceList.Add(k.ToString());
                if (k.ToString().Contains("Designation"))
                    empExperienceList.Add(k.ToString());
                if (k.ToString().Contains("JoinigDate"))
                    empExperienceList.Add(k.ToString());
                if (k.ToString().Contains("ResignedOn"))
                    empExperienceList.Add(k.ToString());
                if (k.ToString().Contains("ReasonToLeave"))
                    empExperienceList.Add(k.ToString());


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
                foreach (var Key in employeeQualificationList)
                {
                    var index = "0";
                    index = Key.Replace("][DegreeId]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][DegreeId]"))
                    {
                        _hrEmployeeQualification = new HR_EmployeeQualification();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][DegreeId]"]))
                        {

                            _hrEmployeeQualification.DegreeId = (Request.Form["det[" + index + "][DegreeId]"]);
                            _hrEmployeeQualification.Institution = (Request.Form["det[" + index + "][Institution]"]);
                            _hrEmployeeQualification.Grade = (Request.Form["det[" + index + "][Grade]"]);
                            _hrEmployeeQualification.Division = (Request.Form["det[" + index + "][Division]"]);
                            _hrEmployeeQualification.DegreeSession = (Request.Form["det[" + index + "][DegreeSession]"]);
                            _hrEmployeeQualification.Marks_gpa = (Request.Form["det[" + index + "][Grade]"]);
                            _hrEmployeeQualification.EmployeeId = hrEmployee.Id;
                            _hrEmployeeQualification.EmployeeNo = hrEmployee.EmployeeID;
                            _hrEmployeeQualification.Status = "-";
                            _hrEmployeeQualification.CreatedBy = 0;
                            _hrEmployeeQualification.CreatedOn = DateTime.Now;
                            _hrEmployeeQualification.ModifiedBy = 0;
                            _hrEmployeeQualification.ModifiedOn = DateTime.Now;

                            try
                            {
                                hrEmployee.HR_EmployeeQualification.Add(_hrEmployeeQualification);
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
                                hrEmployee.HR_EmployeeAllowances.Add(_hrEmployeeAllowances);
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
                foreach (var Key in empExperienceList)
                {
                    var index = "0";
                    index = Key.Replace("][Organization]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][Organization]"))
                    {
                        _hrEmployeeExperience = new HR_EmployeeExperience();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][Organization]"]))
                        {
                            _hrEmployeeExperience.Organization = Request.Form["det[" + index + "][Organization]"];
                            _hrEmployeeExperience.Designation = Request.Form["det[" + index + "][Designation]"];
                            _hrEmployeeExperience.JoinigDate = Convert.ToDateTime(Request.Form["det[" + index + "][JoinigDate]"]);
                            _hrEmployeeExperience.ResignedOn = Convert.ToDateTime(Request.Form["det[" + index + "][ResignedOn]"]);
                            _hrEmployeeExperience.ReasonToLeave = Request.Form["det[" + index + "][ReasonToLeave]"];
                            _hrEmployeeExperience.CreatedOn = DateTime.Now;
                            _hrEmployeeExperience.ModifiedOn = DateTime.Now;
                            _hrEmployeeExperience.ModifiedBy = 0;
                            _hrEmployeeExperience.EmployeeId = hrEmployee.Id;
                            _hrEmployeeExperience.EmployeeNo = hrEmployee.EmployeeID;

                            try
                            {
                                hrEmployee.HR_EmployeeExperience.Add(_hrEmployeeExperience);
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
    }
}
