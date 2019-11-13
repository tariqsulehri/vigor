using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.IRepositories.Indenting.IndentDomestic;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.Inspection;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using ERP.Infrastructure.Repositories.Indenting.Inspection;
using ERP.Infrastructure.Repositories.Parties;

namespace VIGOR.Areas.Indent.Controllers
{
    public class YarnInspectionController : Controller
    {
        private YarnInspectionRepository _inspectionRepository;
        private IndDomesticRepository _indDomesticRepository;
        private FinPartyRepository _finPartyRepository;
        private IndentInspectionRepository _indentInspectionRepository;

        public YarnInspectionController()
        {
            _inspectionRepository = new YarnInspectionRepository();
            _finPartyRepository = new FinPartyRepository();
            _indDomesticRepository = new IndDomesticRepository();
            _indentInspectionRepository = new IndentInspectionRepository();
        }
        // GET: Indent/YarnInspection
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
        [HttpGet]
        public ActionResult Attachment(int Id)
        {
            var inspection = _inspectionRepository.FindById(Id);
            var indInsp = _indentInspectionRepository.GetAllIndInspection()
                .Where(a => a.IndentId == inspection.IndentId).ToList();
            //var indDomestics = _indDomesticRepository.GetAllIndDomectic().Where(a => a.CustomerIDasSeller == inspection.CustomerIDasSeller && a.CommodityTypeId == inspection.CommodityId && a.IsApproved && a.isClosed != true).ToList();
            var indDomestics = _indDomesticRepository.GetAllIndDomectic().Where(a => a.CustomerIDasSeller == inspection.CustomerIDasSeller && a.CommodityTypeId == inspection.CommodityId).ToList();

            foreach (var item in indDomestics)
            {
                foreach (var indentInspection in indInsp)
                {
                    if (item.Id == indentInspection.IndentId)
                    {
                        item.IsAllow = true;
                    }
                }
            }

            ViewBag.indDomestics = indDomestics;

            return View(inspection);
        }
        // GET: Indent/YarnInspection/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Attachment(YarnInspection model)
        {
            model = _inspectionRepository.FindById(model.Id);

            IndentInspection indentInspection;
            var indentInspectionKeysList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("isAllow"))
                    indentInspectionKeysList.Add(k.ToString());
            }
            foreach (var Key in indentInspectionKeysList)
            {
                var index = "0";
                index = Key.Replace("][isAllow]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][isAllow]"))
                {
                    indentInspection = new IndentInspection();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][isAllow]"]))
                    {
                        indentInspection.IndentKey = (Request.Form["det[" + index + "][Contract]"]);
                        indentInspection.SalesContractDetail = (Request.Form["det[" + index + "][DetailId]"]);
                        indentInspection.CommodityTypeId = model.CommodityId;
                        indentInspection.IndentId = model.IndentId;// model.SalesContractDetailID
                        indentInspection.InspSrno = model.InspectionSerialID;
                        indentInspection.LocalDispatchKey = model.IndentDomestic.IndentKey;
                        indentInspection.DispatchId = 27;
                    }
                    try
                    {
                        _indentInspectionRepository.Add(indentInspection);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            return null;
        }
        // GET: Indent/YarnInspection/Create
        public ActionResult Create()
        {
            YarnInspection modeInspection = new YarnInspection();
            modeInspection.InspectionSerialID = _indentInspectionRepository.GetInspectionSerialID();
            modeInspection.RegisterNo = modeInspection.InspectionSerialID;
            modeInspection.InspectionDate = DateTime.Now;
            return View(modeInspection);
        }

        // POST: Indent/YarnInspection/Create
        [HttpPost]
        public ActionResult Create(YarnInspection modeInspection, IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                ModelState.Remove("IndentKey");
                modeInspection.InspectionSerialID = _indentInspectionRepository.GetInspectionSerialID();
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

        // GET: Indent/YarnInspection/Edit/5
        public ActionResult Edit(int id)
        {
            var zed = _inspectionRepository.FindById(id);
            return View(_inspectionRepository.FindById(id));
        }

        // POST: Indent/YarnInspection/Edit/5
        [HttpPost]
        public ActionResult Edit(YarnInspection modeInspection, IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                ModelState.Remove("IndentKey");
                if (ModelState.IsValid)
                {
                    modeInspection.IndentKey = _indDomesticRepository.FindById(modeInspection.IndentId).IndentKey;
                    modeInspection.CustomerSellerName =
                        _finPartyRepository.FindById(modeInspection.CustomerIDasSeller).Title;
                    modeInspection.CustomerBuyerName =
                        _finPartyRepository.FindById(modeInspection.CustomerIDasBuyer).Title;
                    modeInspection.ModifiedOn = DateTime.Now;
                    modeInspection.CustomerId = modeInspection.CustomerIDasBuyer;
                    modeInspection.ShipmentScheduleId = 26;
                    modeInspection = GetYarnInspectionDetail(modeInspection);
                    _inspectionRepository.Edit(modeInspection);
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
                    return null;
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

        // GET: Indent/YarnInspection/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/YarnInspection/Delete/5
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