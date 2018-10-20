<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="CMMWeb_AdminPanel_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageTitle" runat="server">
    Dashboard <small>dashboard & statistics</small>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="actualContent" runat="server">
    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat blue">
                <div class="visual">
                    <i class="icon-bar-chart"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <span data-counter="counterup" data-value="2" id="counter" runat="server">0</span>
                    </div>
                    <div class="desc">Construction Sites</div>
                </div>
                <a class="more" href="../ConstructionSite/ConstructionSiteList.aspx">View more
                     <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat red">
                <div class="visual">
                    <i class="fa fa-user-circle"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <span data-counter="counterup" data-value="12">0</span>
                    </div>
                    <div class="desc">Suppliers</div>
                </div>
                
                <a class="more" href="../Supplier/SupplierList.aspx">View more
                  <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat green">
                <div class="visual">
                    <i class="fa fa-address-card"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <span data-counter="counterup" data-value="5">0</span>
                    </div>
                    <div class="desc">Material Receipts </div>
                </div>
                <a class="more" href="../MaterialReceipt/MaterialReceiptList.aspx">View more
                    <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat purple">
                <div class="visual">
                    <i class="fa fa-globe"></i>
                </div>
                <div class="details">
                    <div class="number">
                        +
                                    <span data-counter="counterup" data-value="89"></span>%
                    </div>
                    <div class="desc">Brand Popularity </div>
                </div>
                <a class="more" href="javascript:;">View more
                   <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
