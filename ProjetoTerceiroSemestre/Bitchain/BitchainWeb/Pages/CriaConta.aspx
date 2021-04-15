<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriaConta.aspx.cs" Inherits="BitchainWeb.Pages.CriaConta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="rsmUsuario" runat="server"></telerik:RadScriptManager>

        <telerik:RadWindowManager ID="rwmUsuario" runat="server" Style="z-index: 9001">
            <Windows>
                <telerik:RadWindow ID="rwUsuarios" runat="server"
                    Width="600"
                    Height="400"
                    Modal="true"
                    VisibleStatusbar="false"
                    Style="background-color: silver; z-index: 7001;"
                    Behaviors="None"
                    Title="Usuários">
                    <ContentTemplate>
                        <div style="margin-top: 10px;">
                            <telerik:RadLabel ID="rlNM_Nome" runat="server"
                                Width="75"
                                Text="Nome">
                            </telerik:RadLabel>

                            <telerik:RadTextBox ID="rtbNome" runat="server"
                                Width="300">
                            </telerik:RadTextBox>
                        </div>

                        <div style="margin-top: 5px;">
                            <telerik:RadLabel ID="rlNM_Email" runat="server"
                                Width="75"
                                Text="E-mail">
                            </telerik:RadLabel>

                            <telerik:RadTextBox ID="rtbEmail" runat="server"
                                Width="300">
                            </telerik:RadTextBox>
                        </div>

                        <div style="margin-top: 5px;">
                            <telerik:RadLabel ID="rlNR_CPF" runat="server"
                                Width="75"
                                Text="CPF">
                            </telerik:RadLabel>

                            <telerik:RadMaskedTextBox ID="rmtbCPF" runat="server"
                                Width="150"
                                Mask="###.###.###-##"
                                Style="text-align: right;">
                            </telerik:RadMaskedTextBox>
                        </div>

                        <div style="margin-top: 5px;">
                            <telerik:RadLabel ID="rlNR_Telefone" runat="server"
                                Width="75"
                                Text="Telefone">
                            </telerik:RadLabel>

                            <telerik:RadMaskedTextBox ID="rmtbTelefone" runat="server"
                                Width="160"
                                Mask="(##) ####-####"
                                Style="text-align: right;">
                            </telerik:RadMaskedTextBox>

                            <telerik:RadLabel ID="rlNR_Celular" runat="server"
                                Style="margin-left: 10px;"
                                Text="Celular">
                            </telerik:RadLabel>

                            <telerik:RadMaskedTextBox ID="rmtbCelular" runat="server"
                                Width="160"
                                Mask="(##) #####-####"
                                Style="text-align: right;">
                            </telerik:RadMaskedTextBox>
                        </div>

                        <div style="margin-top: 5px;">
                            <telerik:RadLabel ID="rlNM_Login" runat="server"
                                Width="75"
                                Text="Login">
                            </telerik:RadLabel>

                            <telerik:RadTextBox ID="rtbLogin" runat="server"
                                Width="250">
                            </telerik:RadTextBox>

                            <telerik:RadCheckBox ID="rcbFL_Habilita" runat="server"
                                Enabled="false"
                                Style="margin-left: 20px;"
                                Text="Habilitado">
                            </telerik:RadCheckBox>
                        </div>

                        <div style="text-align: center; margin-top: 15px;">
                            <telerik:RadButton ID="rbIncluir" runat="server"
                                Text="Incluir"
                                OnClick="rbIncluir_Click">
                            </telerik:RadButton>

                            <telerik:RadButton ID="rbFechaEdicao" runat="server"
                                Text="Fechar"
                                OnClick="rbFechaEdicao_Click">
                            </telerik:RadButton>
                        </div>
                    </ContentTemplate>
                </telerik:RadWindow>

                <telerik:RadWindow ID="rwSucesso" runat="server" 
                                   Visible="false" 
                                   Width="400" 
                                   Height="150" 
                                   Modal="true"
                                   VisibleStatusbar="false"
                                   Style="background-color: silver; z-index: 9001;"
                                   Behaviors="None"
                                   Title="Sucesso!">
                    <ContentTemplate>
                        <telerik:RadLabel ID="rlSucesso" runat="server"
                                          Text="Cadastro efetuado com sucesso! Sua senha são os 4 últimos dígitos do seu CPF!">
                        </telerik:RadLabel>

                        <telerik:RadButton ID="rbSucesso" runat="server"
                                           Text="OK"
                                           style="text-align: center;"
                                           OnClick="rbSucesso_Click">
                        </telerik:RadButton>
                    </ContentTemplate>
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </form>
</body>
</html>
