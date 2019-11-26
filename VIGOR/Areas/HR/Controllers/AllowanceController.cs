using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.HR;

namespace VIGOR.Areas.HR.Controllers
{
    public class AllowanceController : Controller
    {
        // GET: General/Allowance
        private HR_AllowancesRepository _hrAllowancesRepository;
        private ErpDbContext _dbContext;
        public AllowanceController()
        {
            _dbContext=new ErpDbContext();
            _hrAllowancesRepository=new HR_AllowancesRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/Allowance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: General/Allowance/CreateOrUpdate
        public ActionResult CreateOrUpdate()
        {
            return View();
        }
        // POST: General/Allowance/Create
        [HttpPost]
        public ActionResult CreateOrUpdate(HR_Allowances model)
        {
            try
            {
                model.CreatedBy = 0;
                model.CreatedOn = DateTime.Now;
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                model.AllowanceID = GetAllowanceID();
                ModelState.Remove("AllowanceID");
                if (_hrAllowancesRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");

                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _hrAllowancesRepository.Add(model);
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
        // GET: General/Allowance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/Allowance/Create
        [HttpPost]
        public ActionResult Create(HR_Allowances model)
        {
            try
            {
                model.CreatedBy = 0;
                model.CreatedOn = DateTime.Now;
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                model.AllowanceID = GetAllowanceID();
                ModelState.Remove("AllowanceID");
                if (_hrAllowancesRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");

                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _hrAllowancesRepository.Add(model);
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
        // GET: General/Allowance/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_hrAllowancesRepository.FindById(id));
        }

        // POST: General/Allowance/Edit/5
        [HttpPost]
        public ActionResult Edit(HR_Allowances model)
        {
            try
            {

                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                if (_hrAllowancesRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");

                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _hrAllowancesRepository.Edit(model);
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
                return View(model);
            }
        }

        // GET: General/Allowance/Delete/5
        public ActionResult Delete(string id)
        {
            _hrAllowancesRepository.Remove(id);
            return RedirectToAction("Index");
        }

        // POST: General/Allowance/Delete/5
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
        public ActionResult GetEmpAllowance()
        {
            var AllowanceData = _hrAllowancesRepository.GetAllHR_Allowances().ToList();
            var collection = AllowanceData.Select(x => new
            {
                Id = x.AllowanceID,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public string GetAllowanceID()
        {
            int maxno = _dbContext.HR_Allowances.Count();
            maxno = maxno + 1;
            string SerialID = maxno.ToString();
            return SerialID;
        }
    }
}
