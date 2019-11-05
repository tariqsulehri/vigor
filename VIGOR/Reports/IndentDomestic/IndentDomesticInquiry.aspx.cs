using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

namespace VIGOR.Reports.IndentDomestic
{
    public partial class IndentDomesticInquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Server.MapPath("~\\Reports\\IndentDomestic\\CrystalReport1.rpt"));
            inquiryCRV.ReportSource = cryRpt;
        }
    }
}