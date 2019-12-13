using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP.Common;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Infrastructure.Repositories.HR;
using ERP.Infrastructure.Repositories.Indenting;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using PagedList;
using VIGOR.Areas.General.Controllers.Settings;
using VIGOR.Reports;
using VIGOR.ViewsModel;

namespace VIGOR.Areas.Indent.Controllers
{
    public class InquiryController : Controller
    {
        private Entities dbEntities;
        IndDomesticInquiryRepository _indDomesticInquiryRepository;
        
        ProductRepository _product;
        public InquiryController()
        {
            dbEntities = new Entities();
            _indDomesticInquiryRepository = new IndDomesticInquiryRepository();
            _product = new ProductRepository();
        }
        // GET: Indent/Inquiry
        public ActionResult Index()
        {
            ViewBag.DateFrom = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.CreatedOn = LoggedinUser.CurrentFiscalYear.EndDate;
            
 
            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime? DateFrom, IndDomesticInquiry inquiry)
        {
            Session["Departmentid"] = inquiry.DepartmentID.ToString();
            ViewBag.DateFrom = DateFrom;
            ViewBag.CreatedOn = inquiry.CreatedOn;
            if (inquiry.DepartmentID.Equals(0) || inquiry.CommodityTypeId.Equals(0))
            {
                ModelState.AddModelError("", "Invalid Search Criteria");
                return View();
            }
            string strDDLValue = Request.Form["InquiryStatus"].ToString();

            if (strDDLValue.Equals("P"))
            {
                return View(_indDomesticInquiryRepository.GetAllDomecticInquires()
                    .Where(a => a.DepartmentID.Equals(inquiry.DepartmentID) || inquiry.DepartmentID.Equals(0))
                    .Where(a => a.CommodityTypeId.Equals(inquiry.CommodityTypeId) || inquiry.CommodityTypeId.Equals(0))
                    .Where(a => a.CustomerId.Equals(inquiry.CustomerId) || inquiry.CustomerId.Equals(0))
                    .Where(a => a.InquiryStatus.Trim().Equals(strDDLValue.Trim())));
            }
            else if (!strDDLValue.Equals("A"))
            {
                return View(_indDomesticInquiryRepository.GetAllDomecticInquires()
                    .Where(a => a.DepartmentID.Equals(inquiry.DepartmentID) || inquiry.DepartmentID.Equals(0))
                    .Where(a => a.CommodityTypeId.Equals(inquiry.CommodityTypeId) || inquiry.CommodityTypeId.Equals(0))
                    .Where(a => a.CustomerId.Equals(inquiry.CustomerId) || inquiry.CustomerId.Equals(0))
                    .Where(a => a.InquiryStatus.Trim().Equals(strDDLValue.Trim()))
                    .Where(a => a.CreatedOn >= DateFrom && a.CreatedOn <= inquiry.CreatedOn));
            }
            else
            {
                return View(_indDomesticInquiryRepository.GetAllDomecticInquires()
                    .Where(a => a.DepartmentID.Equals(inquiry.DepartmentID) || inquiry.DepartmentID.Equals(0))
                    .Where(a => a.CommodityTypeId.Equals(inquiry.CommodityTypeId) || inquiry.CommodityTypeId.Equals(0))
                    .Where(a => a.CustomerId.Equals(inquiry.CustomerId) || inquiry.CustomerId.Equals(0))
                    .Where(a => a.CreatedOn >= DateFrom && a.CreatedOn <= inquiry.CreatedOn)

                );
            }

        }
        public ActionResult Review()
        {
            return View();
        }
        // GET: Indent/Inquiry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Indent/Inquiry/Create
        public ActionResult Create(int DepartmentID, int CommodityTypeId)
        {

            IndDomesticInquiry model = new IndDomesticInquiry();
            model.InquiryDate = DateTime.Now;
            model.CreatedOn = model.InquiryDate;
            model.InquiryKey = _indDomesticInquiryRepository.InquiryKey(model);
            model.DepartmentID = DepartmentID;
            model.CommodityTypeId = CommodityTypeId;
            model.InquiryStatus = "Y";
            model.IsClosed = "N";
            return View(model);
        }

        // POST: Indent/Inquiry/Create
        [HttpPost]
        public ActionResult Create(IndDomesticInquiry model)
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.Form["NewCommodity"].ToString()))
                {
                    ModelState.Remove("ProductId");
                    model.ProductId = 1;
                }
                if (!String.IsNullOrEmpty(model.WalkingCustomer))
                {
                    ModelState.Remove("CustomerId");
                    model.CustomerId = 1;
                }
                ViewBag.NewCommodity = Request.Form["NewCommodity"].ToString();
                model = GetIquiryOffers(model);
                int CurrentMonth = DateTime.Now.Month;
                if (!string.IsNullOrEmpty(model.InquiryDate.ToString()) && model.InquiryDate.Month != CurrentMonth)
                {
                    ModelState.AddModelError("", "Inquiry Date should be Current Month");
                    return View(model);
                }
                if (model.IndDomesticInquiryOffers.Count() == 0)
                {
                    ModelState.AddModelError("", "Inquiry Offers must be selected ");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    model.CreatedOn = DateTime.Now;
                    model.CreatedBy = 1;
                    model.ModifiedOn = DateTime.Now;
                    model.IsClosed = "N";
                    model.Companyid = 1.ToString();
                    IndDomesticInquiryDetail indDomesticInquiryDetail = new IndDomesticInquiryDetail();
                    indDomesticInquiryDetail.InquiryKey = model.InquiryKey;
                    indDomesticInquiryDetail.ProductId = model.ProductId;
                    indDomesticInquiryDetail.Quantity = model.Quantity;
                    indDomesticInquiryDetail.UosId = model.UosId;
                    indDomesticInquiryDetail.InquiryId = model.Id;
                    indDomesticInquiryDetail.NewCommodity = Request.Form["NewCommodity"].ToString();
                    model.IndDomesticInquiryDetails.Add(indDomesticInquiryDetail); // this object is create for inquirydetail
                    if (string.IsNullOrEmpty(indDomesticInquiryDetail.NewCommodity))
                    { model.ProductId = 1; }//Undefined Product
                    _indDomesticInquiryRepository.Add(model);
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

        // GET: Indent/Inquiry/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            { return null; }
            var inq = _indDomesticInquiryRepository.FindById(id);
            inq.ProductId = inq.IndDomesticInquiryDetails.Where(a => a.InquiryId == inq.Id).FirstOrDefault().ProductId;
            inq.Quantity = inq.IndDomesticInquiryDetails.Where(a => a.InquiryId == inq.Id).FirstOrDefault().Quantity;
            inq.UosId = inq.IndDomesticInquiryDetails.Where(a => a.InquiryId == inq.Id).FirstOrDefault().UosId;
            //ViewBag.NewCommodity
            ViewBag.NewCommodity = inq.IndDomesticInquiryDetails.Where(a => a.InquiryId == inq.Id).FirstOrDefault().NewCommodity;
            return View(inq);
        }

        // POST: Indent/Inquiry/Edit/5
        [HttpPost]
        public ActionResult Edit(IndDomesticInquiry model)
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.Form["NewCommodity"].ToString()))
                {
                    ModelState.Remove("ProductId");
                    model.ProductId = 1;
                }
                if (!String.IsNullOrEmpty(model.WalkingCustomer))
                {
                    ModelState.Remove("CustomerId");
                    model.CustomerId = 1;
                }
                ViewBag.NewCommodity = Request.Form["NewCommodity"].ToString();
                model = GetIquiryOffers(model);
                if (model.IndDomesticInquiryOffers.Count() == 0)
                {
                    ModelState.AddModelError("", "Inquiry Offers must be selected ");
                    return View(model);
                }
                if (model.Quantity<=0)
                {
                    ModelState.AddModelError("", "Inquiry Quantity must be greater then 0 ");
                    return View(model);
                }
                if (ModelState.IsValid)
                {
                    model.CreatedOn = DateTime.Now;
                    model.CreatedBy = 1;
                    model.ModifiedOn = DateTime.Now;
                    model.IsClosed = "N";
                    model.Companyid = 1.ToString();
                    IndDomesticInquiryDetail indDomesticInquiryDetail = new IndDomesticInquiryDetail();
                    indDomesticInquiryDetail.InquiryKey = model.InquiryKey;
                    indDomesticInquiryDetail.ProductId = model.ProductId;
                    indDomesticInquiryDetail.Quantity = model.Quantity;
                    indDomesticInquiryDetail.UosId = model.UosId;
                    indDomesticInquiryDetail.InquiryId = model.Id;
                    indDomesticInquiryDetail.NewCommodity = Request.Form["NewCommodity"].ToString();
                    model.IndDomesticInquiryDetails.Add(indDomesticInquiryDetail);
                    _indDomesticInquiryRepository.Edit(model);
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

        // GET: Indent/Inquiry/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return null;
            }
            IndDomesticInquiry model = new IndDomesticInquiry();
            var _domesticInquiry = _indDomesticInquiryRepository.FindById(id);
            if (_domesticInquiry != null && _domesticInquiry.InquiryStatus != Convert.ToString((char)InquieryStatus.Cancel))
            {
                model.Id = id;
                model.InquiryStatus = Convert.ToString((char)InquieryStatus.Cancel);
                model.IsClosed = _domesticInquiry.IsClosed;

                _indDomesticInquiryRepository.UpdateInquieryStatus(model);

            }
            return RedirectToAction("Index");
        }

        // POST: Indent/Inquiry/Delete/5
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
        private IndDomesticInquiry GetIquiryOffers(IndDomesticInquiry model)
        {
            IndDomesticInquiryOffer _indDomesticInquiryOffer;
            var inquiryOfferList = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("vendor"))
                    inquiryOfferList.Add(k.ToString());
            }
            try
            {
                foreach (var Key in inquiryOfferList)
                {
                    var index = "0";
                    index = Key.Replace("][vendor]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][vendor]"))
                    {
                        _indDomesticInquiryOffer = new IndDomesticInquiryOffer();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][vendor]"]))
                        {
                            _indDomesticInquiryOffer.OfferMadeOn = Convert.ToDateTime(Request.Form["det[" + index + "][offerDate]"]);
                            _indDomesticInquiryOffer.CustomerId = Convert.ToInt32(Request.Form["det[" + index + "][vendor]"]);
                            _indDomesticInquiryOffer.OfferedRate = Convert.ToDecimal(Request.Form["det[" + index + "][offerRate]"]);
                            string paymentTerm = (Request.Form["det[" + index + "][paymentTerm]"]);
                            _indDomesticInquiryOffer.Remarks = (Request.Form["det[" + index + "][remarks]"]);
                            if (string.IsNullOrEmpty(paymentTerm.Trim()))
                                _indDomesticInquiryOffer.PaymentTermsId = model.PaymenTermsId == 0 ? 0 : model.PaymenTermsId;
                            else
                                _indDomesticInquiryOffer.PaymentTermsId = Convert.ToInt32(paymentTerm);
                            if (string.IsNullOrEmpty(_indDomesticInquiryOffer.Remarks.Trim()))
                            {
                                _indDomesticInquiryOffer.Remarks = ".";
                            }
                            _indDomesticInquiryOffer.InquiryId = model.Id;
                            _indDomesticInquiryOffer.InquiryKey = model.InquiryKey;
                            //supplier forms is not completed, so i am using customer id for both CustomerId & OfferedBy
                            _indDomesticInquiryOffer.OfferedBy = _indDomesticInquiryOffer.CustomerId.ToString();
                            _indDomesticInquiryOffer.CreatedBy = 0;
                            _indDomesticInquiryOffer.CreatedOn = DateTime.Now;
                            _indDomesticInquiryOffer.ModifiedBy = 0;
                            _indDomesticInquiryOffer.ModifiedOn = DateTime.Now;
                            try
                            {
                                if (_indDomesticInquiryOffer.OfferedRate > 0)
                                {
                                    model.IndDomesticInquiryOffers.Add(_indDomesticInquiryOffer);
                                }
                            }
                            catch (Exception e)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return model;
        }

        public ActionResult Report(int? Department, int? commodity, string DepartmentName)
        {
            TempData["Department"] = Department;
            TempData["commodity"] = commodity;
            TempData["DepartmentName"] = DepartmentName;
            return View();
        }

        public CustomeReportAction InquieryReport()
        {
            int? dept = Convert.ToInt32(TempData["Department"]);
            int? commodity = Convert.ToInt32(TempData["commodity"]);
            string DepartmentName = TempData["DepartmentName"].ToString();
            ReportDocument reportDocument = new ReportDocument();
            var list = dbEntities.view_domestic_inquiry.ToList().Where(a => a.DepartmentID.Equals(dept)).ToList();
            string reportPath = Path.Combine(Server.MapPath("~/Reports/IndentDomestic"), "DomesticInquiery.rpt");
            reportDocument.Load(reportPath);
            reportDocument.SetDataSource(list);
            reportDocument.SetParameterValue("DateCriteria", "For the period: " + DateTime.Now.ToString("yy-MMM-dd") + "  To:" + DateTime.Now.ToString("yy-MMM-dd") + "");
            reportDocument.SetParameterValue("Department", "Department: " + DepartmentName + "");
            return new CustomeReportAction(reportDocument);
        }

        public ActionResult InquirySheet(int? InquiryID)
        {
            TempData["InquiryID"] = InquiryID;
            return View();
        }
        public CustomeReportAction InquierySheetReport()
        {
            int? dept = Convert.ToInt32(TempData["InquiryID"]);
            ReportDocument reportDocument = new ReportDocument();
            string reportPath = Path.Combine(Server.MapPath("~/Reports/IndentDomestic"), "InquierySheet.rpt");
            reportDocument = CustomeReportAction.SetUsersInfo(reportPath);
            reportDocument.SetParameterValue("@inquiryid", dept);
            //reportDocument.Load(reportPath);
            return new CustomeReportAction(reportDocument);
        }

        //public ReportDocument SetUsersInfo(String source)
        //{
        //    ConnectionInfo crconnectioninfo = new ConnectionInfo();
        //    ReportDocument cryrpt = new ReportDocument();
        //    TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();
        //    Tables CrTables;
        //    //String ServerName = @"sql6007.site4now.net";
        //    //String Database = "DB_A291AD_VigourDevelopment";
        //    //String UserID = "DB_A291AD_VigourDevelopment_admin";
        //    //String Password = "222Cgarden";

        //    String ServerName = @".";
        //    String Database = "DB_A291AD_VigourDevelopment";
        //    String UserID = "W";
        //    String Password = "12345678";
        //    crconnectioninfo.ServerName = ServerName;
        //    crconnectioninfo.DatabaseName = Database;
        //    crconnectioninfo.UserID = UserID;
        //    crconnectioninfo.Password = Password;
        //    cryrpt.Load(source.ToString());
        //    CrTables = cryrpt.Database.Tables;
        //    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
        //    {
        //        crtablelogoninfo = CrTable.LogOnInfo;
        //        crtablelogoninfo.ConnectionInfo = crconnectioninfo;
        //        CrTable.ApplyLogOnInfo(crtablelogoninfo);
        //    }

        //    cryrpt.Refresh();
        //    return cryrpt;
        //}
    }
}
