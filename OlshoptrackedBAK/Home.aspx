<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OlshoptrackedBAK.Home" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
</head>
<body>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />
    <link href='http://fonts.googleapis.com/css?family=Varela+Round' rel='stylesheet' type='text/css' />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.13.1/jquery.validate.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:400,100);

        body {
            background: url(https://dl.dropboxusercontent.com/u/23299152/Wallpapers/wallpaper-22705.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
            font-family: 'Roboto', sans-serif;
        }

        .login-card {
            padding: 40px;
            width: 274px;
            background-color: #F7F7F7;
            margin: 0 auto 10px;
            border-radius: 2px;
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            overflow: hidden;
        }

            .login-card h1 {
                font-weight: 100;
                text-align: center;
                font-size: 2.3em;
            }

            .login-card input[type=submit] {
                width: 100%;
                display: block;
                margin-bottom: 10px;
                position: relative;
            }

        .RadButton {
            width: 100%;
            display: block;
            margin-bottom: 10px;
            position: relative;
        }

        .login-card input[type=text], input[type=password] {
            height: 44px;
            font-size: 16px;
            width: 100%;
            margin-bottom: 10px;
            -webkit-appearance: none;
            background: #fff;
            border: 1px solid #d9d9d9;
            border-top: 1px solid #c0c0c0;
            /* border-radius: 2px; */
            padding: 0 8px;
            box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .RadTextbox {
            height: 44px;
            font-size: 16px;
            width: 100%;
            margin-bottom: 10px;
            -webkit-appearance: none;
            background: #fff;
            border: 1px solid #d9d9d9;
            border-top: 1px solid #c0c0c0;
            /* border-radius: 2px; */
            padding: 0 8px;
            box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        .login-card input[type=text]:hover, input[type=password]:hover {
            border: 1px solid #b9b9b9;
            border-top: 1px solid #a0a0a0;
            -moz-box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
            -webkit-box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
            box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
        }

        .RadTextbox:hover {
            border: 1px solid #b9b9b9;
            border-top: 1px solid #a0a0a0;
            -moz-box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
            -webkit-box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
            box-shadow: inset 0 1px 2px rgba(0,0,0,0.1);
        }

        .login {
            text-align: center;
            font-size: 14px;
            font-family: 'Arial', sans-serif;
            font-weight: 700;
            height: 36px;
            padding: 0 8px;
            /* border-radius: 3px; */
            /* -webkit-user-select: none;
  user-select: none; */
        }

        .login-submit {
            /* border: 1px solid #3079ed; */
            border: 0px;
            color: #fff;
            text-shadow: 0 1px rgba(0,0,0,0.1);
            background-color: #4d90fe;
            /* background-image: -webkit-gradient(linear, 0 0, 0 100%,   from(#4d90fe), to(#4787ed)); */
        }

            .login-submit:hover {
                /* border: 1px solid #2f5bb7; */
                border: 0px;
                text-shadow: 0 1px rgba(0,0,0,0.3);
                background-color: #357ae8;
                /* background-image: -webkit-gradient(linear, 0 0, 0 100%,   from(#4d90fe), to(#357ae8)); */
            }

        .login-card a {
            text-decoration: none;
            color: #666;
            font-weight: 400;
            text-align: center;
            display: inline-block;
            opacity: 0.6;
            transition: opacity ease 0.5s;
        }

            .login-card a:hover {
                opacity: 1;
            }

        .login-help {
            width: 100%;
            text-align: center;
            font-size: 12px;
        }
    </style>
    <div class="login-card">
        <h1>Log-in</h1>
        <br />


        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div>
                <!--<input type="text" name="user" placeholder="Username"/>
     <input type="password" name="pass" placeholder="Password"/>
    <!-- <input type="submit" name="login" class="login login-submit" value="login"/>-->
                <telerik:RadTextBox runat="server" ID="username" DisplayText="Username" Width="100%"></telerik:RadTextBox>
                <br />
                <br />
                <telerik:RadTextBox runat="server" ID="password" DisplayText="Password" TextMode="Password" Width="100%"></telerik:RadTextBox>

                <br />
                <br />


                <telerik:RadButton ID="submit" BackColor="SlateBlue" runat="server" CssClass="classBtn" Text="Submit" OnClick="submit_Click" Font-Bold="true"></telerik:RadButton>
                <asp:Label runat="server" ID="Errorlog"></asp:Label>
            </div>

        </form>
    </div>

    <div class="login-help">
        <!--<a href="#">Register</a> • <a href="#">Forgot Password</a>-->
    </div>
</body>
</html>
