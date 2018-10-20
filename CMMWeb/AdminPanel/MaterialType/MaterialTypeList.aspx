<%@ Page Title="MaterialType List" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="MaterialTypeList.aspx.cs" Inherits="CMMWeb_AdminPanel_MaterialType_MaterialTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitle" Runat="Server">
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
                        <span class="caption-subject font-green sbold uppercase">Materialtype List</span>
                    </div>
                    <div class="actions">
                        <asp:LinkButton runat="server" ID="btnAdd" href="MaterialTypeAddEdit.aspx" Text="ADD" class="btn btn-lg btn-transparent grey-salsa btn-outline btn-circle active">
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-container table-responsive">
                        <asp:GridView ID="gvMaterialTypeList" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered table-hover" OnRowCommand="gvMaterialTypeList_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="MaterialTypeName" HeaderText="Material Type" />
                                <asp:BoundField DataField="IsSystem" HeaderText="Is System?" />

                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        
                                        <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%# "~/CMMWeb/AdminPanel/MaterialType/MaterialTypeAddEdit.aspx?MaterialTypeID="+Eval("MaterialTypeID").ToString()%>' data-toggle="tooltip" data-placement="bottom" title="Edit">
                                        <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                        </asp:HyperLink>

                                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteMaterialType" CommandArgument='<%# Eval("MaterialTypeID") %>' data-toggle="tooltip" data-placement="bottom" title="Delete">
                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                        </asp:LinkButton>

                                        <asp:HyperLink ID="hlView" runat="server" NavigateUrl='<%# "~/CMMWeb/AdminPanel/MaterialType/MaterialTypeView.aspx?MaterialTypeID="+Eval("MaterialTypeID").ToString()%>' data-toggle="tooltip" data-placement="bottom" title="View">
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

