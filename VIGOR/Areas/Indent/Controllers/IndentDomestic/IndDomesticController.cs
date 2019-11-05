using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers.IndentDomestic
{
    public class IndDomesticController : Controller
    {
        IndDomesticRepository _indDomesticRepository;
        public IndDomesticController()
        {
            _indDomesticRepository = new IndDomesticRepository();
        }
        // GET: Indent/IndDomestic
        public ActionResult Index()
        {
            return View();
        }

        // GET: Indent/IndDomestic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/IndDomestic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/IndDomestic/Create
        [HttpPost]
        public ActionResult Create(IndDomestic model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedOn = DateTime.Now;
                    model.CreatedBy = 1;
                    model.ModifiedOn = DateTime.Now;
                    _indDomesticRepository.Add(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        // GET: Indent/IndDomestic/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_indDomesticRepository.FindById(id));
        }

        // POST: Indent/IndDomestic/Edit/5
        [HttpPost]
        public ActionResult Edit(IndDomestic model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedOn = DateTime.Now;
                    model.CreatedBy = 1;
                    model.ModifiedOn = DateTime.Now;
                    _indDomesticRepository.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        // GET: Indent/IndDomestic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/IndDomestic/Delete/5
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
    }
}
