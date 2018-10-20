<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="CMMWeb_AdminPanel_LoginPage" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- E>ND GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="../Default/assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" type="text/css" />
    <link href="../Default/assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="../Default/assets/global/css/components-md.min.css" rel="stylesheet" id="style_components" type="text/css" />
    <link href="../Default/assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <style>
        .login .content{
            background-color:#f0f0f0 !important;
        }
        .bg{
            background-color:#f0f0f0;
        }


    </style>
    <link href="../Default/assets/pages/css/login-4.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    
</head>
<!-- END HEAD -->
<body class="login" >
    
    <form id="form1" runat="server" >

        <div class="logo">
            <h1 style="color:#f0f0f0; font-family:'AR DESTINE'; ">YellowHat</h1>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content">
            <!-- BEGIN LOGIN FORM -->
            <div class="login-form" runat="server">
                <h3 class="form-title" style="color:#e84e41; font-family:'Times New Roman'; ">Login to your account</h3>
                <div class="alert alert-danger display-hide">
                    <button class="close" data-close="alert"></button>
                    <span>Enter any Email-ID and password. </span>
                </div>
                <div class="form-group">
                    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                    <label class="control-label visible-ie8 visible-ie9">Email</label>
                    <div class="input-icon">
                        <i class="fa fa-user"></i>
                        <asp:TextBox runat="server" ID="txtLEmail" class="form-control placeholder-no-fix" placeholder="Email"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="rfvLEmail" ControlToValidate="txtLEmail" ErrorMessage="This field is required." ForeColor="Red" Display="Dynamic" ValidationGroup="btnLogin"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Email ID in correct format" ControlToValidate="txtLEmail" ValidationGroup="btnLogin" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="input-icon">
                        <i class="fa fa-calendar-times-o"></i>
                        <asp:DropDownList ID="ddlFinYearID" runat="server" InitialValue="-1" CssClass="select2 form-control dropdown" OnSelectedIndexChanged="ddlFinYearID_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="ddlFinYearID" ForeColor="Red" ErrorMessage="Select State" ValidationGroup="btnLogin" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Password</label>
                    <div class="input-icon">
                        <i class="fa fa-lock"></i>
                        <asp:TextBox runat="server" ID="txtLPassword" class="form-control placeholder-no-fix" placeholder="Password" type="password"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="rfvLPassword" ControlToValidate="txtLPassword" ErrorMessage="This field is required." ForeColor="Red" Display="Dynamic" ValidationGroup="btnLogin"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-actions">                    
                    <asp:Button Text="Login" runat="server" ID="btnLogin" CssClass="btn" style="background-color:#e84e41; color:#f0f0f0;" ValidationGroup="btnLogin" OnClick="btnLogin_Click" />
                </div>
                <div style="text-align: center; font-weight:bold;">
                    <asp:Label runat="server" ID="lblMessage"></asp:Label>
                </div>
                <div class="forget-password">
                    <h4 style="color:#e84e41;">Forgot your password ?</h4>
                    <p style="color:#e84e41;">
                        no worries, click                       
                        <a href="javascript:;" id="forget-password" style="color:#e84e41; font-weight:bold;">here </a>to reset your password.
                    </p>
                </div>
                <hr style="border-color:#e84e41;"/>
                <div class="create-account">
                    <p style="color:#e84e41;">
                        Don't have an account yet ?&nbsp;                       
                        <a href="javascript:;" id="register-btn" style="color:#e84e41; font-weight:bold;">Create an account </a>
                    </p>
                </div>
            </div>
            <!-- BEGIN FORGOT PASSWORD FORM -->
            <div class="forget-form" runat="server">
                <h3 style="color:#e84e41; font-family:'Times New Roman';">Forget Password ?</h3>
                <p style="color:#e84e41;">Enter your e-mail address below to reset your password. </p>
                <div class="form-group">
                    <div class="input-icon">
                        <i class="fa fa-envelope"></i>
                        <asp:TextBox runat="server" ID="txtForgetEmailID" class="form-control placeholder-no-fix" autocomplete="off" placeholder="Email" ValidationGroup="btnSubmit"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtForgetEmailID" ErrorMessage="This field is required." ForeColor="Red" Display="Dynamic" ValidationGroup="btnSubmit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator6" runat="server" ErrorMessage="Enter Email ID in correct format" ControlToValidate="txtEmailID" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="btnSubmit" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div style="text-align: center;">
                        <asp:Label runat="server" ID="lblfmessage"></asp:Label>
                    </div>
                </div>
                <div class="form-actions">
                    <button type="button" id="back-btn" class="btn red btn-outline">Back </button>
                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn pull-right" style="background-color:#e84e41; color:#f0f0f0;" OnClick="btnSubmit_Click" ValidationGroup="btnSubmit" />
                </div>
            </div>
            <!-- END FORGOT PASSWORD Fdiv -->
            <!-- BEGIN REGISTRATION FORM -->
            <div class="register-form" runat="server">
                <h3 style="color:#e84e41; font-family:'Times New Roman';">Sign Up</h3>
                <p style="color:#e84e41;">Enter your personal details below: </p>
                <div class="form-group">
                    <div class="input-icon">
                        <i class="fa fa-font"></i>
                        <asp:TextBox runat="server" ID="txtUserName" class="form-control placeholder-no-fix" placeholder="UserName"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="This field is required." ForeColor="Red" ValidationGroup="btnSignUp"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtUserName" ForeColor="Red" ErrorMessage="User Name is too long" ValidationGroup="btnSignUp" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                    </div>
                </div>


                <div class="form-group">
                    <div class="input-icon">
                        <i class="fa fa-sitemap"></i>
                        <asp:TextBox runat="server" ID="txtOrganizationName" class="form-control placeholder-no-fix" placeholder="Orgnization Name"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="rfvOrganizationName" ControlToValidate="txtOrganizationName" Display="Dynamic" ErrorMessage="This field is required." ForeColor="Red" ValidationGroup="btnSignUp"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator4" ControlToValidate="txtOrganizationName" ForeColor="Red" ErrorMessage="Organization Name is too long" ValidationGroup="btnSignUp" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="input-icon">
                        <i class="fa fa-building-o"></i>
                        <asp:TextBox runat="server" ID="txtAddress" class="form-control placeholder-no-fix" placeholder="Enter Company Address" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="This field is required." ForeColor="Red" ValidationGroup="btnSignUp"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator7" ControlToValidate="txtAddress" ForeColor="Red" ErrorMessage="Address is too long" ValidationGroup="btnSignUp" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,500}$"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="input-icon">
                        <i class="fa fa-arrow-circle-o-right"></i>
                        <asp:DropDownList ID="ddlStateID" runat="server" InitialValue="-1" CssClass="select2 form-control dropdown" ></asp:DropDownList>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="rfvStateID" ControlToValidate="ddlStateID" ForeColor="Red" ErrorMessage="Select State" ValidationGroup="btnSignUp" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="input-icon">
                        <i class="fa fa-location-arrow"></i>
                        <asp:TextBox runat="server" ID="txtCity" class="form-control placeholder-no-fix" placeholder="City"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="rfvCity" ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="This field is required." ValidationGroup="btnSignUp" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5" ControlToValidate="txtCity" ForeColor="Red" ErrorMessage="City Name is too long" ValidationGroup="btnSignUp" Display="Dynamic" ValidationExpression="^\s*([^\s]\s*){0,50}$"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <p style="color:#e84e41;">Enter your account details below: </p>
                <div class="form-group ">
                    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                    <label class="control-label visible-ie8 visible-ie9">Email</label>
                    <div class="input-icon">
                        <i class="fa fa-envelope"></i>
                        <asp:TextBox runat="server" ID="txtEmailID" class="form-control placeholder-no-fix" placeholder="Email"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="rfvEmailID" ControlToValidate="txtEmailID" ErrorMessage="This field is required." ForeColor="Red" Display="Dynamic" CssClass="required" ValidationGroup="btnSignUp"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Email ID in correct format" ControlToValidate="txtEmailID" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="btnSignUp" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Password</label>
                    <div class="input-icon">
                        <i class="fa fa-lock"></i>
                        <asp:TextBox runat="server" ID="txtPassword" class="form-control placeholder-no-fix" placeholder="Password" type="password"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="txtrfvPassword" ControlToValidate="txtPassword" ErrorMessage="This field is required." ForeColor="Red" Display="Dynamic" ValidationGroup="btnSignUp"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Re-type Your Password</label>
                    <div class="controls">
                        <div class="input-icon">
                            <i class="fa fa-check"></i>
                            <asp:TextBox runat="server" ID="txtRetypePassword" class="form-control placeholder-no-fix" placeholder="Retype Password" type="password"></asp:TextBox>
                        </div>
                        <div style="text-align: center; font-weight: bold">
                            <asp:RequiredFieldValidator runat="server" ID="rfvRetype" ControlToValidate="txtRetypePassword" ErrorMessage="This field is required." ForeColor="Red" Display="Dynamic" ValidationGroup="btnSignUp"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password must be same as above" ControlToCompare="txtPassword" ControlToValidate="txtRetypePassword" ForeColor="Red" ValidationGroup="btnSignUp" Display="Dynamic"></asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="checkbox">
                        <label class="control-label" style="color:#e84e41;">
                            <asp:CheckBox runat="server" ID="cdIsActive" value="0"></asp:CheckBox>
                            Is Active?
                        </label>
                    </div>
                </div>
                <div class="form-actions">
                    <button id="register-back-btn" type="button" class="btn red btn-outline">Back </button>
                    <asp:Button runat="server" ID="btnRegister" class="btn pull-right"  Text="Sign Up" ValidationGroup="btnSignUp" OnClick="btnRegister_Click" style="background-color:#e84e41; color:#f0f0f0;"/>
                </div>
            </div>
            <!-- END REGISTRATION FORM -->
        </div>
        <!-- END LOGIN FORM -->

        <!--divD LOGIN -->
        <!-- BEGIN COPYRIGHT -->
        <div class="copyright">2018-19 &copy; YellowHat </div>
        <!-- END COPYRIGHT -->
        <!--[if lt IE 9]>
<script src="../Default/assets/global/plugins/respond.min.js"></script>
<script src="../Default/assets/global/plugins/excanvas.min.js"></script> 
<![endif]-->
        <!-- BEGIN CORE PLUGINS -->
        <script src="../Default/assets/global/plugins/jquery.min.js" type="text/javascript"></script>
        <script src="../Default/assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="../Default/assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
        <script src="../Default/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
        <script src="../Default/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
        <script src="../Default/assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="../Default/assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
        <script src="../Default/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="../Default/assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
        <script src="../Default/assets/global/plugins/jquery-validation/js/additional-methods.min.js" type="text/javascript"></script>
        <script src="../Default/assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
        <script src="../Default/assets/global/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <script src="../Default/assets/global/scripts/app.min.js" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="../Default/assets/pages/scripts/login-4.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL SCRIPTS -->
        <!-- BEGIN THEME LAYOUT SCRIPTS -->
        <!-- END THEME LAYOUT SCRIPTS -->
    </form>
</body>
</html>
