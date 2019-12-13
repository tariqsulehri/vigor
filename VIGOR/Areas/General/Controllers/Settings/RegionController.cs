using ERP.Core.Models.Common;
using ERP.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class RegionController : Controller
    {
        RegionRepository _regionRepository;
        public RegionController()
        {
            _regionRepository = new RegionRepository();
        }
        // GET: Region
        public ActionResult Index()
        {
            return View();
        }

        // GET: Region/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Region/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Region/Create
        [HttpPost]
        public ActionResult Create(Region model)
        {
            try
            {
                if (_regionRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }

                if (ModelState.IsValid)
                {
                    _regionRepository.Add(model);

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

        // GET: Region/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_regionRepository.FindById(id));
        }

        // POST: Region/Edit/5
        [HttpPost]
        public ActionResult Edit(Region model)
        {
            if (_regionRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                _regionRepository.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Region/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return null;
            }
            _regionRepository.Remove(id);
            return null;
        }

        // POST: Region/Delete/5
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
        public ActionResult GetRegion()
        {
            var Year = _regionRepository.GetAllRegions().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintRegion()
        {
            return View(_regionRepository.GetAllRegions());
        }
    }
}
