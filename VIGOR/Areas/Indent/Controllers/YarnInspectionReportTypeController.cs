using ERP.Core.Models.Indenting.Inspection;
using ERP.Infrastructure.Repositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class YarnInspectionReportTypeController : Controller
    {
        YarnInspectionReportTypeRepository _yarnInspectionReportTypeRepository;
        public YarnInspectionReportTypeController()
        {
            _yarnInspectionReportTypeRepository = new YarnInspectionReportTypeRepository();
        }
        // GET: Indent/YarnInspectionReportType
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/YarnInspectionReportType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/YarnInspectionReportType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/YarnInspectionReportType/Create
        [HttpPost]
        public ActionResult Create(YarnInspectionReportType model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_yarnInspectionReportTypeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _yarnInspectionReportTypeRepository.Add(model);
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

        // GET: Indent/YarnInspectionReportType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_yarnInspectionReportTypeRepository.FindById(id));
        }

        // POST: Indent/YarnInspectionReportType/Edit/5
        [HttpPost]
        public ActionResult Edit(YarnInspectionReportType model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_yarnInspectionReportTypeRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _yarnInspectionReportTypeRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/YarnInspectionReportType/Delete/5
        public ActionResult Delete(int id)
        {
            YarnInspectionReportType model = new YarnInspectionReportType();
            model.Id = id;
            _yarnInspectionReportTypeRepository.Remove(model);
            return null;
        }

        // POST: Indent/YarnInspectionReportType/Delete/5
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
        public ActionResult GetYarnInspectionReportType()
        {
            var Year = _yarnInspectionReportTypeRepository.GetAllYarnInspectionReportTypes().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintYarnInspectionReportType()
        {
            return View(_yarnInspectionReportTypeRepository.GetAllYarnInspectionReportTypes().ToList());
        }
    }
}
