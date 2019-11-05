using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Finance;

using ERP.Infrastructure.Repositories.FinRepository;

namespace VIGOR.Areas.GL.Controllers
{
    public class fnYearController : Controller
    {
        // GET: GL/fnYear
        FinFescalYearRepository _yeaRrep;
        FinFescalYearDetailRepository _monthDetail;
        public fnYearController()
        {
            _yeaRrep = new FinFescalYearRepository();
            _monthDetail = new FinFescalYearDetailRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: GL/fnYear/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GL/fnYear/Create
        public ActionResult Create()
        {
            FinFescalYear model = new FinFescalYear();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            return View(model);
        }

        // POST: GL/fnYear/Create
        [HttpPost]
        public ActionResult Create(FinFescalYear model)
        {
            try
            {
                if (_yeaRrep.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    model.CreatedOn = System.DateTime.Now;
                    model.ModifiedOn = System.DateTime.Now;
                    model.CreatedBy = 0;
                    _yeaRrep.Add(model);
                    Months(model);
                    return null;
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View(model);
            }
        }

        // GET: GL/fnYear/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_yeaRrep.FindById(id));
        }

        // POST: GL/fnYear/Edit/5
        [HttpPost]
        public ActionResult Edit(FinFescalYear model)
        {
            if (_yeaRrep.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                model.ModifiedOn = System.DateTime.Now;
                model.ModifiedBy = 0;
                _yeaRrep.Edit(model);

                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: GL/fnYear/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GL/fnYear/Delete/5
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
        public ActionResult GetYears()
        {
            var Year = _yeaRrep.GetAllFescalYears().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Title,
                StartDate = x.StartDate.ToString("dd/MM/yyyy"),
                EndDate = x.EndDate.ToString("dd/MM/yyyy"),
                Active = x.Active==true?"Active":"InActive"

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }


        private List<FinFescalYearDetail> Months(FinFescalYear model)
        {
            FinFescalYearDetail month = new FinFescalYearDetail();
            var monthlist = MonthNames(model.StartDate, model.EndDate);
            List<DateTime> MonthNames(DateTime date1, DateTime date2)
            {
                var monthList = new List<DateTime>();
                while (date1 < date2)
                {
                    monthList.Add(date1);
                    date1 = date1.AddMonths(1);
                }
                return monthList;
            }
            foreach (var moth in monthlist)
            {
                month.StartDate = new DateTime(moth.Year, moth.Month, 1);
                month.EndDate = new DateTime(moth.Year, moth.Month, 1).AddMonths(1).AddDays(-1);
                month.Title = ToShortMonthName(moth) + " - " + moth.Year;
                month.MonthKey = month.Title;
                month.CreatedOn = DateTime.Now;
                month.ModifiedOn = DateTime.Now;
                month.Active = true;
                month.YearId = model.Id;
                _monthDetail.Add(month);
                //model.FinFescalYearDetails.Add(month);
            }
            return model.FinFescalYearDetails.ToList();
        }
        public string ToShortMonthName(DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }
}

