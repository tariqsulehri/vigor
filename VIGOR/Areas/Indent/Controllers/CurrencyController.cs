using ERP.Core.Models.Indenting;
using ERP.Infrastructure.Repositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class CurrencyController : Controller
    {
        CurrencyRepository _currencyRepository;
        public CurrencyController()
        {
            _currencyRepository = new CurrencyRepository();
        }
        // GET: Indent/Currency
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/Currency/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/Currency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/Currency/Create
        [HttpPost]
        public ActionResult Create(Currency model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_currencyRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _currencyRepository.Add(model);
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

        // GET: Indent/Currency/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_currencyRepository.FindById(id));
        }

        // POST: Indent/Currency/Edit/5
        [HttpPost]
        public ActionResult Edit(Currency model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_currencyRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _currencyRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/Currency/Delete/5
        public ActionResult Delete(int id)
        {
            Currency model = new Currency();
            model.Id = id;
            _currencyRepository.Remove(model);
            return null;
        }

        // POST: Indent/Currency/Delete/5
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
        public ActionResult GetCurrency()
        {
            var Year = _currencyRepository.GetAllCurrencys().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description,
                Symbol=x.Symbol
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintCurrency()
        {
            return View(_currencyRepository.GetAllCurrencys().ToList());
        }
    }
}
