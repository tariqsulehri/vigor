using ERP.Core.Models.Indenting;
using ERP.Infrastructure.Repositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class IndentSizeGroupController : Controller
    {
        IndSizeGroupRepository indeIndSizeGroupRepository;
        public IndentSizeGroupController()
        {
            indeIndSizeGroupRepository = new IndSizeGroupRepository();
        }
      
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult Details(int id)
        {
            return View();
        }

    
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Create(IndSizeGroup model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (indeIndSizeGroupRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    indeIndSizeGroupRepository.Add(model);
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

     
        public ActionResult Edit(int id)
        {
            return View(indeIndSizeGroupRepository.FindById(id));
        }

       
        [HttpPost]
        public ActionResult Edit(IndSizeGroup model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (indeIndSizeGroupRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                indeIndSizeGroupRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

    
        public ActionResult Delete(int id)
        {
            IndSizeGroup model = new IndSizeGroup();
            model.Id = id;
            indeIndSizeGroupRepository.Remove(model);
            return null;
        }

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
        public ActionResult GetIndentSizeGroup()
        {
            var Year = indeIndSizeGroupRepository.GetAllIndSizeGroups().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }

    }
}
