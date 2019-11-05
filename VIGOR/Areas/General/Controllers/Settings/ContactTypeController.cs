using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Common.Party;
using ERP.Infrastructure.Repositories.Common.PatryCommon;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class ContactTypeController : Controller
    {
        ContactTypesRepository _contactTypesRepository;
        public ContactTypeController()
        {
            _contactTypesRepository = new ContactTypesRepository();
        }
        // GET: General/ContactType
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/ContactType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/ContactType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/ContactType/Create
        [HttpPost]
        public ActionResult Create(ContactType model)
        {
            try
            {
                if (_contactTypesRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _contactTypesRepository.Add(model);
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

        // GET: General/ContactType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_contactTypesRepository.FindById(id));
        }

        // POST: General/ContactType/Edit/5
        [HttpPost]
        public ActionResult Edit(ContactType model)
        {
            if (_contactTypesRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _contactTypesRepository.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: General/ContactType/Delete/5
        public ActionResult Delete(int id)
        {
            _contactTypesRepository.Remove(id);
            return null;
        }

        // POST: General/ContactType/Delete/5
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
        public ActionResult GetContactType()
        {
            var Year = _contactTypesRepository.GetAllContactsTypes().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintContactType()
        {
            return View(_contactTypesRepository.GetAllContactsTypes());
        }
    }
}
