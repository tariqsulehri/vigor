using ERP.Core.Models.Common;
using ERP.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class StateController : Controller
    {
        StateRepository _stateRepository;
        public StateController()
        {
            _stateRepository = new StateRepository();
        }
        // GET: State
        public ActionResult Index()
        {
            return View();
        }

        // GET: State/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: State/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: State/Create
        [HttpPost]
        public ActionResult Create(State model)
        {
            try
            {
                if (_stateRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _stateRepository.Add(model);
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

        // GET: State/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_stateRepository.FindById(id));
        }

        // POST: State/Edit/5
        [HttpPost]
        public ActionResult Edit(State model)
        {
            if (_stateRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _stateRepository.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: State/Delete/5
        public ActionResult Delete(int id)
        {
            _stateRepository.Remove(id);
            return null;
        }

        // POST: State/Delete/5
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
        public ActionResult GetState()
        {
            var Year = _stateRepository.GetAllStates().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title=x.Name,
                country=x.Country.Name,
                region=x.Country.Region.Title
                
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintState()
        {
            return View(_stateRepository.GetAllStates());
        }
    }
}
