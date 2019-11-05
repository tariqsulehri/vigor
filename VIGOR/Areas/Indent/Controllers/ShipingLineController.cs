using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Core.Models.Indenting;


namespace VIGOR.Areas.Indent.Controllers
{
    public class ShipingLineController : Controller
    {
        ShipingLineRepository _shipingLineRepository;
        public ShipingLineController()
        {
            _shipingLineRepository = new ShipingLineRepository();
        }
        // GET: Indent/ShipingLine
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/ShipingLine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/ShipingLine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/ShipingLine/Create
        [HttpPost]
        public ActionResult Create(ShipingLine model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_shipingLineRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _shipingLineRepository.Add(model);
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

        // GET: Indent/ShipingLine/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_shipingLineRepository.FindById(id));
        }

        // POST: Indent/ShipingLine/Edit/5
        [HttpPost]
        public ActionResult Edit(ShipingLine model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_shipingLineRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _shipingLineRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/ShipingLine/Delete/5
        public ActionResult Delete(int id)
        {
            ShipingLine model= new ShipingLine();
            model.Id = id;
            _shipingLineRepository.Remove(model);
            return null;
        }

        // POST: Indent/ShipingLine/Delete/5
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
        public ActionResult GetShipingLine()
        {
            var Year = _shipingLineRepository.GetAllShipingLine().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Name
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintShipingLine()
        {
            return View(_shipingLineRepository.GetAllShipingLine().ToList());
        }
    }
}
