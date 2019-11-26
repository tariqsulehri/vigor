using AutoMapper;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentExport;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using ERP.Infrastructure.Repositories.Parties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace VIGOR.Areas.Indent.Controllers.IndentExport
{
    public class IndentExportController : Controller
    {
        private IndDomesticInquiryRepository _indDomesticInquiryRepository;
        private IndExportInquiryRepository _indExportInquiryRepository;
        private IndDomesticRepository _indDomestic;
        private FinPartyRepository _finPartyRepository;
        private FinPartyRepository _party;

        public IndentExportController()
        {
            _indDomesticInquiryRepository = new IndDomesticInquiryRepository();
            _indExportInquiryRepository = new IndExportInquiryRepository();
            _indDomestic = new IndDomesticRepository();
            _finPartyRepository = new FinPartyRepository();
            _party = new FinPartyRepository();
        }
        // GET: Indent/IndentExport
        public ActionResult Index()
        {
            ViewBag.FromDate = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.Todate = LoggedinUser.CurrentFiscalYear.EndDate;
            return View();
        }

        [HttpPost]
        public ActionResult Index(DateTime FromDate, DateTime Todate, Int32? DepartmentID, Int32? CommodityTypeId, string IndentKey)
        {
            ViewBag.FromDate = FromDate;
            ViewBag.Todate = Todate;
            if (string.IsNullOrEmpty(DepartmentID.ToString()))
                DepartmentID = 0;
            if (string.IsNullOrEmpty(CommodityTypeId.ToString()))
                CommodityTypeId = 0;

            if (DepartmentID.Equals(0) || CommodityTypeId.Equals(0))
            {
                ModelState.AddModelError("", "Invalid Search Criteria");
                return View();
            }
            ViewBag.Contracts = _indDomestic.GetAllIndDomectic()
                .Where(a => a.DepartmentID.Equals(DepartmentID) || DepartmentID.Equals(0))
                .Where(a => a.CommodityTypeId.Equals(CommodityTypeId) || CommodityTypeId.Equals(0))
                .Where(a => a.IndentKey.Trim().Equals(IndentKey) || IndentKey.Equals(string.Empty))
                .Where(a => a.IndentDate >= FromDate && a.IndentDate <= Todate);

            TempData["DepartmentID"] = DepartmentID;
            TempData["CommodityID"] = CommodityTypeId;

            return View();
        }

        public ActionResult ViewContractExport(int id)
        {
            IndExportInquiry inquiery = new IndExportInquiry();
            var domestic = _indDomestic.FindById(id);
            inquiery = _indExportInquiryRepository.FindById(domestic.InquiryId);
            domestic.CustomerIDasBuyer = inquiery.IndExportInquiryOffer.FirstOrDefault(x => x.IsFinalized == true).CustomerId;
            domestic.CustomerIDasSeller = inquiery.CustomerId;

            if (domestic.CommodityTypeId.Equals(1))
            {
                return RedirectToAction("ViewContractFabric", new { id });
            }
            else
            {
                decimal DispatchCount = new IndDomesticDispatchScheduleRepository().GetAllIndDomesticDispatchSchedule().Where(a => a.IndentId == id && a.TypeOfTransaction == "D").ToList().Count();
                if (DispatchCount > 0)
                    domestic.IsScheduleGenerated = true;
                decimal invoicedCount = new IndCommissionInvoiceRepository().GetAllIndIndCommissionInvoice().Where(a => a.IndentId == id).ToList().Count();

                if (invoicedCount > 0)
                    domestic.isInvoiced = true;

                ViewBag.IndAgent = _indDomestic.GetAgentsByIndentId(domestic.Id).ToList();

                return View(domestic);
            }

        }

        //  GET: Indent/IndentDomestic/Create
        public ActionResult Create(int id)
        {

            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            IndDomestic model = new IndDomestic();
            IndExportInquiry inquiery = new IndExportInquiry();
            inquiery = _indExportInquiryRepository.FindById(id);
            if (inquiery != null)
            {
                model.InquiryKey = inquiery.InquiryKey;
                model.InquiryId = id;
                model.OfferDate = inquiery.InquiryDate;
                model.IndentKey = _indDomestic.IndentKey("export");
                model.DepartmentID = inquiery.DepartmentID;
                model.CommodityTypeId = inquiery.CommodityTypeId;
                model.CurrencyId = inquiery.CurrencyId;
                model.Destination = inquiery.Destination;

                model.CustomerIDasBuyer = inquiery.IndExportInquiryOffer.FirstOrDefault(x => x.IsFinalized == true).CustomerId;
                model.CustomerIDasSeller = inquiery.CustomerId;

                model.CustomerId = inquiery.CustomerId;
                model.PaymenTermsId = inquiery.PaymenTermsId;
                model.IndentDate = DateTime.Now;
                model.DelDateValidUpto = DateTime.Now;
                IndDomesticDetail _detail = new IndDomesticDetail();
                foreach (var item in inquiery.IndExportInquiryDetail)
                {
                    _detail.CommodityId = item.ProductId;
                    _detail.UosID = item.UosId;
                    _detail.Quantity = item.Quantity;
                    decimal Rate = _detail.Rate = inquiery.IndExportInquiryOffer.Where(a => a.InquiryId == inquiery.Id && a.OfferedBy == model.CustomerIDasBuyer.ToString()).FirstOrDefault().OfferedRate;
                    _detail.Rate = Rate;
                    _detail.TotalValue = item.Quantity * _detail.Rate;
                    model.IndDomesticDetails.Add(_detail);
                }

                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "Invalid Inquiry");
                return RedirectToAction("index", "IndentExport");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IndDomestic model)
        {
            IndentInfo indentInfoModel = new IndentInfo();
            List<IndentAgent> getIndAgentList = new List<IndentAgent>();
            try
            {
                if (ModelState.IsValid)
                {
                    
                    model = GetDomesticDetailDetail(model);
                    getIndAgentList = GetIndAgentList(model.Id);
                    model.CreatedOn = DateTime.Now;
                    model.ModifiedOn = DateTime.Now;
                    model.LastApprovedOn = DateTime.Now;
                    model.closedDate = DateTime.Now;
                    model.confirmDate = DateTime.Now;
                    model.InvoiceDueDate = DateTime.Now;
                    model.CustomerId = model.CustomerIDasSeller;
                    model.CommodityGroups = 1;
                    model.IndentStatus = true;
                    model.CustomerSellerName = _party.FindById(model.CustomerIDasSeller).Title;
                    model.CustomerBuyerName = _party.FindById(model.CustomerIDasBuyer).Title;

                    indentInfoModel.LoomType = Request.Form["LoomType"];
                    indentInfoModel.SalesContractNo = Request.Form["SalesContractNo"];
                    indentInfoModel.foreignIndentNo = Request.Form["foreignIndentNo"];
                    if (!string.IsNullOrEmpty(Request.Form["foreignIndentDate"]))
                    {
                        indentInfoModel.foreignIndentDate = Convert.ToDateTime(Request.Form["foreignIndentDate"]);
                    }
                    indentInfoModel.PurchaseOrderNo = Request.Form["PurchaseOrderNo"];
                    indentInfoModel.BuyerReferenceNo = Request.Form["BuyerReferenceNo"];
                    indentInfoModel.GoodsDes = Request.Form["GoodsDes"];
                    model.IndentInfos.Add(indentInfoModel);

                    _indDomestic.Add(model, getIndAgentList, "export");
                    IndExportInquiry IndExportInquiry = new IndExportInquiry();
                    IndExportInquiry.Id = model.InquiryId;
                    if (IndExportInquiry.Id > 0)
                    {
                        IndExportInquiry.InquieryStatus = "C";
                        IndExportInquiry.IsClosed = "Y";
                        IndExportInquiry.InquiryClosedDate = DateTime.Now;
                        _indExportInquiryRepository.UpdateInquieryStatus(IndExportInquiry);

                    }
                    return RedirectToAction("Index", "IndentExport", new { Area = "Indent" });
                }
                else
                {
                    model = GetDomesticDetailDetail(model);
                    return View(model);
                }
            }

            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public ActionResult EditContractYarn(int id)
        {
            IndExportInquiry inquiery = new IndExportInquiry();
            var domestic = _indDomestic.FindById(id);
            inquiery = _indExportInquiryRepository.FindById(domestic.InquiryId);
            domestic.CustomerIDasBuyer = inquiery.IndExportInquiryOffer.FirstOrDefault(x => x.IsFinalized == true).CustomerId;
            domestic.CustomerIDasSeller = inquiery.CustomerId;

            decimal DispatchCount = new IndDomesticDispatchScheduleRepository().GetAllIndDomesticDispatchSchedule().Where(a => a.IndentId == id && a.TypeOfTransaction == "D").ToList().Count();
            if (DispatchCount > 0)
                domestic.IsScheduleGenerated = true;
            decimal invoicedCount = new IndCommissionInvoiceRepository().GetAllIndIndCommissionInvoice().Where(a => a.IndentId == id).ToList().Count();

            if (invoicedCount > 0)
                domestic.isInvoiced = true;

            ViewBag.IndAgent = _indDomestic.GetAgentsByIndentId(domestic.Id).ToList();

            return View(domestic);
        }

        [HttpPost]
        public ActionResult EditContractYarn(IndDomestic model)
        {
            List<IndentAgent> getIndAgentList = new List<IndentAgent>();
            try
            {
                if (ModelState.IsValid)
                {
                    model = GetDomesticDetailDetail(model);
                    getIndAgentList = GetIndAgentList(model.Id);
                    model.ModifiedOn = DateTime.Now;
                    model.LastApprovedOn = DateTime.Now;
                    model.CustomerId = model.CustomerIDasSeller;
                    model.CommodityGroups = 1;
                    _indDomestic.Edit(model);
                    _indDomestic.Edit(model, getIndAgentList);
                    return RedirectToAction("Index");
                }
                else
                {
                    model = GetDomesticDetailDetail(model);
                    return View(model);
                }
            }
            //catch (Exception e)
            //{
            //    return View(model);
            //}
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        private IndDomestic GetDomesticDetailDetail(IndDomestic model)
        {
            IndDomesticDetail domesticDetail;
            IndCommission commission;
            CommInvoiceAgentComm commInvoiceAgent;
            var gridKeysList = new List<string>();
            var gridComissionList = new List<string>();
            var gridAgentsList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("CommodityId"))
                    gridKeysList.Add(k.ToString());
                if (k.ToString().Contains("CustomerIdCommPaidFrom"))
                    gridComissionList.Add(k.ToString());
                if (k.ToString().Contains("agent"))
                    gridAgentsList.Add(k.ToString());
            }
            foreach (var Key in gridKeysList)
            {
                var index = "0";
                index = Key.Replace("][CommodityId]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][CommodityId]"))
                {
                    domesticDetail = new IndDomesticDetail();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CommodityId]"]))
                    {
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CommodityId]"]))
                        { domesticDetail.CommodityId = Convert.ToInt32(Request.Form["det[" + index + "][CommodityId]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][Quantity]"]))
                        { domesticDetail.Quantity = Convert.ToDecimal(Request.Form["det[" + index + "][Quantity]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][Rate]"]))
                        { domesticDetail.Rate = Convert.ToDecimal(Request.Form["det[" + index + "][Rate]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][UosID]"]))
                        { domesticDetail.UosID = Convert.ToInt32(Request.Form["det[" + index + "][UosID]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CommoditySpecification]"]))
                        { domesticDetail.CommoditySpecification = (Request.Form["det[" + index + "][CommoditySpecification]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][SizeSpecifications]"]))
                        { domesticDetail.SizeSpecifications = (Request.Form["det[" + index + "][SizeSpecifications]"]); }
                        domesticDetail.TotalValue = domesticDetail.Rate * domesticDetail.Quantity;
                        domesticDetail.IndentKey = model.IndentKey;
                        domesticDetail.LabDipDate = DateTime.Now;
                        domesticDetail.ColourId = 1;
                        domesticDetail.DesignId = 1;
                        domesticDetail.SizeCode = 1;
                        domesticDetail.BarCode = "barcode";
                        domesticDetail.DesignNo = "1";
                        domesticDetail.FabricWidth = "1";
                        domesticDetail.LabDip = "1";
                        domesticDetail.LabDipOption = "1";
                        domesticDetail.SalesContractDetailID = "1";
                        domesticDetail.TypeColor = "1";

                        model.IndDomesticDetails.Add(domesticDetail);
                    }

                }

            }
            foreach (var Key in gridComissionList)
            {
                var index = "0";
                index = Key.Replace("][CustomerIdCommPaidFrom]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][CustomerIdCommPaidFrom]"))
                {
                    commission = new IndCommission();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CustomerIdCommPaidFrom]"]))
                    {
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CustomerIdCommPaidFrom]"]))
                        { commission.CustomerIdCommPaidFrom = Convert.ToInt32(Request.Form["det[" + index + "][CustomerIdCommPaidFrom]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CustomerIdCommPaidTo]"]))
                        { commission.CustomerIdCommPaidTo = Convert.ToInt32(Request.Form["det[" + index + "][CustomerIdCommPaidTo]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CommissionRate]"]))
                        { commission.CommissionRate = Convert.ToDecimal(Request.Form["det[" + index + "][CommissionRate]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CommissionType]"]))
                        { commission.CommissionType = Convert.ToString(Request.Form["det[" + index + "][CommissionType]"]); }
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][CalculatedCommissionValue]"]))
                        { commission.CalculatedCommissionValue = Convert.ToDecimal(Request.Form["det[" + index + "][CalculatedCommissionValue]"]); }
                        if (Request.Form["det[" + index + "][IsinLocalCurrecncy]"] != null && Request.Form["det[" + index + "][IsinLocalCurrecncy]"] == "true,false")
                        {
                            commission.IsinLocalCurrecncy = true;
                        }
                        else
                        {
                            commission.IsinLocalCurrecncy = false;
                        }
                        if (Request.Form["det[" + index + "][IsPrintable]"] != null && Request.Form["det[" + index + "][IsPrintable]"] == "true,false")
                        {
                            commission.IsPrintable = true;
                        }
                        else
                        {
                            commission.IsPrintable = false;
                        }
                        commission.IndentKey = model.IndentKey;
                        commission.SaleContractCommID = model.InquiryKey;
                        commission.CreatedOn = DateTime.Now;
                        commission.ModifiedOn = DateTime.Now;
                        commission.CreatedBy = 1;
                        commission.ModifiedBy = 1;
                        commission.CompanyId = 5;
                        commission.Remarks = ".";
                        model.IndCommission.Add(commission);
                    }

                }

            }

            return model;
        }

        private List<IndentAgent> GetIndAgentList(int IndentId)
        {
            List<IndentAgent> indAgentList = new List<IndentAgent>();
            IndentAgent indentAgent;
            var gridAgentsList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("agent"))
                    gridAgentsList.Add(k.ToString());
            }
            foreach (var Key in gridAgentsList)
            {
                var index = "0";
                index = Key.Replace("][agent]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][agent]"))
                {
                    indentAgent = new IndentAgent();
                    if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][agent]"]))
                    {
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][agent]"]))
                        {
                            var a = (Request.Form["det[" + index + "][agent]"]);

                            try
                            {
                                if (a.Contains(","))
                                {
                                    var companyAgent = a.Split(',');
                                    try
                                    {
                                        indentAgent.CustomerIDasAgentID = Convert.ToInt16(companyAgent[Convert.ToInt16(index)]);
                                    }
                                    catch (Exception exc)
                                    {

                                    }
                                }
                                else
                                {
                                    indentAgent.CustomerIDasAgentID = Convert.ToInt16(Request.Form["det[" + index + "][agent]"]);
                                }
                            }
                            catch (Exception eee)
                            {
                            }

                            indentAgent.IndentId = IndentId;
                            indAgentList.Add(indentAgent);
                        }
                    }

                }

            }
            return indAgentList;
        }
    }
}