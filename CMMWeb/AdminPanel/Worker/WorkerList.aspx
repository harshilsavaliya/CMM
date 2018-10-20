<%@ Page Title="Worker List" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="WorkerList.aspx.cs" Inherits="CMMWeb_AdminPanel_Worker_WorkerList" %>

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
            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Worker List</span>
                    </div>
                   <div class="actions">
                        <asp:LinkButton runat="server" ID="btnAdd" href="WorkerAddEdit.aspx" Text="ADD" class="btn btn-lg btn-transparent grey-salsa btn-outline btn-circle active">
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-container table-responsive">
                        <asp:GridView ID="gvWorkerList" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered table-hover" OnRowCommand="gvWorkerList_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="WorkerName" HeaderText="Worker" />
                                <asp:BoundField DataField="WorkerCode" HeaderText="Worker code"/>
                                <asp:BoundField DataField="WorkerTypeName" HeaderText="Worker type" />
                                <asp:BoundField DataField="PerDayRupees" HeaderText="Per day Rs."/>
                                <asp:BoundField DataField="CityName" HeaderText="City" />
                                <asp:BoundField DataField="ConstructionSiteName" HeaderText="Constructionsite" />
                                <asp:BoundField DataField="ProofName" HeaderText="Proof"/>
                                <asp:BoundField DataField="ProofNo" HeaderText="Proof no" />
                                <asp:BoundField DataField="MobileNo" HeaderText="Mobile" />
                                <asp:BoundField DataField="AMobileNo" HeaderText="Alternate mobile" />
                                <asp:BoundField DataField="IsActive" HeaderText="Is Active?" />

                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        
                                        <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%# "~/CMMWeb/AdminPanel/Worker/WorkerAddEdit.aspx?WorkerID="+Eval("WorkerID").ToString()%>' data-toggle="tooltip" data-placement="bottom" title="Edit">
                                        <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                        </asp:HyperLink>

                                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteWorker" CommandArgument='<%# Eval("WorkerID") %>' data-toggle="tooltip" data-placement="bottom" title="Delete">
                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                        </asp:LinkButton>

                                        <asp:HyperLink ID="hlView" runat="server" NavigateUrl='<%# "~/CMMWeb/AdminPanel/Worker/WorkerView.aspx?WorkerID="+Eval("WorkerID").ToString()%>' data-toggle="tooltip" data-placement="bottom" title="View">
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