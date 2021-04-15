<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Moeda.aspx.cs" Inherits="BitchainWeb.Pages.Moeda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="rsmMoeda" runat="server"></telerik:RadScriptManager>

        <div style="text-align:right; float: left; width: 800px;">
            <img src="../img/Logo.png" />

            <telerik:RadButton ID="rbTelaInicial" runat="server"
                               OnClick="rbTelaInicial_Click"
                               style="margin-left: 300px;"
                               Text="Voltar">
            </telerik:RadButton>
        </div>

        <div>
            <telerik:RadGrid ID="rgMoedas" runat="server"
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
                             DataSourceID="MoedasLinqDataSource"
                             OnItemCommand="rgMoedas_ItemCommand">
                <PagerStyle Mode="NextPrevAndNumeric" PageSizeControlType="None" />
                <ClientSettings> <Selecting AllowRowSelect="true" /> </ClientSettings>

                <MasterTableView DataKeyNames="ID_MOEDA"
                                 NoMasterRecordsText="Não há moedas há serem mostradas!"
                                 CommandItemDisplay="Top"
                                 EditMode="PopUp">
                    <CommandItemTemplate>
                        <telerik:RadButton ID="rbEditar" runat="server"
                                           CommandName="Editar"
                                           Text="Editar moeda">
                        </telerik:RadButton>

                        <telerik:RadButton ID="rbIncluir" runat="server"
                                           CommandName="Incluir"
                                           Text="Incluir moeda">
                        </telerik:RadButton>

                        <telerik:RadButton ID="rbRelatorio" runat="server"
                                           OnClick="rbRelatorio_Click"
                                           style="margin-left: 450px;"
                                           Text="Imprimir">
                        </telerik:RadButton>
                    </CommandItemTemplate>

                    <Columns>
                        <telerik:GridBoundColumn DataField="ID_MOEDA"
                                                 HeaderText="Código"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="EqualTo"
                                                 FilterControlWidth="60"
                                                 UniqueName="ID_Moeda">
                            <HeaderStyle Width="80" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NM_DESCRICAO"
                                                 HeaderText="Descrição"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="Contains"
                                                 FilterControlWidth="280"
                                                 UniqueName="NM_Descricao">
                            <HeaderStyle Width="300" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NM_SIGLA"
                                                 HeaderText="Sigla"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="Contains"
                                                 FilterControlWidth="280"
                                                 UniqueName="NM_Sigla">
                            <HeaderStyle Width="300" />
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>

            <telerik:RadWindowManager ID="rwmMoeda" runat="server" style="z-index: 9001">
                <Windows>
                    <telerik:RadWindow ID="rwMoedas" runat="server"
                                       Width="600"
                                       Height="400"
                                       Modal="true"
                                       VisibleStatusbar="false"
                                       style="background-color: silver; z-index: 7001;"
                                       Behaviors="None"
                                       Title="Moedas">
                        <ContentTemplate>
                            <div style="margin-top: 10px;">
                                <telerik:RadLabel ID="rlNM_Sigla" runat="server"
                                                  Width="75"
                                                  Text="Sigla">
                                </telerik:RadLabel>

                                <telerik:RadTextBox ID="rtbSigla" runat="server"
                                                    Width="150">
                                </telerik:RadTextBox>
                            </div>
                            <div style="margin-top: 10px;">
                                <telerik:RadLabel ID="rlNM_Descricao" runat="server"
                                                  Width="75"
                                                  Text="Nome">
                                </telerik:RadLabel>

                                <telerik:RadTextBox ID="rtbDescricao" runat="server"
                                                    Width="300" >
                                </telerik:RadTextBox>
                            </div>

                            <div style="margin-top: 5px;">
                                <telerik:RadLabel ID="rlCotacao" runat="server"
                                                  Width="75"
                                                  Text="Cotação">
                                </telerik:RadLabel>

                                <telerik:RadNumericTextBox ID="rntbCotacao" runat="server"
                                                          Width="110"
                                                          NumberFormat-DecimalDigits="2"
                                                          style="text-align: right;">
                                </telerik:RadNumericTextBox>

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

            <asp:LinqDataSource ID="MoedasLinqDataSource" runat="server"
                                ContextTypeName="BitchainWeb.BaseDataContext"
                                EntityTypeName=""
                                EnableInsert="True"
                                EnableUpdate="True"
                                EnableDelete="True"
                                TableName="ListaMoedas">
            </asp:LinqDataSource>
        </div>
        <asp:HiddenField ID="hfID_Moeda" runat="server" Value="0"/>
    </form>
</body>
</html>
