using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Common;
using ERP.Core.Models.Common.Party;
using ERP.Infrastructure.Repositories.Common;
using ERP.Infrastructure.Repositories.Common.PatryCommon;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class MachineryController : Controller
    {
        MachineRepository _machineRepository;
        public MachineryController()
        {
            _machineRepository = new MachineRepository();
        }
        // GET: Machinery
        public ActionResult Index()
        {
            return View();
        }

        // GET: Machinery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Machinery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Machinery/Create
        [HttpPost]
        public ActionResult Create(Machine model)
        {
            try
            {
                if (_machineRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _machineRepository.Add(model);
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

        // GET: Machinery/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_machineRepository.FindById(id));
        }

        // POST: Machinery/Edit/5
        [HttpPost]
        public ActionResult Edit(Machine model)
        {
            if (_machineRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _machineRepository.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Machinery/Delete/5
        public ActionResult Delete(int id)
        {
            _machineRepository.Remove(id);
            return null;
        }

        // POST: Machinery/Delete/5
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
        public ActionResult GetMachinery(bool active)
        {
            var Year = _machineRepository.GetAllMachines().ToList().Where(a=>a.IsActive==active);
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Name,
                active=x.IsActive?"Active":"InActive"
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintMachinery(bool active)
        {
            return View(_machineRepository.GetAllMachines().ToList().Where(a => a.IsActive == active));
        }
    }
}