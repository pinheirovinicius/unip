<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="BitchainWeb.Pages.PaginaInicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="smPaginaInicial" runat="server" ></asp:ScriptManager>

        <div class="RadMenu_Default">
            <telerik:RadMenu ID="rmSVG" runat="server"
                             DataFieldID="ID_Menu_Web" 
                             RenderMode="Classic"
                             EnableEmbeddedSkins="true"
                             DataFieldParentID="ID_Menu_Pai" 
                             DataNavigateUrlField="NM_URL" 
                             DataSourceID="MenuLinqDataSource" 
                             DataTextField="NM_Descricao" 
                             DataValueField="ID_Menu_Web"
                             Font-Names="Calibri"
                             style="z-index: 2301;"
                             Width="100%"/>

            <asp:LinqDataSource ID="MenuLinqDataSource" runat="server" 
                                ContextTypeName="BitchainWeb.BaseDataContext" 
                                EntityTypeName="" 
                                Where="Menu_Web.ID_Sistema = 1"
                                Select="new (ID_Menu_Web, Menu_Web.ID_Menu_Pai, Menu_Web.NM_URL, Menu_Web.NM_Descricao)"
                                TableName="Menu_Web_Permissaos">
            </asp:LinqDataSource>
        </div>

        <img src="../img/Logo.png" style="text-align: center; width: 800px; margin-top: 60px; margin-left: 60px;" />

    </form>
</body>
</html>
