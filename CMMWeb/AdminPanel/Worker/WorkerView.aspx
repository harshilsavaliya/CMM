<%@ Page Title="Worker View" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="WorkerView.aspx.cs" Inherits="CMMWeb_AdminPanel_Worker_WorkerView" %>

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
                                <asp:Label ID="Label1" runat="server" Text="WORKER VIEW"></asp:Label>
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
                                        <td>
                                            Proof Image :
                                            <br />
                                            <asp:Image ID="Image1" Width="10em" runat="server"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Worker : <asp:Label runat="server" ID="lblWorker"></asp:Label></td>
                                        <td>Worker Type : <asp:Label runat="server" ID="lblWorkerType"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Worker code : <asp:Label runat="server" ID="lblWorkerCode"></asp:Label></td>
                                        <td>Per day Rs. : <asp:Label runat="server" ID="lblPerDayRs"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>City : <asp:Label runat="server" ID="lblCity"></asp:Label></td>
                                        <td>Construction site : <asp:Label runat="server" ID="lblConstructionSite"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Proof : <asp:Label runat="server" ID="lblProof"></asp:Label></td>
                                        <td>Document no : <asp:Label runat="server" ID="lblProofNo"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>mobile : <asp:Label runat="server" ID="lblMobile"></asp:Label></td>
                                        <td>Alternate mobile : <asp:Label runat="server" ID="lblAMobile"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Address : <asp:Label runat="server" ID="lblAddress"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Is Active? : <asp:Label runat="server" ID="lblActive"></asp:Label></td>
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

