<%@ Page Title="MaterialReceipt View" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="MaterialReceiptView.aspx.cs" Inherits="CMMWeb_AdminPanel_MaterialReceipt_MaterialReceiptView" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        tr, td
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="breadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="actualContent" runat="Server">
    <asp:Panel runat="server" ID="pnl">
        <div class="row">
            <div class="col-md-12">
                <div class="tab-content">
                    <div class="tab-pane active" id="tab_0">
                        <div class="portlet box green">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-gift"></i>
                                    <asp:Label runat="server" Text="MATERIALRECEIPT VIEW"></asp:Label>
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a>
                                    <a href="javascript:;" class="remove"></a>
                                </div>
                            </div>
                            <div class="portlet-body form">
                                <div class="form-body">
                                    <h1 align="center">Delivery Challan</h1>
                                    <table class="table table-responsive" align="center" width="85%" height="65%" cellpadding="5px">
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image1" Width="10em" runat="server" ImageUrl='<%#Eval("ImageData",GetUrl("{0}")) %>'/>
                                            </td>
                                            <td>
                                                <h2><asp:Label runat="server" ID="lblOrganization"></asp:Label></h2><br />
                                                Address:- <asp:Label runat="server" ID="lblAddress"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  style="font-size:large;">Receipt No :
                                                <asp:Label runat="server" ID="lblReceiptNo"></asp:Label>
                                            </td >
                                            <td style="font-size:large;">Receipt Date :
                                                <asp:Label runat="server" ID="lblReceiptDate"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="font-size:large;">Constructionsite :
                                                <asp:Label runat="server" ID="lblConstructionSite"></asp:Label></td>
                                             <td style="font-size:large;">Contractor :
                                                <asp:Label runat="server" ID="lblContractorName"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td style="font-size:large;">Materialtype Name :
                                                <asp:Label runat="server" ID="lblMaterialTypeName"></asp:Label></td>
                                            <td style="font-size:large;">Material Name :
                                                <asp:Label runat="server" ID="lblMaterialName"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="font-size:large;">Quantity :
                                                <asp:Label runat="server" ID="lblQuantity"></asp:Label></td>
                                            <td style="font-size:large;">Unit :
                                                <asp:Label runat="server" ID="lblUnitName"></asp:Label></td>
                                            
                                        </tr>
                                        
                                        <tr>
                                            <td style="font-size:large;">Supplier :
                                                <asp:Label runat="server" ID="lblSupplierName"></asp:Label></td>
                                            <td style="font-size:large;">Vehicle No :
                                                <asp:Label runat="server" ID="lblVehicleNo"></asp:Label></td>
                                            
                                        </tr>

                                        <tr>
                                            <td style="font-size:large;">Driver :
                                                <asp:Label runat="server" ID="lblDriverName"></asp:Label></td>
                                            <td style="font-size:large;">Other Details :
                                                <asp:Label runat="server" ID="lblOtherDetail"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <%--<br />
                                    <asp:HiddenField ID="hfGridHtml" runat="server" />--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div>
        <asp:Button runat="server" ID="btnPrint" class="btn btn-transparent grey-salsa btn-outline btn-circle active" OnClick="btnPrint_Click" Text="PRINT" />
    </div>
</asp:Content>

