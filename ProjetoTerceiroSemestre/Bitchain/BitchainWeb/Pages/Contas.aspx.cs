using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace BitchainWeb.Pages
{
    public partial class Contas : System.Web.UI.Page
    {
        string aviso;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rbTelaInicial_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Pages\PaginaInicial.aspx");
        }

        protected void rbFechaEdicao_Click(object sender, EventArgs e)
        {
            rwConta.VisibleOnPageLoad = false;
        }

        protected void rbSalvaEdicao_Click(object sender, EventArgs e)
        {
            using (var db = new BaseDataContext())
            {
                try
                {
                    if (Validacao("Editar"))
                    {
                        var Conta = db.Contas.Single(u => u.ID_CONTA == int.Parse(hfID_Conta.Value));

                        Conta.ID_BANCO = Convert.ToInt32(rcbID_Banco.SelectedItem.Value);
                        Conta.NR_AGENCIA = rtbNR_Agencia.Text;
                        Conta.NR_CCORRENTE = rtbNR_CCorrente.Text.Trim();
                        Conta.NR_DV = rtbNR_DV.Text;
                        Conta.FL_HABILITA = (byte)(rcbFL_Habilita.Checked == true ? 1 : 0);

                        db.SubmitChanges();

                        rwConta.Visible = false;
                        rgContas.Rebind();
                        rwmWindow.RadAlert("Conta alterada com sucesso!", 400, 100, "Atenção", null);
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

        protected void rbIncluir_Click(object sender, EventArgs e)
        {
            using (var db = new BaseDataContext())
            {
                try
                {
                    if (Validacao("Incluir"))
                    {
                        var Conta = new Conta();

                        Conta.ID_USUARIO = Convert.ToInt32(rcbNM_Nome.SelectedValue);
                        Conta.ID_BANCO = Convert.ToInt32(rcbID_Banco.SelectedItem.Value);
                        Conta.NR_AGENCIA = rtbNR_Agencia.Text;
                        Conta.NR_CCORRENTE = rtbNR_CCorrente.Text.Trim();
                        Conta.NR_DV = rtbNR_DV.Text;
                        Conta.VL_SALDO = 0;
                        Conta.FL_HABILITA = 1;
                        Conta.DT_CADASTRO = DateTime.Now;

                        db.Contas.InsertOnSubmit(Conta);
                        db.SubmitChanges();

                        rwConta.Visible = false;
                        rgContas.Rebind();
                        rwmWindow.RadAlert("Conta adicionada com sucesso!", 400, 100, "Atenção", null);
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

        protected void rgContas_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                if (rgContas.SelectedItems.Count == 1)
                {
                    hfID_Conta.Value = (rgContas.SelectedItems[0] as GridDataItem).GetDataKeyValue("ID_CONTA").ToString();
                    rwConta.VisibleOnPageLoad = true;

                    LimpaEdicao();
                    CarregaDadosParaEdicao();
                    rwConta.Visible = true;
                    rwConta.VisibleOnPageLoad = true;
                    rbSalvaEdicao.Visible = true;
                    rbIncluir.Visible = false;
                    rcbNM_Nome.Enabled = false;
                    rcbID_Banco.Enabled = false;
                }
                else
                {
                    rwmWindow.RadAlert("Selecione uma conta!", 300, 50, "Atenção", null);
                    rwmWindow.Visible = true;
                    rwConta.Visible = false;
                }
            }
            else if (e.CommandName == "Incluir")
            {
                LimpaEdicao();
                rwConta.Visible = true;
                rwConta.VisibleOnPageLoad = true;
                rwmWindow.Visible = true;
                rbSalvaEdicao.Visible = false;
                rbIncluir.Visible = true;
                rcbNM_Nome.Enabled = true;
                rcbID_Banco.Enabled = true;
            }
        }

        protected void rgConta_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.CommandItem)
            {
                CarregaBanco();
                CarregaUsuario();
            }
        }

        private void CarregaBanco()
        {
            using (var db = new BaseDataContext())
            {
                var lstBanco = db.Bancos.ToList();
                rcbID_Banco.DataSource = lstBanco.ToList();
                rcbID_Banco.DataBind();
            }
        }

        private void CarregaUsuario()
        {
            using (var db = new BaseDataContext())
            {
                var lstUsuarios = db.Usuarios.Where(u => u.FL_HABILITA == 1).ToList();
                rcbNM_Nome.DataSource = lstUsuarios.ToList();
                rcbNM_Nome.DataBind();
            }
        }

        private void LimpaEdicao()
        {
            rcbNM_Nome.SelectedValue = null;
            rcbNM_Nome.Text = string.Empty;
            rcbID_Banco.SelectedValue = null;
            rcbID_Banco.Text = string.Empty;
            rtbNR_Agencia.Text = string.Empty;
            rtbNR_CCorrente.Text = string.Empty;
            rtbNR_DV.Text = string.Empty;
            rcbFL_Habilita.Checked = false;
        }

        private void CarregaDadosParaEdicao()
        {
            using (var db = new BaseDataContext())
            {
                var conta = db.Contas.Single(u => u.ID_CONTA == int.Parse(hfID_Conta.Value));

                rcbNM_Nome.SelectedValue = conta.Usuario.ID_USUARIO.ToString();
                rcbID_Banco.SelectedValue = conta.Banco.ID_BANCO.ToString();
                rtbNR_Agencia.Text = conta.NR_AGENCIA;
                rtbNR_CCorrente.Text = conta.NR_CCORRENTE;
                rtbNR_DV.Text = conta.NR_DV;
                rcbFL_Habilita.Checked = conta.FL_HABILITA == 1 ? true : false;

                conta = null;
            }
        }

        private bool Validacao(string Acao)
        {
            var sucesso = false;

            if (CamposPreenchidos())
                sucesso = true;
            else if (Pesquisa(Acao))
                aviso = "Conta já existente";
            else
                aviso = "Preencha todos os campos";

            return sucesso;
        }

        private bool CamposPreenchidos()
        {
            var sucesso = false;

            if (!string.IsNullOrEmpty(rcbNM_Nome.SelectedValue) || 
                !string.IsNullOrEmpty(rcbID_Banco.SelectedValue) ||
                !string.IsNullOrEmpty(rtbNR_Agencia.Text) || !string.IsNullOrEmpty(rtbNR_CCorrente.Text) || !string.IsNullOrEmpty(rtbNR_DV.Text))
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
                    var lstConta = db.Contas.Where(m => (!string.IsNullOrEmpty(rtbNR_Agencia.Text) && m.NR_AGENCIA == rtbNR_Agencia.Text.Trim()) ||
                                                        (!string.IsNullOrEmpty(rtbNR_CCorrente.Text) && m.NR_CCORRENTE == rtbNR_CCorrente.Text.Trim()) ||
                                                        (!string.IsNullOrEmpty(rtbNR_DV.Text) && m.NR_DV == rtbNR_DV.Text));

                    if (Acao == "Editar")
                    {
                        if (lstConta.Count(l => l.ID_CONTA != int.Parse(hfID_Conta.Value)) == 0)
                            sucesso = true;
                        else
                            aviso = "\"Dados de conta\" já existente";
                    }
                    else
                    {
                        if (lstConta.Count() == 0)
                            sucesso = true;
                        else
                            aviso = "\"Dados de conta\" já existente";
                    }
                }
            }
            catch (Exception ex)
            {
                rwmWindow.RadAlert(ex.Message, 300, 50, "Atenção", null);
            }

            return sucesso;
        }

        protected void rbRelatorio_Click(object sender, EventArgs e)
        {
            var filtro = "RPT=ListaDeContas&Tipo=Excel";
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