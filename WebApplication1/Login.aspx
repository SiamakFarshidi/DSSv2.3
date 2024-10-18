<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>



<asp:Content ID="Content3" ContentPlaceHolderID="NavBar" runat="server">

    <nav class="navbar navbar-expand-xl">
        <div class="container h-100">
            <a onclick="$('#cover').show();" class="navbar-brand" href="index.html">
                <h1 class="tm-site-title mb-0">Decision Studio</h1>
            </a>
            <button class="navbar-toggler ml-auto mr-0" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <i class="fas fa-bars tm-nav-icon"></i>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mx-auto h-100">

                    <li class="nav-item">
                        <a onclick="$('#cover').show();" class="nav-link" href="index.html">
                            <i class="fas fa-home"></i>
                            Home
                                <span class="sr-only">(current)</span>
                        </a>
                    </li>

                    <li class="nav-item">
                        <a onclick="$('#cover').show();" class="nav-link " href="Publications.html">
                            <i class="fas fa-book-open"></i>
                            Publications
                                <span class="sr-only">(current)</span>
                        </a>
                    </li>

                    <li class="nav-item">
                        <a onclick="$('#cover').show();" class="nav-link" href="DSSTeam.html">
                            <i class="fas fa-users"></i>
                            Our Team
                                <span class="sr-only">(current)</span>
                        </a>
                    </li>

                    <li class="nav-item active">
                        <a onclick="$('#cover').show();" class="nav-link" href="Login.aspx">
                            <i class="fas fa-power-off"></i>
                            Login
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="fb-root"></div>
    <script async defer crossorigin="anonymous" src="https://connect.facebook.net/nl_NL/sdk.js#xfbml=1&version=v4.0&appId=155359921665900&autoLogAppEvents=1"></script>

    <script>
        //------------------------------------------------Facebook

        function statusChangeCallback(response) {
            console.log('statusChangeCallback');
            console.log(response);
            if (response.status === 'connected') {

                FB.api('/me?fields=id,name,email', function (response) {
                    login_social_network(response.name, response.email, response.id);
                });

            }
        }
        function checkLoginState() {
            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });
        }

        function loginFacebook() {
            window.fbAsyncInit = function () {
                FB.init({
                    appId: '155359921665900',
                    xfbml: true,
                    version: 'v4.0'
                });

                FB.getLoginStatus(function (response) {
                    statusChangeCallback(response);
                });

            };

            (function (d, s, id) {
                var js, fjs = d.getElementsByTagName(s)[0];
                if (d.getElementById(id)) return;
                js = d.createElement(s); js.id = id;
                js.src = "//connect.facebook.net/en_US/sdk.js";
                fjs.parentNode.insertBefore(js, fjs);
            }(document, 'script', 'facebook-jssdk'));
        }
    </script>


    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet" type="text/css">
    <script src="https://apis.google.com/js/api:client.js"></script>
    <script>
        //------------------------------------------------Google 
        var googleUser = {};
        var startApp = function () {
            gapi.load('auth2', function () {
                // Retrieve the singleton for the GoogleAuth library and set up the client.
                auth2 = gapi.auth2.init({
                    client_id: '937120975018-piaukekec17jteogi1qijjr53o1domd0.apps.googleusercontent.com',
                    cookiepolicy: 'single_host_origin',
                    // Request scopes in addition to 'profile' and 'email'
                    //scope: 'additional_scope'
                });
                attachSignin(document.getElementById('customBtn'));
            });
        };

        function attachSignin(element) {
            console.log(element.id);
            auth2.attachClickHandler(element, {},
                function (googleUser) {
                    login_social_network(googleUser.getBasicProfile().getName(), googleUser.getBasicProfile().getEmail(), googleUser.getBasicProfile().getId());
                }, function (error) {
                    alert(JSON.stringify(error, undefined, 2));
                });
        }
    </script>

    <script>
        function login_social_network(Name, Email, ID) {

            window.location = "Login.aspx?login_social_network=1" +
                "&Name=" + Name +
                "&Email=" + Email +
                "&ID=" + ID;
        }

        function user_login() {
            Login();
        }

        function user_registration() {
            Registration();
        }

    </script>

    <div class="container tm-mt-big tm-mb-big">
        <div class="row">
            <div class="col-12 mx-auto tm-login-col">
                <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
                    <div class="row">
                        <div class="col-12 text-center">
                            <h4 class="tm-block-title mb-4" style="color: orange;">Welcome to Decision Studio</h4>
                            <h2 class="tm-block-title mb-4" id="txtCaption">Login</h2>
                        </div>
                    </div>
                    <div class="row mt-2" id="PlnLogin" style="height: 480px;">
                        <div class="col-12">
                            <div class="form-group mt-2">
                                <label for="LoginEmail">Email</label>
                                <input
                                    name="LoginEmail"
                                    type="text"
                                    class="form-control validate"
                                    id="LoginEmail"
                                    value=""
                                    required />
                            </div>
                            <div class="form-group mt-2">
                                <label for="Loginpassword">Password</label>
                                <input
                                    name="Loginpassword"
                                    type="password"
                                    class="form-control validate"
                                    id="Loginpassword"
                                    value=""
                                    required />
                            </div>
                            <div class="form-group mt-2">

                                <button class="mt-2 btn btn-primary btn-block text-uppercase" onclick="user_login();"
                                    style="padding: 0px; width: 47%; height: 60px; float: left; margin-right: 6%;">
                                    Login
                                </button>

                                <button class="mt-2 btn btn-primary btn-block text-uppercase" id="btnRegistration"
                                    style="padding: -0px; width: 47%; height: 60px; float: right;">
                                    Register
                                </button>
                                <div style="clear: both;"></div>
                                <br />
                                <a href="login.aspx" style="color: white;" class="lnkForgetPassword">Forgot your password?</a>
                            </div>
                            <br />

                            <div id="gSignInWrapper">
                                <div id="customBtn" class="customGPlusSignIn mt-2 btn btn-primary btn-block"
                                    style="padding: -0px; padding-top: 8px; width: 47%; height: 40px; margin-right: 6%; float: left;">
                                    <span class="buttonText">
                                        <span style="background-color: #4966b6; padding: 3px; border-radius: 3px;">
                                            <span style="background-color: white; color: #4966b6; padding: 1px; padding-left: 4px; padding-right: 1px; border-radius: 2px;">
                                                <i class="fab fa-google"></i>
                                            </span>&nbsp; Login with Google&nbsp;</span> </span>
                                </div>
                            </div>
                            <a class="fb-login-button mt-2 btn btn-primary btn-block text-uppercase" size="large" scope="public_profile,email" onlogin="checkLoginState();" href='#1' id='facebookLogin'
                                style="padding: -0px; padding-top: 5px; width: 47%; height: 40px; float: right;">Login with Facebook</a>

                            <div id="name"></div>
                            <script>startApp();</script>
                        </div>
                    </div>

                    <div class="row mt-2" id="PlnRegistration" style="display: none; height: 480px;">
                        <div class="col-12">
                            <div class="form-group mt-2">
                                <label for="username">Name</label>
                                <input
                                    name="Reg_username"
                                    type="text"
                                    class="form-control validate"
                                    id="Reg_username"
                                    value=""
                                    required />
                            </div>
                            <div class="form-group mt-2">
                                <label for="password">Email</label>
                                <input
                                    name="Reg_email"
                                    type="email"
                                    class="form-control validate"
                                    id="Reg_email"
                                    value=""
                                    required />
                            </div>
                            <div class="form-group mt-2">
                                <label for="password">Password</label>
                                <input
                                    name="Reg_password1"
                                    type="password"
                                    class="form-control validate"
                                    id="Reg_password1"
                                    value=""
                                    required />
                            </div>
                            <div class="form-group mt-2">
                                <label for="password">Retype Password</label>
                                <input
                                    name="Reg_password2"
                                    type="password"
                                    class="form-control validate"
                                    id="Reg_password2"
                                    value=""
                                    required />
                            </div>
                            <button class="mt-2 btn btn-primary btn-block text-uppercase" onclick="user_registration();"
                                style="padding: -0px; width: 47%; height: 60px; margin-right: 6%; float: left;">
                                Register
                            </button>

                            <button class="mt-2 btn btn-primary btn-block text-uppercase" id="btnLogin"
                                style="padding: 0px; width: 47%; height: 60px; float: right;">
                                Login
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script>

        $("#btnRegistration").click(function () {
            $("#PlnLogin").hide(500);
            $("#PlnRegistration").show(500);

            document.getElementById("txtCaption").innerText = "Registation";
        });

        $("#btnLogin").click(function () {
            $("#PlnLogin").show(500);
            $("#PlnRegistration").hide(500);
            document.getElementById("txtCaption").innerText = "Login";

        });

        //---------------------------------------------------- Ajax

        function Login() {
            JsonCase = { "Email": document.getElementById("LoginEmail").value, "Password": document.getElementById("Loginpassword").value };
            var postdata = JSON.stringify(JsonCase);

            try {
                $.ajax({
                    type: "POST",
                    url: "GenericHandlers/Login.ashx",
                    cache: false,
                    data: postdata,
                    success: getSuccess,
                    error: getFail
                });
            } catch (e) {
                alert(e);
            }
            function getSuccess(data, textStatus, jqXHR) {

                if (data === "succeed") {
                    $('#cover').show();
                    window.location = "Default.aspx";
                }
                else
                    showMessageBox("Login", data);
            }

            function getFail(jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        }

        function Registration() {
            JsonCase = { "Name": document.getElementById("Reg_username").value, "Email": document.getElementById("Reg_email").value, "Password": document.getElementById("Reg_password1").value };
            var postdata = JSON.stringify(JsonCase);

            try {
                $.ajax({
                    type: "POST",
                    url: "GenericHandlers/Registration.ashx",
                    cache: false,
                    data: postdata,
                    success: getSuccess,
                    error: getFail
                });
            } catch (e) {
                alert(e);
            }
            function getSuccess(data, textStatus, jqXHR) {

                if (data === "succeed")
                    showMessageBox("Registration", "Registration has been succeed!");
                else
                    showMessageBox("Registration", "Registration has been failed!");
            }

            function getFail(jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        }


    </script>

</asp:Content>
