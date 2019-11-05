using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using ERP.Core.Models.Finance;
using ERP.Core.Models.Finance.GeneralVM;
using ERP.Infrastructure;
using ERP.Infrastructure.Repositories.FinRepository;
using ERP.Infrastructure.Repositories.Common;
using ERP.Infrastructure.Repositories.HR;
using VIGOR.Areas.GL.Models;
using VIGOR.ViewsModel;
using ERP.Core.Models.Admin;
using ERP.Core.Models.Common;
using ERP.Core.Models.HR;
using VIGOR.Models;

namespace VIGOR.Reports.ControlBalance
{
    public partial class PaymentAndReceipts : System.Web.UI.Page
    {
        private CoaL1Repository coaL1Repository;
        private ErpDbContext bdContext;
        private Entities dbEntities;
        private ReportDocument cryRpt;


        public PaymentAndReceipts()
        {
            coaL1Repository = new CoaL1Repository();
            bdContext = new ErpDbContext();
            dbEntities = new Entities();


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LueAccounts();
                LueLocation();
                LueDepartment();
                LueEmployee();
                ReportType();
                FromDate.Value = LoggedinUser.CurrentFiscalYear.StartDate.ToString("yyyy-MM-dd");
                ToDate.Value = LoggedinUser.CurrentFiscalYear.EndDate.ToString("yyyy-MM-dd");
            }
            else
            {
                if (!string.IsNullOrEmpty(AccountCode.Value))
                {
                     ShowReport_Click(sender, e);
                }
            }

        }

        private void LueLocation()
        {
            CityRepository cityrepo = new CityRepository();
            City city = new City();
            city.Id = 0;
            city.Name = "Select";
            var list = cityrepo.GetAllCities().ToList();
            list.Add(city);
            LueLoac.DataSource = list.OrderBy(a => a.Id);
            LueLoac.DataTextField = "Name";
            LueLoac.DataValueField = "Id";
            LueLoac.DataBind();
        }
        private void LueDepartment()
        {
            HrDepartmentRepository departmentRepository = new HrDepartmentRepository();
            HrDepartment department = new HrDepartment();
            department.id = 0;
            department.Title = "Select";
            var list = departmentRepository.GetAllDepartment().ToList();
            list.Add(department);
            LueDep.DataSource = list.OrderBy(a => a.id);
            LueDep.DataTextField = "Title";
            LueDep.DataValueField = "id";
            LueDep.DataBind();
        }
        private void LueEmployee()
        {
            HrEmployeeRepository emprepo = new HrEmployeeRepository();
            HrEmployee employee = new HrEmployee();
            employee.Id = 0;
            employee.Title = "Select";
            var list = emprepo.GetAllEmployees().ToList();
            list.Add(employee);
            LueEmp.DataSource = list.OrderBy(a => a.Id);
            LueEmp.DataTextField = "Title";
            LueEmp.DataValueField = "Id";
            LueEmp.DataBind();
        }
        private void LueAccounts()
        {
            var list = dbEntities.ALLCOAViews.ToList();
            grdgstAccount.DataSource = null;
            grdgstAccount.DataSource = list.OrderBy(a => a.Code).ToList();
            grdgstAccount.DataBind();
        }

        private void ReportType()
        {
            Hashtable ht1 = new Hashtable();
            //ht1.Add(1, "Control Account LedgerH ");
            //ht1.Add(2, "Control Account SummaryH");
            //ht1.Add(3, "Control Account BalanceH");
            ht1.Add(4, "Control Account Ledger ");
            ht1.Add(5, "Control Account Summary");
            ht1.Add(6, "Control Account Balance");
            rptType.DataSource = ht1;
            rptType.DataTextField = "Value";
            rptType.DataValueField = "Key";
            rptType.DataBind();
        }
        protected void ShowReport_Click(object sender, EventArgs e)
        {
            cryRpt = new ReportDocument();
            string AccountCode = this.AccountCode.Value;
            string AccountTitle = this.AccountTitle.Value;
            Int32 rptype = Convert.ToInt32(rptType.SelectedValue);

            DateTime fromdate = Convert.ToDateTime(FromDate.Value);
            DateTime todate = Convert.ToDateTime(ToDate.Value);
            if (string.IsNullOrEmpty(AccountCode) || string.IsNullOrEmpty(AccountTitle)) { return; }
            decimal Opbal = dbEntities.view_financial_trans.Where(a => a.VoucherDate < fromdate && a.L5Code.Contains(AccountCode)).ToList().Sum(a => a.Debit - a.Credit);
            List<AccountTransectionViewModel> listVmFinLedgers = new List<AccountTransectionViewModel>();
            AccountTransectionViewModel vnFinLedger;
            if (!string.IsNullOrEmpty(AccountCode))
            {
                var lst = dbEntities.view_financial_trans.Where(a => a.VoucherDate >= fromdate && a.VoucherDate <= todate && a.L5Code.Contains(AccountCode)).ToList();
                decimal balance = Opbal;
                foreach (var p in lst)
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

                var collection = lst.Select(x => new
                {


                }).ToList();
            }
            switch (rptype)
            {
                case 4:

                    cryRpt.Load(Server.MapPath("~\\Reports\\ControlBalance\\ControlLedger.rpt"));
                    cryRpt.SetDataSource(listVmFinLedgers);
                    cryRpt.SetParameterValue("Criteria", "For the period: " + fromdate.ToString("yy-MMM-dd") + "  To:" + todate.ToString("yy-MMM-dd") + "");
                    cryRpt.SetParameterValue("OpeningBalance", Opbal);
                    cryRpt.SetParameterValue("ControlAccount", AccountCode + " " + AccountTitle);
                    ControlAccountCRV.ReportSource = cryRpt;
                    break;

                case 5:
                    cryRpt.Load(Server.MapPath("~\\Reports\\ControlBalance\\ControlBalanceSummary.rpt"));
                    cryRpt.SetDataSource(listVmFinLedgers);
                    cryRpt.SetParameterValue("Criteria", "For the period: " + fromdate.ToString("yy-MMM-dd") + "  To:" + todate.ToString("yy-MMM-dd") + "");
                    cryRpt.SetParameterValue("OpeningBalance", Opbal);
                    cryRpt.SetParameterValue("ControlAccount", AccountCode + " " + AccountTitle);
                    ControlAccountCRV.ReportSource = cryRpt;

                    break;
                case 6:
                    cryRpt.Load(Server.MapPath("~\\Reports\\ControlBalance\\ControlClosingBalance.rpt"));
                    cryRpt.SetDataSource(listVmFinLedgers);
                    cryRpt.SetParameterValue("Criteria", "For the period: " + fromdate.ToString("yy-MMM-dd") + "  To:" + todate.ToString("yy-MMM-dd") + "");
                    cryRpt.SetParameterValue("OpeningBalance", Opbal);
                    cryRpt.SetParameterValue("ControlAccount", AccountCode + " " + AccountTitle);
                    ControlAccountCRV.ReportSource = cryRpt;

                    break;
            }

        }

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            // LueAccounts();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "AccountModal", "$('#AccountModal').modal({backdrop: 'static', keyboard: false})", true);
        }

        protected void lnkSelectedRowt_Click(object sender, EventArgs e)
        {

            LinkButton Lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)Lnk.NamingContainer;
            Get_Selected_Row(row);
            btnClose_click(sender, e);
        }

        private void Get_Selected_Row(GridViewRow GrdRow)
        {
            try
            {
                this.AccountCode.Value = ((Label)GrdRow.FindControl("lblcode")).Text;
                this.AccountTitle.Value = ((Label)GrdRow.FindControl("lblTitle")).Text;
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnClose_click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "AccountModal", "$('#AccountModal').modal('hide')", true);
        }
        protected void SubmitAppraisalGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdgstAccount.PageIndex = e.NewPageIndex;

            LueAccounts();
        }
    }
}