using ERP.Core.Models.Indenting;
using ERP.Infrastructure.Repositories.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.General.Controllers.Settings
{
    public class QcInspectorsController : Controller
    {
        private QcInspectorRepository _QcInspectorRepository;

        public QcInspectorsController()
        {
            _QcInspectorRepository = new QcInspectorRepository();
        }
        // GET: General/QcInspectors
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/QcInspectors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/QcInspectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/QcInspectors/Create
        [HttpPost]
        public ActionResult Create(QcInspector model)
        {
            try
            {
                model.CreatedBy = 0;
                model.CreatedOn = DateTime.Now;
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                if (_QcInspectorRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _QcInspectorRepository.Add(model);
                        return null;
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: General/QcInspectors/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_QcInspectorRepository.FindById(id));
        }

        // POST: General/QcInspectors/Edit/5
        [HttpPost]
        public ActionResult Edit(QcInspector model)
        {
            try
            {
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                if (_QcInspectorRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");

                    return RedirectToActionPermanent("Index", "QcInspectors");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _QcInspectorRepository.Edit(model);
                        return null;
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            catch
            {
                return View(model);
            }
        }

        // GET: General/QcInspectors/Delete/5
        public ActionResult Delete(int id)
        {
            QcInspector model=new QcInspector();
            model.Id = id;
            _QcInspectorRepository.Remove(model);
            return RedirectToAction("Index");
        }

        // POST: General/QcInspectors/Delete/5
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
        public ActionResult GetQcInspector(bool active)
        {
            var qciData = _QcInspectorRepository.GetAllQcInspector().Where(a=>a.isActive==active).ToList();
            var collection = qciData.Select(x => new
            {
                Id = x.Id,
                Title = x.FullName
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
    }
}
