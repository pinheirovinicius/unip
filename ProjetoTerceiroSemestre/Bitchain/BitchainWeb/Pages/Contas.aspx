    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contas.aspx.cs" Inherits="BitchainWeb.Pages.Contas" %>

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
        <telerik:RadScriptManager ID="rsmConta" runat="server"></telerik:RadScriptManager>
        <div style="text-align:right; float: left; width: 800px;">
            <img src="../img/Logo.png" />

            <telerik:RadButton ID="rbTelaInicial" runat="server"
                               OnClick="rbTelaInicial_Click"
                               style="margin-left: 300px;"
                               Text="Voltar">
            </telerik:RadButton>
        </div>

        <div>
            <telerik:RadGrid ID="rgContas" runat="server"
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
                             DataSourceID="ContasLinqDataSource"
                             OnItemCommand="rgContas_ItemCommand"
                             OnItemCreated="rgConta_ItemCreated" >
                <PagerStyle Mode="NextPrevAndNumeric" PageSizeControlType="None" />
                <ClientSettings> <Selecting AllowRowSelect="true" /> </ClientSettings>

                <MasterTableView DataKeyNames="ID_CONTA"
                                 NoMasterRecordsText="Não há contas há serem mostradas!"
                                 CommandItemDisplay="Top"
                                 EditMode="PopUp">
                    <CommandItemTemplate>
                        <telerik:RadButton ID="rbEditar" runat="server"
                                           CommandName="Editar"
                                           Text="Editar conta">
                        </telerik:RadButton>

                        <telerik:RadButton ID="rbIncluir" runat="server"
                                           CommandName="Incluir"
                                           Text="Abrir conta">
                        </telerik:RadButton>

                        <telerik:RadButton ID="rbRelatorio" runat="server"
                                           OnClick="rbRelatorio_Click"
                                           style="margin-left: 468px;"
                                           Text="Imprimir">
                        </telerik:RadButton>
                    </CommandItemTemplate>

                    <Columns>

                        <telerik:GridBoundColumn DataField="usuario.NM_NOME"
                                                 HeaderText="Nome"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="Contains"
                                                 FilterControlWidth="300"
                                                 UniqueName="NM_Nome">
                            <HeaderStyle Width="300" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Usuario.NR_CPF"
                                                 HeaderText="CPF"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="EqualTo"
                                                 FilterControlWidth="110"
                                                 UniqueName="NR_CPF">
                            <HeaderStyle Width="110" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Banco.NM_Descricao"
                                                 HeaderText="Conta"
                                                 AutoPostBackOnFilter="true"
                                                 ShowFilterIcon="false"
                                                 CurrentFilterFunction="Contains"
                                                 FilterControlWidth="200">
                        </telerik:GridBoundColumn>

                        <telerik:GridNumericColumn DataField="VL_SALDO"
                                                   HeaderText="Saldo"
                                                   DataFormatString="{0:n2}"
                                                   FilterControlWidth="80"
                                                   ShowFilterIcon="false"
                                                   AllowFiltering="false"
                                                   AutoPostBackOnFilter="true"
                                                   CurrentFilterFunction="EqualTo"
                                                   ReadOnly="true"
                                                   DecimalDigits="2"
                                                   UniqueName="VL_Saldo">
                            <ItemStyle HorizontalAlign="Right" />
                        </telerik:GridNumericColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>

            <telerik:RadWindowManager ID="rwmWindow" runat="server" style="z-index: 9001">
                <Windows>
                    <telerik:RadWindow ID="rwConta" runat="server"
                                       Width="600"
                                       Height="400"
                                       Modal="true"
                                       VisibleStatusbar="false"
                                       style="background-color: silver; z-index: 7001;"
                                       Behaviors="None"
                                       Title="Contas">
                        <ContentTemplate>
                            <div style="margin-top: 10px;">
                                <telerik:RadLabel ID="rlNome" runat="server"
                                                  Width="85"
                                                  Text="Nome">
                                </telerik:RadLabel>

                                <telerik:RadComboBox ID="rcbNM_Nome" runat="server"
                                                     Width="400"
                                                     DropDownWidth="550"
                                                     MinFilterLength="3"
                                                     Filter="Contains"
                                                     AutoPostBack="true"
                                                     EmptyMessage="Selecione um usuário."
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
                                <telerik:RadLabel ID="rlBanco" runat="server"
                                                  Width="85"
                                                  Text="Banco">
                                </telerik:RadLabel>

                                <telerik:RadComboBox ID="rcbID_Banco" runat="server"
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

            <asp:LinqDataSource ID="ContasLinqDataSource" runat="server"
                                ContextTypeName="BitchainWeb.BaseDataContext"
                                EntityTypeName=""
                                EnableInsert="True"
                                EnableUpdate="True"
                                EnableDelete="True"
                                TableName="Contas">
            </asp:LinqDataSource>
        </div>
    <asp:HiddenField ID="hfID_Conta" runat="server" Value="0"/>
    </form>
</body>
</html>
