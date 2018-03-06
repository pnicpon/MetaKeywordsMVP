<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainView.aspx.cs" Inherits="MetaKeywords.Views.MainView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><asp:Label ID="lblHeader" runat="server"></asp:Label></h1>
        </div>
        <asp:Panel ID="pnlUrl" runat="server" DefaultButton="btnGetSearchResult">
            <asp:Label ID="lblUrl" runat="server" Text="Wprowadź URL"></asp:Label>
            <asp:TextBox ID="txtUrl" runat="server" autocomplete="off" Width="350px"></asp:TextBox>
            <asp:CheckBox ID="cbShowPage" runat="server" />
            <asp:Button ID="btnGetSearchResult" runat="server" OnClick="btnGetSearchResult_Click" ValidationGroup="form" />
            <br />            
            <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ControlToValidate="txtUrl" Display="Dynamic" ForeColor="Red" ValidationGroup="form"></asp:RequiredFieldValidator>
        </asp:Panel>
        <asp:Panel ID="pnlMessage" runat="server" Visible="false">
            <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="pnlResult" runat="server" Visible="false" style="float:left; width:250px; margin-top:10px;">
            <asp:GridView ID="gridResult" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="355px">
                <Columns>
                    <asp:BoundField DataField="Keyword" />
                    <asp:BoundField DataField="Count" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="pnlPreview" runat="server" Visible="false">
            <iframe id="framePreview" runat="server" scrolling="auto" style="width:100%; height: 500px;"></iframe>
        </asp:Panel>
    </form>
</body>
</html>
