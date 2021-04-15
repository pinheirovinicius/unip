<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BitchainWeb.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="rsmLogin" runat="server"></telerik:RadScriptManager>

        <telerik:RadWindowManager ID="rwmLogin" runat="server" />

        <div style="text-align: center; margin-top: 120px;">
            <asp:Image ID="iLogo" runat="server" ImageUrl="~/img/Logo.png" />
        </div>
        <div style="text-align: center; margin-top: 15px;">
            <telerik:RadLabel ID="rlLogIn" runat="server" Text="Usuário:" Width="60"></telerik:RadLabel>
            <telerik:RadTextBox ID="rtbLogIn" runat="server" EmptyMessage="informe seu login"></telerik:RadTextBox>
        </div>
        <div style="text-align: center; margin-top: 5px;">
            <telerik:RadLabel ID="rlSenha" runat="server" Text="Senha:" Width="60"></telerik:RadLabel>
            <telerik:RadTextBox ID="rtbSenha" runat="server" EmptyMessage="informe sua senha" TextMode="Password"></telerik:RadTextBox>
        </div>
        <div style="text-align: center;">
            <telerik:RadLabel ID="rlCriaConta" runat="server" ></telerik:RadLabel>
        </div>

        <div style="text-align: center; margin-top: 10px;">
            <telerik:RadButton ID="rbLogIn" runat="server" Text="Log In" OnClick="rbLogIn_Click1"></telerik:RadButton>
        </div>
    </form>
</body>
</html>
