using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;
using ERP.Infrastructure.Repositories.HR;

namespace VIGOR.Areas.HR.Controllers
{
    public class AllowanceController : Controller
    {
        // GET: General/Allowance
        private HR_AllowancesRepository _hrAllowancesRepository;
        public AllowanceController()
        {
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
        // GET: HR/Allowance/CreateOrUpdate
        public ActionResult CreateOrUpdate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOrUpdate(HR_Allowances model)
        {
            try
            {
                model.CreatedBy = 0;
                model.CreatedOn=DateTime.Now;
                model.ModifiedOn=DateTime.Now;
                model.ModifiedBy = 0;
                if (_hrAllowancesRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicate Data is Not Allowed");
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
                model.Type = "A";
                model.SubType = "R";
                model.ApplyOn = "1";
                model.TaxStatus = "E";
                model.CreatedBy = 0;
                model.ModifiedBy = 0;
                model.CreatedOn = DateTime.Now;
                model.ModifiedOn = DateTime.Now;
                if (_hrAllowancesRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
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
        [HttpGet]
        // GET: HR/Allowance/Edit/5
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
                //model.CreatedOn=DateTime.Now;
                if (_hrAllowancesRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicate Data is Not allowed");
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
                return View();
            }
        }

        // GET: General/Allowance/Delete/5
        public ActionResult Delete(string id)
        {

           var result= _hrAllowancesRepository.Remove(id);
           if (result = !false)
           {
               return null;
            }
           else
           {
               ModelState.AddModelError(String.Empty, "Not found");
           }
           return null;

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

        public ActionResult GetAllowanceInfo()
        {
            var result = _hrAllowancesRepository.GetAllHR_Allowances().ToList();
            var collection = result.Select(x => new
            {
                Id=x.AllowanceID,
                Title=x.Description,
                Type=x.Type,
                SubType=x.SubType,
                TaxStatus=x.TaxStatus
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
    }
}
