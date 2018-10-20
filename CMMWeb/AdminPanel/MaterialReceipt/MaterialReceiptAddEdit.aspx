<%@ Page Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="MaterialReceiptAddEdit.aspx.cs" Inherits="CMMWeb_AdminPanel_MaterialReceipt_MaterialReceiptAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="breadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="actualContent" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="tab-content">
                <div class="tab-pane active" id="tab_0">
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-gift"></i>
                                <asp:Label runat="server" ID="lblTitle"></asp:Label>
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <!-- BEGIN FORM-->
                            <div class="form-horizontal">
                                <div class="form-body">
                                    <div style="font-size: medium; text-align: center; color: red;">
                                        <asp:ValidationSummary ID="vsMRAddEdit" runat="server" HeaderText="Please solve following error(s)." CssClass="btn btn-danger" DisplayMode="List" ValidationGroup="btnSubmit" />
                                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                    </div>
                                    <br />

                                    <div class="form-group">
                                        <label class="control-label col-md-2">Receipt No</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtReceiptNo" CssClass="form-control input-circle" placeholder="Enter Receipt No"></asp:TextBox>
                                            <asp:RegularExpressionValidator runat="server" ID="rev" ControlToValidate="txtReceiptNo" ForeColor="Red" ErrorMessage="Receipt no is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{0,10}$"></asp:RegularExpressionValidator>
                                        </div>

                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Receipt Date</label>
                                        <div class="col-md-4">
                                            <div class="input-group input-append date" id="datePicker">
                                                <asp:TextBox runat="server" ID="txtReceiptDate" name="date" class="form-control" placeholder="Start Date"></asp:TextBox>
                                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>

                                            <%--<asp:TextBox runat="server" ID="txtReceiptDate" CssClass="form-control input-circle" placeholder="Enter Receipt Date"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvReceiptDate" ControlToValidate="txtReceiptDate" ForeColor="Red" ErrorMessage="Receipt Date is Compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator Operator="DataTypeCheck" Type="Date" runat="server" ControlToValidate="txtReceiptDate" ErrorMessage="Receipt Date must be in dd/MM/yyyy format" ForeColor="Red" ValidationGroup="btnSubmit" Display="Dynamic"></asp:CompareValidator>
                                                </div>--%>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label"><span style="color: red;">*</span> Construction Site</label>
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="ddlConstructionSiteID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvConstructionSite" ControlToValidate="ddlConstructionSiteID" ForeColor="Red" ErrorMessage="Select Construction Site" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Material Type</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlMaterialTypeID" runat="server" CssClass="form-control select-me input-circle"  InitialValue="-1" OnSelectedIndexChanged="ddlMaterialTypeID_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvddlMaterialTypeID" ControlToValidate="ddlMaterialTypeID" ForeColor="Red" ErrorMessage="Select Material Type" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Material</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlMaterialID" runat="server" CssClass="form-control select-me input-circle"  InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddlMaterialID" ForeColor="Red" ErrorMessage="Select Material" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Quantity</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control input-circle" placeholder="Enter Quantity">
                                            </asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvQuantity" ControlToValidate="txtQuantity" ForeColor="Red" ErrorMessage="Quantity is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ControlToValidate="txtQuantity" ForeColor="Red" ErrorMessage="Quantity is must be in digit and it is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^[0-9]{0,15}$"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Unit</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlUnitID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="ddlUnitID" ForeColor="Red" ErrorMessage="Select Unit" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Contractor</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlContractorID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvContractor" ControlToValidate="ddlContractorID" ForeColor="Red" ErrorMessage="Select Contractor" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Supplier</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlSupplierID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvSupplierID" ControlToValidate="ddlSupplierID" ForeColor="Red" ErrorMessage="Select Supplier" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2">Vehicle No</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtVehicle" CssClass="form-control input-circle" placeholder="Enter Vehicle No"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtVehicle" ForeColor="Red" ErrorMessage="Vehicle no must be in proper format like GJ 12 MJ 1240" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^([A-Z|a-z]{2}\s{1}\d{2}\s{1}[A-Z|a-z]{1,2}\s{1}\d{1,4})?([A-Z|a-z]{3}\s{1}\d{1,4})?$"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2">Driver</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtDriverName" CssClass="form-control input-circle" placeholder="Enter Driver Name"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator4" ControlToValidate="txtDriverName" ForeColor="Red" ErrorMessage="Driver name is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label">Other Details</label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="txtOtherDetail" CssClass="form-control input-circle" placeholder="Enter Other Details" TextMode="MultiLine"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5" ControlToValidate="txtOtherDetail" ForeColor="Red" ErrorMessage="Other Detail is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,5000}$"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-offset-5 col-md-6">
                                            <asp:Button runat="server" ID="btnSubmit" class="btn btn-circle green" ValidationGroup="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                                            <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-circle grey-salsa btn-outline" href="MaterialReceiptList.aspx" Text="Cancel"></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- END FORM-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
