using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Core.Models.Indenting;

namespace VIGOR.Areas.Indent.Controllers
{
    public class IndPaymentTermsController : Controller
    {
        IndPaymentTermsRepository _indPaymentTermsRepository;
        public IndPaymentTermsController()
        {
            _indPaymentTermsRepository = new IndPaymentTermsRepository();
        }
        // GET: Indent/IndPaymentTerms
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/IndPaymentTerms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/IndPaymentTerms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/IndPaymentTerms/Create
        [HttpPost]
        public ActionResult Create(IndPaymentTerms model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                //if (_indPaymentTermsRepository.IsDuplicate(model))
                //{
                //    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                //    return View(model);
                //}
                if (ModelState.IsValid)
                {
                    _indPaymentTermsRepository.Add(model);
                    return null;
                }
                else
                {
                    return View(model);
                }
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Indent/IndPaymentTerms/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_indPaymentTermsRepository.FindById(id));
        }

        // POST: Indent/IndPaymentTerms/Edit/5
        [HttpPost]
        public ActionResult Edit(IndPaymentTerms model)
        {

            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_indPaymentTermsRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _indPaymentTermsRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/IndPaymentTerms/Delete/5
        public ActionResult Delete(int id)
        {
            IndPaymentTerms indPaymentTerms= new IndPaymentTerms();
            indPaymentTerms.Id = id;
            _indPaymentTermsRepository.Remove(indPaymentTerms);
            return null;
        }

        // POST: Indent/IndPaymentTerms/Delete/5
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
        public ActionResult GetIndPaymentTerms()
        {
            var Year = _indPaymentTermsRepository.GetAllIndPaymentTerms().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintIndPaymentTerms()
        {
            return View(_indPaymentTermsRepository.GetAllIndPaymentTerms().ToList());
        }
    }
}
