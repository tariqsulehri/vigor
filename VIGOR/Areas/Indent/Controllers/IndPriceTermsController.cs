using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Core.Models.Indenting;


namespace VIGOR.Areas.Indent.Controllers
{
    public class IndPriceTermsController : Controller
    {
        IndPriceTermsRepository _indPriceTermsRepository;
        public IndPriceTermsController()
        {
            _indPriceTermsRepository = new IndPriceTermsRepository();
        }
        // GET: Indent/IndPriceTerms
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/IndPriceTerms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/IndPriceTerms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/IndPriceTerms/Create
        [HttpPost]
        public ActionResult Create(IndPriceTerms model)
        {
           // model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                //if (_indPriceTermsRepository.IsDuplicate(model))
                //{
                //    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                //    return View(model);
                //}
                if (ModelState.IsValid)
                {
                    _indPriceTermsRepository.Add(model);
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

        // GET: Indent/IndPriceTerms/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_indPriceTermsRepository.FindById(id));
        }

        // POST: Indent/IndPriceTerms/Edit/5
        [HttpPost]
        public ActionResult Edit(IndPriceTerms model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_indPriceTermsRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _indPriceTermsRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/IndPriceTerms/Delete/5
        public ActionResult Delete(int id)
        {
            IndPriceTerms indPriceTerms= new IndPriceTerms();
            indPriceTerms.Id = id;
            _indPriceTermsRepository.Remove(indPriceTerms);
            return null;
        }

        // POST: Indent/IndPriceTerms/Delete/5
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
        public ActionResult GetIndPriceTerms()
        {
            var Year = _indPriceTermsRepository.GetAllIndPriceTerms().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description,
                Abbrivation = x.Abbrivation
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintIndPriceTerms()
        {
            return View(_indPriceTermsRepository.GetAllIndPriceTerms().ToList());
        }
    }
}
