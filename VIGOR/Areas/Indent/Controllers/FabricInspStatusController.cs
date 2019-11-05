using ERP.Core.Models.Indenting.Inspection;
using ERP.Infrastructure.Repositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class FabricInspStatusController : Controller
    {
        FabricInspStatusRepository _fabricInspStatusRepository;
        public FabricInspStatusController()
        {
            _fabricInspStatusRepository = new FabricInspStatusRepository();
        }
        // GET: Indent/FabricInspStatus
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/FabricInspStatus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/FabricInspStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/FabricInspStatus/Create
        [HttpPost]
        public ActionResult Create(FabricInspStatus model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_fabricInspStatusRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _fabricInspStatusRepository.Add(model);
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

        // GET: Indent/FabricInspStatus/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_fabricInspStatusRepository.FindById(id));
        }

        // POST: Indent/FabricInspStatus/Edit/5
        [HttpPost]
        public ActionResult Edit(FabricInspStatus model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_fabricInspStatusRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _fabricInspStatusRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/FabricInspStatus/Delete/5
        public ActionResult Delete(int id)
        {
            FabricInspStatus model = new FabricInspStatus();
            model.Id = id;
            _fabricInspStatusRepository.Remove(model);
            return null;
        }

        // POST: Indent/FabricInspStatus/Delete/5
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
        public ActionResult GetFabricInspStatus()
        {
            var Year = _fabricInspStatusRepository.GetAllFabricInspStatus().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description,
                Symbol = x.StatusId
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintFabricInspStatus()
        {
            return View(_fabricInspStatusRepository.GetAllFabricInspStatus().ToList());
        }
    }
}
