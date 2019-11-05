using ERP.Core.Models.Indenting.Inspection;
using ERP.Infrastructure.Repositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class YarnInspectionGradeController : Controller
    {
        YarnInspectionGradeRepository _yarnInspectionGradeRepository;
        public YarnInspectionGradeController()
        {
            _yarnInspectionGradeRepository = new YarnInspectionGradeRepository();
        }
        // GET: Indent/YarnInspectionGrade
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/YarnInspectionGrade/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/YarnInspectionGrade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/YarnInspectionGrade/Create
        [HttpPost]
        public ActionResult Create(YarnInspectionGrade model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_yarnInspectionGradeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _yarnInspectionGradeRepository.Add(model);
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

        // GET: Indent/YarnInspectionGrade/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_yarnInspectionGradeRepository.FindById(id));
        }

        // POST: Indent/YarnInspectionGrade/Edit/5
        [HttpPost]
        public ActionResult Edit(YarnInspectionGrade model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_yarnInspectionGradeRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _yarnInspectionGradeRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/YarnInspectionGrade/Delete/5
        public ActionResult Delete(int id)
        {
            YarnInspectionGrade model = new YarnInspectionGrade();
            model.Id = id;
            _yarnInspectionGradeRepository.Remove(model);
            return null;
        }

        // POST: Indent/YarnInspectionGrade/Delete/5
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
        public ActionResult GetYarnInspectionGrade()
        {
            var Year = _yarnInspectionGradeRepository.GetAllYarnInspectionGrades().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintYarnInspectionGrade()
        {
            return View(_yarnInspectionGradeRepository.GetAllYarnInspectionGrades().ToList());
        }
    }
}
