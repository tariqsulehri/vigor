using ERP.Core.Models.Indenting;
using ERP.Infrastructure.Repositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class FabricInspTypeController : Controller
    {
        FabricInspTypeRepository _fabricInspTypeRepository;
        public FabricInspTypeController()
        {
            _fabricInspTypeRepository = new FabricInspTypeRepository();
        }
        // GET: Indent/FabricInspType
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/FabricInspType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/FabricInspType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/FabricInspType/Create
        [HttpPost]
        public ActionResult Create(FabricInspType model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_fabricInspTypeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _fabricInspTypeRepository.Add(model);
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

        // GET: Indent/FabricInspType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_fabricInspTypeRepository.FindById(id));
        }

        // POST: Indent/FabricInspType/Edit/5
        [HttpPost]
        public ActionResult Edit(FabricInspType model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_fabricInspTypeRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _fabricInspTypeRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/FabricInspType/Delete/5
        public ActionResult Delete(int id)
        {
            FabricInspType model = new FabricInspType();
            model.Id = id;
            _fabricInspTypeRepository.Remove(model);
            return null;
        }

        // POST: Indent/FabricInspType/Delete/5
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
        public ActionResult GetFabricInspType()
        {
            var Year = _fabricInspTypeRepository.GetAllFabricInspTypes().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintFabricInspType()
        {
            return View(_fabricInspTypeRepository.GetAllFabricInspTypes().ToList());
        }
    }
}
