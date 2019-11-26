using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Indenting.InspExport;
using ERP.Infrastructure.Repositories.Indenting.InspExport;

namespace VIGOR.Areas.Indent.Controllers
{
    public class ExpInspFabricController : Controller
    {
        private FabricInspReportExportRepository _fabricInspReportExportRepository;

        public ExpInspFabricController()
        {
            _fabricInspReportExportRepository=new  FabricInspReportExportRepository();
        }
        // GET: Indent/ExpInspFabric
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime? fromDate, DateTime? toDate, Int32? inspectionType, string indenttNo)
        {
            //ViewBag.FabricInspection = _fabricInspReportLocalRepository.GetAllFabricInspReportLocal()
            //    .Where(a => a.FabInspTypeId.Equals(inspectionType) || inspectionType.Equals(0) || inspectionType.Equals(null))
            //    .Where(a => a.IndentKey.Equals(indenttNo) || indenttNo.Equals(string.Empty))
            //    .Where(a => a.InspectionDate >= fromDate && a.InspectionDate <= toDate);
            //ViewBag.FromDate = fromDate;
            //ViewBag.Todate = toDate;
            return View();
        }
        // GET: Indent/ExpInspFabric/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/ExpInspFabric/Create
        public ActionResult Create()
        {
            FabricInspReportExport model = new FabricInspReportExport();
            model.InspectionSerialNoID = _fabricInspReportExportRepository.GetInspectionSerialNoID('E');
            model.InspectionDate=DateTime.Now;
            return View(model);
        }

        // POST: Indent/ExpInspFabric/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Indent/ExpInspFabric/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indent/ExpInspFabric/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Indent/ExpInspFabric/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/ExpInspFabric/Delete/5
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
