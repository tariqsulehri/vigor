using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Core.Models.Indenting;


namespace VIGOR.Areas.Indent.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _productRepository;
        public ProductController()
        {
            _productRepository = new ProductRepository();

        }
        // GET: Indent/Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/Product/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_productRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _productRepository.Add(model);
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

        // GET: Indent/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_productRepository.FindById(id));
        }

        // POST: Indent/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_productRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _productRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product model = new Product();
            model.Id = id;
            _productRepository.Remove(model);
            return null;
        }

        // POST: Indent/Product/Delete/5
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
        public ActionResult GetProduct()
        {
            var Year = _productRepository.GetAllProduct().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description,
                commodity=x.CommodityType.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintProduct()
        {
            return View(_productRepository.GetAllProduct().ToList());
        }
    }
}
