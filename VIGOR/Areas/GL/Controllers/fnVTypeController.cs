using ERP.Infrastructure.Repositories.FinRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.IRepositories.FinanceIRepositories;
using ERP.Core.Models.Finance;

namespace VIGOR.Areas.GL.Controllers
{
    public class fnVTypeController : Controller
    {
        FinVTypeRepository _finVTypeRepository;
       
        public fnVTypeController()
        {
            _finVTypeRepository = new FinVTypeRepository();
           
        }
        // GET: GL/fnVType
        public ActionResult Index()
        {
            return View();
        }

        // GET: GL/fnVType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GL/fnVType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GL/fnVType/Create
        [HttpPost]
        public ActionResult Create(FinVType model)
        {
            try
            {
                if (_finVTypeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    model.Key = model.Key.PadLeft(3, '0');
                    _finVTypeRepository.Add(model);
                  
                    return null;
                }
                else
                {
                    return View(model);
                }
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
        }

        // GET: GL/fnVType/Edit/5
        public ActionResult Edit(int id)
        {
            FinVType model = new FinVType();
            model = _finVTypeRepository.FindById(id);
            model.Key = model.Key.TrimStart(new Char[] { '0' }); ;
            return View(model);
        }

        // POST: GL/fnVType/Edit/5
        [HttpPost]
        public ActionResult Edit(FinVType model)
        {
            try
            {
                if (_finVTypeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    model.Key = model.Key.PadLeft(3, '0');
                    _finVTypeRepository.Edit(model);
                    return null;
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
        }

        // GET: GL/fnVType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GL/fnVType/Delete/5
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
        public ActionResult GetfnVType()
        {
            var Year = _finVTypeRepository.GetAllTypes().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Vtype
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
    }
}
