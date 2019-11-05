using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers.IndentDomestic
{
    public class IndDomesticDispatchScheduleController : Controller
    {
        IndDomesticDispatchScheduleRepository _indDomesticDispatchScheduleRepository;
        public IndDomesticDispatchScheduleController()
        {
            _indDomesticDispatchScheduleRepository = new IndDomesticDispatchScheduleRepository();
        }
        // GET: Indent/IndDomesticDispatchSchedule
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dispatch()
        {
            return View();
        }
        // GET: Indent/IndDomesticDispatchSchedule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/IndDomesticDispatchSchedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/IndDomesticDispatchSchedule/Create
        [HttpPost]
        public ActionResult Create(IndDomesticDispatchSchedule model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                //if (_indDomesticDispatchScheduleRepository.IsDuplicate(model))
                //{
                //    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                //    return View(model);
                //}
                if (ModelState.IsValid)
                {
                    _indDomesticDispatchScheduleRepository.Add(model);
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

        // GET: Indent/IndDomesticDispatchSchedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indent/IndDomesticDispatchSchedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Indent/IndDomesticDispatchSchedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/IndDomesticDispatchSchedule/Delete/5
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
    }
}
