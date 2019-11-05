using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Core.Models.Indenting;


namespace VIGOR.Areas.Indent.Controllers
{
    public class GoodsForwarderController : Controller
    {
        GoodsForwarderRepository _goodsForwarderRepository;
        public GoodsForwarderController()
        {
            _goodsForwarderRepository = new GoodsForwarderRepository();
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
        public ActionResult Create(GoodsForwarder model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_goodsForwarderRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _goodsForwarderRepository.Add(model);
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
            return View(_goodsForwarderRepository.FindById(id));
        }

        // POST: Indent/GoodsForwarder/Edit/5
        [HttpPost]
        public ActionResult Edit(GoodsForwarder model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_goodsForwarderRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _goodsForwarderRepository.Edit(model);
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
            GoodsForwarder model= new GoodsForwarder();
            model.Id = id;
            _goodsForwarderRepository.Remove(model);
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
        public ActionResult GetGoodsForwarder()
        {
            var Year = _goodsForwarderRepository.GetAllGoodsForwarder().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Name
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintGoodsForwarder()
        {
            return View(_goodsForwarderRepository.GetAllGoodsForwarder().ToList());
        }
    }
}
