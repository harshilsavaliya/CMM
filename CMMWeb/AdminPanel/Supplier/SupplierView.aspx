<%@ Page Title="Supplier View" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="SupplierView.aspx.cs" Inherits="CMMWeb_AdminPanel_Supplier_SupplierView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="breadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="actualContent" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="tab-content">
                <div class="tab-pane active" id="tab_0">
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-gift"></i>
                                <asp:Label runat="server" Text="SUPPLIER VIEW"></asp:Label>
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <div class="form-body">
                                <table class="table table-responsive">
                                    <tr>
                                        <td colspan="2">Supplier :
                                            <asp:Label runat="server" ID="lblSupplierName"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>Email :
                                            <asp:Label runat="server" ID="lblEmail"></asp:Label></td>
                                        <td>Mobile :
                                            <asp:Label runat="server" ID="lblMobile"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Address :
                                            <asp:Label runat="server" ID="lblAddress"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>State :
                                            <asp:Label runat="server" ID="lblState"></asp:Label></td>
                                        <td>City :
                                            <asp:Label runat="server" ID="lblCity"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>ContactPerson :
                                            <asp:Label runat="server" ID="lblContactPerson"></asp:Label></td>
                                        <td>Is Active? :
                                            <asp:Label runat="server" ID="lblIsSystem"></asp:Label></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

