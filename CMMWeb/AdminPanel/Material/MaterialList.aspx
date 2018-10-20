<%@ Page Title="Material List" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="MaterialList.aspx.cs" Inherits="CMMWeb_AdminPanel_Material_MaterialList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="breadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="actualContent" runat="Server">
    <div class="m-heading-1 border-green m-bordered">
        <div class="row">
            <div class="col-xs-6">
                <asp:DropDownList ID="ddlMaterialTypeID" runat="server" CssClass=" form-control select-me input-circle" AutoPostBack="True" InitialValue="-1">
                </asp:DropDownList>
            </div>
          
            <div class="col-xs-6">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-sm btn-transparent grey-salsa btn-outline btn-circle active" Text="Search" OnClick="btnSearch_Click" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <!-- Begin: life time stats -->
            <div class="portlet light portlet-fit portlet-datatable bordered">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-settings font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Material List</span>
                    </div>
                    <div class="actions">
                        <asp:LinkButton runat="server" ID="btnAdd" href="MaterialAddEdit.aspx" Text="ADD" class="btn btn-lg btn-transparent grey-salsa btn-outline btn-circle active">
                        </asp:LinkButton>
                    </div>
                </div>

                <div class="portlet-body">
                    <div class="table-container table-responsive">
                        <asp:GridView ID="gvMaterialList" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered table-hover" OnRowCommand="gvMaterialList_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="MaterialName" HeaderText="Material" />
                                <asp:BoundField DataField="MaterialTypeName" HeaderText="Material Type" />
                                <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                                <asp:BoundField DataField="IsSystem" HeaderText="Is System?" />

                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>

                                        <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%# "~/CMMWeb/AdminPanel/Material/MaterialAddEdit.aspx?MaterialID="+Eval("MaterialID").ToString()%>' data-toggle="tooltip" data-placement="bottom" title="Edit">
                                        <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                        </asp:HyperLink>

                                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteMaterial" CommandArgument='<%# Eval("MaterialID") %>' data-toggle="tooltip" data-placement="bottom" title="Delete">
                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                        </asp:LinkButton>

                                        <asp:HyperLink ID="hlView" runat="server" NavigateUrl='<%# "~/CMMWeb/AdminPanel/Material/MaterialView.aspx?MaterialID="+Eval("MaterialID").ToString()%>' data-toggle="tooltip" data-placement="bottom" title="View">
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

