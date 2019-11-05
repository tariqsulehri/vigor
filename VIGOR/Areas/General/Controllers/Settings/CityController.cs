using ERP.Core.Models.Common;
using ERP.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class CityController : Controller
    {
        CityRepository _cityRepository;
        CountryRepository _country;
        StateRepository stateRepository;
        public CityController()
        {
            _cityRepository = new CityRepository();
            _country = new CountryRepository();
            stateRepository = new StateRepository();
        }
        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(City model)
        {
            try
            {
                if (_cityRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _cityRepository.Add(model);
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

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_cityRepository.FindById(id));
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(City model)
        {
            if (_cityRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _cityRepository.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            _cityRepository.Remove(id);
            return null;
        }

        // POST: City/Delete/5
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
        public ActionResult GetCity()
        {
            var Year = _cityRepository.GetAllCities().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Name,
                state = x.State.Name,
                country = x.State.Country.Name,
                region = x.State.Country.Region.Title
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintCity()
        {
            return View(_cityRepository.GetAllCities());
        }

        public JsonResult GetAllCityOfCountry(int countryID)
        {
            try
            {
                var query = from c in _cityRepository.GetAllCities()
                            join s in stateRepository.GetAllStates() on  c.StId equals s.Id
                            where s.CId.Equals(countryID)
                            select new
                            {
                                Id = c.Id,
                                Title = c.Name
                            };
                return Json(query, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { throw ex; }
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}
