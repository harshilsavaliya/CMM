<%@ Page Title="Profile Settings" Language="C#" MasterPageFile="~/CMMWeb/MasterPage/CMMMasterPage.master" AutoEventWireup="true" CodeFile="profilesetting.aspx.cs" Inherits="CMMWeb_AdminPanel_Profile_profilesetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Default/assets/pages/scripts/imagePicker.js"></script>
    <link href="../../Default/assets/pages/css/imagePicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="breadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="actualContent" runat="Server">
    <div class="profile">
        <div class="tabbable-line tabbable-full-width">
            <ul class="nav nav-tabs">
                <%--<li class="active">
                    <a href="#tab_1_1" data-toggle="tab">Overview </a>
                </li>--%>
                <li>
                    <a href="#tab_1_3" data-toggle="tab">My Profile </a>
                </li>
            </ul>
            <div class="tab-content">
                <!--tab_1_2-->
                <div class="tab-pane active" id="Tabs">
                    <div class="row profile-account">
                        <div class="col-md-3">
                            <ul class="ver-inline-menu tabbable margin-bottom-10">
                                <li class="active">
                                    <a data-toggle="tab" href="#tabs-1" aria-controls="tabs-1" role="tab">
                                        <i class="fa fa-user-circle-o"></i>Personal info </a>
                                    <span class="after"></span>
                                </li>
                                <li>
                                    <a data-toggle="tab" href="#tabs-2" aria-controls="tabs-2" role="tab">
                                        <i class="fa fa-pencil-square-o"></i>Edit Profile</a>
                                </li>
                                <li>
                                    <a data-toggle="tab" href="#tabs-4" aria-controls="tabs-4" role="tab">
                                        <i class="fa-file-picture-o"></i>Add Logo</a>
                                </li>
                                <li>
                                    <a data-toggle="tab" href="#tabs-3" aria-controls="tabs-3" role="tab">
                                        <i class="fa fa-lock"></i>Change Password </a>
                                </li>
                            </ul>
                        </div>
                        <div class="col-md-9">
                            <div class="tab-content">
                                <div id="tabs-1" class="tab-pane active" role="tabpanel">
                                    <div role="form">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Name</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtDisplayName" runat="server" CssClass="form-control input-circle" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Email</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-circle" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Organization</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtOrganization" runat="server" CssClass="form-control input-circle" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Company Address</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-circle" Enabled="false" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">State</label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-control select-me input-circle" AutoPostBack="True" InitialValue="-1" Enabled="false"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">City</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control input-circle" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="tabs-2" class="tab-pane" role="tabpanel">
                                    <div style="font-size: medium; text-align: center; color: red;">
                                        <asp:ValidationSummary ID="vsMaterialAddEdit" runat="server" HeaderText="Please solve following error(s)." CssClass="btn btn-danger" DisplayMode="List" ValidationGroup="btnSubmit" />
                                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                    </div>
                                    <br />
                                    <div role="form">
                                        <div class="form-horizontal">                                            
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Organization</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtOrganization1" runat="server" CssClass="form-control input-circle"></asp:TextBox>
                                                </div>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtOrganization1" Display="None" ErrorMessage="Organization Name is required." ForeColor="Red" ValidationGroup="btnSubmit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ControlToValidate="txtOrganization1" ForeColor="Red" ErrorMessage="Organization Name is too long" ValidationGroup="btnSubmit" Display="None" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Name</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtName1" runat="server" CssClass="form-control input-circle"></asp:TextBox>
                                                </div>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtName1" Display="None" ErrorMessage="User Name is required." ForeColor="Red" ValidationGroup="btnSubmit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtName1" ForeColor="Red" ErrorMessage="User Name is too long" ValidationGroup="btnSubmit" Display="None" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Email</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEmail1" runat="server" CssClass="form-control input-circle"></asp:TextBox>
                                                </div>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvEmailID" ControlToValidate="txtEmail1" ErrorMessage="Email is required." ForeColor="Red" Display="None" ValidationGroup="btnSubmit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Email ID in correct format" ControlToValidate="txtEmail1" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="btnSubmit" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Company Address</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control input-circle" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtAddress1" Display="None" ErrorMessage="Address is required." ForeColor="Red" ValidationGroup="btnSubmit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5" ControlToValidate="txtAddress1" ForeColor="Red" ErrorMessage="Address is too long" ValidationGroup="btnSubmit" Display="None" ValidationExpression="^\s*([^\s]\s*){0,500}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>  
                                            <div class="form-group">
                                                <label class="control-label col-md-3">State</label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList runat="server" ID="ddlStateID1" CssClass="form-control select-me input-circle" AutoPostBack="True" InitialValue="-1"></asp:DropDownList>
                                                </div>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvStateID" ControlToValidate="ddlStateID1" ForeColor="Red" ErrorMessage="Select State" ValidationGroup="btnSubmit" Display="None" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">City</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtCity1" runat="server" CssClass="form-control input-circle"></asp:TextBox>
                                                </div>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtCity1" Display="None" ErrorMessage="City is required." ForeColor="Red" ValidationGroup="btnSubmit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator4" ControlToValidate="txtCity1" ForeColor="Red" ErrorMessage="Name of the city is too long" ValidationGroup="btnSubmit" Display="None" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-actions">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-8">
                                                        <asp:Button runat="server" ID="btnSubmit" class="btn btn-circle green" ValidationGroup="btnSubmit" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                                                        <%--<asp:HyperLink ID="hyperlink" runat="server">ADD</asp:HyperLink>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div id="tabs-4" class="tab-pane" role="tabpanel">
                                    <div style="font-size: medium; text-align: center;">                                        
                                        <asp:Label runat="server" ID="lblMessage2"></asp:Label>
                                    </div>
                                    <br />
                                    <div role="form">
                                        <div class="form-horizontal">
                                            <img id='img1' align="middle"/>
                                            <br />
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Organization Logo</label>
                                                <div class="col-md-8">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control input-circle"></asp:FileUpload>
                                                </div>
                                            </div>
                                            <div class="form-actions">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-8">
                                                        <asp:Button runat="server" ID="btnLogo" class="btn btn-circle green" ValidationGroup="btnSubmit" Text="Submit" OnClick="btnLogo_Click"></asp:Button>
                                                    </div>
                                                </div>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>
                                <div id="tabs-3" class="tab-pane" role="tabpanel">
                                    <div style="font-size: medium; text-align: center; color: red;">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please solve following error(s)." CssClass="btn btn-danger" DisplayMode="List" ValidationGroup="password" />
                                        <asp:Label runat="server" ID="lblMessage1"></asp:Label>
                                    </div>
                                    <br />
                                    <div role="form">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Current Password</label>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control input-circle" TextMode="Password" placeholder="Current Password"></asp:TextBox>
                                                </div>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtCurrentPassword" Display="None" ErrorMessage="Current Password is required." ForeColor="Red" ValidationGroup="password"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">New Password</label>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtNewPassword" runat="server" placeholder="New Password" CssClass="form-control input-circle" TextMode="Password"></asp:TextBox>
                                                </div>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtCurrentPassword" Display="None" ErrorMessage="New Password is required." ForeColor="Red" ValidationGroup="password"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label col-md-3">Re-type New Password</label>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" CssClass="form-control input-circle" TextMode="Password" placeholder="Re-type New Password"></asp:TextBox>
                                                </div>
                                                <div style="text-align: center; font-weight: bold">
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtConfirmNewPassword" Display="None" ErrorMessage="Confirm new password is required." ForeColor="Red" ValidationGroup="password"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator runat="server" ID="cvpassword" ControlToValidate="txtConfirmNewPassword" ControlToCompare="txtNewPassword" Display="None" ErrorMessage="Password must be same as new password." ForeColor="Red" ValidationGroup="password"></asp:CompareValidator>
                                                </div>
                                            </div>
                                            <div class="form-actions">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-7">
                                                        <asp:Button runat="server" ID="btnChangePassword" class="btn btn-circle green" ValidationGroup="password" Text="change password" OnClick="btnChangePassword_Click"></asp:Button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>
                        <!--end col-md-9-->
                    </div>
                </div>
                <!--end tab-pane-->
                <!--end tab-pane-->
                <asp:HiddenField ID="TabName" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

