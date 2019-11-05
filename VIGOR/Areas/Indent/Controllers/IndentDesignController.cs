using ERP.Core.Models.Indenting;
using ERP.Infrastructure.Repositories.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers
{
    public class IndentDesignController : Controller
    {
        IndDesignRepository indDesignRepository;
        public IndentDesignController()
        {
            indDesignRepository = new IndDesignRepository();
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
        public ActionResult Create(IndDesign model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (indDesignRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    indDesignRepository.Add(model);
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
            return View(indDesignRepository.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(IndDesign model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (indDesignRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                indDesignRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            IndDesign model = new IndDesign();
            model.Id = id;
            indDesignRepository.Remove(model);
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
        public ActionResult GetIndDesign()
        {
            var Year = indDesignRepository.GetAllIndDesigns().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Symbol = x.Symbol,
                Title = x.Description

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }

    }
}
