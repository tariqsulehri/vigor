using ERP.Core.Models.Indenting.Inspection;
using ERP.Infrastructure.Repositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class FabricInspStandardController : Controller
    {
        FabricInspStandardRepository _fabricInspStandardRepository;
        public FabricInspStandardController()
        {
            _fabricInspStandardRepository = new FabricInspStandardRepository();
        }
        // GET: Indent/FabricInspStandard
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/FabricInspStandard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/FabricInspStandard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/FabricInspStandard/Create
        [HttpPost]
        public ActionResult Create(FabricInspStandard model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_fabricInspStandardRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _fabricInspStandardRepository.Add(model);
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

        // GET: Indent/FabricInspStandard/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_fabricInspStandardRepository.FindById(id));
        }

        // POST: Indent/FabricInspStandard/Edit/5
        [HttpPost]
        public ActionResult Edit(FabricInspStandard model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_fabricInspStandardRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _fabricInspStandardRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/FabricInspStandard/Delete/5
        public ActionResult Delete(int id)
        {
            FabricInspStandard model = new FabricInspStandard();
            model.Id = id;
            _fabricInspStandardRepository.Remove(model);
            return null;
        }

        // POST: Indent/FabricInspStandard/Delete/5
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
        public ActionResult GetFabricInspStandard()
        {
            var Year = _fabricInspStandardRepository.GetAllfabricInspStandard().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintFabricInspStandard()
        {
            return View(_fabricInspStandardRepository.GetAllfabricInspStandard().ToList());
        }
    }
}
