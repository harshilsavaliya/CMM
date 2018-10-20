<%@ Page Title=""  ValidateRequest="false" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="Sample.aspx.cs" Inherits="CMMWeb_AdminPanel_Sample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="breadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="actualContent" runat="Server">
    <asp:Panel runat="server" ID="pnl">
    <div id="Grid">

        <table  style="border-collapse: collapse; border: 1px solid #ccc; font-size: 9pt;">
            <tr>
                <th style="background-color: #B8DBFD; border: 1px solid #ccc">Customer Id</th>
                <th style="background-color: #B8DBFD; border: 1px solid #ccc">Name</th>
                <th style="background-color: #B8DBFD; border: 1px solid #ccc">Country</th>
            </tr>
            <tr>
                <td style="width: 120px; border: 1px solid #ccc">1</td>
                <td style="width: 150px; border: 1px solid #ccc">John Hammond</td>
                <td style="width: 120px; border: 1px solid #ccc">United States</td>
            </tr>
            <tr>
                <td style="width: 120px; border: 1px solid #ccc">2</td>
                <td style="width: 150px; border: 1px solid #ccc">Mudassar Khan</td>
                <td style="width: 120px; border: 1px solid #ccc">India</td>
            </tr>
            <tr>
                <td style="width: 120px; border: 1px solid #ccc">3</td>
                <td style="width: 150px; border: 1px solid #ccc">Suzanne Mathews</td>
                <td style="width: 120px; border: 1px solid #ccc">France</td>
            </tr>
            <tr>
                <td style="width: 120px; border: 1px solid #ccc">4</td>
                <td style="width: 150px; border: 1px solid #ccc">Robert Schidner</td>
                <td style="width: 120px; border: 1px solid #ccc">Russia</td>
            </tr>
    <asp:Image ID="Image1" Width="10em" runat="server" />

        </table>
    </div>
    </asp:Panel>
    <br />
    <asp:HiddenField ID="hfGridHtml" runat="server" />
    <asp:Button ID="btnExport" runat="server" Text="Export To PDF" OnClick="btnExport_Click" />
</asp:Content>

