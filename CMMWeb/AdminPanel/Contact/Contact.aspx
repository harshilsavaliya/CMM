<%@ Page Title="Contact" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="CMMWeb_AdminPanel_Contact_Contact" %>

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
                                    <asp:Label runat="server">Contact</asp:Label>
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
                                            <label class="col-md-3 control-label"><span style="color: red;">*</span>Name</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtName" CssClass="form-control input-circle" placeholder="Enter Name"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvSupplierName" ControlToValidate="txtName" ForeColor="Red" ErrorMessage="Name is Compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="rev" ControlToValidate="txtName" ForeColor="Red" ErrorMessage="Name is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label"><span style="color: red;">*</span>Email</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control input-circle" placeholder="Enter Email Address"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator2" ValidationGroup="btnSubmit" runat="server" ErrorMessage="Enter Email ID in correct format" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Email is Compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label"><span style="color: red;">*</span>Subject</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtSubject" CssClass="form-control input-circle" placeholder="Enter Subject"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtSubject" ForeColor="Red" ErrorMessage="Subject is Compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtSubject" ForeColor="Red" ErrorMessage="Subject is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label"><span style="color: red;">*</span>Message</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtMessage" CssClass="form-control input-circle" placeholder="Enter Message" TextMode="MultiLine"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtMessage" ForeColor="Red" ErrorMessage="Message is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,1000}$"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtMessage" ForeColor="Red" ErrorMessage="Message is Compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div> 
                                    </div>
                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-offset-3 col-md-7">
                                                <asp:Button runat="server" ID="btnSubmit" class="btn btn-circle green" ValidationGroup="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
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

