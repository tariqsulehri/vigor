using ERP.Core.Models.Indenting.Inspection;
using ERP.Infrastructure.Repositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class FabricInspLoomTypeController : Controller
    {
        FabricInspLoomTypeRepository _fabricInspLoomTypeRepository;
        public FabricInspLoomTypeController()
        {
            _fabricInspLoomTypeRepository = new FabricInspLoomTypeRepository();
        }
        // GET: Indent/FabricInspLoomType
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/FabricInspLoomType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/FabricInspLoomType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/FabricInspLoomType/Create
        [HttpPost]
        public ActionResult Create(FabricInspLoomType model)
        {
            try
            {
                if (_fabricInspLoomTypeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _fabricInspLoomTypeRepository.Add(model);
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

        // GET: Indent/FabricInspLoomType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_fabricInspLoomTypeRepository.FindById(id));
        }

        // POST: Indent/FabricInspLoomType/Edit/5
        [HttpPost]
        public ActionResult Edit(FabricInspLoomType model)
        {
            if (_fabricInspLoomTypeRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _fabricInspLoomTypeRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/FabricInspLoomType/Delete/5
        public ActionResult Delete(int id)
        {
            FabricInspLoomType model = new FabricInspLoomType();
            model.Id = id;
            _fabricInspLoomTypeRepository.Remove(model);
            return null;
        }

        // POST: Indent/FabricInspLoomType/Delete/5
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
        public ActionResult GetFabricInspLoomType()
        {
            var Year = _fabricInspLoomTypeRepository.GetAllFabricInspLoomType().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintFabricInspLoomType()
        {
            return View(_fabricInspLoomTypeRepository.GetAllFabricInspLoomType().ToList());
        }
    }
}