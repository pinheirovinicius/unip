<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bancos.aspx.cs" Inherits="BitchainWeb.Pages.Bancos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="rsmBanco" runat="server"></telerik:RadScriptManager>
        <div style="text-align:right; float: left; width: 800px;">
            <img src="../img/Logo.png" />

            <telerik:RadButton ID="rbTelaInicial" runat="server"
                               OnClick="rbTelaInicial_Click"
                               style="margin-left: 300px;"
                               Text="Voltar">
            </telerik:RadButton>
        </div>

        <div>
            <telerik:RadGrid ID="rgBancos" runat="server"
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
                             DataSourceID="BancosLinqDataSource"
                             OnItemCommand="rgBancos_ItemCommand">
                <PagerStyle Mode="NextPrevAndNumeric" PageSizeControlType="None" />
                <ClientSettings> <Selecting AllowRowSelect="true" /> </ClientSettings>

                <MasterTableView DataKeyNames="ID_BANCO"
                                 NoMasterRecordsText="Não há bancos há serem mostrados!"
                                 CommandItemDisplay="Top"
                                 EditMode="PopUp">
                    <CommandItemTemplate>
                        <telerik:RadButton ID="rbEditar" runat="server"
                                           CommandName="Editar"
                                           Text="Editar banco">
                        </telerik:RadButton>

                        <telerik:RadButton ID="rbIncluir" runat="server"
                                           CommandName="Incluir"
                                           Text="Incluir banco">
                        </telerik:RadButton>

                        <telerik:RadButton ID="rbRelatorio" runat="server"
                                           OnClick="rbRelatorio_Click"
                                           style="margin-left: 468px;"
                                           Text="Imprimir">
                        </telerik:RadButton>
                    </CommandItemTemplate>

                    <Columns>
                        <telerik:GridBoundColumn DataField="NR_Banco"
                                                 HeaderText="Nº Banco"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="EqualTo"
                                                 FilterControlWidth="60"
                                                 UniqueName="NR_Banco">
                            <HeaderStyle Width="80" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NM_DESCRICAO"
                                                 HeaderText="Banco"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="Contains"
                                                 FilterControlWidth="280"
                                                 UniqueName="NM_Descricao">
                            <HeaderStyle Width="300" />
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>

            <telerik:RadWindowManager ID="rwmWindow" runat="server" style="z-index: 9001">
                <Windows>
                    <telerik:RadWindow ID="rwBanco" runat="server"
                                       Width="600"
                                       Height="400"
                                       Modal="true"
                                       VisibleStatusbar="false"
                                       style="background-color: silver; z-index: 7001;"
                                       Behaviors="None"
                                       Title="Bancos">
                        <ContentTemplate>
                            <div style="margin-top: 10px;">
                                <telerik:RadLabel ID="rlNR_Banco" runat="server"
                                                  Width="75"
                                                  Text="Nº Banco">
                                </telerik:RadLabel>

                                <telerik:RadTextBox ID="rtbNR_Banco" runat="server" 
                                                    Width="80" 
                                                    MaxLength="3" >
                                </telerik:RadTextBox>
                            </div>

                            <div style="margin-top: 5px;">
                                <telerik:RadLabel ID="rlNM_Descricao" runat="server"
                                                  Width="75"
                                                  Text="Banco">
                                </telerik:RadLabel>

                                <telerik:RadTextBox ID="rtbNM_Descricao" runat="server"
                                                    Width="300">
                                </telerik:RadTextBox>
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

            <asp:LinqDataSource ID="BancosLinqDataSource" runat="server"
                                ContextTypeName="BitchainWeb.BaseDataContext"
                                EntityTypeName=""
                                EnableInsert="True"
                                EnableUpdate="True"
                                EnableDelete="True"
                                TableName="Bancos">
            </asp:LinqDataSource>
        </div>
    <asp:HiddenField ID="hfID_Banco" runat="server" Value="0"/>
    </form>
</body>
</html>
