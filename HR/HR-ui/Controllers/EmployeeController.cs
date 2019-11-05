using ERP.Infrastructure.Repositories.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;

namespace VIGOR.Areas.HR.Controllers.Settings
{
    public class EmployeeController : Controller
    {
        HrEmployeeRepository _hrEmployeeRepository;
        public EmployeeController()
        {
            _hrEmployeeRepository = new HrEmployeeRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/Employee/Create
        public ActionResult Create()
        {
            return View();
        }
        //PositionCreate
        public ActionResult PositionCreate()
        {
            return View();
        }
        //Efile
        public ActionResult Efile()
        {
            return View();
        }
        //History
        public ActionResult History()
        {
            return View();
        }
        //Intimation
        public ActionResult Intimation()
        {
            return View();
        }
        //CriticalIncident
        public ActionResult CriticalIncident()
        {
            return View();
        }
        //NonConfirmity
        public ActionResult NonConfirmity()
        {
            return View();
        }
        //LoanAdvance
        public ActionResult LoanAdvance()
        {
            return View();
        }
        //LoanAdvanceRec
        public ActionResult LoanAdvanceRec()
        {
            return View();
        }
        //Increment
        public ActionResult Increment()
        {
            return View();
        }
        //Revision
        public ActionResult Revision()
        {
            return View();
        }
        //Transfer
        public ActionResult Transfer()
        {
            return View();
        }
        //Promotion
        public ActionResult Promotion()
        {
            return View();
        }
        //Region
        public ActionResult Resign()
        {
            return View();
        }
        // POST: HR/Employee/Create
        [HttpPost]
        public ActionResult Create(HrEmployee model)
        {
            model.CreatedBy = 0;
            model.ModifiedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (ModelState.IsValid)
                {
                    _hrEmployeeRepository.Add(model);
                    return RedirectToAction("Index");
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

        // GET: HR/Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_hrEmployeeRepository.FindById(id));
        }

        // POST: HR/Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(HrEmployee model)
        {
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (ModelState.IsValid)
                {
                    _hrEmployeeRepository.Edit(model);
                    return RedirectToAction("Index");
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

        // GET: HR/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HR/Employee/Delete/5
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
        public ActionResult GetEmployee()
        {
            var Year = _hrEmployeeRepository.GetAllEmployees().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
    }
}
