<%@ Page Title="" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="SalaryAddEdit.aspx.cs" Inherits="CMMWeb_AdminPanel_SalaryOfAll_SalaryAddEdit" %>

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
                                        <label class="control-label col-md-2"><span style="color: red;">*</span> Construction site</label>
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="ddlConstructionSiteID" runat="server" CssClass="form-control select-me input-circle" InitialValue="-1">
                                            </asp:DropDownList>
                                            <div style="text-align: center; font-weight: bold">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="ddlConstructionSiteID" ForeColor="Red" ErrorMessage="Select Construction site" ValidationGroup="btnSubmit" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
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
                            </div>
                            <!-- END FORM-->
                        </div>
                    </div>
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
                        <span class="caption-subject font-green sbold uppercase">Salary List</span>
                    </div>
                    <div class="actions">
                        <asp:Button runat="server" ID="btnAdd" Text="ADD" class="btn btn-lg btn-transparent grey-salsa btn-outline btn-circle active" OnClick="btnAdd_Click"/>                       
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-container table-responsive">
                        <asp:GridView ID="gvWorkerList" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered table-hover table-responsive">
                            <Columns>
                                <asp:BoundField DataField="WorkerID" />
                                <asp:BoundField DataField="WorkerName" HeaderText="Worker" />                                
                                <asp:TemplateField HeaderText="Working Days">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtWorkingDays" CssClass="form-control input-circle" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Per day salary">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPerDaySalary" runat="server" CssClass="form-control input-circle" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Absent days">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtAbsentDays" CssClass="form-control input-circle" AutoPostBack="true" OnTextChanged="txtAbsentDays_TextChanged"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Deduction">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDeduction" runat="server" CssClass="form-control input-circle" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Totalsalary">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtTotalSalary" CssClass="form-control input-circle" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Salary in words">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTotalSalaryInWords" runat="server" CssClass="form-control input-circle" ReadOnly="true" ForeColor="Green"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Is paid">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkIsPaid" CssClass="form-control input-circle"></asp:CheckBox>
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

