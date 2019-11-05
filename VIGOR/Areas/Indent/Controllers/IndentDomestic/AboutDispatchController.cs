using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP.Common;
using ERP.Core.Models.Admin;
using VIGOR.Reports;
using VIGOR.Reports.IndentDomestic;

namespace VIGOR.Areas.Indent.Controllers.IndentDomestic
{
    public class AboutDispatchController : Controller
    {
        // GET: Indent/AboutDispatch
        public ActionResult Index()
        {
            ViewBag.FromDate = LoggedinUser.CurrentFiscalYear.StartDate;
            ViewBag.Todate = LoggedinUser.CurrentFiscalYear.EndDate;
            AboutDispatch obj = new AboutDispatch();
            Hashtable ht = new Hashtable();
            ht = obj.AboutDispatchReport();
            ViewBag.ReportType = new SelectList(ht, "Key", "Value");
            return View();
        }

        [HttpGet]
        public ActionResult Report(int tabid, DateTime DateFrom, DateTime DateTo, int ComdID, int? Dept, int? Product, string IndentKey,
                                    string IndStatus, string SellerID, string BuyerID, int ReportType)
        {
            TempData["tabid"] = tabid;
            TempData["ReportType"] = ReportType;
            TempData["DateFrom"] = DateFrom;

            TempData["DateTo"] = DateTo;

            return PartialView("~/Areas/Indent/Views/AboutDispatch/_View.cshtml");
        }
        public CustomeReportAction DispatchReport()
        {
            int ReportType = Convert.ToInt32(TempData["ReportType"]);
            DateTime DateFrom = Convert.ToDateTime(TempData["DateFrom"]);
            DateTime DateTo = Convert.ToDateTime(TempData["DateTo"]);
            string reportPath = string.Empty;
            ReportDocument reportDocument = new ReportDocument();
            switch (ReportType)
            {
                case 1://Local Dispatch[Seller Wise]
                    reportDocument = new ReportDocument();
                   // reportDocument = new LocalDispatchSellerWise();
                   reportPath = Path.Combine(Server.MapPath("~/Reports/IndentDomestic"), "LocalDispatchSellerWise.rpt");

                    break;
                case 2://Local Dispatch[Buyer Wise]
                    break;
                case 3://Monthly Dispatch Summary[Seller Wise]
                    break;
                case 4://Monthly Dispatch Summary[Buyer Wise]
                    break;
                case 5://Sales Tax Invoices Not Received
                    break;
                default:
                    break;
            }
            reportDocument = CustomeReportAction.SetUsersInfo(reportPath);
            reportDocument.SetParameterValue("@CompanyName", LoggedinUser.Company.Name.Trim());
            reportDocument.SetParameterValue("@FromDate", DateFrom);
            reportDocument.SetParameterValue("@ToDate", DateTo);



            return new CustomeReportAction(reportDocument);
        }
    }
}