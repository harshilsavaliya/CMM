<%@ Page Title="Financial year view" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="FinYearView.aspx.cs" Inherits="CMMWeb_AdminPanel_FinYear_FinYearView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="breadCrumb" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="actualContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="tab-content">
                <div class="tab-pane active" id="tab_0">
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-gift"></i>
                                <asp:Label ID="Label1" runat="server" Text="FINANCIAL YEAR VIEW"></asp:Label>
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
                                        <td>From date :
                                            <asp:Label runat="server" ID="lblFromDate"></asp:Label></td>
                                        <td>To date :
                                            <asp:Label runat="server" ID="lblToDate"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Fin. Year :
                                            <asp:Label runat="server" ID="lblFinYear"></asp:Label></td>
                                        <td>Sequence :
                                            <asp:Label runat="server" ID="lblSequence"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Is Active? :
                                            <asp:Label runat="server" ID="lblIsActive"></asp:Label>
                                        </td>
                                        <td></td>
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

