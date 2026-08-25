<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="singup.aspx.cs" Inherits="onlineinventory.singup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

            <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0"/>
        <meta name="description" content="POS - Bootstrap Admin Template"/>
		<meta name="keywords" content="admin, estimates, bootstrap, business, corporate, creative, invoice, html5, responsive, Projects"/>
        <meta name="author" content="Dreamguys - Bootstrap Admin Template"/>
        <meta name="robots" content="noindex, nofollow"/>
        <title>Login - Pos </title>
		
		<!-- Favicon -->
        <link rel="shortcut icon" type="image/x-icon" href="assets/img/favicon.png"/>
		
		<!-- Bootstrap CSS -->
        <link rel="stylesheet" href="assets/css/bootstrap.min.css"/>
		
        <!-- Fontawesome CSS -->
		<link rel="stylesheet" href="assets/plugins/fontawesome/css/fontawesome.min.css"/>
		<link rel="stylesheet" href="assets/plugins/fontawesome/css/all.min.css"/>
		
		<!-- Main CSS -->
        <link rel="stylesheet" href="assets/css/style.css"/>
</head>
<body class="account-page">
    <form id="form1" runat="server">

         
		<!-- Main Wrapper -->
        <div class="main-wrapper">
			<div class="account-content">
				<div class="login-wrapper">
                    <div class="login-content">
                        <div class="login-userset">
                            <div class="login-logo logo-normal">
                                <img src="assets/img/logo.png" alt="img"/>
                            </div>
							<a href="index.html" class="login-logo logo-white">
								<img src="assets/img/logo-white.png"  alt=""/>
							</a>
                            <div class="login-userheading">
                                <h3>Create an Account</h3>
                                <h4>Continue where you left off</h4>
                            </div>
                            <div class="form-login">
                                <label>Full Name</label>
                                <div class="form-addons">
                                    <asp:TextBox ID="txtfullname" runat="server"  placeholder="Enter your full name"></asp:TextBox>
                                    <img src="assets/img/icons/users1.svg" alt="img"/>
                                </div>
                            </div>
                            <div class="form-login">
                                <label>Email</label>
                                <div class="form-addons">
                                    <asp:TextBox ID="txtemail" runat="server" TextMode="Email" placeholder="Enter your email address"></asp:TextBox>
                                    <img src="assets/img/icons/mail.svg" alt="img"/>
                                </div>
                            </div>
                            <div class="form-login">
                                <label>Password</label>
                                <div class="pass-group">
                                    <asp:TextBox ID="txtpassword" class="pass-input" placeholder="Enter your password" TextMode="Password" runat="server"></asp:TextBox>
                                    <span class="fas toggle-password fa-eye-slash"></span>
                                </div>
                            </div>
                            <div class="form-login">
                                <asp:Label ID="lblinfo" runat="server" Text="" ForeColor="Red"></asp:Label>

                                <asp:Button ID="btnlogin"  class="btn btn-login" runat="server" Text="Sing Up" OnClick="btnlogin_Click" />
                            </div>
                            <div class="signinform text-center">
                                <h4>Already a user? <a href="signin.aspx" class="hover-a">Sign In</a></h4>
                            </div>
                            <div class="form-setlogin">
                                <h4>Or sign up with</h4>
                            </div>
                            
                        </div>
                    </div>
                    <div class="login-img">
                        <img src="assets/img/login.jpg" alt="img"/>
                    </div>
                </div>
			</div>
        </div>
		<!-- /Main Wrapper -->
		
       
    </form>

    <!-- jQuery -->
<script src="assets/js/jquery-3.6.0.min.js"></script>

<!-- Feather Icon JS -->
<script src="assets/js/feather.min.js"></script>

<!-- Bootstrap Core JS -->
<script src="assets/js/bootstrap.bundle.min.js"></script>

<!-- Custom JS -->
<script src="assets/js/script.js"></script>
</body>
</html>
