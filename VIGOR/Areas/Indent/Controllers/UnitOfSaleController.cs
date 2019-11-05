using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 using  ERP.Infrastructure.Repositories.Indenting;
using  ERP.Core.Models.Indenting;

namespace VIGOR.Areas.Indent.Controllers
{
    public class UnitOfSaleController : Controller
    {
        private UnitOfSaleRepository unitOfSaleRepository;
        public UnitOfSaleController()
        {
            unitOfSaleRepository= new UnitOfSaleRepository();
        }
        // GET: Indent/UnitOfSale
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/UnitOfSale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/UnitOfSale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/UnitOfSale/Create
        [HttpPost]
        public ActionResult Create(UnitOfSale model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (unitOfSaleRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    unitOfSaleRepository.Add(model);
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

        // GET: Indent/UnitOfSale/Edit/5
        public ActionResult Edit(int id)
        {
            return View(unitOfSaleRepository.FindById(id));
        }

        // POST: Indent/UnitOfSale/Edit/5
        [HttpPost]
        public ActionResult Edit(UnitOfSale model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (unitOfSaleRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                unitOfSaleRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/UnitOfSale/Delete/5
        public ActionResult Delete(int id)
        {
            UnitOfSale model = new UnitOfSale();
            model.Id = id;
            unitOfSaleRepository.Remove(model);
            return null;
        }

        // POST: Indent/UnitOfSale/Delete/5
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
        public ActionResult GetUnitOfSale()
        {
            var UOS = unitOfSaleRepository.GetAllUnitOfSales().ToList();
            var collection = UOS.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        
    }
}
