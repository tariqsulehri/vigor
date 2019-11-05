using ERP.Infrastructure.Repositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Indenting;

namespace VIGOR.Areas.Indent.Controllers
{
    public class UnitOfRateController : Controller
    {
        UnitOfRateRepository unitOfRateRepository;
        public UnitOfRateController()
        {
            unitOfRateRepository = new UnitOfRateRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UnitOfRate model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (unitOfRateRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    unitOfRateRepository.Add(model);
                    return null;
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

      
        public ActionResult Edit(int id)
        {
            return View(unitOfRateRepository.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(UnitOfRate model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (unitOfRateRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                unitOfRateRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/IndUnitOfMeasure/Delete/5
        public ActionResult Delete(int id)
        {
            UnitOfRate model = new UnitOfRate();
            model.Id = id;
            unitOfRateRepository.Remove(model);
            return null;
        }

        // POST: Indent/IndUnitOfMeasure/Delete/5
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
        public ActionResult GetIndUnitOfRate()
        {
            var Year = unitOfRateRepository.GetAllUnitOfRates().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintIndUnitOfRate()
        {
            return View(unitOfRateRepository.GetAllUnitOfRates().ToList());
        }
    }
}
