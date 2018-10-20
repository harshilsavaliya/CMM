<%@ Page Title="" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="SalaryAddEdit.aspx.cs" Inherits="CMMWeb_AdminPanel_Salary_SalaryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
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
                                        <asp:ValidationSummary ID="vsSalaryAddEdit" runat="server" HeaderText="Please solve following error(s)." CssClass="btn btn-danger" DisplayMode="BulletList" ValidationGroup="btnSubmit" />
                                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                    </div>
                                    <br />

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Month</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlMonthID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1" AutoPostBack="true" OnSelectedIndexChanged="ddlMonthID_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvSupplierID" ControlToValidate="ddlMonthID" ForeColor="Red" ErrorMessage="Select Month" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                                                              
                                        <label class="control-label col-md-2">Financial year</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtFinYear" runat="server" CssClass="form-control input-circle" MaxLength="50" ReadOnly="true">
                                            </asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtCity" ForeColor="Red" ErrorMessage="City is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Worker</label>
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="ddlWorkerID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1" AutoPostBack="true" OnSelectedIndexChanged="ddlWorkerID_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="ddlWorkerID" ForeColor="Red" ErrorMessage="Select Worker" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">            
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Working days</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtWorkingDays" runat="server" CssClass="form-control input-circle" placeholder="Enter Working days" TextMode="Number" AutoPostBack="true" ReadOnly="true">
                                            </asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvWorkingDays" ControlToValidate="txtWorkingDays" ForeColor="Red" ErrorMessage="Working days field is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                    ControlToValidate="txtWorkingDays" ErrorMessage="Working days field is two large" ForeColor="Red"
                                                    ValidationExpression="^[0-9]{0,10}$" Display="Dynamic" ValidationGroup="btnSubmit"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtWorkingDays" ForeColor="Red" ErrorMessage="Working days field is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2"><span style="color: red;">*</span>Per day salary</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtPerDaySalary" CssClass="form-control input-circle" placeholder="Enter per day salary" TextMode="Number" MaxLength="10" ReadOnly="true"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtPerDaySalary" ForeColor="Red" ErrorMessage="Per day salry is compulsary"  ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                    ControlToValidate="txtPerDaySalary" ErrorMessage="Per day salary is two large" ForeColor="Red"
                                                    ValidationExpression="^[0-9]{0,10}$" Display="Dynamic" ValidationGroup="btnSubmit"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2">Absent Days</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtAbsentDays" CssClass="form-control input-circle" placeholder="Enter Absent days" TextMode="Number" OnTextChanged="txtAbsentDays_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                    ControlToValidate="txtAbsentDays" ErrorMessage="Absent days field is two large" ForeColor="Red"
                                                    ValidationExpression="^[0-9]{0,10}$" Display="Dynamic" ValidationGroup="btnSubmit"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <label class="control-label col-md-2">Deduction</label>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtDeduction" CssClass="form-control input-circle" placeholder="Enter Deduction" TextMode="Number" ForeColor="Red" ReadOnly="true"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                                    ControlToValidate="txtDeduction" ErrorMessage="Deduction is two large" ForeColor="Red"
                                                    ValidationExpression="^[0-9]{0,10}$" Display="Dynamic" ValidationGroup="btnSubmit"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span>Total salary</label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="txtTotalSalary" ReadOnly="true" CssClass="form-control input-circle" placeholder="Enter total salary" TextMode="Number" MaxLength="10"></asp:TextBox>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtTotalSalary" ForeColor="Red" ErrorMessage="total salry is compulsary" ValidationGroup="btnSubmit" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                    ControlToValidate="txtTotalSalary" ErrorMessage="Total salary is two large" ForeColor="Red"
                                                    ValidationExpression="^[0-9]{0,10}$" Display="Dynamic" ValidationGroup="btnSubmit"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2"><span style="color: red;">*</span>Total salary in words</label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ReadOnly="true" ID="txtTotalSalaryInWords" CssClass="form-control input-circle" placeholder="Total salary in words" ForeColor="Green"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-4">
                                            <div class="checkbox">
                                                <label class="control-label">
                                                    <asp:CheckBox runat="server" ID="cdIsPaid" value="0"></asp:CheckBox>
                                                    Is Paid?
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-offset-5 col-md-6">
                                            <asp:Button runat="server" ID="btnSubmit" class="btn btn-circle green" ValidationGroup="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                                            <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-circle grey-salsa btn-outline" href="SalaryList.aspx" Text="Cancel"></asp:LinkButton>
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

