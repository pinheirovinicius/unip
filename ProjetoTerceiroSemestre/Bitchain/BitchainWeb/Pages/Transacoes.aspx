<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transacoes.aspx.cs" Inherits="BitchainWeb.Pages.Transacoes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style type="text/css">
        .rcbHeader ul,
        .rcbFooter ul,
        .rcbItem ul,
        .rcbHovered ul,
        .rcbDisabled ul {
            margin: 0;
            padding: 0;
            width: 100%;
            display: inline-block;
            list-style-type: none;
        }

        .rcbScroll {
            overflow: scroll !important;
            overflow-x: hidden !important;
        }

        .col1 {
            margin: 0;
            padding: 0 5px 0 0;
            width: 23%;
            line-height: 14px;
            float: left;
        }

        .col2 {
            margin: 0;
            padding: 0 5px 0 0;
            width: 75%;
            line-height: 14px;
            float: left;
        }
    </style>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="rsmTransacoes" runat="server"></telerik:RadScriptManager>
        <div style="text-align:right; float: left; width: 800px;">
            <img src="../img/Logo.png" />

            <telerik:RadButton ID="rbTelaInicial" runat="server"
                               OnClick="rbTelaInicial_Click"
                               style="margin-left: 300px;"
                               Text="Voltar">
            </telerik:RadButton>
        </div>

        <div>
            <telerik:RadGrid ID="rgTransacoes" runat="server"
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
                             DataSourceID="TransacoesLinqDataSource"
                             OnItemCommand="rgTransacoes_ItemCommand"
                             OnItemCreated="rgTransacoes_ItemCreated" >
                <PagerStyle Mode="NextPrevAndNumeric" PageSizeControlType="None" />
                <ClientSettings> <Selecting AllowRowSelect="true" /> </ClientSettings>

                <MasterTableView DataKeyNames="ID_Transacao"
                                 NoMasterRecordsText="Não há transações há serem mostradas!"
                                 CommandItemDisplay="Top"
                                 EditMode="PopUp">
                    <CommandItemTemplate>
                        <telerik:RadButton ID="rbIncluir" runat="server"
                                           CommandName="Incluir"
                                           Text="Nova transação">
                        </telerik:RadButton>

                        <telerik:RadButton ID="rbRelatorio" runat="server"
                                           OnClick="rbRelatorio_Click"
                                           style="margin-left: 550px;"
                                           Text="Imprimir">
                        </telerik:RadButton>
                    </CommandItemTemplate>

                    <Columns>
                        <telerik:GridBoundColumn DataField="ID_Transacao"
                                                 HeaderText="Protocolo"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="EqualTo"
                                                 FilterControlWidth="60"
                                                 UniqueName="ID_Transacao">
                            <HeaderStyle Width="80" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NM_Usuario_De"
                                                 HeaderText="Cliente"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="Contains"
                                                 FilterControlWidth="300"
                                                 UniqueName="NM_Usuario_De">
                            <HeaderStyle Width="300" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NM_Banco_De"
                                                 HeaderText="Banco"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="EqualTo"
                                                 FilterControlWidth="200"
                                                 UniqueName="NM_Banco_De">
                            <HeaderStyle Width="200" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NM_Usuario_Para"
                                                 HeaderText="Favorecido"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="Contains"
                                                 FilterControlWidth="300"
                                                 UniqueName="NM_Usuario_Para">
                            <HeaderStyle Width="300" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="NM_Banco_Para"
                                                 HeaderText="Banco Favorecido"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="EqualTo"
                                                 FilterControlWidth="200"
                                                 UniqueName="NM_Banco_Para">
                            <HeaderStyle Width="200" />
                        </telerik:GridBoundColumn>

                        <telerik:GridNumericColumn DataField="VL_Transacao"
                                                   HeaderText="Vlr Transação"
                                                   DataFormatString="{0:n2}"
                                                   FilterControlWidth="90"
                                                   ShowFilterIcon="false"
                                                   AllowFiltering="false"
                                                   AutoPostBackOnFilter="true"
                                                   CurrentFilterFunction="EqualTo"
                                                   ReadOnly="true"
                                                   DecimalDigits="2"
                                                   UniqueName="VL_Transacao">
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <telerik:RadWindowManager ID="rwmWindow" runat="server" style="z-index: 9001">
                <Windows>
                    <telerik:RadWindow ID="rwWindow" runat="server"
                                       Width="600"
                                       Height="500"
                                       Modal="true"
                                       VisibleStatusbar="false"
                                       style="background-color: silver; z-index: 7001;"
                                       Behaviors="None"
                                       Title="Nova transação">
                        <ContentTemplate>
                            <div style="margin-top: 10px;">
                                <telerik:RadLabel ID="rlNM_Usuario_De" runat="server"
                                                  Width="85"
                                                  Text="Cliente">
                                </telerik:RadLabel>

                                <telerik:RadComboBox ID="rcbNM_Usuario_De" runat="server"
                                                     Width="400"
                                                     DropDownWidth="550"
                                                     MinFilterLength="3"
                                                     Filter="Contains"
                                                     AutoPostBack="true"
                                                     EmptyMessage="Selecione um cliente."
                                                     style="z-index: 9001;"
                                                     DataTextField="NM_Nome"
                                                     DataValueField="ID_Usuario" >
                                    <Localization NoMatches="Nenhuma correspondência"
                                                  ShowMoreFormatString="Itens <b>1</b>-<b>{0}</b> de <b>{1}</b>" />
                                    <HeaderTemplate>
                                        <ul>
                                            <li class="col1">CPF</li>
                                            <li class="col2">Nome</li>
                                        </ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <ul>
                                            <li class="col1">
                                                <%# DataBinder.Eval(Container.DataItem, "NR_CPF") %></li>
                                            <li class="col2">
                                                <%# DataBinder.Eval(Container.DataItem, "NM_NOME") %></li>
                                        </ul>
                                    </ItemTemplate>
                                </telerik:RadComboBox>
                            </div>

                            <div style="margin-top: 5px;">
                                <telerik:RadLabel ID="rlBanco_De" runat="server"
                                                  Width="85"
                                                  Text="Banco cliente">
                                </telerik:RadLabel>

                                <telerik:RadComboBox ID="rcbBanco_De" runat="server"
                                                     Width="300"
                                                     DropDownWidth="550"
                                                     MinFilterLength="3"
                                                     Filter="Contains"
                                                     AutoPostBack="true"
                                                     EmptyMessage="Selecione um banco."
                                                     style="z-index: 9001;"
                                                     DataTextField="NM_Descricao"
                                                     DataValueField="ID_Banco" >
                                    <Localization NoMatches="Nenhuma correspondência"
                                                  ShowMoreFormatString="Itens <b>1</b>-<b>{0}</b> de <b>{1}</b>" />
                                    <HeaderTemplate>
                                        <ul>
                                            <li class="col1">NR_Banco</li>
                                            <li class="col2">Banco</li>
                                        </ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <ul>
                                            <li class="col1">
                                                <%# DataBinder.Eval(Container.DataItem, "NR_BANCO") %></li>
                                            <li class="col2">
                                                <%# DataBinder.Eval(Container.DataItem, "NM_DESCRICAO") %></li>
                                        </ul>
                                    </ItemTemplate>
                                </telerik:RadComboBox>
                            </div>

                            <div style="margin-top: 10px;">
                                <telerik:RadLabel ID="rlNM_Usuario_Para" runat="server"
                                                  Width="85"
                                                  Text="Favorecido">
                                </telerik:RadLabel>

                                <telerik:RadComboBox ID="rcbNM_Usuario_Para" runat="server"
                                                     Width="400"
                                                     DropDownWidth="550"
                                                     MinFilterLength="3"
                                                     Filter="Contains"
                                                     AutoPostBack="true"
                                                     EmptyMessage="Selecione um favorecido."
                                                     style="z-index: 9001;"
                                                     DataTextField="NM_Nome"
                                                     DataValueField="ID_Usuario" >
                                    <Localization NoMatches="Nenhuma correspondência"
                                                  ShowMoreFormatString="Itens <b>1</b>-<b>{0}</b> de <b>{1}</b>" />
                                    <HeaderTemplate>
                                        <ul>
                                            <li class="col1">CPF</li>
                                            <li class="col2">Nome</li>
                                        </ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <ul>
                                            <li class="col1">
                                                <%# DataBinder.Eval(Container.DataItem, "NR_CPF") %></li>
                                            <li class="col2">
                                                <%# DataBinder.Eval(Container.DataItem, "NM_NOME") %></li>
                                        </ul>
                                    </ItemTemplate>
                                </telerik:RadComboBox>
                            </div>
                            
                            <div style="margin-top: 5px;">
                                <telerik:RadLabel ID="rlBanco_Para" runat="server"
                                                  Width="85"
                                                  Text="Banco favorecido">
                                </telerik:RadLabel>

                                <telerik:RadComboBox ID="rcbBanco_Para" runat="server"
                                                     Width="300"
                                                     DropDownWidth="550"
                                                     MinFilterLength="3"
                                                     Filter="Contains"
                                                     AutoPostBack="true"
                                                     EmptyMessage="Selecione um banco."
                                                     style="z-index: 9001;"
                                                     DataTextField="NM_Descricao"
                                                     DataValueField="ID_Banco" >
                                    <Localization NoMatches="Nenhuma correspondência"
                                                  ShowMoreFormatString="Itens <b>1</b>-<b>{0}</b> de <b>{1}</b>" />
                                    <HeaderTemplate>
                                        <ul>
                                            <li class="col1">NR_Banco</li>
                                            <li class="col2">Banco</li>
                                        </ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <ul>
                                            <li class="col1">
                                                <%# DataBinder.Eval(Container.DataItem, "NR_BANCO") %></li>
                                            <li class="col2">
                                                <%# DataBinder.Eval(Container.DataItem, "NM_DESCRICAO") %></li>
                                        </ul>
                                    </ItemTemplate>
                                </telerik:RadComboBox>
                            </div>

                            <div style="margin-top: 5px;">
                                <telerik:RadLabel ID="rlNR_Agencia" runat="server"
                                                  Width="85"
                                                  Text="Agencia">
                                </telerik:RadLabel>

                                <telerik:RadTextBox ID="rtbNR_Agencia" runat="server"
                                                    MaxLength="5"
                                                    Width="80">
                                </telerik:RadTextBox>
                            </div>

                            <div style="margin-top: 5px;">
                                <telerik:RadLabel ID="rlNR_CCorrente" runat="server"
                                                  Width="85"
                                                  Text="C. Corrente">
                                </telerik:RadLabel>

                                <telerik:RadTextBox ID="rtbNR_CCorrente" runat="server"
                                                    MaxLength="20"
                                                    Width="200">
                                </telerik:RadTextBox>
                            </div>

                            <div style="margin-top: 5px;">
                                <telerik:RadLabel ID="rlNR_DV" runat="server"
                                                  Width="85"
                                                  Text="DV">
                                </telerik:RadLabel>

                                <telerik:RadTextBox ID="rtbNR_DV" runat="server"
                                                    MaxLength="3"
                                                    Width="80">
                                </telerik:RadTextBox>
                            </div>

                            <div style="margin-top: 5px;">
                                <telerik:RadLabel ID="rlVL_Valor" runat="server"
                                                  Width="85"
                                                  Text="Valor">
                                </telerik:RadLabel>

                                <telerik:RadNumericTextBox ID="rntbVL_Valor" runat="server"
                                                          Width="110"
                                                          NumberFormat-DecimalDigits="2"
                                                          style="text-align: right;">
                                </telerik:RadNumericTextBox>
                            </div>

                            <div style="text-align: center; margin-top: 15px;">
                                <telerik:RadButton ID="rbIncluir" runat="server"
                                                   Text="Transferir"
                                                   OnClick="rbIncluir_Click">
                                </telerik:RadButton>
                                
                                <telerik:RadButton ID="rbFechaEdicao" runat="server" 
                                                   Text="Cancelar" 
                                                   OnClick="rbFechaEdicao_Click" >
                                </telerik:RadButton>
                            </div>
                        </ContentTemplate>
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>

            <asp:LinqDataSource ID="TransacoesLinqDataSource" runat="server"
                                ContextTypeName="BitchainWeb.BaseDataContext"
                                EntityTypeName=""
                                EnableInsert="True"
                                EnableUpdate="True"
                                EnableDelete="True"
                                TableName="vw_lstTransacaos">
            </asp:LinqDataSource>
        </div>

        <asp:HiddenField ID="hfID_Transacao" runat="server" Value="0"/>
        <asp:HiddenField ID="hfID_ContaDe" runat="server" Value="0" />
        <asp:HiddenField ID="hfID_ContaPara" runat="server" Value="0" />

    </form>
</body>
</html>
