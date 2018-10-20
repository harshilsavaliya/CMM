<%@ Page Title="Salary List" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="SalaryList.aspx.cs" Inherits="CMMWeb_AdminPanel_Salary_SalaryList" %>

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
            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Salary List</span>
                    </div>
                    <div class="actions">
                        <asp:LinkButton runat="server" ID="btnAdd" href="SalaryAddEdit.aspx" Text="ADD" class="btn btn-lg btn-transparent grey-salsa btn-outline btn-circle active">
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-container table-responsive">
                        <asp:GridView ID="gvSalaryList" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered table-hover" OnRowCommand="gvSalaryList_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="WorkerName" HeaderText="Worker" />
                                <asp:BoundField DataField="MonthName" HeaderText="Month" />
                                <%--<asp:BoundField DataField="FinYear" HeaderText="Fin. Year" />--%>
                                <asp:BoundField DataField="TotalWorkingDays" HeaderText="Working days" />
                                <asp:BoundField DataField="PerDaySalary" HeaderText="Per day salary" />
                                <asp:BoundField DataField="AbsentDays" HeaderText="Absent days" />
                                <asp:BoundField DataField="Deduction" HeaderText="Deduction" />
                                <asp:BoundField DataField="TotalSalary" HeaderText="Total Salary" />
                                <asp:BoundField DataField="IsPaid" HeaderText="Is Paid?" />                                
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        
                                        <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%# "~/CMMWeb/AdminPanel/Salary/SalaryAddEdit.aspx?SalaryID="+Eval("SalaryID").ToString()%>' data-toggle="tooltip" data-placement="bottom" title="Edit">
                                        <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                        </asp:HyperLink>

                                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteSalary" CommandArgument='<%# Eval("SalaryID") %>' data-toggle="tooltip" data-placement="bottom" title="Delete">
                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                        </asp:LinkButton>

                                        <asp:HyperLink ID="hlView" runat="server" NavigateUrl='<%# "~/CMMWeb/AdminPanel/Salary/SalaryView.aspx?SalaryID="+Eval("SalaryID").ToString()%>' data-toggle="tooltip" data-placement="bottom" title="View">
                                        <i class="fa fa-list-alt" aria-hidden="true"></i>
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

            </div>
            <!-- End: life time stats -->
        </div>
    </div>
</asp:Content>

