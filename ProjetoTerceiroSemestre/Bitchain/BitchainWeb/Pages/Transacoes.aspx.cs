using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace BitchainWeb.Pages
{
    public partial class Transacoes : System.Web.UI.Page
    {
        string aviso;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rbTelaInicial_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Pages\PaginaInicial.aspx");
        }

        protected void rgTransacoes_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Incluir")
            {
                LimpaEdicao();
                rwWindow.Visible = true;
                rwWindow.VisibleOnPageLoad = true;
                rwmWindow.Visible = true;
            }
        }

        protected void rgTransacoes_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.CommandItem)
            {
                CarregaBancos();
                CarregaUsuarios();
            }
        }

        private void CarregaBancos()
        {
            using (var db = new BaseDataContext())
            {
                var lstBanco = db.Bancos.ToList();
                rcbBanco_De.DataSource = lstBanco.ToList();
                rcbBanco_De.DataBind();

                rcbBanco_Para.DataSource = lstBanco.ToList();
                rcbBanco_Para.DataBind();
            }
        }

        private void CarregaUsuarios()
        {
            using (var db = new BaseDataContext())
            {
                var lstUsuarios = db.Usuarios.Where(u => u.FL_HABILITA == 1).ToList();

                rcbNM_Usuario_De.DataSource = lstUsuarios.ToList();
                rcbNM_Usuario_De.DataBind();

                rcbNM_Usuario_Para.DataSource = lstUsuarios.ToList();
                rcbNM_Usuario_Para.DataBind();
            }
        }

        private void LimpaEdicao()
        {
            rcbNM_Usuario_De.SelectedValue = null;
            rcbNM_Usuario_Para.SelectedValue = null;
            rcbBanco_De.SelectedValue = null;
            rcbBanco_Para.SelectedValue = null;

            rcbNM_Usuario_De.Text = string.Empty;
            rcbNM_Usuario_Para.Text = string.Empty;
            rcbBanco_De.Text = string.Empty;
            rcbBanco_Para.Text = string.Empty;

            rtbNR_Agencia.Text = string.Empty;
            rtbNR_CCorrente.Text = string.Empty;
            rtbNR_DV.Text = string.Empty;
            rntbVL_Valor.Value = 0;
        }

        protected void rbIncluir_Click(object sender, EventArgs e)
        {
            using (var db = new BaseDataContext())
            {
                try
                {
                    if (Validacao("Incluir"))
                    {
                        var transacao = new Transacao();
                        var contaDe = db.Contas.Single(c => c.ID_CONTA == int.Parse(hfID_ContaDe.Value));
                        var contaPara = db.Contas.Single(c => c.ID_CONTA == int.Parse(hfID_ContaPara.Value));

                        transacao.ID_USUARIO_DE = int.Parse(rcbNM_Usuario_De.SelectedValue);
                        transacao.ID_CONTA_DE = int.Parse(hfID_ContaDe.Value);
                        transacao.ID_USUARIO_PARA = int.Parse(rcbNM_Usuario_Para.SelectedValue);
                        transacao.ID_CONTA_PARA = int.Parse(hfID_ContaPara.Value);
                        transacao.VL_BRUTO = Convert.ToDecimal(rntbVL_Valor.Value);
                        transacao.DT_TRANSACAO = DateTime.Now;
                        contaDe.VL_SALDO = contaDe.VL_SALDO - Convert.ToDecimal(rntbVL_Valor.Value);
                        contaPara.VL_SALDO = contaPara.VL_SALDO + Convert.ToDecimal(rntbVL_Valor.Value);

                        db.Transacaos.InsertOnSubmit(transacao);
                        db.SubmitChanges();

                        rwWindow.Visible = false;
                        rgTransacoes.Rebind();
                        rwmWindow.RadAlert($"Transação efetuada com sucesso! Protocolo: {transacao.ID_TRANSACAO}", 400, 100, "Atenção", null);
                    }
                    else
                    {
                        rwmWindow.RadAlert(aviso, 350, 100, "Atenção", null);
                    }
                }
                catch (Exception ex)
                {
                    rwmWindow.RadAlert(ex.Message, 350, 100, "Atenção", null);
                }
            }
        }

        protected void rbFechaEdicao_Click(object sender, EventArgs e)
        {
            rwWindow.VisibleOnPageLoad = false;
        }

        private bool Validacao(string Acao)
        {
            var sucesso = false;

            if (!CamposPreenchidos())
                aviso = "Preencha todos os campos";
            else if (!Pesquisa(Acao))
                aviso = "Erro na transação";
            else if (!ValidaTransacao())
            {

            }
            else
                sucesso = true;

            return sucesso;
        }

        private bool CamposPreenchidos()
        {
            var sucesso = false;

            if (!string.IsNullOrEmpty(rcbNM_Usuario_De.SelectedValue) ||
                !string.IsNullOrEmpty(rcbNM_Usuario_Para.SelectedValue) ||
                !string.IsNullOrEmpty(rcbBanco_De.SelectedValue) ||
                !string.IsNullOrEmpty(rcbBanco_Para.SelectedValue) ||
                !string.IsNullOrEmpty(rtbNR_Agencia.Text) || 
                !string.IsNullOrEmpty(rtbNR_CCorrente.Text) || 
                !string.IsNullOrEmpty(rtbNR_DV.Text) ||
                rntbVL_Valor.Value > 0)
                sucesso = true;
            else
                aviso = "Preencha todos os campos";

            return sucesso;
        }

        private bool Pesquisa(string Acao)
        {
            var sucesso = false;

            try
            {
                using (var db = new BaseDataContext())
                {
                    //var lstConta = db.Contas.Where(m => (!string.IsNullOrEmpty(rtbNR_Agencia.Text) && m.NR_AGENCIA == rtbNR_Agencia.Text.Trim()) ||
                    //                                    (!string.IsNullOrEmpty(rtbNR_CCorrente.Text) && m.NR_CCORRENTE == rtbNR_CCorrente.Text.Trim()) ||
                    //                                    (!string.IsNullOrEmpty(rtbNR_DV.Text) && m.NR_DV == rtbNR_DV.Text));

                    //if (lstConta.Count() > 0)
                    //    sucesso = true;
                    //else
                    //    aviso = "\"Dados de conta\" já existente";

                    var contaDe = db.Contas.Where(c => c.ID_USUARIO == int.Parse(rcbNM_Usuario_De.SelectedValue) && c.ID_BANCO == int.Parse(rcbBanco_De.SelectedValue));
                    var contaPara = db.Contas.Where(c => c.ID_USUARIO == int.Parse(rcbNM_Usuario_Para.SelectedValue) && c.ID_BANCO == int.Parse(rcbBanco_Para.SelectedValue) && c.NR_AGENCIA == rtbNR_Agencia.Text.Trim() && c.NR_CCORRENTE == rtbNR_CCorrente.Text.Trim() && c.NR_DV == rtbNR_DV.Text.Trim());

                    if (contaDe.Count() > 0 && contaPara.Count() > 0)
                    {
                        if (contaDe.Count() == 1)
                        {
                            hfID_ContaDe.Value = contaDe.Single().ID_CONTA.ToString();
                        }
                        if (contaPara.Count() == 1)
                        {
                            hfID_ContaPara.Value = contaPara.Single().ID_CONTA.ToString();
                        }

                        sucesso = true;
                    }
                    else if (contaDe.Count() == 0)
                        aviso = "Conta de cliente inválida";
                    else if (contaPara.Count() == 0)
                        aviso = "Conta de favoreciso inválida";
                }
            }
            catch (Exception ex)
            {
                rwmWindow.RadAlert(ex.Message, 300, 50, "Atenção", null);
            }

            return sucesso;
        }

        private bool ValidaTransacao()
        {
            var sucesso = false;

            using (var db = new BaseDataContext())
            {
                var contaDe = db.Contas.Single(c => c.ID_CONTA == int.Parse(hfID_ContaDe.Value));
                var contaPara = db.Contas.Single(c => c.ID_CONTA == int.Parse(hfID_ContaPara.Value));

                if (contaDe.VL_SALDO < Convert.ToDecimal(rntbVL_Valor.Value))
                    aviso = "Saldo insuficiente";
                else if (contaPara.FL_HABILITA == 0)
                    aviso = "Conta favorecida desabilitada";
                else if (contaDe.FL_HABILITA == 0)
                    aviso = "Conta cliente desabilitada";
                else
                    sucesso = true;

                contaDe = null;
                contaPara = null;
            }

            return sucesso;
        }

        protected void rbRelatorio_Click(object sender, EventArgs e)
        {
            var filtro = "RPT=ListaDeTransacoes&Tipo=Excel";
            var dadoEncriptado = CryptoServiceHelper.RijndaelHelper.Default.Encrypt(filtro);
            var query = CryptoServiceHelper.UrlHelper.UrlTokenEncode(dadoEncriptado);
            var script = String.Format(@"window.open('Reports/Reports.aspx?q={0}','_blank');", query);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "reportResultPage", script, true);

            filtro = null;
            dadoEncriptado = null;
            query = null;
            script = null;
        }
    }
}