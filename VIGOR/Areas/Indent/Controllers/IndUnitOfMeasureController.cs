using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Core.Models.Indenting;

namespace VIGOR.Areas.Indent.Controllers
{
    public class IndUnitOfMeasureController : Controller
    {
        IndUnitOfMeasureRepository _indUnitOfMeasureRepository;
        public IndUnitOfMeasureController()
        {
            _indUnitOfMeasureRepository = new IndUnitOfMeasureRepository();
        }
        // GET: Indent/IndUnitOfMeasure
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/IndUnitOfMeasure/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/IndUnitOfMeasure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/IndUnitOfMeasure/Create
        [HttpPost]
        public ActionResult Create(IndUnitOfMeasure model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_indUnitOfMeasureRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _indUnitOfMeasureRepository.Add(model);
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

        // GET: Indent/IndUnitOfMeasure/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_indUnitOfMeasureRepository.FindById(id));
        }

        // POST: Indent/IndUnitOfMeasure/Edit/5
        [HttpPost]
        public ActionResult Edit(IndUnitOfMeasure model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_indUnitOfMeasureRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _indUnitOfMeasureRepository.Edit(model);
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
            IndUnitOfMeasure model = new IndUnitOfMeasure();
            model.Id = id;
            _indUnitOfMeasureRepository.Remove(model);
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
        public ActionResult GetIndUnitOfMeasure()
        {
            var Year = _indUnitOfMeasureRepository.GetAllIndUnitOfMeasure().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintIndUnitOfMeasure()
        {
            return View(_indUnitOfMeasureRepository.GetAllIndUnitOfMeasure().ToList());
        }
    }
}
