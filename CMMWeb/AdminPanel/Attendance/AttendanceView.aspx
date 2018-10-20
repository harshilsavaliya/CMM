<%@ Page Title="" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="AttendanceView.aspx.cs" Inherits="CMMWeb_AdminPanel_Attendance_AttendanceView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
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
                                <asp:Label ID="Label1" runat="server" Text="ATTENDANCE VIEW"></asp:Label>
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
                                        <td>Date :
                                            <asp:Label runat="server" ID="lblDate"></asp:Label></td>
                                        <td> Hour :
                                            <asp:Label runat="server" ID="lblHour"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Construction site :
                                            <asp:Label runat="server" ID="lblConstructionSite"></asp:Label></td>
                                        <td>Worker :
                                            <asp:Label runat="server" ID="lblWorker"></asp:Label></td>
                                    </tr>
                                    
                                    <tr>
                                        <td>Shift :
                                            <asp:Label runat="server" ID="lblShift"></asp:Label></td>
                                        <td>Attendance :
                                            <asp:Label runat="server" ID="lblAttedance"></asp:Label></td>
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

