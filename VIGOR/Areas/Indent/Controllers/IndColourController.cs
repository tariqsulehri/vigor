using ERP.Core.Models.Indenting;
using ERP.Infrastructure.Repositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class IndColourController : Controller
    {
        IndColourRepository indeIndColourRepository;
        public IndColourController()
        {
            indeIndColourRepository = new IndColourRepository();
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
        public ActionResult Create(IndColour model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (indeIndColourRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    indeIndColourRepository.Add(model);
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
            return View(indeIndColourRepository.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(IndColour model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (indeIndColourRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                indeIndColourRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            IndColour model = new IndColour();
            model.Id = id;
            indeIndColourRepository.Remove(model);
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
        public ActionResult GetIndColour()
        {
            var Year = indeIndColourRepository.GetAllIndColours().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                ColourID=x.ColourId,
                ColourCode=x.CodeId,
                Title = x.ColourDescription,
                Description=x.Description

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }

    }
}
