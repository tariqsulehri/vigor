using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Core.Models.Admin;
using ERP.Infrastructure.Repositories.Indenting.IndentDemestic;
using ERP.Infrastructure;
using VIGOR.ViewsModel;
using ERP.Infrastructure.Repositories.Indenting.Inspection;
using VIGOR.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using ERP.Core.Models.Indenting.Inspection;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace VIGOR.Areas.Indent.Controllers
{
    public class FollowUpSheetController : Controller
    {
        private Entities dbContext;
        EFilingSystemRepository efileRepo = new EFilingSystemRepository();
        private IndDomesticRepository _indDomestic;
        public FollowUpSheetController()
        {
            _indDomestic = new IndDomesticRepository();

        }
        public ActionResult Index()
        {
            ViewBag.FromDate = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.Todate = LoggedinUser.CurrentFiscalYear.EndDate;
            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime FromDate, DateTime Todate, Int32? DepartmentID, Int32? CommodityTypeId, string IndentKey,
            Int32? CustomerIDasSeller, Int32? CustomerIDasBuyer, string PONO, string IndentStatus)
        {
            ViewBag.FromDate = FromDate;
            ViewBag.Todate = Todate;
            if (string.IsNullOrEmpty(DepartmentID.ToString())) DepartmentID = 0;
            if (string.IsNullOrEmpty(CommodityTypeId.ToString())) CommodityTypeId = 0;
            if (string.IsNullOrEmpty(CustomerIDasSeller.ToString())) CustomerIDasSeller = 0;
            if (string.IsNullOrEmpty(CustomerIDasBuyer.ToString())) CustomerIDasBuyer = 0;

            if (DepartmentID.Equals(0) || CommodityTypeId.Equals(0))
            {
                ModelState.AddModelError("", "Invalid Search Criteria");
                return View();
            }
            dbContext = new Entities();
            if (IndentStatus.Trim().Equals("Y"))
            {
                ViewBag.Contracts = dbContext.view_IndDomestic_detail.ToList()
                    .Where(a => a.DepartmentID.Equals(DepartmentID) || DepartmentID.Equals(0))
                    .Where(a => a.CommodityId.Equals(CommodityTypeId) || CommodityTypeId.Equals(0))
                    .Where(a => a.LocalContractNo.Trim().Equals(IndentKey) || IndentKey.Equals(string.Empty))
                    .Where(a => a.SellectId.Equals(CustomerIDasSeller) || CustomerIDasSeller.Equals(0))
                    .Where(a => a.BuyerId.Equals(CustomerIDasBuyer) || CustomerIDasBuyer.Equals(0))
                    .Where(a=>a.IndentStatus)
                    .Where(a => a.IndentDate >= FromDate && a.IndentDate <= Todate);
            }
            else if(IndentStatus.Trim().Equals("P"))
            {
                ViewBag.Contracts = dbContext.view_IndDomestic_detail.ToList()
                    .Where(a => a.DepartmentID.Equals(DepartmentID) || DepartmentID.Equals(0))
                    .Where(a => a.CommodityId.Equals(CommodityTypeId) || CommodityTypeId.Equals(0))
                    .Where(a => a.LocalContractNo.Trim().Equals(IndentKey) || IndentKey.Equals(string.Empty))
                    .Where(a => a.SellectId.Equals(CustomerIDasSeller) || CustomerIDasSeller.Equals(0))
                    .Where(a => a.BuyerId.Equals(CustomerIDasBuyer) || CustomerIDasBuyer.Equals(0));
            }
            else if(IndentStatus.Trim().Equals("C"))
            {
                ViewBag.Contracts = dbContext.view_IndDomestic_detail.ToList()
                    .Where(a => a.DepartmentID.Equals(DepartmentID) || DepartmentID.Equals(0))
                    .Where(a => a.CommodityId.Equals(CommodityTypeId) || CommodityTypeId.Equals(0))
                    .Where(a => a.LocalContractNo.Trim().Equals(IndentKey) || IndentKey.Equals(string.Empty))
                    .Where(a => a.SellectId.Equals(CustomerIDasSeller) || CustomerIDasSeller.Equals(0))
                    .Where(a => a.BuyerId.Equals(CustomerIDasBuyer) || CustomerIDasBuyer.Equals(0))
                    .Where(a => a.indentClosed)
                    .Where(a => a.IndentDate >= FromDate && a.IndentDate <= Todate);
            }
            else if(IndentStatus.Trim().Equals("D"))
            {
                ViewBag.Contracts = dbContext.view_IndDomestic_detail.ToList()
                    .Where(a => a.DepartmentID.Equals(DepartmentID) || DepartmentID.Equals(0))
                    .Where(a => a.CommodityId.Equals(CommodityTypeId) || CommodityTypeId.Equals(0))
                    .Where(a => a.LocalContractNo.Trim().Equals(IndentKey) || IndentKey.Equals(string.Empty))
                    .Where(a => a.SellectId.Equals(CustomerIDasSeller) || CustomerIDasSeller.Equals(0))
                    .Where(a => a.BuyerId.Equals(CustomerIDasBuyer) || CustomerIDasBuyer.Equals(0))
                    .Where(a => a.isCancelled)
                    .Where(a => a.IndentDate >= FromDate && a.IndentDate <= Todate);
            }
            else if (IndentStatus.Trim().Equals("U"))
            {
                ViewBag.Contracts = dbContext.view_IndDomestic_detail.ToList()
                    .Where(a => a.DepartmentID.Equals(DepartmentID) || DepartmentID.Equals(0))
                    .Where(a => a.CommodityId.Equals(CommodityTypeId) || CommodityTypeId.Equals(0))
                    .Where(a => a.LocalContractNo.Trim().Equals(IndentKey) || IndentKey.Equals(string.Empty))
                    .Where(a => a.SellectId.Equals(CustomerIDasSeller) || CustomerIDasSeller.Equals(0))
                    .Where(a => a.BuyerId.Equals(CustomerIDasBuyer) || CustomerIDasBuyer.Equals(0))
                    .Where(a => a.IsApproved!=true)
                    .Where(a => a.IndentDate >= FromDate && a.IndentDate <= Todate);
            }
            else
            {
                ViewBag.Contracts = dbContext.view_IndDomestic_detail.ToList()
                    .Where(a => a.DepartmentID.Equals(DepartmentID) || DepartmentID.Equals(0))
                    .Where(a => a.CommodityId.Equals(CommodityTypeId) || CommodityTypeId.Equals(0))
                    .Where(a => a.LocalContractNo.Trim().Equals(IndentKey) || IndentKey.Equals(string.Empty))
                    .Where(a => a.SellectId.Equals(CustomerIDasSeller) || CustomerIDasSeller.Equals(0))
                    .Where(a => a.BuyerId.Equals(CustomerIDasBuyer) || CustomerIDasBuyer.Equals(0))
                    .Where(a => a.IndentDate >= FromDate && a.IndentDate <= Todate);
            }
            return View();


        }


        public ActionResult ViewIndent(int IndentID)
        {
            IndDomestic model = new IndDomestic();
            model = _indDomestic.FindById(IndentID);
            return View(model);
        }
        [HttpGet]
        public ActionResult CloseIndent(int IndentID)
        {
            ViewBag.AlreadyClosed = string.Empty;
            ViewBag.SuccessfullyClosed = string.Empty;

            if (IndentID > 0)
            {
                var indent = _indDomestic.FindById(IndentID);
                if (indent != null)
                {
                    if (!indent.IsApproved) { ViewBag.AlreadyClosed = indent.IndentKey + " is not approved yet"; }
                    else if (indent.isClosed) { ViewBag.AlreadyClosed = indent.IndentKey + " is already closed"; }
                    else
                    {
                        indent.isClosed = true;
                        _indDomestic.Update(indent);
                        ViewBag.SuccessfullyClosed = indent.IndentKey + " is Successfully closed";
                    }
                }
            }
            return View();
        }
        public ActionResult Complaints(int IndentID)
        {
            return View();
        }

        public ActionResult Efile(int IndentID)
        {
            EFilingSystem efile = new EFilingSystem();
            List<EFilingSystem> lst = new List<EFilingSystem>();
            var indent = _indDomestic.FindById(IndentID);
            efile.ReferenceID1 = indent.IndentKey;
            efile.CompanyId = LoggedinUser.Company.Id;
            efile.Company_Key = LoggedinUser.Company.Id.ToString();
            ViewBag.Efile = lst = efileRepo.GetAllIndDomesticEFilings().Where(a => a.ReferenceID1.Equals(indent.IndentKey)).ToList();
            return View(efile);
        }
        [HttpPost]
        public ActionResult Efile(EFilingSystem efile, IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                List<EFilingSystem> eFilingSystems = new List<EFilingSystem>();
                eFilingSystems = GetEFiles(efile);
                foreach (var file in files)
                {
                    foreach (var item in eFilingSystems)
                    {
                        if (!String.IsNullOrEmpty(item.EFilingID))
                        {
                            efileRepo.Remove(item);
                        }
                        if (file != null && file.ContentLength > 0)
                        {
                            string fileExtention = Path.GetExtension(file.FileName);
                            if (!string.IsNullOrEmpty(item.EFilingID) && !string.IsNullOrEmpty(item.FileAttached))
                            {
                                System.IO.File.Delete(Server.MapPath("~/File/" + item.FileAttached));
                                file.SaveAs(Path.Combine(Server.MapPath("~/File"), item.EFilingID + fileExtention));
                            }
                            if (String.IsNullOrEmpty(item.EFilingID))
                            {
                                item.EFilingID = efileRepo.NewFileKey(item);
                                item.FileAttached = item.EFilingID + fileExtention;
                                file.SaveAs(Path.Combine(Server.MapPath("~/File"), item.FileAttached));
                            }
                        }
                        efileRepo.Add(item);
                        eFilingSystems.Remove(item);
                        break;
                    }
                }
                return null;



            }
            catch (Exception e) { throw e; }

        }
        public ActionResult FabricSample()
        {
            return View();
        }
        public ActionResult FabricSampleDetails()
        {
            return View();
        }

        public ActionResult Inspection(int IndentID, int ComodityType)
        {
            YarnInspectionRepository _inspectionRepository;
            FabricInspReportLocalRepository _fabricInspReportLocalRepository;
            ViewBag.YarnInspection = new List<YarnInspection>();
            ViewBag.FabricInspection = new List<FabricInspReportLocal>();
            if (ComodityType == 2)
            {
                _inspectionRepository = new YarnInspectionRepository();
                ViewBag.YarnInspection = _inspectionRepository.GetAllYarnInspections().Where(a => a.IndentId == IndentID).ToList();
            }
            else
            {
                _fabricInspReportLocalRepository = new FabricInspReportLocalRepository();
                ViewBag.FabricInspection = _fabricInspReportLocalRepository.GetAllFabricInspReportLocal();

            }
            return View();
        }
        public ActionResult InspectionView(int InspType, int InspId)
        {
            if (InspType == 2)
            {
                YarnInspection modeInspection = new YarnInspection();
                YarnInspectionRepository _inspectionRepository = new YarnInspectionRepository();
                modeInspection = _inspectionRepository.FindById(InspId);
                return View(modeInspection);
            }
            else
            {
                return View();
            }

        }

        public ActionResult SalesContractStatus(int IndentID)
        {
            IndDomestic model = new IndDomestic();
            model = _indDomestic.FindById(IndentID);
            return View(model);
        }
        public ActionResult IndDispatches(int IndentID)
        {
            IndDomesticDispatchScheduleRepository _indDomesticDispatchScheduleRepository = new IndDomesticDispatchScheduleRepository();
            var Dispatches = _indDomesticDispatchScheduleRepository.GetAllIndDomesticDispatchSchedule().Where(a => a.IndentId == IndentID).ToList();
            return View(Dispatches);
            // && (a.TypeOfTransaction == "D" || a.TypeOfTransaction == "R")
        }
        public CustomeReportAction DSSReport()
        {
            int? IndId = Convert.ToInt32(TempData["Id"]);
            string reportType = TempData["rptType"].ToString();
            ReportDocument reportDocument = new ReportDocument();
            string reportPath = string.Empty;
            if (!string.IsNullOrEmpty(reportType))
            {
                if (reportType.Equals("BlankDSS"))
                {
                    reportPath = Path.Combine(Server.MapPath("~/Reports/IndentDomestic"), "BlankDSS.rpt");
                }
                else
                {
                    reportPath = Path.Combine(Server.MapPath("~/Reports/IndentDomestic"), "DSS.rpt");

                }
            }
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


        public ActionResult PrintDSS(int IndentID, string type)
        {
            TempData["Id"] = IndentID;
            TempData["rptType"] = type;
            return View();
        }

        public ActionResult PrintFollowUpSheetDetail(int IndentID, string type)
        {
            TempData["Id"] = IndentID;
            return View();
        }

        public CustomeReportAction FollowUpSheetReport()
        {
            int? IndId = Convert.ToInt32(TempData["Id"]);
            ReportDocument reportDocument = new ReportDocument();
            string reportPath = string.Empty;
            reportPath = Path.Combine(Server.MapPath("~/Reports/IndentDomestic"), "BlankDSS.rpt");
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



        // GET: Indent/FollowUpSheet/Details/5
        public ActionResult SheduleReportExel(int CommodityTypeId, int DepartmentID)
        {
            string file = "ScheduleDomesticSaleFabrics-A.xlt";
            string fullPath = Path.Combine(Server.MapPath("~/Reports/IndentDomestic"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
            //Int32 row, col = 0;
            //try
            //{
            //    string fileName = file;

            //    object missing = System.Reflection.Missing.Value;
            //    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel.Workbook Workbook = excelApp.Workbooks.Add(Type.Missing);
            //    Workbook = excelApp.Workbooks.Open(fileName, missing, missing, missing, missing, missing,
            //       missing, missing, missing, missing, missing,
            //       missing, missing, missing, missing);

            //    ((Microsoft.Office.Interop.Excel._Workbook)Workbook).Activate();

            //    excelApp.Cells[5, 2] = DateTime.Now.Date.ToString(LoggedinUser.BISDateFormat);
            //    excelApp.Cells[6, 2] = Crit4Report.ToString();

            //    row = 10;
            //    foreach (DataRow r in dtStatusReport.Rows)
            //    {


            //        excelApp.Cells[row, 1] = r["SalesContractNo"].ToString();
            //        excelApp.Cells[row, 2] = r["CustomerSelller"].ToString().Trim() + " / " + r["CustomerBuyer"].ToString().Trim();

            //        excelApp.Cells[row, 3] = r["SellerContractNo"].ToString(); // Seller Contract r["CommodityDesc"].ToString();
            //        excelApp.Cells[row, 4] = r["PurchaseOrderNo"].ToString(); // Purchase Order  r["CommodityDesc"].ToString();

            //        row = row + 1;
            //        excelApp.Cells[row, 1] = Convert.ToDateTime(r["SalesContractDate"]).ToString(LoggedinUser.StringDateFormat);
            //        excelApp.Cells[row, 2] = r["CommodityDesc"].ToString();
            //        excelApp.Cells[row, 3] = (r["SizeSpecifications"] != DBNull.Value) ? r["SizeSpecifications"].ToString() : ""; // Selvage Weave r["CommodityDesc"].ToString();
            //        excelApp.Cells[row, 4] = r["DeliveryRemarks"].ToString();

            //        //excelApp.Cells[row + 1, 5].Value = r["PriceTerm"].ToString();
            //        //excelApp.Cells[row + 2, 5].Value = r["QualityRemarks"].ToString();

            //        CC_UnitofSale uu = new CC_UnitofSaleHandler().GetSingle(r["UOSID"].ToString());

            //        if (r["Rate"] != DBNull.Value)
            //            excelApp.Cells[row, 5] = "'" + Math.Round(Convert.ToDecimal(r["Rate"]), 2).ToString() + "/" + uu.UOR.UORDescription.Substring(0, 1);

            //        excelApp.Cells[row, 6] = Math.Round(Convert.ToDecimal(r["Quantity"]), 2);

            //        decimal a = Convert.ToDecimal(r["DisQuantity"]) - Convert.ToDecimal(r["RetQuantity"]);

            //        excelApp.Cells[row, 7] = Math.Round(a, 2);
            //        excelApp.Cells[row, 8] = Math.Round(Convert.ToDecimal(r["BalQuantity"]), 2);

            //        Boolean samplereceived = new SampleHandler().IsLFSampleReceived(r["SalesContractNo"].ToString(), r["CommodityId"].ToString());
            //        excelApp.Cells[row, 9] = (samplereceived) ? "Y" : "N";

            //        Int32 printDispatch = row;
            //        List<SL_DispacthScheduleDomestic> dispatch = new SL_DispacthScheduleDomesticHandler().GetDispatches(r["SalesContractNo"].ToString());

            //        foreach (SL_DispacthScheduleDomestic dis in dispatch)
            //        {
            //            if (dis.SalesContractDetail.SalesContractDetailID == r["SalesContractDetailID"].ToString())
            //            {
            //                excelApp.Cells[printDispatch, 10] = (dis.ContractedDeliveryDate == null) ? "" : "'" + Convert.ToDateTime(dis.ContractedDeliveryDate).ToString(LoggedinUser.StringDateFormat);
            //                excelApp.Cells[printDispatch, 11] = "'" + dis.TranDate.ToString(LoggedinUser.StringDateFormat);
            //                excelApp.Cells[printDispatch, 12] = dis.Quantity;
            //                excelApp.Cells[printDispatch, 13] = dis.SalestaxInvoiceNo;
            //                excelApp.Cells[printDispatch, 14] = (dis.SalestaxInvoiceDate == null) ? "" : "'" + Convert.ToDateTime(dis.SalestaxInvoiceDate).ToString(LoggedinUser.StringDateFormat);

            //                if (dis.TypeOfTransection == 'R')
            //                    excelApp.Cells[printDispatch, 12] = -dis.Quantity;

            //                SL_IndentInspection temp = new BIS.Handler.sale.SL_IndentInspectionHandler().GetLocalFabricFinalInspection(dis.SalesContractNo, dis.LocalDispatchNo);

            //                //MessageBox.Show( r["SalesContractNo"].ToString()  + "   " + temp.InspSrno );

            //                excelApp.Cells[printDispatch, 22] = new BIS.Handler.sale.SL_InspectionFabricReportsHandler().GetLocalInspection(temp.InspSrno, true)._MainReport.InspectionReportNo;

            //                printDispatch = printDispatch + 1;
            //            }
            //        }

            //        Int32 printpaymentrow = row;

            //        List<SL_DispacthScheduleDomestic> payments = new SL_DispacthScheduleDomesticHandler().GetPayments(r["SalesContractNo"].ToString());

            //        foreach (SL_DispacthScheduleDomestic prn in payments)
            //        {
            //            if (prn.SalesContractDetail.SalesContractDetailID == r["SalesContractDetailID"].ToString())
            //            {
            //                excelApp.Cells[printpaymentrow, 15] = "'" + prn.TranDate.ToString(LoggedinUser.StringDateFormat);
            //                excelApp.Cells[printpaymentrow, 16] = prn.Quantity;
            //                excelApp.Cells[printpaymentrow, 17] = prn.GrossAmount;
            //                Int32 tempcol = 18;
            //                foreach (SL_DomesticPaymentAddon dd in prn.Addonlist)
            //                { excelApp.Cells[printpaymentrow, tempcol] = dd.TotalValue; tempcol = tempcol + 1; }

            //                excelApp.Cells[printpaymentrow, 20] = prn.IncomeTaxAmount;
            //                excelApp.Cells[printpaymentrow, 21] = prn.NetReceivable;
            //                printpaymentrow = printpaymentrow + 1;
            //            }
            //        }



            //        row = (printpaymentrow >= printDispatch) ? printpaymentrow : printDispatch;

            //        row = row + 1;
            //    }

            //    string newfileName = null;
            //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //    saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            //    saveFileDialog1.FilterIndex = 1;



            //    Workbook.Close();
            //    Workbook = null;

            //    excelApp.Quit();
            //    excelApp = null;
            //}
            //catch (Exception ex) { }






        }

        // GET: Indent/FollowUpSheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indent/FollowUpSheet/Create
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

        // GET: Indent/FollowUpSheet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Indent/FollowUpSheet/Edit/5
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

        // GET: Indent/FollowUpSheet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Indent/FollowUpSheet/Delete/5
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
        private List<EFilingSystem> GetEFiles(EFilingSystem model)
        {
            List<EFilingSystem> lstEfile = new List<EFilingSystem>();
            EFilingSystem _efile;
            var EFilingSystem = new List<string>();
            foreach (var k in Request.Form.Keys)
            {
                if (k.ToString().Contains("DocumentType"))
                    EFilingSystem.Add(k.ToString());
            }
            try
            {
                foreach (var Key in EFilingSystem)
                {
                    var index = "0";
                    index = Key.Replace("][DocumentType]", "");
                    index = index.Replace("det[", "");
                    if (Request.Form.AllKeys.Any(k => k == "det[" + index + "][DocumentType]"))
                    {
                        _efile = new EFilingSystem();
                        if (!string.IsNullOrEmpty(Request.Form["det[" + index + "][DocumentType]"]))
                        {
                            _efile.DocumentType = (Request.Form["det[" + index + "][DocumentType]"]);
                            _efile.FileDescription = (Request.Form["det[" + index + "][FileDescription]"]);
                            _efile.ReferenceID2 = (Request.Form["det[" + index + "][ReferenceID2]"]);
                            _efile.EFilingID = (Request.Form["det[" + index + "][EFilingID]"]);
                            _efile.FileAttached = (Request.Form["det[" + index + "][FileAttached]"]);

                            if (String.IsNullOrEmpty(_efile.FileDescription))
                                _efile.FileDescription = _efile.DocumentType;
                            _efile.TranType = 4;
                            _efile.CompanyId = model.CompanyId;
                            _efile.Company_Key = model.Company_Key;
                            _efile.ReferenceID1 = model.ReferenceID1;
                            _efile.CreatedBy = LoggedinUser.LoggedInUser.Id;
                            _efile.CreatedOn = DateTime.Now;
                            _efile.ModifiedBy = LoggedinUser.LoggedInUser.Id;
                            _efile.ModifiedOn = DateTime.Now;
                            lstEfile.Add(_efile);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return lstEfile;
        }

    }
}
