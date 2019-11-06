using ERP.Infrastructure.Repositories.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;
using ERP.Core.Models.Indenting;

namespace VIGOR.Areas.HR.Controllers
{
    public class DepartmentController : Controller
    {
        HrDepartmentRepository _hrDepartmentRepository;

        public DepartmentController()
        {
            _hrDepartmentRepository = new HrDepartmentRepository();
        }
        // GET: HR/Department
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HR/Department/Create
        public ActionResult Create()
        {
            HrDepartment model = new HrDepartment();
            model.CreatedOn = DateTime.Now;
            model.ModifiedOn = DateTime.Now;
            model.CreatedBy = 0;
            model.ModifiedBy = 0;

            return View(model);
        }

        // POST: HR/Department/Create
        [HttpPost]
        public ActionResult Create(HrDepartment model)
        {
            model.CreatedOn = DateTime.Now;
            model.ModifiedOn = DateTime.Now;
            model.CreatedBy = 0;
            model.ModifiedBy = 0;
            model.Title = model.DeptDescription.ToString();
            model.CompanyID = "001";
            model.isActve = "y";
            model.DeptCreatedOn = DateTime.Now;
            try
            {
                if (_hrDepartmentRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                //  if (ModelState.IsValid) {
                _hrDepartmentRepository.Add(model);
                return null;
                //}
                //    else{
                //        return View(model);
                //    }


            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        // GET: HR/Department/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_hrDepartmentRepository.FindById(id));
        }

        // POST: HR/Department/Edit/5
        [HttpPost]
        public ActionResult Edit(HrDepartment model)
        {
            model.ModifiedOn = DateTime.Now;
            model.Title = model.DeptDescription;
            try
            {
                if (_hrDepartmentRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                //if (ModelState.IsValid)
                //{
                _hrDepartmentRepository.Edit(model);
                return null;
                //}
                //else
                //{
                //    return View(model);
                //}
            }
            catch
            {
                return View(model);
            }
        }

        // GET: HR/Department/Delete/5
        public ActionResult Delete(int id)
        {
            _hrDepartmentRepository.Remove(id);
            return null;
        }

        // POST: HR/Department/Delete/5
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
        public ActionResult GetDepartment()
        {
            var Year = _hrDepartmentRepository.GetAllDepartment().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.id,
                Title = x.Title
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintDepartment()
        {
            return View(_hrDepartmentRepository.GetAllDepartment());
        }
    }
}
