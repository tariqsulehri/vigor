<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlAccount.aspx.cs" Inherits="VIGOR.Reports.ControlBalance.PaymentAndReceipts" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CONTROL ACCOUNTS</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../crystalreportviewers13/js/crviewer/crv.js"></script>
    <style type="text/css">
        .Background {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 1000px;
            height: 600px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
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
    
    <script>
        $(document).ready(function () {
            $("#SearchCOA").keyup(function (e) {
                SearchCOA();
            });
        });
        function SearchCOA() {
            var value = $('#SearchCOA').val().toUpperCase();
            $("#grdgstAccount tr").each(function (index) {
                if (index !== 0) {
                    $row = $(this);
                    var id = $row.find("td:eq(0)").text();
                    var Name = $row.find("td:eq(1)").text();
                    if ((id.toUpperCase().indexOf(value) > -1) || (Name.toUpperCase().indexOf(value) > -1)) {
                        $(this).show();
                    }
                    else {
                        $(this).hide();
                    }

                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="jumbotron">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="row">

            <div class="col-lg-12 container">
                <div class="row" style="text-align: center"><b>CONTROL ACCOUNTS</b></div>
                <hr />
                <div class="col-lg-2">
                    <label>From</label>
                    <input type="date" id="FromDate" class="form-control" name="FromDate" runat="server" />
                </div>
                <div class="col-lg-2">
                    <label>To</label>
                    <input type="date" id="ToDate" class="form-control" name="ToDate" runat="server" />
                </div>
                <div class="col-lg-1">

                    <br />
                    <asp:UpdatePanel ID="UpbtnOpen" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnOpen" runat="server" Text="Account" CssClass="btn btn-warning" OnClick="btnOpen_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-lg-3">
                    <label>Account Code</label>
                    <div class="form-group">
                        <input type="text" id="AccountCode" name="AccountCode" runat="server" class="form-control" readonly="readonly" />
                    </div>
                </div>
                <div class="col-lg-4">
                    <label>Account Title</label>
                    <div class="form-group">
                        <input type="text" id="AccountTitle" name="AccountTitle" runat="server" class="form-control" readonly="readonly" />
                    </div>
                </div>
                <div class="col-lg-2">
                    <label>Location</label>
                    <div class="form-group">
                        <asp:DropDownList ID="LueLoac" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3">
                    <label>Department</label>
                    <div class="form-group">
                        <asp:DropDownList ID="LueDep" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3">
                    <label>Employee</label>
                    <div class="form-group">
                        <asp:DropDownList ID="LueEmp" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3">
                    <label>Report Type</label>
                    <div class="form-group">
                        <asp:DropDownList ID="rptType" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-1">
                    <br />
                    <asp:Button ID="ShowReport" runat="server" Text="Show Report" CssClass="btn btn-danger" OnClick="ShowReport_Click" />
                </div>

            </div>
            <div class="container col-lg-12">
                <CR:CrystalReportViewer ID="ControlAccountCRV" runat="server" AutoDataBind="True" ToolPanelView="None" />

            </div>
        </div>

        <div id="AccountModal" class="modal fade" tabindex="-1">
            <div class="modal-dialog" style="width: 75%">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: white">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <h4>
                                    <asp:Label class="modal-title" ID="lblModalTitle" ForeColor="#0098AF" runat="server" Text="Account"></asp:Label></h4>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal-body" style="background-color: white">
                        <div class="input-group add-on">
                            <input id="SearchCOA" class="form-control" type="text" placeholder="Search" style="width: 400px" /></div>

                        <div class="table-responsive">
                            <div style="overflow-y: auto; height: 400px">
                                <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>--%>
                                        <asp:GridView ID="grdgstAccount" class="table table-bordered table-striped table-condensed"
                                            runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#0098AF"
                                            HeaderStyle-ForeColor="White" DataKeyNames="Code" EmptyDataText="Record is Empty" Style="height: 300px">

                                            <Columns>
                                                <asp:TemplateField HeaderText="Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Title">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkSendCode" CssClass="btn-danger btn-xs" runat="server" CommandArgument='<%#Eval("Code")%>' OnClick="lnkSelectedRowt_Click">Select</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                   <%-- </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                    </div>



                    <div class="modal-footer" style="background-color: white">
                        <div class="col-md-12 ">
                            <div class="ls-button-group demo-btn pull-right">
                                <asp:UpdatePanel ID="upbtnSubmitDoctor" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnCloseModel" runat="server" Text="Close" class="btn" CausesValidation="false" OnClick="btnClose_click" />
                                        &nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>


    </form>

</body>
</html>
