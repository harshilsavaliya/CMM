<%@ Page Title="" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="UnitAddEdit.aspx.cs" Inherits="CMMWeb_AdminPanel_Unit_UnitAddEdit" %>

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
                                            <asp:ValidationSummary ID="vsUnitAddEdit" runat="server" HeaderText="Please solve following error(s)." CssClass="btn btn-danger" DisplayMode="List" ValidationGroup="btnSubmit" />
                                            <asp:Label runat="server" ID="lblMessage"></asp:Label>  
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="col-md-3 control-label"><span style="color: red;">*</span> Unit</label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtUnitName" CssClass="form-control input-circle" placeholder="Enter Unit"></asp:TextBox>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvUnitName" ControlToValidate="txtUnitName" ForeColor="Red" ErrorMessage="Unit Name is Compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtUnitName" ForeColor="Red" ErrorMessage="Unit is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="col-md-offset-3 col-md-7">
                                                <div class="checkbox">
                                                    <label class="control-label">
                                                        <asp:CheckBox runat="server" ID="cdIsActive" value="0"></asp:CheckBox>
                                                        Is System?
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <div class="row">
                                            <div class="col-md-offset-4 col-md-6">
                                                <asp:Button runat="server" ID="btnSubmit" class="btn btn-circle green" ValidationGroup="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                                                <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-circle grey-salsa btn-outline" href="UnitList.aspx" Text="Cancel"></asp:LinkButton>
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

