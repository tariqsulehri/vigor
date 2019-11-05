<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hello.aspx.cs" Inherits="VIGOR.Reports.hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="grdgstAccount" class="table table-bordered table-striped table-condensed flip-content"
                      runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#0098AF"
                      HeaderStyle-ForeColor="White" EmptyDataText="Record is Empty">
            <Columns>
                <asp:TemplateField HeaderText="Code">
                    <ItemTemplate>
                        <asp:Label ID="lblcode" runat="server" Text='<%#Eval("L1Code")%>'></asp:Label>
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
                        <asp:LinkButton ID="lnkSendCode" CssClass="btn btn-xs green" runat="server" CommandArgument='<%#Eval("L1Code")%>' OnClick="lnkSendCode_Click">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </form>
</body>
</html>
