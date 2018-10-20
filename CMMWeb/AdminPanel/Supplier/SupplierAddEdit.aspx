<%@ Page Title="" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="SupplierAddEdit.aspx.cs" Inherits="CMMWeb_AdminPanel_Supplier_SupplierAddEdit" %>

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
                                            <asp:ValidationSummary ID="vsCSiteAddEdit" runat="server" HeaderText="Please solve following error(s)." CssClass="btn btn-danger" DisplayMode="List" ValidationGroup="btnSubmit" />
                                            <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="col-md-3 control-label"><span style="color: red;">*</span>Supplier</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtSupplierName" CssClass="form-control input-circle" placeholder="Enter Supplier"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvSupplierName" ControlToValidate="txtSupplierName" ForeColor="Red" ErrorMessage="Supplier Name is Compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="rev" ControlToValidate="txtSupplierName" ForeColor="Red" ErrorMessage="Supplier Name is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Mobile</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control input-circle" placeholder="Enter Mobile Number" TextMode="Phone"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                        ControlToValidate="txtMobile" ErrorMessage="Mobile NO must be in ten digit" ForeColor="Red"
                                                        ValidationExpression="[0-9]{10}" Display="Dynamic" ValidationGroup="btnSubmit"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Email</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control input-circle" placeholder="Enter Email Address"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator2" ValidationGroup="btnSubmit" runat="server" ErrorMessage="Enter Email ID in correct format" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Address</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control input-circle" placeholder="Enter Address" TextMode="MultiLine"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtAddress" ForeColor="Red" ErrorMessage="Address is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,1000}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">State</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtState" CssClass="form-control input-circle" placeholder="Enter State"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator4" ControlToValidate="txtState" ForeColor="Red" ErrorMessage="State Name is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">City</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtCity" CssClass="form-control input-circle" placeholder="Enter City"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5" ControlToValidate="txtCity" ForeColor="Red" ErrorMessage="City Name is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Contact Person</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtContactPerson" CssClass="form-control input-circle" placeholder="Enter Contact Person Name"></asp:TextBox>
                                            </div>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator6" ControlToValidate="txtContactPerson" ForeColor="Red" ErrorMessage="Name of the Contact person is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="col-md-offset-3 col-md-7">
                                                <div class="checkbox">
                                                    <label class="control-label">
                                                        <asp:CheckBox runat="server" ID="cdIsActive" value="0"></asp:CheckBox>
                                                        Is Active?
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-offset-4 col-md-6">
                                                <asp:Button runat="server" ID="btnSubmit" class="btn btn-circle green" ValidationGroup="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                                                <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-circle grey-salsa btn-outline" href="SupplierList.aspx" Text="Cancel"></asp:LinkButton>
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

