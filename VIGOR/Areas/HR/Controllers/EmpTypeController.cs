using ERP.Core.Models.HR;
using ERP.Infrastructure.Repositories.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.HR.Controllers
{
    public class EmpTypeController : Controller
    {
        private HR_EmployeeTypeRepository _HR_EmployeeTypeRepository;

        public EmpTypeController()
        {
            _HR_EmployeeTypeRepository = new HR_EmployeeTypeRepository();
        }
        // GET: HR/EmpType
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/EmpType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/EmpType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HR/EmpType/Create
        [HttpPost]
        public ActionResult Create(HR_EmployeeType model)
        {
            try
            {
                model.CreatedBy = 0;
                model.CreatedOn = DateTime.Now;
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                if (_HR_EmployeeTypeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _HR_EmployeeTypeRepository.Add(model);
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

        // GET: HR/EmpType/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_HR_EmployeeTypeRepository.FindById(id));
        }

        // POST: HR/EmpType/Edit/5
        [HttpPost]
        public ActionResult Edit(HR_EmployeeType model)
        {
            try
            {
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                if (_HR_EmployeeTypeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");

                    return RedirectToActionPermanent("Index", "QcInspectors");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _HR_EmployeeTypeRepository.Edit(model);
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

        // GET: HR/EmpType/Delete/5
        public ActionResult Delete(string id)
        {
            _HR_EmployeeTypeRepository.Remove(id);
            return RedirectToAction("Index");
        }

        // POST: HR/EmpType/Delete/5
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
        public ActionResult GetEmpType()
        {
            var EmpTypeData = _HR_EmployeeTypeRepository.GetAllHR_EmployeeType().ToList();
            var collection = EmpTypeData.Select(x => new
            {
                Id = x.EmployeeTypeID,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
    }
}
