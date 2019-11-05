using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Finance;
using ERP.Core.Models.Finance.GeneralVM;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.FinRepository;
using VIGOR.Areas.GL.Models;
using VIGOR.Models;
using VIGOR.ViewsModel;
namespace VIGOR.Reports.PaymentsAndReceipts
{
    public partial class PaymentAndReceipts : System.Web.UI.Page
    {
        private CoaL5Repository coaL5Repository;
        private ErpDbContext bdContext;
        private Entities dbEntities;

        public PaymentAndReceipts()
        {
            coaL5Repository = new CoaL5Repository();
            bdContext = new ErpDbContext();
            dbEntities = new Entities();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LueAccounts();
                ReportType();
                FromDate.Value = LoggedinUser.CurrentFiscalYear.StartDate.ToString("yyyy-MM-dd");
                ToDate.Value = LoggedinUser.CurrentFiscalYear.EndDate.ToString("yyyy-MM-dd");
            }
            else
            {
                btnPrint_Click(sender,e);
            }
        }

        private void LueAccounts()
        {
            CoaL5 objCoaL5= new CoaL5();
            var list = coaL5Repository.GetL5Accounts().Where(a => a.BookType != "G").ToList();
            lueAccounts.DataSource = list.OrderBy(a => a.L5Code);
            lueAccounts.DataTextField = "Title";
            lueAccounts.DataValueField = "L5Code";
            lueAccounts.DataBind();
            
        }

        private void ReportType()
        {
            Hashtable ht1 = new Hashtable();
            ht1.Add(1, "Payment & Receipt Account");
            ht1.Add(2, "Payment & Receipt [ Summary]");
            ht1.Add(3, "Cash Flow Statement");
            rptType.DataSource = ht1;
            rptType.DataTextField = "Value";
            rptType.DataValueField = "Key";
            rptType.DataBind();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {




            ReportDocument cryRpt = new ReportDocument();
            string AccountCode = lueAccounts.SelectedItem.Value;
            Int32 rptype = Convert.ToInt32(rptType.SelectedValue);
            DateTime fromdate = Convert.ToDateTime(FromDate.Value);
            DateTime todate = Convert.ToDateTime(ToDate.Value);
            if (string.IsNullOrEmpty(AccountCode)) { return; }
            decimal Opbal = dbEntities.view_financial_trans.Where(a => a.VoucherDate < fromdate && a.L5Code.Contains(AccountCode)).ToList().Sum(a => a.Debit - a.Credit);

            List<AccountTransectionViewModel> listVmFinLedgers = new List<AccountTransectionViewModel>();
            AccountTransectionViewModel vnFinLedger;
            if (!string.IsNullOrEmpty(AccountCode))
            {
                var lst = dbEntities.view_financial_trans.Where(a => a.VoucherDate >= fromdate && a.VoucherDate <= todate && a.VKey.Substring(8, 3) != "001").ToList();
                var flowlist = lst.Where(a => a.L5Code.Equals(AccountCode)).ToList();
                var collection = (from s in lst
                                  join Payment in flowlist
                                      on s.VKey equals Payment.VKey
                                  where s.L5Code != AccountCode
                                  select s);
                decimal balance = Opbal;
                foreach (var p in collection)
                {
                    vnFinLedger = new AccountTransectionViewModel();
                    vnFinLedger.l1Code = p.L1Code;
                    vnFinLedger.l1_Title = p.L1Title;
                    vnFinLedger.l2Code = p.L2Code;
                    vnFinLedger.l2_Title = p.L2Title;
                    vnFinLedger.l3Code = p.L3Code;
                    vnFinLedger.l3_Title = p.L3Title;
                    vnFinLedger.l4Code = p.L4Code;
                    vnFinLedger.l4_Title = p.L4Title;
                    vnFinLedger.GlCode = p.L5Code;
                    vnFinLedger.l5_Title = p.GlTitle;
                    vnFinLedger.Debit = p.Debit;
                    vnFinLedger.Credit = p.Credit;
                    vnFinLedger.Detail = p.Detail;
                    vnFinLedger.VKey = p.VKey;
                    vnFinLedger.CreateDate = p.VoucherDate;
                    balance = (balance + p.Debit) - p.Credit;
                    vnFinLedger.BAL = balance;
                    vnFinLedger.Location = p.Location;
                    vnFinLedger.Department = p.Title;
                    vnFinLedger.Employee = p.Employee;
                    vnFinLedger.VoucherNO = p.VoucherNo;
                    vnFinLedger.Voucher = p.Vtype;
                    listVmFinLedgers.Add(vnFinLedger);
                }

            }
            else
            {
                var collection = dbEntities.view_financial_trans.Where(a => a.VoucherDate >= fromdate && a.VoucherDate <= todate && a.VKey.Substring(8, 3) != "001").ToList();
                foreach (var p in collection)
                {
                    vnFinLedger = new AccountTransectionViewModel();
                    vnFinLedger.l1Code = p.L1Code;
                    vnFinLedger.l1_Title = p.L1Title;
                    vnFinLedger.l2Code = p.L2Code;
                    vnFinLedger.l2_Title = p.L2Title;
                    vnFinLedger.l3Code = p.L3Code;
                    vnFinLedger.l3_Title = p.L3Title;
                    vnFinLedger.l4Code = p.L4Code;
                    vnFinLedger.l4_Title = p.L4Title;
                    vnFinLedger.GlCode = p.L5Code;
                    vnFinLedger.l5_Title = p.GlTitle;
                    vnFinLedger.Debit = p.Debit;
                    vnFinLedger.Credit = p.Credit;
                    vnFinLedger.Detail = p.Detail;
                    vnFinLedger.VKey = p.VKey;
                    vnFinLedger.CreateDate = p.VoucherDate;
                    vnFinLedger.Location = p.Location;
                    vnFinLedger.Department = p.Title;
                    vnFinLedger.Employee = p.Employee;
                    vnFinLedger.VoucherNO = p.VoucherNo;
                    vnFinLedger.Voucher = p.Vtype;
                    listVmFinLedgers.Add(vnFinLedger);
                }
            }
            switch (rptype)
            {
                case 1:
                    cryRpt.Load(Server.MapPath("~\\Reports\\PaymentsAndReceipts\\PaymentAndReceiptAccount.rpt"));
                    cryRpt.SetDataSource(listVmFinLedgers);
                    cryRpt.SetParameterValue("Criteria", "For the period: " + fromdate.ToString("yy-MMM-dd") + "  To:" + todate.ToString("yy-MMM-dd") + "");
                    cryRpt.SetParameterValue("OpeningBalance", Opbal);
                    crvPaymentandReceipt.ReportSource = cryRpt;
                    break;
                case 2:


                    cryRpt.Load(Server.MapPath("~\\Reports\\PaymentsAndReceipts\\PaymentAndReceiptSummary.rpt"));
                    cryRpt.SetDataSource(listVmFinLedgers);
                    cryRpt.SetParameterValue("Criteria", "For the period: " + fromdate.ToString("yy-MMM-dd") + "  To:" + todate.ToString("yy-MMM-dd") + "");
                    cryRpt.SetParameterValue("OpeningBalance", Opbal);
                    crvPaymentandReceipt.ReportSource = cryRpt;


                    break;

                case 3:
                    cryRpt.Load(Server.MapPath("~\\Reports\\PaymentsAndReceipts\\CashFlowStatement.rpt"));
                    cryRpt.SetDataSource(listVmFinLedgers.Select(p => new
                    {
                        l1Code = p.l1Code,
                        l1_Title = p.l1_Title,
                        l2Code = p.l2Code,
                        l2_Title = p.l2_Title,
                        l3Code = p.l3Code,
                        l3_Title = p.l3_Title,
                        l4Code = p.l4Code,
                        l4_Title = p.l4_Title,
                        GlCode = p.GlCode,
                        l5_Title = p.l5_Title,
                        Debit = p.Debit,
                        Credit = p.Credit,
                        Detail = p.Detail,
                        vkey = p.VKey,
                        CreateDate = p.CreateDate,
                        Location = p.Location,
                        Department = p.Department,
                        Employee = p.Employee,
                        VoucherNO = p.VoucherNO,
                        Voucher = p.Voucher,
                    Vtype = (p.VKey.Substring(8, 3)== "004" || p.VKey.Substring(8, 3) == "005") ? "Receipt":"Payment"

                    }));
                    cryRpt.SetParameterValue("Criteria", "For the period: " + fromdate.ToString("yy-MMM-dd") + "  To:" + todate.ToString("yy-MMM-dd") + "");
                    cryRpt.SetParameterValue("OpeningBalance", Opbal);
                    crvPaymentandReceipt.ReportSource = cryRpt;

                    
                    break;
            }
        }
       
    }
}