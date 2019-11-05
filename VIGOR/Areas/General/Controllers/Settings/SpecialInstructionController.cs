using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Common.Party;
using ERP.Infrastructure.Repositories.Common.PatryCommon;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class SpecialInstructionController : Controller
    {
        SpecialInstructionRepository _specialInstructionRepository;
        public SpecialInstructionController()
        {
            _specialInstructionRepository = new SpecialInstructionRepository();
        }
        // GET: General/SpecialInstruction
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/SpecialInstruction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/SpecialInstruction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/SpecialInstruction/Create
        [HttpPost]
        public ActionResult Create(SpecialInstruction model)
        {
            try
            {
                if (_specialInstructionRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _specialInstructionRepository.Add(model);
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

        // GET: General/SpecialInstruction/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_specialInstructionRepository.FindById(id));
        }

        // POST: General/SpecialInstruction/Edit/5
        [HttpPost]
        public ActionResult Edit(SpecialInstruction model)
        {
            if (_specialInstructionRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _specialInstructionRepository.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: General/SpecialInstruction/Delete/5
        public ActionResult Delete(int id)
        {
            _specialInstructionRepository.Remove(id);
            return null;
        }

        // POST: General/SpecialInstruction/Delete/5
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
        public ActionResult GetSpecialInstruction(bool active)
        {
            var Year = _specialInstructionRepository.GetAllSpecialInstructions().ToList().Where(a=>a.IsActive==active);
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Name,
                active=x.IsActive?"Active": "InActive"
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintSpecialInstruction(bool active)
        {
            return View(_specialInstructionRepository.GetAllSpecialInstructions().ToList().Where(a => a.IsActive == active));
        }
    }
}
