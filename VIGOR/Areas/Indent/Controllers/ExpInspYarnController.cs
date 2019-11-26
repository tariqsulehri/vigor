using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting.Inspection;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using ERP.Infrastructure.Repositories.Indenting.Inspection;
using ERP.Infrastructure.Repositories.Parties;

namespace VIGOR.Areas.Indent.Controllers
{
    public class ExpInspYarnController : Controller
    {
        private YarnInspectionRepository _inspectionRepository;
        private IndDomesticRepository _indDomesticRepository;
        private FinPartyRepository _finPartyRepository;
        private IndentInspectionRepository _indentInspectionRepository;

        public ExpInspYarnController()
        {
            _inspectionRepository = new YarnInspectionRepository();
            _finPartyRepository = new FinPartyRepository();
            _indDomesticRepository = new IndDomesticRepository();
            _indentInspectionRepository = new IndentInspectionRepository();
        }

        // GET: Indent/ExpInspYarn
        public ActionResult Index()
        {
            ViewBag.FromDate = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.Todate = LoggedinUser.CurrentFiscalYear.EndDate;

            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime? fromDate, DateTime? toDate, Int32? CustomerIDasSeller,
            Int32? CustomerIDasBuyer, Int32? CommodityId, string regNo, Int32? InspReportTypeId,
            string indNo, Int32? QcInspectorID)
        {
            ViewBag.YarnInspection = _inspectionRepository.GetAllYarnInspections()
                .Where(a => a.CustomerIDasSeller.Equals(CustomerIDasSeller) || CustomerIDasSeller.Equals(0) || CustomerIDasSeller.Equals(null))
                .Where(a => a.CommodityId.Equals(CommodityId) || CommodityId.Equals(0) || CommodityId.Equals(null))
                .Where(a => a.InspReportTypeId.Equals(InspReportTypeId) || InspReportTypeId.Equals(0) || InspReportTypeId.Equals(null))
                .Where(a => a.QcInspectorID.Equals(QcInspectorID) || QcInspectorID.Equals(0) || QcInspectorID.Equals(null))
                .Where(a => a.RegisterNo.Equals(regNo) || regNo.Equals(string.Empty))
                .Where(a => a.IndentKey.Equals(indNo) || indNo.Equals(string.Empty))
                .Where(a => a.CustomerIDasBuyer.Equals(CustomerIDasBuyer) || CustomerIDasBuyer.Equals(0) || CustomerIDasBuyer.Equals(null))
                .Where(a => a.InspectionDate >= fromDate && a.InspectionDate <= toDate);


            ViewBag.FromDate = fromDate;
            ViewBag.Todate = toDate;
            return View();
        }

        // GET: Indent/ExpInspYarn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/ExpInspYarn/Create
        public ActionResult Create()
        {
            YarnInspection modeInspection = new YarnInspection();
            modeInspection.InspectionSerialID = _inspectionRepository.GetInspectionSerialID('E');
            modeInspection.RegisterNo = modeInspection.InspectionSerialID;
            modeInspection.InspectionDate = DateTime.Now;
            modeInspection.InspectionForMarket = 'E';
            return View(modeInspection);
        }

        // POST: Indent/ExpInspYarn/Create
        [HttpPost]
        public ActionResult Create(YarnInspection modeInspection, IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                ModelState.Remove("IndentKey");
                modeInspection.InspectionSerialID = _inspectionRepository.GetInspectionSerialID('E');
                modeInspection.RegisterNo = modeInspection.InspectionSerialID;
                if (ModelState.IsValid)
                {
                    modeInspection.IndentKey = _indDomesticRepository.FindById(modeInspection.IndentId).IndentKey;
                    modeInspection.CustomerSellerName =
                        _finPartyRepository.FindById(modeInspection.CustomerIDasSeller).Title;
                    modeInspection.CustomerBuyerName =
                        _finPartyRepository.FindById(modeInspection.CustomerIDasBuyer).Title;

                    modeInspection.CreatedOn = DateTime.Now;
                    modeInspection.ModifiedOn = DateTime.Now;
                    modeInspection.CustomerId = modeInspection.CustomerIDasBuyer;
                    modeInspection.ShipmentScheduleId = 26;
                    modeInspection = GetYarnInspectionDetail(modeInspection);
                    _inspectionRepository.Add(modeInspection);
                    foreach (var file in files)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            foreach (var item in modeInspection.YarnInspectionAttachments)
                            {
                                string filename = Path.GetExtension(file.FileName);
                                file.SaveAs(Path.Combine(Server.MapPath("~/File"), filename + Path.GetExtension(file.FileName)));
                                modeInspection.YarnInspectionAttachments.Remove(item);
                                break;
                            }
                        }
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(modeInspection);
                }
            }
            catch (Exception e)
            {
                return View(modeInspection);
            }
        }

        // GET: Indent/ExpInspYarn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indent/ExpInspYarn/Edit/5
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

        // GET: Indent/ExpInspYarn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/ExpInspYarn/Delete/5
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

        private YarnInspection GetYarnInspectionDetail(YarnInspection model)
        {
            YarnInspectionAttachments attachments;
            YarnInspectionsUsterSetting usterSetting;
            var gridKeysList = new List<string>();
            var gridComissionList = new List<string>();
            var gridusterSetting = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("FileDescription"))
                    gridKeysList.Add(k.ToString());
                if (k.ToString().Contains("Id"))
                    gridusterSetting.Add(k.ToString());
            }
            foreach (var Key in gridKeysList)
            {
                var index = "0";
                index = Key.Replace("][FileDescription]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][FileDescription]"))
                {
                    attachments = new YarnInspectionAttachments();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][FileDescription]"]))
                    {
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][FileDescription]"]))
                        { attachments.FileDescription = (Request.Form["det[" + index + "][FileDescription]"]); }
                        attachments.YarnInspectionId = model.Id;
                        attachments.InspectionSerialID = model.InspectionSerialID;
                        attachments.FileName = "file";
                        attachments.CreatedOn = DateTime.Now;
                        attachments.DeleteOn = DateTime.Now;
                        model.YarnInspectionAttachments.Add(attachments);
                    }
                }
            }
            foreach (var Key in gridusterSetting)
            {
                var index = "0";
                index = Key.Replace("][Id]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][Id]"))
                {
                    usterSetting = new YarnInspectionsUsterSetting();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][Id]"]))
                    {
                        usterSetting.UsterResultTypeId = (Request.Form["det[" + index + "][Id]"]);
                        usterSetting.value = !string.IsNullOrEmpty(Request.Form["det[" + index + "][value]"]) ? Convert.ToDecimal(Request.Form["det[" + index + "][value]"]) : 0;
                        usterSetting.CreatedBy = 0;
                        usterSetting.ModifiedBy = 0;
                        usterSetting.CreatedOn = DateTime.Now;
                        usterSetting.ModifiedOn = DateTime.Now;
                        usterSetting.Description = "-";
                        usterSetting.YarnInspectionId = model.Id;
                        usterSetting.InspectionSerialID = model.InspectionSerialID;
                        model.YarnInspectionsUsterSetting.Add(usterSetting);
                    }
                }
            }
            return model;
        }
    }
}
