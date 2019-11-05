<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndentDomesticInquiry.aspx.cs" Inherits="VIGOR.Reports.IndentDomestic.IndentDomesticInquiry" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Domestic Inquiry Report</title>
    <link rel="shortcut icon" href="~/assets/assets/demo/default/media/img/logo/Website-Logo100x90.png" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../crystalreportviewers13/js/crviewer/crv.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div  class="form-horizontal">
            <div class="container" style="margin:5% 10% 5% 10%">
               
                    <CR:CrystalReportViewer ID="inquiryCRV" runat="server" AutoDataBind="true" ToolPanelView="None" Width="100%" />   
                
     
            </div>
        </div>
      
        
    </form>
</body>
</html>
