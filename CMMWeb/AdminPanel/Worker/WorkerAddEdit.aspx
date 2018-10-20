<%@ Page Title="" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="WorkerAddEdit.aspx.cs" Inherits="CMMWeb_AdminPanel_AddWorker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pagetitle" runat="Server">
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
                                        <asp:ValidationSummary ID="vsWorkerAddEdit" runat="server" HeaderText="Please solve following error(s)." CssClass="btn btn-danger" DisplayMode="BulletList" ValidationGroup="btnSubmit" />
                                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                    </div>
                                    <br />

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Worker name</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtWorkerName" runat="server" CssClass="form-control input-circle" placeholder="Enter Worker name" MaxLength="50">
                                            </asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvQuantity" ControlToValidate="txtWorkerName" ForeColor="Red" ErrorMessage="Worker name is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2"> Worker code</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtWorkerCode" runat="server" CssClass="form-control input-circle" placeholder="Enter Worker code" MaxLength="50" TextMode="Number">
                                            </asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Worker type </label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlWorkerTypeID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="ddlWorkerTypeID" ForeColor="Red" ErrorMessage="Select Worker type" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Construction site</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlConstructionSiteID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvSupplierID" ControlToValidate="ddlConstructionSiteID" ForeColor="Red" ErrorMessage="Select Constuction site" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2">City</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control input-circle" placeholder="Enter City" MaxLength="50">
                                            </asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtCity" ForeColor="Red" ErrorMessage="City is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Per day rupees</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtPerDayRupees" runat="server" CssClass="form-control input-circle" placeholder="Enter per day rupees" MaxLength="50">
                                            </asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtPerDayRupees" ForeColor="Red" ErrorMessage="Per day rupees is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span>Mobile</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control input-circle" placeholder="Enter mobile number" TextMode="Number"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                    ControlToValidate="txtMobile" ErrorMessage="Mobile no must be in ten digit" ForeColor="Red"
                                                    ValidationExpression="[0-9]{10}" Display="Dynamic" ValidationGroup="btnSubmit"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtMobile" ForeColor="Red" ErrorMessage="Mobile no is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2">Alternate Mobile</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtAMobile" CssClass="form-control input-circle" placeholder="Enter alternate mobile number" TextMode="Number"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                    ControlToValidate="txtAMobile" ErrorMessage="Mobile NO must be in ten digit" ForeColor="Red"
                                                    ValidationExpression="[0-9]{10}" Display="Dynamic" ValidationGroup="btnSubmit"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label">Address</label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control input-circle" placeholder="Enter Address" TextMode="MultiLine"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5" ControlToValidate="txtAddress" ForeColor="Red" ErrorMessage="Address is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,5000}$"></asp:RegularExpressionValidator>
                                                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtAddress" ForeColor="Red" ErrorMessage="Address is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span>Proof</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlProofID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="ddlConstructionSiteID" ForeColor="Red" ErrorMessage="Select Proof" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <label class="control-label col-md-2"><span style="color: red;">*</span>Document No.</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtDocumentNumber" CssClass="form-control input-circle" placeholder="Enter Document no" TextMode="Number"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtDocumentNumber" ForeColor="Red" ErrorMessage="Document is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-4">
                                            <div class="checkbox">
                                                <label class="control-label">
                                                    <asp:CheckBox runat="server" ID="cdIsActive" value="0"></asp:CheckBox>
                                                    Is Active?
                                                </label>
                                            </div>
                                        </div>
                                        <label class="control-label col-md-2"><span style="color:red;">*</span>Proof image</label>
                                        <div class="col-md-4">
                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control input-circle"></asp:FileUpload>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="FileUpload1" ForeColor="Red" ErrorMessage="Upload image of the proof" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-offset-5 col-md-6">
                                            <asp:Button runat="server" ID="btnSubmit" class="btn btn-circle green" ValidationGroup="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                                            <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-circle grey-salsa btn-outline" href="WorkerList.aspx" Text="Cancel"></asp:LinkButton>
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
