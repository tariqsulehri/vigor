using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Common;
using ERP.Infrastructure.Repositories.Common;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class BusinessTypesController : Controller
    {
        BusinessTypesRepository _businessTypesRepository;
        public BusinessTypesController()
        {
            _businessTypesRepository = new BusinessTypesRepository();
        }
        // GET: General/BusinessTypes
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/BusinessTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/BusinessTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/BusinessTypes/Create
        [HttpPost]
        public ActionResult Create(BusinessTypes model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;

            try
            {
                if (_businessTypesRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _businessTypesRepository.Add(model);
                    return null;
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

        // GET: General/BusinessTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_businessTypesRepository.FindById(id));
        }

        // POST: General/BusinessTypes/Edit/5
        [HttpPost]
        public ActionResult Edit(BusinessTypes model)
        {
            model.ModifiedOn = DateTime.Now;
            if (_businessTypesRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _businessTypesRepository.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: General/BusinessTypes/Delete/5
        public ActionResult Delete(int id)
        {
            _businessTypesRepository.Remove(id);
            return null;
        }

        // POST: General/BusinessTypes/Delete/5
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
        public ActionResult GetBusinessTypes(bool active)
        {
            var Year = _businessTypesRepository.GetAllBusinessTypes().ToList().Where(a=>a.IsActive==active);
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.BusinessTitle,
                Active=x.IsActive?"Active":"InActive"
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintBusinessTypes(bool active)
        {
            return View(_businessTypesRepository.GetAllBusinessTypes().Where(a => a.IsActive == active));
        }
    }
}
