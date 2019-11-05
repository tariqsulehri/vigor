using ERP.Core.Models.Indenting;
using ERP.Infrastructure.Repositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class ExchangeRatesController : Controller
    {
        ExchangeRatesRepository _exchangeRatesRepository;
        public ExchangeRatesController()
        {
            _exchangeRatesRepository = new ExchangeRatesRepository();
        }
        // GET: Indent/ExchangeRates
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/ExchangeRates/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/ExchangeRates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/ExchangeRates/Create
        [HttpPost]
        public ActionResult Create(ExchangeRates model)
        {
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                //if (_exchangeRatesRepository.IsDuplicate(model))
                //{
                //    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                //    return View(model);
                //}
                if (ModelState.IsValid)
                {
                    _exchangeRatesRepository.Add(model);
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

        // GET: Indent/ExchangeRates/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_exchangeRatesRepository.FindById(id));
        }

        // POST: Indent/ExchangeRates/Edit/5
        [HttpPost]
        public ActionResult Edit(ExchangeRates model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            //if (_exchangeRatesRepository.IsDuplicate(model))
            //{
            //    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
            //    return View(model);
            //}
            if (ModelState.IsValid)
            {
                _exchangeRatesRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/ExchangeRates/Delete/5
        public ActionResult Delete(int id)
        {
            ExchangeRates model = new ExchangeRates();
            model.Id = id;
            _exchangeRatesRepository.Remove(model);
            return null;
        }

        // POST: Indent/ExchangeRates/Delete/5
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
        public ActionResult GetExchangeRates()
        {
            var Year = _exchangeRatesRepository.GetAllExchangeRates().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Currency.Description,
                buy = x.BuyingRate,
                sell=x.SellingRate,
                Date = x.ExRDate.ToString()
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintExchangeRates()
        {
            return View(_exchangeRatesRepository.GetAllExchangeRates().ToList());
        }
    }
}
