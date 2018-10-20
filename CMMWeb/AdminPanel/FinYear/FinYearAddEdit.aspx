<%@ Page Title="" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="FinYearAddEdit.aspx.cs" Inherits="CMMWeb_AdminPanel_FinYear_FinYearAddEdit" %>

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
                                        <asp:ValidationSummary ID="vsCSiteAddEdit" runat="server" HeaderText="Please solve following error(s)." CssClass="btn btn-danger" DisplayMode="BulletList" ValidationGroup="btnSubmit" />
                                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <div class="col-xs-2 control-label"><span style="color:red;">*</span>From Date</div>
                                        <div class="col-xs-4">
                                            <div class="input-group input-append date" id="datePicker">
                                                <asp:TextBox runat="server" ID="txtFromDate" name="date" class="form-control" placeholder="Enter start date"></asp:TextBox>
                                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvFromdate" ControlToValidate="txtFromDate" ForeColor="Red" ErrorMessage="From date is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            <!-- /input-group -->
                                        </div>
                                        <div class="col-xs-2 control-label"><span style="color:red;">*</span>To Date</div>                                        
                                        <div class="col-xs-4">
                                            <div class="input-group input-append date" id="datePicker2">
                                                <asp:TextBox runat="server" ID="txtToDate" name="date" class="form-control" placeholder="Enter end date" OnTextChanged="txtToDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvToDate" ControlToValidate="txtToDate" ForeColor="Red" ErrorMessage="To date is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">Fin. year</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtFinYear" CssClass="form-control input-circle" placeholder="Enter Financial year" ></asp:TextBox>
                                        </div>
                                        <label class="col-md-2 control-label">Sequence</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtSequence" CssClass="form-control input-circle" placeholder="Enter Sequence"></asp:TextBox>
                                        </div>

                                    </div>

                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-6">
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
                                            <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-circle grey-salsa btn-outline" href="FinYearList.aspx" Text="Cancel" data-toggle="tooltip" data-placement="bottom" title="Go to Fin. Year List Page"></asp:LinkButton>
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
