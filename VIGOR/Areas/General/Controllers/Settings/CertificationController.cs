using System;
using ERP.Infrastructure.Repositories.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Common;
using ERP.Core.Models.Common.Party;
using ERP.Infrastructure.Repositories.Common.PatryCommon;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class CertificationController : Controller
    {
        CertificationsRepository _certificationsRepository;
        public CertificationController()
        {
            _certificationsRepository = new CertificationsRepository();
        }
        // GET: Certification
        public ActionResult Index()
        {
            return View();
        }

        // GET: Certification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Certification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Certification/Create
        [HttpPost]
        public ActionResult Create(Certifications model)
        {
            try
            {
                if (_certificationsRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _certificationsRepository.Add(model);
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

        // GET: Certification/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_certificationsRepository.FindById(id));
        }

        // POST: Certification/Edit/5
        [HttpPost]
        public ActionResult Edit(Certifications model)
        {
            if (_certificationsRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _certificationsRepository.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Certification/Delete/5
        public ActionResult Delete(int id)
        {
            _certificationsRepository.Remove(id);
            return null;
        }

        // POST: Certification/Delete/5
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
        public ActionResult GetCertification(bool active)
        {
            var Year = _certificationsRepository.GetAllCertifications().ToList().Where(a => a.IsActive == active);
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.CertificationName,
                Active=x.IsActive? "Active" : "InActive"
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintCertification(bool active)
        {
            return View(_certificationsRepository.GetAllCertifications().ToList().Where(a => a.IsActive == active));
        }
    }
}
