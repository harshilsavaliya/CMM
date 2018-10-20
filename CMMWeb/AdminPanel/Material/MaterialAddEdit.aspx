<%@ Page Title="" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="MaterialAddEdit.aspx.cs" Inherits="CMMWeb_AdminPanel_Material_MaterialAddEdit" %>

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
                                <asp:label runat="server" id="lblTitle"></asp:label>
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
                                        <asp:validationsummary id="vsMaterialAddEdit" runat="server" headertext="Please solve following error(s)." cssclass="btn btn-danger" displaymode="List" validationgroup="btnSubmit" />
                                        <asp:label runat="server" id="lblMessage"></asp:label>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="col-md-3 control-label"><span style="color: red;">*</span> Material</label>
                                        <div class="col-md-7">
                                            <asp:textbox runat="server" id="txtMaterialName" cssclass="form-control input-circle" placeholder="Enter Material Name"></asp:textbox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:requiredfieldvalidator runat="server" id="rfvMaterialName" controltovalidate="txtMaterialName" forecolor="Red" errormessage="Material Name is Compulsary" validationgroup="btnSubmit" display="Dynamic"></asp:requiredfieldvalidator>
                                                <asp:regularexpressionvalidator runat="server" id="rev" controltovalidate="txtMaterialName" forecolor="Red" errormessage="Material Name is too long" validationgroup="btnSubmit" display="Dynamic" validationexpression="^\s*([^\s]\s*){0,50}$"></asp:regularexpressionvalidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 control-label"><span style="color: red;">*</span> Material Type</label>
                                        <div class="col-md-7">
                                            <asp:dropdownlist id="ddlMaterialTypeID" runat="server" cssclass="form-control select-me input-circle" initialvalue="-1">
                                                </asp:dropdownlist>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:requiredfieldvalidator runat="server" id="rfvddlMaterialTypeID" controltovalidate="ddlMaterialTypeID" forecolor="Red" errormessage="Select Material Type" validationgroup="btnSubmit" display="Dynamic" initialvalue="-1"></asp:requiredfieldvalidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 control-label">Unit</label>
                                        <div class="col-md-7">
                                            <asp:dropdownlist id="ddlUnitID" runat="server" cssclass="form-control select-me input-circle" initialvalue="-1">
                                                </asp:dropdownlist>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="col-md-offset-3 col-md-7">
                                            <div class="checkbox">
                                                <label class="control-label">
                                                    <asp:checkbox runat="server" id="cdIsActive" value="0"></asp:checkbox>
                                                    Is System?
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-offset-4 col-md-6">
                                            <asp:button runat="server" id="btnSubmit" class="btn btn-circle green" validationgroup="btnSubmit" text="Submit" onclick="btnSubmit_Click"></asp:button>
                                            <asp:linkbutton runat="server" id="btnCancel" class="btn btn-circle grey-salsa btn-outline" href="MaterialList.aspx" text="Cancel"></asp:linkbutton>
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




