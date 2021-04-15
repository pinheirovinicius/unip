<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="BitchainWeb.Pages.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="rsmUsuario" runat="server"></telerik:RadScriptManager>
        <div style="text-align:right; float: left; width: 800px;">
            <img src="../img/Logo.png" />

            <telerik:RadButton ID="rbTelaInicial" runat="server"
                               OnClick="rbTelaInicial_Click"
                               style="margin-left: 300px;"
                               Text="Voltar">
            </telerik:RadButton>
        </div>

        <div>
            <telerik:RadGrid ID="rgUsuarios" runat="server"
                             Font-Names="calibri"
                             AutoGenerateColumns="false"
                             AllowFilteringByColumn="true"
                             AllowPaging="true"
                             PageSize="15"
                             Width="800"
                             AllowSorting="true"
                             AllowAutomaticInserts="true"
                             AllowAutomaticDeletes="true"
                             AllowAutomaticUpdates="true"
                             DataSourceID="UsuariosLinqDataSource"
                             OnItemCommand="rgUsuarios_ItemCommand">
                <PagerStyle Mode="NextPrevAndNumeric" PageSizeControlType="None" />
                <ClientSettings> <Selecting AllowRowSelect="true" /> </ClientSettings>

                <MasterTableView DataKeyNames="ID_USUARIO"
                                 NoMasterRecordsText="Não há usuários há serem mostrados!"
                                 CommandItemDisplay="Top"
                                 EditMode="PopUp">
                    <CommandItemTemplate>
                        <telerik:RadButton ID="rbEditarUsuario" runat="server"
                                           CommandName="EditarUsuario"
                                           Text="Editar usuário">
                        </telerik:RadButton>

                        <telerik:RadButton ID="rbIncluir" runat="server"
                                           CommandName="Incluir"
                                           Text="Incluir usuário">
                        </telerik:RadButton>

                        <telerik:RadButton ID="rbRelatorio" runat="server"
                                           OnClick="rbRelatorio_Click"
                                           style="margin-left: 450px;"
                                           Text="Imprimir">
                        </telerik:RadButton>
                    </CommandItemTemplate>

                    <Columns>
                        <telerik:GridBoundColumn DataField="ID_USUARIO"
                                                 HeaderText="Código"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="EqualTo"
                                                 FilterControlWidth="60"
                                                 UniqueName="ID_Usuario">
                            <HeaderStyle Width="80" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NM_NOME"
                                                 HeaderText="Nome usuário"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="Contains"
                                                 FilterControlWidth="280"
                                                 UniqueName="NM_Nome">
                            <HeaderStyle Width="300" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NM_LOGIN"
                                                 HeaderText="Login"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="Contains"
                                                 FilterControlWidth="280"
                                                 UniqueName="NM_Login">
                            <HeaderStyle Width="300" />
                        </telerik:GridBoundColumn>

                        <%--<telerik:GridButtonColumn ButtonType="ImageButton"
                                                  CommandName="Edit">
                            <HeaderStyle Width="45" />
                        </telerik:GridButtonColumn>

                        <telerik:GridButtonColumn ButtonType="ImageButton"
                                                  CommandName="Delete"
                                                  ConfirmDialogType="RadWindow"
                                                  ConfirmText="Deseja excluir esse usuário?"
                                                  ConfirmTitle="Exclusão de usuario">
                            <HeaderStyle Width="45" />
                        </telerik:GridButtonColumn>--%>
                    </Columns>


                </MasterTableView>
            </telerik:RadGrid>

            <telerik:RadWindowManager ID="rwmUsuario" runat="server" style="z-index: 9001">
                <Windows>
                    <telerik:RadWindow ID="rwUsuarios" runat="server"
                                       Width="600"
                                       Height="400"
                                       Modal="true"
                                       VisibleStatusbar="false"
                                       style="background-color: silver; z-index: 7001;"
                                       Behaviors="None"
                                       Title="Usuários">
                        <ContentTemplate>
                            <div style="margin-top: 10px;">
                                <telerik:RadLabel ID="rlNM_Nome" runat="server"
                                                  Width="75"
                                                  Text="Nome">
                                </telerik:RadLabel>

                                <telerik:RadTextBox ID="rtbNome" runat="server"
                                                    Width="300" >
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
                                                          style="text-align: right;">
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
                                                          style="text-align: right;">
                                </telerik:RadMaskedTextBox>

                                <telerik:RadLabel ID="rlNR_Celular" runat="server"
                                                  style="margin-left: 10px;"
                                                  Text="Celular">
                                </telerik:RadLabel>

                                <telerik:RadMaskedTextBox ID="rmtbCelular" runat="server"
                                                          Width="160"
                                                          Mask="(##) #####-####"
                                                          style="text-align: right;">
                                </telerik:RadMaskedTextBox>
                            </div>

                            <div style="margin-top: 5px;">
                                <telerik:RadLabel ID="rlNM_Perfil" runat="server"
                                                  Width="75"
                                                  Text="Perfil">
                                </telerik:RadLabel>

                                <telerik:RadTextBox ID="rtbPerfil" runat="server"
                                                    Width="150">
                                </telerik:RadTextBox>
                            </div>

                            <div style="margin-top: 5px;">
                                <telerik:RadLabel ID="rlNM_Login" runat="server"
                                                  Width="75"
                                                  Text="Login">
                                </telerik:RadLabel>

                                <telerik:RadTextBox ID="rtbLogin" runat="server"
                                                    Enabled="false"
                                                    Width="250">
                                </telerik:RadTextBox>

                                <telerik:RadCheckBox ID="rcbFL_Habilita" runat="server"
                                                     Enabled="false"
                                                     style="margin-left: 20px;"
                                                     Text="Habilitado">
                                </telerik:RadCheckBox>
                            </div>

                            <div style="text-align: center; margin-top: 15px;">
                                <telerik:RadButton ID="rbSalvaEdicao" runat="server" 
                                                   Text="Salvar" 
                                                   OnClick="rbSalvaEdicao_Click" >
                                </telerik:RadButton>

                                <telerik:RadButton ID="rbIncluir" runat="server"
                                                   Text="Incluir"
                                                   Visible="false"
                                                   OnClick="rbIncluir_Click">
                                </telerik:RadButton>
                                
                                <telerik:RadButton ID="rbFechaEdicao" runat="server" 
                                                   Text="Fechar" 
                                                   OnClick="rbFechaEdicao_Click" >
                                </telerik:RadButton>
                            </div>
                        </ContentTemplate>
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>

            <asp:LinqDataSource ID="UsuariosLinqDataSource" runat="server"
                                ContextTypeName="BitchainWeb.BaseDataContext"
                                EntityTypeName=""
                                EnableInsert="True"
                                EnableUpdate="True"
                                EnableDelete="True"
                                TableName="Usuarios">
            </asp:LinqDataSource>
        </div>
    <asp:HiddenField ID="hfID_Usuario" runat="server" Value="0"/>
    </form>
</body>
</html>