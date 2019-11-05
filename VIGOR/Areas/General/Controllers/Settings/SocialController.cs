using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Common.Party;
using ERP.Infrastructure.Repositories.Common.PatryCommon;
namespace VIGOR.Areas.General.Controllers.Settings
{
    public class SocialController : Controller
    {
        SocialRepository _socialRepository;
        public SocialController()
        {
            _socialRepository = new SocialRepository();
        }
        // GET: General/Social
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/Social/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/Social/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/Social/Create
        [HttpPost]
        public ActionResult Create(Social model)
        {
            try
            {
                if (_socialRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _socialRepository.Add(model);
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

        // GET: General/Social/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_socialRepository.FindById(id));
        }

        // POST: General/Social/Edit/5
        [HttpPost]
        public ActionResult Edit(Social model)
        {
            if (_socialRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _socialRepository.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: General/Social/Delete/5
        public ActionResult Delete(int id)
        {
            _socialRepository.Remove(id);
            return null;
        }

        // POST: General/Social/Delete/5
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
        public ActionResult GetSocial()
        {
            var Year = _socialRepository.GetAllSocials().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Detail
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintSocial()
        {
            return View(_socialRepository.GetAllSocials());
        }
    }
}
