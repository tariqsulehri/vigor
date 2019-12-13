using ERP.Infrastructure.Repositories.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;
using ERP.Infrastructure;
using ERP.Core.Models.Common;

namespace VIGOR.Areas.HR.Controllers
{
    public class GazzettedDayController : Controller
    {
        private HR_GazzettedDaysRepository _HR_GazzettedDaysRepository;
        private ErpDbContext _db;
        public GazzettedDayController()
        {
            _HR_GazzettedDaysRepository = new HR_GazzettedDaysRepository();
            _db = new ErpDbContext();
        }
        // GET: HR/GazzettedDay
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/GazzettedDay/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/GazzettedDay/Create
        public ActionResult Create()
        {
            HR_GazzettedDays obj = new HR_GazzettedDays();
            Company company = _db.Companies.FirstOrDefault();

            obj.companyID = company.Id;
            obj.CompanyKey = company.Id.ToString().PadLeft(3,'0');
            return View(obj);
        }

        // POST: HR/GazzettedDay/Create
        [HttpPost]
        public ActionResult Create(HR_GazzettedDays model)
        {
            try
            {
                model.GazzettedDateId = GetGazzettedDaysID();
                model.TranYear = GetTranYearID();
                ModelState.Remove("GazzettedDateId");
                ModelState.Remove("TranYear");
                model.CreatedBy = 0;
                model.CreatedOn = DateTime.Now;
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                if (_HR_GazzettedDaysRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _HR_GazzettedDaysRepository.Add(model);
                        return null;
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: HR/GazzettedDay/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_HR_GazzettedDaysRepository.FindById(id));
        }

        // POST: HR/GazzettedDay/Edit/5
        [HttpPost]
        public ActionResult Edit(HR_GazzettedDays model)
        {
            try
            {
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                if (_HR_GazzettedDaysRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");

                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _HR_GazzettedDaysRepository.Edit(model);
                        return null;
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            catch
            {
                return View(model);
            }
        }

        // GET: HR/GazzettedDay/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/GazzettedDay/Delete/5
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
        public ActionResult GetGazzettedDay(bool active)
        {
            var positionData = _HR_GazzettedDaysRepository.GetAllHR_GazzettedDays().Where(a => a.IsActive == active).ToList();
            var collection = positionData.Select(x => new
            {
                Id = x.GazzettedDateId,
                From = x.GazzettedDateFrom.ToString(),
                To = x.GazzettedDateTo.ToString(),
                Descp = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public string GetGazzettedDaysID()
        {
            int maxno = _db.HR_GazzettedDays.Count();
            maxno = maxno + 1;
            string SerialID = DateTime.Today.Year + maxno.ToString().PadLeft(2, '0');
            return SerialID;
        }
        public string GetTranYearID()
        {
            var getYear = DateTime.Today.Year;
            var year = 2019;
            string getid = "0000";
            if (year == getYear)
            {
                getid = "0001";
            }
            else
            {
                getid = getid + 1;
            }
            return getid;
        }
    }
}
