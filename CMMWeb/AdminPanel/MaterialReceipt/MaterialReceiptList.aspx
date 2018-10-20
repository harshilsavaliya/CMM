<%@ Page Title="MaterialReceipt List" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="MaterialReceiptList.aspx.cs" Inherits="CMMWeb_AdminPanel_MaterialReceiptReceipt_MaterialReceiptReceiptList" %>

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
                <asp:DropDownList ID="ddlConstructionSiteID" runat="server" CssClass=" form-control select-me input-circle" AutoPostBack="True" InitialValue="-1">
                </asp:DropDownList>
            </div>
            <div class="col-xs-6">
                <asp:DropDownList ID="ddlMaterialID" runat="server" CssClass=" form-control select-me input-circle" AutoPostBack="True" InitialValue="-1">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-xs-6">
                <asp:DropDownList ID="ddlContractorID" runat="server" CssClass=" form-control select-me input-circle" AutoPostBack="True" InitialValue="-1">
                </asp:DropDownList>
            </div>
            <div class="col-xs-6">
                <asp:DropDownList ID="ddlSupplierID" runat="server" CssClass=" form-control select-me input-circle" AutoPostBack="True" InitialValue="-1">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="form-group">
                <div class="col-xs-6">
                    <div class="input-group input-append date" id="datePicker">
                        <asp:TextBox runat="server" ID="txtFromDate" name="date" class="form-control" placeholder="Start Date"></asp:TextBox>
                        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>
                    <!-- /input-group -->                   
                </div>
                <div class="col-xs-6">
                    <div class="input-group input-append date" id="datePicker2">
                        <asp:TextBox runat="server" ID="txtToDate" name="date" class="form-control" placeholder="End Date"></asp:TextBox>
                        <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>
                </div>
            </div>              
        </div>
        <br />
        <div class="row">
            <div class="col-xs-11 col-md-11">
            <div class="col-xs-offset-5 col-md-offset-6">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-sm btn-transparent grey-salsa btn-outline btn-circle active" Text="Search" OnClick="btnSearch_Click1" />
            </div>
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
                        <span class="caption-subject font-green sbold uppercase">MaterialReceipt List</span>
                    </div>
                    <div class="actions">
                        <asp:LinkButton runat="server" ID="btnAdd" href="MaterialReceiptAddEdit.aspx" Text="ADD" class="btn btn-lg btn-transparent grey-salsa btn-outline btn-circle active">
                        </asp:LinkButton>
                        <asp:Button runat="server" ID="btnPrint" class="btn btn-lg btn-transparent grey-salsa btn-outline btn-circle active" OnClick="btnPrint_Click" Text="PRINT"/>

                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-container table-responsive">
                        <asp:GridView ID="gvMaterialReceiptList" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered table-hover" OnRowCommand="gvMaterialReceiptList_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No"/>
                                <asp:BoundField DataField="ReceiptDate" HeaderText="Receipt Date" DataFormatString="{0:dd-MM-yyyy}"/>
                                <asp:BoundField DataField="ConstructionSiteName" HeaderText="Construction Site" />
                                <asp:BoundField DataField="MaterialName" HeaderText="Material" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                <asp:BoundField DataField="UnitName" HeaderText="Unit" />
                                <asp:BoundField DataField="ContractorName" HeaderText="Contractor" />
                                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" />

                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%# "~/CMMWeb/AdminPanel/MaterialReceipt/MaterialReceiptAddEdit.aspx?MaterialReceiptID="+Eval("MaterialReceiptID").ToString()%>' data-toggle="tooltip" data-placement="bottom" title="Edit">
                                        <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                        </asp:HyperLink>

                                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteMaterialReceipt" CommandArgument='<%# Eval("MaterialReceiptID") %>' data-toggle="tooltip" data-placement="bottom" title="Delete">
                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                        </asp:LinkButton>

                                        <asp:HyperLink ID="hlView" runat="server" NavigateUrl='<%# "~/CMMWeb/AdminPanel/MaterialReceipt/MaterialReceiptView.aspx?MaterialReceiptID="+Eval("MaterialReceiptID").ToString()%>' data-toggle="tooltip" data-placement="bottom" title="View">
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

