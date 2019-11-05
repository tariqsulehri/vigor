using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Common;
using ERP.Infrastructure.Repositories.Common;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class LocationsController : Controller
    {
        private LocationsRepository _locationsRepository;

        public LocationsController()
        {
                _locationsRepository=new LocationsRepository();
        }
        // GET: General/Locations
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/Locations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/Locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/Locations/Create
        [HttpPost]
        public ActionResult Create(Locations model)
        {
            try
            {
                if (_locationsRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                model.Company = LoggedinUser.Company.Id.ToString();
                model.RefId = "000";
                ModelState.Remove("Company");
                ModelState.Remove("LocationID");
                if (ModelState.IsValid)
                {
                    _locationsRepository.Add(model);
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

        // GET: General/Locations/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_locationsRepository.FindById(id));
        }

        // POST: General/Locations/Edit/5
        [HttpPost]
        public ActionResult Edit(Locations model)
        {
            if (_locationsRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _locationsRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: General/Locations/Delete/5
        public ActionResult Delete(int id)
        {
            var location = _locationsRepository.FindById(id);
            _locationsRepository.Remove(location);
            return null;
        }

        // POST: General/Locations/Delete/5
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
        public ActionResult GetLocations()
        {
            var Year = _locationsRepository.GetAllLocations().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.LocationDescription
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintLocations(bool active)
        {
            return View(_locationsRepository.GetAllLocations().ToList());
        }
    }
}
