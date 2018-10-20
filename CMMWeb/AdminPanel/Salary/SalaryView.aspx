<%@ Page Title="" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="SalaryView.aspx.cs" Inherits="CMMWeb_AdminPanel_Salary_SalaryView" %>

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
                                        <td>Worker : <asp:Label runat="server" ID="lblWorker"></asp:Label></td>
                                        <td>Financial year : <asp:Label runat="server" ID="lblFinYear"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Month : <asp:Label runat="server" ID="lblMonth"></asp:Label></td>
                                        <td>Working days : <asp:Label runat="server" ID="lblWorkingDays"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>PerDaySalary : <asp:Label runat="server" ID="lblPerDaySalary"></asp:Label></td>
                                        <td>AbsentDays : <asp:Label runat="server" ID="lblAbsentDays"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Deduction : <asp:Label runat="server" ID="lblDeduction"></asp:Label></td>
                                        <td>Total salary : <asp:Label runat="server" ID="lblTotalSalary"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Is Paid? : <asp:Label runat="server" ID="lblIsPaid"></asp:Label></td>
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

