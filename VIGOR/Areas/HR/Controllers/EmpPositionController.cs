using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;
using ERP.Infrastructure.Repositories.HR;

namespace VIGOR.Areas.HR.Controllers
{
    public class EmpPositionController : Controller
    {
        // GET: HR/EmpPosition
        private HR_DesignationRepository _hrDesignationRepository;

        public EmpPositionController()
        {
            _hrDesignationRepository=new HR_DesignationRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: HR/EmpPosition/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: HR/EmpPosition/CreateOrUpdate
        public ActionResult CreateOrUpdate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOrUpdate(HR_Designation model)
        {
            try
            {
                model.CreatedBy = 0;
                model.CreatedOn = DateTime.Now;
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                if (_hrDesignationRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _hrDesignationRepository.Add(model);
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

        // GET: HR/EmpPosition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HR/EmpPosition/Create
        [HttpPost]
        public ActionResult Create(HR_Designation model)
        {
            try
            {
                model.CreatedBy = 0;
                model.CreatedOn=DateTime.Now;
                model.ModifiedBy = 0;
                model.ModifiedOn=DateTime.Now;
                if (_hrDesignationRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");
                    
                    return RedirectToActionPermanent("Index", "EmpPosition");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _hrDesignationRepository.Add(model);
                        return RedirectToAction("Index", "EmpPosition");
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

        // GET: HR/EmpPosition/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_hrDesignationRepository.FindById(id));
        }

        // POST: HR/EmpPosition/Edit/5
        [HttpPost]
        public ActionResult Edit(HR_Designation model)
        {
            try
            {
                
                model.ModifiedBy = 0;
                model.ModifiedOn = DateTime.Now;
                if (_hrDesignationRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicated data Is Not allowed");

                    return RedirectToActionPermanent("Index", "EmpPosition");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _hrDesignationRepository.Edit(model);
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

        // GET: HR/EmpPosition/Delete/5
        public ActionResult Delete(string id)
        {
            _hrDesignationRepository.Remove(id);
            return RedirectToAction("Index");
        }

        // POST: HR/EmpPosition/Delete/5
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
        public ActionResult GetEmpPosition(bool active)
        {
            var positionData = _hrDesignationRepository.GetAllHR_Designation().Where(a=>a.isactive==active).ToList();
            var collection = positionData.Select(x => new
            {
                Id = x.DesignationId,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
    }
}
