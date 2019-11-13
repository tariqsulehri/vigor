using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP.Common;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VIGOR.Reports;
using ERP.Infrastructure.Repositories.Parties;

namespace VIGOR.Areas.Indent.Controllers
{
    public class IndentDomesticController : Controller
    {
        private IndDomesticInquiryRepository _indDomesticInquiryRepository;
        private IndDomesticRepository _indDomestic;
        private FinPartyRepository _party;
        public IndentDomesticController()
        {
            _indDomesticInquiryRepository = new IndDomesticInquiryRepository();
            _indDomestic = new IndDomesticRepository();
            _party = new FinPartyRepository();

        }


        // GET: Indent/IndentDomestic
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

            return View();
        }
        public ActionResult LookUpContracts()
        {
            ViewBag.FromDate = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.Todate = LoggedinUser.CurrentFiscalYear.EndDate;
            return View();
        }

        public ActionResult LookUp(DateTime FromDate, DateTime ToDate, int? IndentNO, int? DeptID, int? SCNO)//, DateTime ToDate,string IndentNO,int? DeptID,int? SCNO
        {
            var contract = _indDomestic.GetAllIndDomectic()
                .Where(a => a.DepartmentID.Equals(DeptID) || DeptID.Equals(null) || DeptID.Equals(0))
                /*.Where(a => a.IndentKey.Equals(IndentNO) || IndentNO.Equals(null))*/
                .Where(a => a.IndentDate >= FromDate && a.IndentDate <= ToDate);
            var collection = contract.Select(x => new
            {
                Id = x.Id,
                IndentDate = x.IndentDate.ToString("yyyy-MM-dd"),
                IndentKey = x.IndentKey,
                Saller = _party.FindById(x.CustomerIDasSeller).Title,
                CustomerBuyerName = _party.FindById(x.CustomerIDasBuyer).Title

            }).ToList();
            return Json(new { draw = 1, recordsTotal = collection.Count, recordsFiltered = 10, data = collection }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadContract(int id)
        {
            var data = _indDomestic.FindById(id);

            data.CustomerSellerName = _party.FindById(data.CustomerIDasSeller).Title;
            data.CustomerBuyerName = _party.FindById(data.CustomerIDasBuyer).Title;

            return Json(new
            {
                ContractKey = data.IndentKey,
                IndId = data.Id,
                SellerId = data.CustomerIDasSeller,
                SellerName = data.CustomerSellerName,
                BuyerId = data.CustomerIDasBuyer,
                BuyerName = data.CustomerBuyerName,
                CommodityId = data.CommodityTypeId,
                CommodityName = data.CommodityType.Description

            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetList(DateTime FromDate, DateTime Todate, Int32 DepartmentID, Int32 CommodityTypeId, string IndentKey)
        {
            if (Isvalid(FromDate, Todate, DepartmentID, CommodityTypeId, ref IndentKey))
            {
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                var lstContract = new List<ERP.Core.Models.Indenting.IndentDomestic.IndDomestic>();
                lstContract = _indDomestic.GetAllIndDomectic()
                    .Where(a => a.DepartmentID.Equals(DepartmentID))
                    .Where(a => a.CommodityTypeId.Equals(CommodityTypeId))
                    .Where(a => a.IndentKey.ToLower().Equals(IndentKey.ToLower()) || IndentKey.Equals(string.Empty))
                    .Where(a => a.IndentDate >= FromDate && a.IndentDate <= Todate).ToList();
                int totalrows = lstContract.Count();
                int totalrowsafterfiltering = lstContract.Count();
                lstContract = lstContract.Skip(start).Take(length).ToList();
                var Collection = lstContract.Select(x => new
                {
                    InquiryKey = x.InquiryKey,
                    IndentKey = x.IndentKey,
                    IndentDate = x.IndentDate.ToString("yyyy-MM-dd"),
                    CommodityTitle = x.CommodityType.Description,
                    Department = x.HrDepartment.Title,
                    PaymentTerm = x.IndPaymentTerms.Description,
                    PriceTerm = x.PriceTerms,
                    IndentStatus = x.IndentStatus == true ? "Active" : "Closed",
                    isClosed = x.isClosed == true ? "Yes" : "No",
                    IsSubmitForApproval = x.IsSubmitForApproval == true ? "Yes" : "No",
                    IsApproved = x.IsApproved != true ? "NO" : "Yes",
                    ViewURL = "/Indent/IndentDomestic/ViewContractFabric?id=" + x.Id

                });
                return Json(new
                {
                    data = Collection,
                    draw = Request["draw"],
                    recordsTotal = totalrows,
                    recordsFiltered = totalrowsafterfiltering
                }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(
                    new
                    {
                        data = string.Empty,
                        draw = Request["draw"],
                        recordsTotal = 0,
                        recordsFiltered = 0
                    }, JsonRequestBehavior.AllowGet);
            }
        }

        //  GET: Indent/IndentDomestic/Create
        public ActionResult Create(int id)
        {

            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            IndDomestic model = new IndDomestic();
            var inquiery = _indDomesticInquiryRepository.FindById(id);
            if (inquiery != null)
            {
                model.InquiryKey = inquiery.InquiryKey;
                model.InquiryId = id;
                model.OfferDate = inquiery.InquiryDate;
                model.IndentKey = _indDomestic.IndentKey();
                model.DepartmentID = inquiery.DepartmentID;
                model.CommodityTypeId = inquiery.CommodityTypeId;

                model.CurrencyId = LoggedinUser.Company.LocalCurrencyId;
                model.CustomerIDasLocalAgent = LoggedinUser.Company.domesticAgentID;

                //model.CustomerIDasBuyer = inquiery.IndDomesticInquiryReviews.FirstOrDefault().BuyerId;
                //model.CustomerIDasSeller = inquiery.IndDomesticInquiryReviews.FirstOrDefault().SellerId;

                model.CustomerId = inquiery.CustomerId;
                model.PaymenTermsId = inquiery.PaymenTermsId;
                model.IndentDate = DateTime.Now;
                model.DelDateValidUpto = DateTime.Now;
                IndDomesticDetail _detail = new IndDomesticDetail();
                foreach (var item in inquiery.IndDomesticInquiryDetails)
                {
                    _detail.CommodityId = item.ProductId;
                    _detail.UosID = item.UosId;
                    _detail.Quantity = item.Quantity;
                    decimal Rate = _detail.Rate = inquiery.IndDomesticInquiryOffers.Where(a => a.InquiryId == inquiery.Id && a.OfferedBy == model.CustomerIDasBuyer.ToString()).FirstOrDefault().OfferedRate;
                    _detail.Rate = Rate;
                    model.IndDomesticDetails.Add(_detail);
                }

                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "Invalid Inquiry");
                return RedirectToAction("index", "Inquiry");
            }

        }

        // POST: Indent/IndentDomestic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IndDomestic model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model = GetDomesticDetailDetail(model);
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

                    _indDomestic.Add(model);
                    IndDomesticInquiry IndDomesticInquiry = new IndDomesticInquiry();
                    IndDomesticInquiry.Id = model.InquiryId;
                    if (IndDomesticInquiry.Id > 0)
                    {
                        IndDomesticInquiry.InquiryStatus = "C";
                        IndDomesticInquiry.IsClosed = "Y";
                        IndDomesticInquiry.InquiryClosedDate = DateTime.Now;
                        _indDomesticInquiryRepository.UpdateInquieryStatus(IndDomesticInquiry);

                    }
                    return RedirectToAction("Index", "Inquiry", new { Area = "Indent" });
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
        public ActionResult ViewContractFabric(int id)
        {
            var domestic = _indDomestic.FindById(id);
            if (domestic.CommodityTypeId.Equals(2))
            {
                return RedirectToAction("ViewContractYarn", new { id });
            }
            else
            {
                decimal DispatchCount = new IndDomesticDispatchScheduleRepository().GetAllIndDomesticDispatchSchedule().Where(a => a.IndentId == id && a.TypeOfTransaction == "D").ToList().Count();
                if (DispatchCount > 0)
                    domestic.IsScheduleGenerated = true;
                decimal invoicedCount = new IndCommissionInvoiceRepository().GetAllIndIndCommissionInvoice().Where(a => a.IndentId == id).ToList().Count();

                if (invoicedCount > 0)
                    domestic.isInvoiced = true;
                return View(domestic);
            }

        }
        public ActionResult ViewContractYarn(int id)
        {
            var domestic = _indDomestic.FindById(id);
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
                return View(domestic);
            }

        }

        public ActionResult EditYarn(int id)
        {
            var domestic = _indDomestic.FindById(id);
            decimal DispatchCount = new IndDomesticDispatchScheduleRepository().GetAllIndDomesticDispatchSchedule().Where(a => a.IndentId == id && a.TypeOfTransaction == "D").ToList().Count();
            if (DispatchCount > 0)
                domestic.IsScheduleGenerated = true;
            decimal invoicedCount = new IndCommissionInvoiceRepository().GetAllIndIndCommissionInvoice().Where(a => a.IndentId == id).ToList().Count();

            if (invoicedCount > 0)
                domestic.isInvoiced = true;
            return View(domestic);
        }

        [HttpPost]
        public ActionResult EditYarn(IndDomestic model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model = GetDomesticDetailDetail(model);
                    model.ModifiedOn = DateTime.Now;
                    model.LastApprovedOn = DateTime.Now;
                    model.CustomerId = model.CustomerIDasSeller;
                    model.CommodityGroups = 1;
                    _indDomestic.Edit(model);
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


        public ActionResult Edit(int id)
        {
            var domestic = _indDomestic.FindById(id);
            if (domestic.CommodityTypeId.Equals(2))
            {
                return RedirectToAction("EditYarn", new { id });
            }
            else
            {
                decimal DispatchCount = new IndDomesticDispatchScheduleRepository().GetAllIndDomesticDispatchSchedule().Where(a => a.IndentId == id && a.TypeOfTransaction == "D").ToList().Count();
                if (DispatchCount > 0)
                    domestic.IsScheduleGenerated = true;
                decimal invoicedCount = new IndCommissionInvoiceRepository().GetAllIndIndCommissionInvoice().Where(a => a.IndentId == id).ToList().Count();

                if (invoicedCount > 0)
                    domestic.isInvoiced = true;
                return View(domestic);
            }

        }

        // POST: Indent/IndentDomestic/Edit/5
        [HttpPost]
        public ActionResult Edit(IndDomestic model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model = GetDomesticDetailDetail(model);

                    model.ModifiedOn = DateTime.Now;
                    model.LastApprovedOn = DateTime.Now;
                    model.CustomerId = model.CustomerIDasSeller;
                    model.CommodityGroups = 1;
                    _indDomestic.Edit(model);
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

        public ActionResult SendForApprovel(int id)
        {
            string message = string.Empty;
            var a = _indDomestic.FindById(id);
            if (!a.IsSubmitForApproval)
            {
                IndDomestic model = new IndDomestic();
                model.Id = id;
                model.LastApprovedOn = DateTime.Now;
                model.IsSubmitForApproval = true;
                model.IsApproved = a.IsApproved;

                _indDomestic.Update(model);
                message = "This Contract " + a.IndentKey + " is successfully Submited for Approvel";
            }
            else
            {
                message = "This Contract " + a.IndentKey + " is already Submited for Approvel";

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Approved(int id)
        {
            string message = string.Empty;
            var a = _indDomestic.FindById(id);
            if (!a.IsApproved)
            {
                IndDomestic model = new IndDomestic();
                model.Id = id;
                model.LastApprovedOn = DateTime.Now;
                model.IsSubmitForApproval = a.IsSubmitForApproval;
                model.IsApproved = true;
                model.ApprovedBy = LoggedinUser.LoggedInUser.Id;
                _indDomestic.Update(model);
                message = "This Contract " + a.IndentKey + " is successfully Approved";
            }
            else
            {
                message = "This Contract " + a.IndentKey + " is already Approved";

            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SendForApprovel(IndDomestic model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.LastApprovedOn = DateTime.Now;
                    model.IsSubmitForApproval = true;
                    _indDomestic.Update(model);
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


        // GET: Indent/IndentDomestic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/IndentDomestic/Delete/5
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

        public ActionResult ReportType(int id)
        {
            Session["ID"] = id;
            return PartialView("_ReportType");
        }

        public CustomeReportAction SaleContractReport()
        {
            int? IndId = Convert.ToInt32(TempData["Id"]);
            string reportType = TempData["rptType"].ToString();
            ReportDocument reportDocument = new ReportDocument();
            string reportPath = Path.Combine(Server.MapPath("~/Reports/IndentDomestic"), "SaleContract.rpt");
            reportDocument = CustomeReportAction.SetUsersInfo(reportPath);
            reportDocument.SetParameterValue("@indId", IndId);
            reportDocument.SetParameterValue("@CompName", LoggedinUser.Company.Name.Trim());
            reportDocument.SetParameterValue("@Address", LoggedinUser.Company.MailAddress);
            reportDocument.SetParameterValue("@Phone", "Phone " + LoggedinUser.Company.Phone);
            reportDocument.SetParameterValue("@Fax", "Fax " + LoggedinUser.Company.Fax);
            reportDocument.SetParameterValue("@WebSite", "WebSite " + LoggedinUser.Company.WebAddress);
            reportDocument.SetParameterValue("@Email", "Email " + LoggedinUser.Company.Email);

            return new CustomeReportAction(reportDocument);
        }


        public ActionResult Print(int id, string type)
        {
            TempData["Id"] = id;
            TempData["rptType"] = type;

            return View();
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
                        commission.IndentKey = model.IndentKey;
                        commission.SaleContractCommID = model.InquiryKey;
                        commission.CreatedOn = DateTime.Now;
                        commission.ModifiedOn = DateTime.Now;
                        commission.CreatedBy = 1;
                        commission.ModifiedBy = 1;
                        commission.CompanyId = 5;
                        commission.Remarks = "asda";
                        model.IndCommission.Add(commission);
                    }

                }

            }
            foreach (var Key in gridAgentsList)
            {
                var index = "0";
                index = Key.Replace("][agent]", "");
                index = index.Replace("det[", "");
                if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][agent]"))
                {
                    commInvoiceAgent = new CommInvoiceAgentComm();
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
                                        commInvoiceAgent.CompanyId = Convert.ToInt16(companyAgent[Convert.ToInt16(index)]);
                                    }
                                    catch (Exception exc)
                                    { 

                                    }
                                }
                                else
                                {
                                    commInvoiceAgent.CompanyId = Convert.ToInt16(Request.Form["det[" + index + "][agent]"]);
                                }
                            }
                            catch (Exception eee)
                            {
                            }
                        }
                        commInvoiceAgent.SaleContractCommID = "test";
                        commInvoiceAgent.IndentId = model.Id;
                        commInvoiceAgent.IndentKey = model.IndentKey;
                        commInvoiceAgent.CommissionType = "a";
                        commInvoiceAgent.CommissionDiscountRemarks = "test";
                        commInvoiceAgent.ModifiedOn = DateTime.Now;
                        commInvoiceAgent.ModifiedBy = 0;
                        model.CommInvoiceAgentComm.Add(commInvoiceAgent);

                    }

                }

            }
            return model;
        }

        private Boolean Isvalid(IndDomestic model)
        {
            Boolean isvalid = true;
            if (model.CustomerIDasSeller != model.CustomerIDasLocalAgent && model.CustomerIDasBuyer != model.CustomerIDasSeller)
            {

                return isvalid;
            }
            else
            {
                isvalid = false;
            }





            return isvalid;
        }
        private Boolean Isvalid(DateTime FromDate, DateTime Todate, Int32 DepartmentID, Int32 CommodityTypeId, ref string IndentKey)
        {
            Boolean isvalid = true;
            if (IsValidate.IsvalidateYear(FromDate, Todate))
            {
                if (string.IsNullOrEmpty(CommodityTypeId.ToString()) || string.IsNullOrEmpty(DepartmentID.ToString()))
                {
                    CommodityTypeId = 0;
                    DepartmentID = 0;
                    isvalid = false;
                }
                if (string.IsNullOrEmpty(IndentKey))
                {
                    IndentKey = string.Empty;
                }

            }
            else
            {
                isvalid = false;
            }





            return isvalid;
        }
    }
}
