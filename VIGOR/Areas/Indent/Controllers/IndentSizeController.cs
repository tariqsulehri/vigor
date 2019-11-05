using ERP.Infrastructure.Repositories.Indenting;
 using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class IndentSizeController : Controller
    {
        IndSizeRepository indSizeRepository;
        public IndentSizeController()
        {
            indSizeRepository = new IndSizeRepository();
        }
        // GET: Indent/GoodsForwarder
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/GoodsForwarder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/GoodsForwarder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/GoodsForwarder/Create
        [HttpPost]
        public ActionResult Create(IndSize model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (indSizeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    indSizeRepository.Add(model);
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

        // GET: Indent/GoodsForwarder/Edit/5
        public ActionResult Edit(int id)
        {
            return View(indSizeRepository.FindById(id));
        }

        // POST: Indent/GoodsForwarder/Edit/5
        [HttpPost]
        public ActionResult Edit(IndSize model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (indSizeRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                indSizeRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/GoodsForwarder/Delete/5
        public ActionResult Delete(int id)
        {
            IndSize model = new IndSize();
            model.Id = id;
            indSizeRepository.Remove(model);
            return null;
        }

        // POST: Indent/GoodsForwarder/Delete/5
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
        public ActionResult GetIndentSize()
        {
            var Year = indSizeRepository.GetAllIndSizes().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
      
    }
}
