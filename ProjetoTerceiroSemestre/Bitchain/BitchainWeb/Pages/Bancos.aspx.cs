using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace BitchainWeb.Pages
{
    public partial class Bancos : System.Web.UI.Page
    {
        string aviso = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rgBancos_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                if (rgBancos.SelectedItems.Count == 1)
                {
                    hfID_Banco.Value = (rgBancos.SelectedItems[0] as GridDataItem).GetDataKeyValue("ID_BANCO").ToString();
                    rwBanco.VisibleOnPageLoad = true;

                    LimpaEdicao();
                    CarregaDadosParaEdicao();
                    rwBanco.Visible = true;
                    rwBanco.VisibleOnPageLoad = true;
                    rbSalvaEdicao.Visible = true;
                    rbIncluir.Visible = false;
                }
                else
                {
                    rwmWindow.RadAlert("Selecione um banco!", 300, 50, "Atenção", null);
                    rwmWindow.Visible = true;
                    rwBanco.Visible = false;
                }
            }
            else if (e.CommandName == "Incluir")
            {
                LimpaEdicao();
                rwBanco.Visible = true;
                rwBanco.VisibleOnPageLoad = true;
                rwmWindow.Visible = true;
                rbSalvaEdicao.Visible = false;
                rbIncluir.Visible = true;
            }
        }

        protected void rbTelaInicial_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Pages\PaginaInicial.aspx");
        }

        protected void rbFechaEdicao_Click(object sender, EventArgs e)
        {
            rwBanco.VisibleOnPageLoad = false;
        }
       
        protected void rbSalvaEdicao_Click(object sender, EventArgs e)
        {
            using (var db = new BaseDataContext())
            {
                try
                {
                    if (Validacao("Editar"))
                    {
                        var banco = db.Bancos.Single(u => u.ID_BANCO == int.Parse(hfID_Banco.Value));

                        banco.NR_BANCO = rtbNR_Banco.Text;
                        banco.NM_DESCRICAO = rtbNM_Descricao.Text.ToUpper().Trim();

                        db.SubmitChanges();

                        rwBanco.Visible = false;
                        rgBancos.Rebind();
                        rwmWindow.RadAlert("Banco alterado com sucesso!", 400, 100, "Atenção", null);
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
                        var banco = new Banco();

                        banco.NR_BANCO = rtbNR_Banco.Text;
                        banco.NM_DESCRICAO = rtbNM_Descricao.Text.ToUpper().Trim();

                        db.Bancos.InsertOnSubmit(banco);
                        db.SubmitChanges();

                        rwBanco.Visible = false;
                        rgBancos.Rebind();
                        rwmWindow.RadAlert("Banco adicionado com sucesso!", 400, 100, "Atenção", null);
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

        private void LimpaEdicao()
        {
            rtbNR_Banco.Text= null;
            rtbNM_Descricao.Text = string.Empty;
        }

        private void CarregaDadosParaEdicao()
        {
            using (var db = new BaseDataContext())
            {
                var banco = db.Bancos.Single(u => u.ID_BANCO == int.Parse(hfID_Banco.Value));

                rtbNR_Banco.Text = banco.NR_BANCO;
                rtbNM_Descricao.Text = banco.NM_DESCRICAO;

                banco = null;
            }
        }

        private bool Validacao(string Acao)
        {
            var sucesso = false;

            if (CamposPreenchidos())
                sucesso = true;
            else if (Pesquisa(Acao))
                aviso = "Banco já existente";
            else
                aviso = "Preencha todos os campos";

            return sucesso;
        }

        private bool CamposPreenchidos()
        {
            var sucesso = false;

            if (!string.IsNullOrEmpty(rtbNM_Descricao.Text) || !string.IsNullOrEmpty(rtbNR_Banco.Text))
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
                    var lstBanco = db.Bancos.Where(m => (!string.IsNullOrEmpty(rtbNM_Descricao.Text) && m.NM_DESCRICAO == rtbNM_Descricao.Text.ToUpper().Trim()) ||
                                                        (!string.IsNullOrEmpty(rtbNR_Banco.Text) && m.NR_BANCO == rtbNR_Banco.Text));

                    if (Acao == "Editar")
                    {
                        if (lstBanco.Count(l => l.ID_BANCO != int.Parse(hfID_Banco.Value)) == 0)
                            sucesso = true;
                        else
                            aviso = "\"Número do banco\" ou \"Nome\" já existente";
                    }
                    else
                    {
                        if (lstBanco.Count() == 0)
                            sucesso = true;
                        else
                            aviso = "\"Número do banco\" ou \"Nome\" já existente";
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
            var filtro = "RPT=ListaDeBancos&Tipo=Excel";
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