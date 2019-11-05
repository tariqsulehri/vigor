using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Indenting.IndentExport;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;

namespace VIGOR.Areas.Indent.Controllers.IndentExport
{
    public class IndExportInquiryController : Controller
    {
        private IndExportInquiryRepository _indExportInquiryRepository;

        public IndExportInquiryController()
        {
            _indExportInquiryRepository = new IndExportInquiryRepository();
        }
        // GET: Indent/IndExportInquiry
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime fromDate, DateTime toDate, Int32? commodityId,
            Int32? departmentID, Int32? CustomerId)
        {
            ViewBag.IndExportInquiryList = _indExportInquiryRepository.GetAllExportInquires()
                .Where(a => a.CommodityTypeId.Equals(commodityId) || commodityId.Equals(0) || commodityId.Equals(null))
                .Where(a => a.DepartmentID.Equals(departmentID) || departmentID.Equals(0) || departmentID.Equals(null))
                .Where(a => a.CustomerId.Equals(CustomerId) || CustomerId.Equals(0) || CustomerId.Equals(null))
                .Where(a => a.InquiryDate >= fromDate && a.InquiryDate <= toDate);

            return View();
        }
        // GET: Indent/IndExportInquiry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult AddAttachments()
        {
            return View();
        }

        public ActionResult ReviewInquiry()
        {
            return View();
        }
        // GET: Indent/IndExportInquiry/Create
        public ActionResult Create(int DepartmentID, int CommodityTypeId)
        {
            IndExportInquiry model = new IndExportInquiry();
            model.InquiryDate = DateTime.Now;
            model.InquiryKey = _indExportInquiryRepository.InquiryKey(model);
            model.DepartmentID = DepartmentID;
            model.CommodityTypeId = CommodityTypeId;
            model.InquiryStatus = Convert.ToChar("Y");
            return View(model);
        }

        // POST: Indent/IndExportInquiry/Create
        [HttpPost]
        public ActionResult Create(IndExportInquiry model)
        {
            model.CreatedOn = DateTime.Now;
            model.ModifiedOn = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    model.IsClosed = "C";// 'C';
                    _indExportInquiryRepository.Add(model);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                }
            }
            return View(model);
        }

        // GET: Indent/IndExportInquiry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indent/IndExportInquiry/Edit/5
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

        // GET: Indent/IndExportInquiry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/IndExportInquiry/Delete/5
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
