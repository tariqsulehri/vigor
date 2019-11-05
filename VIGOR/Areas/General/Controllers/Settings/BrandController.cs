using ERP.Core.Models.Inventory;
using ERP.Infrastructure.Repositories.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class BrandController : Controller
    {
        BrandRepository _brandRepository;
        public BrandController()
        {
            _brandRepository = new BrandRepository();
        }
        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }

        // GET: Brand/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            Brand model = new Brand();
            model.UserId = "0";
            return View(model);
        }

        // POST: Brand/Create
        [HttpPost]
        public ActionResult Create(Brand model)
        {
            model.UserId = "0";
            try
            {
                if (_brandRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _brandRepository.Add(model);
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

        // GET: Brand/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_brandRepository.FindById(id));
        }

        // POST: Brand/Edit/5
        [HttpPost]
        public ActionResult Edit(Brand model)
        {
            model.UserId = "0";
            if (_brandRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _brandRepository.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Brand/Delete/5
        public ActionResult Delete(int id)
        {
            _brandRepository.Remove(id);
            return null;
        }

        // POST: Brand/Delete/5
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
        public ActionResult GetBrand(bool active)
        {
            var Year = _brandRepository.GetAllbrands().ToList().Where(a=>a.Active==active);
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Title,
                Active = x.Active?"Active":"InActive"
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintBrand(bool active)
        {
            return View(_brandRepository.GetAllbrands().ToList().Where(a => a.Active == active));
        }
    }
}
