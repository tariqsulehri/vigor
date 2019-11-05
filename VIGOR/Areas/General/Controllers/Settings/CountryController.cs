using ERP.Infrastructure.Repositories.Common;
using System.Linq;
using System.Web.Mvc;
using ERP.Core.Models.Common;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class CountryController : Controller
    {
        CountryRepository _countryRepository;
        public CountryController()
        {
            _countryRepository = new CountryRepository();
        }
        // GET: Country
        public ActionResult Index()
        {
            return View();
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(Country model)
        {
            try
            {
                if (_countryRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _countryRepository.Add(model);
                         return null;
                }
                else
                {
                    return View(model);
                }
               
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            var a = _countryRepository.FindById(id);
            return View(_countryRepository.FindById(id));
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(Country model)
        {
            try
            {
                if (_countryRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _countryRepository.Edit(model);
                    return null;
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            _countryRepository.Remove(id);
            return null;
        }

        // POST: Country/Delete/5
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
        public ActionResult GetCountry()
        {
            var Year = _countryRepository.GetAllCountries().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Name,
                region = x.Region.Title
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintCountry()
        {
            return View(_countryRepository.GetAllCountries());
        }
    }
}
