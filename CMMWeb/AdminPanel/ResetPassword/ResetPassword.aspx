<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="CMMWeb_AdminPanel_Login_ResetPassword" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Metronic | User Login 4</title>
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
    <link href="../Default/assets/pages/css/login-4.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />

</head>
<!-- END HEAD -->
<body class="login">
    <form id="form1" runat="server">
        <div class="logo">
            <a href="index.html">
                <img src="../Default/assets/pages/img/logo-big.png" alt="" />
            </a>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content">
            <!-- BEGIN LOGIN FORM -->
            <div class="login-form" runat="server">
                <h3 class="form-title">Enter New Password</h3>
                <div class="alert alert-danger display-hide">
                    <button class="close" data-close="alert"></button>
                    <span>Enter any Email-ID and password. </span>
                </div>
                <div class="form-group">
                    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                    <label class="control-label visible-ie8 visible-ie9">Email</label>
                    <div class="input-icon">
                        <i class="fa fa-user"></i>
                        <asp:TextBox runat="server" ID="txtLEmail" class="form-control placeholder-no-fix" placeholder="Enter your Login Email-ID"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="rfvLEmail" ControlToValidate="txtLEmail" ErrorMessage="This field is required." ForeColor="Red" Display="Dynamic" ValidationGroup="btnLogin"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Email ID in correct format" ControlToValidate="txtLEmail" ValidationGroup="btnLogin" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Password</label>
                    <div class="input-icon">
                        <i class="fa fa-lock"></i>
                        <asp:TextBox runat="server" ID="txtPassword" class="form-control placeholder-no-fix" placeholder="Enter Password" type="password"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtPassword" ErrorMessage="This field is required." ForeColor="Red" Display="Dynamic" ValidationGroup="btnLogin"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Confirm Password</label>
                    <div class="input-icon">
                        <i class="fa fa-lock"></i>
                        <asp:TextBox runat="server" ID="txtConfirmPassword" class="form-control placeholder-no-fix" placeholder="Confirm Password" type="password"></asp:TextBox>
                    </div>
                    <div style="text-align: center; font-weight: bold">
                        <asp:RequiredFieldValidator runat="server" ID="rfvLPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="This field is required." ForeColor="Red" Display="Dynamic" ValidationGroup="btnLogin"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="Password must be same" ControlToValidate="txtPassword" ControlToCompare="txtConfirmPassword" ForeColor="Red" Display="Dynamic" ValidationGroup="btnLogin"></asp:CompareValidator>
                    </div>
                    <div style="text-align: center;">
                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                    </div>
                </div>

                <div class="form-actions">
                    <asp:Button Text="Update" runat="server" ID="btnLogin" CssClass="btn green" ValidationGroup="btnLogin" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
        <!-- END LOGIN FORM -->

        <!--divD LOGIN -->
        <!-- BEGIN COPYRIGHT -->
        <div class="copyright">2014 &copy; Metronic - Admin Dashboard Template. </div>
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
