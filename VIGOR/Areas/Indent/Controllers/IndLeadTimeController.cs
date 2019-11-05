using ERP.Core.Models.Indenting;
using ERP.Infrastructure.Repositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class IndLeadTimeController : Controller
    {
        IndLeadTimeRepository _indLeadTimeRepository;
        public IndLeadTimeController()
        {
            _indLeadTimeRepository = new IndLeadTimeRepository();
        }
        // GET: Indent/IndLeadTime
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/IndLeadTime/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/IndLeadTime/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/IndLeadTime/Create
        [HttpPost]
        public ActionResult Create(IndLeadTime model)
        {
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_indLeadTimeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _indLeadTimeRepository.Add(model);
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

        // GET: Indent/IndLeadTime/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_indLeadTimeRepository.FindById(id));
        }

        // POST: Indent/IndLeadTime/Edit/5
        [HttpPost]
        public ActionResult Edit(IndLeadTime model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_indLeadTimeRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _indLeadTimeRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/IndLeadTime/Delete/5
        public ActionResult Delete(int id)
        {
            IndLeadTime model = new IndLeadTime();
            model.Id = id;
            _indLeadTimeRepository.Remove(model);
            return null;
        }

        // POST: Indent/IndLeadTime/Delete/5
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
        public ActionResult GetIndLeadTime()
        {
            var Year = _indLeadTimeRepository.GetAllIndLeadTime().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintIndLeadTime()
        {
            return View(_indLeadTimeRepository.GetAllIndLeadTime().ToList());
        }
    }
}
