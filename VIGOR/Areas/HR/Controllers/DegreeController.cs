using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.HR;
using ERP.Infrastructure.Repositories.HR;

namespace VIGOR.Areas.HR.Controllers
{
    public class DegreeController : Controller
    {
        // GET: General/Degree
        private HR_DegreeRepository _hrDegreeRepository;

        public DegreeController()
        {
            _hrDegreeRepository =new HR_DegreeRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: General/Degree/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult CreateOrUpdate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOrUpdate(HR_Degree model)
        {
            try
            {
                if (_hrDegreeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty,"Duplicate Data is not Allowed");
                    return View(model);
                }
                else
                {
                    if(ModelState.IsValid)
                    {
                        _hrDegreeRepository.Add(model);
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
        // GET: General/Degree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/Degree/Create
        [HttpPost]
        public ActionResult Create(HR_Degree model)
        {
            try
            {
                if (_hrDegreeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicate Data is Not Allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _hrDegreeRepository.Add(model);
                        RedirectToAction("Create", "Employee");
                    }
                    else
                    {
                        return View(model);
                    }

                }

                return RedirectToAction("Create","Employee");
            }
            catch
            {
                return View();
            }
        }

        // GET: General/Degree/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_hrDegreeRepository.FindById(id));
        }

        // POST: General/Degree/Edit/5
        [HttpPost]
        public ActionResult Edit(HR_Degree model)
        {
            try
            {
                if (_hrDegreeRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(String.Empty, "Duplicate Data is not allowed");
                    return View(model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _hrDegreeRepository.Edit(model);
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

        // GET: General/Degree/Delete/5
        public ActionResult Delete(string id)
        {
            _hrDegreeRepository.Remove(id);
            return null;
        }

        // POST: General/Degree/Delete/5
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

        public ActionResult GetDegreeInfo()
        {
            var result = _hrDegreeRepository.GetAllHR_Degree().ToList();
           var collection=result.Select(x=>new
           {
               Id=x.DegreeID,
               Title=x.Description
           }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
    }
}
