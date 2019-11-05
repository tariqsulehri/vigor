using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Common;
using ERP.Infrastructure.Repositories.Common;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class CompanyController : Controller
    {
        CompanyRepository _companyRepository;
        public CompanyController()
        {
            _companyRepository = new CompanyRepository();
        }
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(Company model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            model.CreatedDate = DateTime.Now;
            model.LastUpDate = DateTime.Now;

            try
            {
                if (_companyRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _companyRepository.Add(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_companyRepository.FindById(id));
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(Company model)
        {
            model.LastUpDate = DateTime.Now;
            model.ModifiedOn = DateTime.Now;
            if (_companyRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _companyRepository.Edit(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            _companyRepository.Remove(id);
            return null;
        }

        // POST: Company/Delete/5
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
        public ActionResult GetCompany(bool active)
        {
            var Year = _companyRepository.GetAllCompanies().ToList().Where(a=>a.IsActive== active);
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Name,
                Active = x.IsActive?"Active":"InActive"
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintCompany(bool active)
        {
            return View(_companyRepository.GetAllCompanies().Where(a => a.IsActive == active));
        }
    }
}
