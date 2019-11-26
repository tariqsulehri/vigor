using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Core.Models.Indenting;


namespace VIGOR.Areas.Indent.Controllers
{
    public class IndGeneralDescriptionsController : Controller
    {
        IndGeneralDescriptionsRepository _indGeneralDescriptionsRepository;
        IndPriceTermsRepository _indPriceTermsRepository;
        public IndGeneralDescriptionsController()
        {
            _indPriceTermsRepository = new IndPriceTermsRepository();
            _indGeneralDescriptionsRepository = new IndGeneralDescriptionsRepository();
        }
        // GET: Indent/IndGeneralDescriptions
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/IndGeneralDescriptions/Details/5
        public ActionResult LookUpIndGeneralDescriptions(string type)
        {

            List<IndGeneralDescriptions> _IndGeneralDescriptions = new List<IndGeneralDescriptions>();//<IndGeneralDescriptions>();

            if (type.Trim() == "PriceTerms")
            {
                var priceTerms = _indPriceTermsRepository.GetAllIndPriceTerms();
                foreach (var indPriceTermse in priceTerms)
                {
                    var GD = new IndGeneralDescriptions()
                    {
                        Id = indPriceTermse.Id,
                        Description = indPriceTermse.Description
                    };
                    _IndGeneralDescriptions.Add(GD);
                }
                return View(_IndGeneralDescriptions);
            }
            return View(_indGeneralDescriptionsRepository.GetAllIndGeneralDescriptions());
        }

        // GET: Indent/IndGeneralDescriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/IndGeneralDescriptions/Create
        [HttpPost]
        public ActionResult Create(IndGeneralDescriptions model)
        {
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            try
            {
                if (_indGeneralDescriptionsRepository.IsDuplicate(model))
                {
                    ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    _indGeneralDescriptionsRepository.Add(model);
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

        // GET: Indent/IndGeneralDescriptions/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_indGeneralDescriptionsRepository.FindById(id));
        }

        // POST: Indent/IndGeneralDescriptions/Edit/5
        [HttpPost]
        public ActionResult Edit(IndGeneralDescriptions model)
        {
            model.ModifiedBy = 0;
            model.ModifiedOn = DateTime.Now;
            if (_indGeneralDescriptionsRepository.IsDuplicate(model))
            {
                ModelState.AddModelError(string.Empty, "Duplicate Data is not Allowed");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                _indGeneralDescriptionsRepository.Edit(model);
                return null;
            }
            else
            {
                return View(model);
            }
        }

        // GET: Indent/IndGeneralDescriptions/Delete/5
        public ActionResult Delete(int id)
        {
            IndGeneralDescriptions model = new IndGeneralDescriptions();
            model.Id = id;
            _indGeneralDescriptionsRepository.Remove(model);
            return null;
        }

        // POST: Indent/IndGeneralDescriptions/Delete/5
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
        public ActionResult GetIndGeneralDescriptions()
        {
            var Year = _indGeneralDescriptionsRepository.GetAllIndGeneralDescriptions().ToList();
            var collection = Year.Select(x => new
            {
                Id = x.Id,
                Title = x.Description
            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintIndGeneralDescriptions()
        {
            return View(_indGeneralDescriptionsRepository.GetAllIndGeneralDescriptions().ToList());
        }
    }
}
