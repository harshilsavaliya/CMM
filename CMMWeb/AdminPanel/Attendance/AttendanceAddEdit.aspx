<%@ Page Title="" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="AttendanceAddEdit.aspx.cs" Inherits="CMMWeb_AdminPanel_Attendance_AttendanceAddEdit" %>

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
                                        <asp:ValidationSummary ID="vsAttendanceAddEdit" runat="server" HeaderText="Please solve following error(s)." CssClass="btn btn-danger" DisplayMode="List" ValidationGroup="btnSubmit" />
                                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                    </div>
                                    <br />

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Date</label>
                                        <div class="col-md-4">
                                            <div class="input-group input-append date" id="datePicker">
                                                <asp:TextBox runat="server" ID="txtDate" name="date" class="form-control" placeholder="Date"></asp:TextBox>
                                                <span class="input-group-addon add-on"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvDate" ControlToValidate="txtDate" ForeColor="Red" ErrorMessage="Select date" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2">Hour</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtHour" CssClass="form-control input-circle" placeholder="Enter Hour"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RegularExpressionValidator runat="server" ID="rev" ControlToValidate="txtHour" ForeColor="Red" ErrorMessage="Hour is too long" ValidationGroup="btnSubmit" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{0,10}$"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Construction site</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlConstructionSiteID" runat="server" CssClass="form-control select-me input-circle"  InitialValue="-1" OnSelectedIndexChanged="ddlConstructionSiteID_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvddlCSID" ControlToValidate="ddlConstructionSiteID" ForeColor="Red" ErrorMessage="Select Construction site" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Worker</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlWorkerID" runat="server" CssClass="form-control select-me input-circle"  InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddlWorkerID" ForeColor="Red" ErrorMessage="Select Worker" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Shift</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlShiftID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="ddlShiftID" ForeColor="Red" ErrorMessage="Select shift" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-offset-2 col-md-4">
                                            <div class="checkbox">
                                                <label class="control-label">
                                                    <asp:CheckBox runat="server" ID="cdAttendance" value="0"></asp:CheckBox>
                                                    Attendance
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-offset-5 col-md-6">
                                            <asp:Button runat="server" ID="btnSubmit" class="btn btn-circle green" ValidationGroup="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                                            <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-circle grey-salsa btn-outline" href="AttendanceList.aspx" Text="Cancel"></asp:LinkButton>
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

