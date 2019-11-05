<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentAndReceipts.aspx.cs" Inherits="VIGOR.Reports.PaymentsAndReceipts.PaymentAndReceipts" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment & Receipts</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../crystalreportviewers13/js/crviewer/crv.js"></script>
    <style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
    </style>
    <style>
        label {
            font-weight: normal !important;
            margin-bottom: 0px !important;
        }
        .jumbotron {
            font-size: 14px !important;
            /*line-height: 0px !important;*/
        }
        hr {
            margin: 0px;
            border-top: 1px solid #080808;
    
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="jumbotron">

        <div class="row">
            <div class="container col-lg-12">
              
                <div class="row" style="text-align: center"><b>PAYMENTS & RECEIPTS</b></div>
                <hr/>
                
                <div class="col-lg-2">
                 <label>From</label>

                    <input type="date" id="FromDate" class="form-control" name="FromDate" runat="server" />

                </div>
                <div class="col-lg-2">
                    <label>To</label>
                    <input type="date" id="ToDate" class="form-control" name="ToDate" runat="server" />
                </div>
                <div class="col-lg-2">
                    <label>Account Code</label>
                    
                    <div class="form-group">

                        <asp:DropDownList ID="lueAccounts" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4">
                    <label>Report Type</label>
                    <div class="form-group">

                        <asp:DropDownList ID="rptType" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-2">
                    <br />
                    <asp:Button ID="btnPrint" runat="server" Text="Show Report" CssClass="btn btn-danger" OnClick="btnPrint_Click" />
                </div>

            </div>
            <div class="container col-lg-12">
                <CR:CrystalReportViewer ID="crvPaymentandReceipt" runat="server" AutoDataBind="true" ToolPanelView="None" Width="100%" PrintMode="ActiveX" />

            </div>
        </div>


    </form>
</body>
</html>
