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
        // GET: General/Allowance/CreateOrUpdate
        public ActionResult CreateOrUpdate()
        {
            return View();
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
                        return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: General/Allowance/Edit/5
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

        // GET: General/Allowance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
    }
}
