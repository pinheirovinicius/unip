using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace BitchainWeb.Pages
{
    public partial class Moeda : System.Web.UI.Page
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
            rwmMoeda.Visible = false;
        }

        protected void rbSalvaEdicao_Click(object sender, EventArgs e)
        {
            using (var db = new BaseDataContext())
            {
                try
                {
                    if (Validacao("Editar"))
                    {
                        var moeda = db.ListaMoedas.Single(u => u.ID_MOEDA == int.Parse(hfID_Moeda.Value));

                        moeda.NM_SIGLA = rtbSigla.Text.ToUpper().Trim();
                        moeda.NM_DESCRICAO = rtbDescricao.Text.ToUpper().Trim();
                        moeda.VL_REAL = Convert.ToDecimal(rntbCotacao.Value);
                        moeda.FL_HABILITA = (byte)(rcbFL_Habilita.Checked == true ? 1 : 0);

                        db.SubmitChanges();

                        rwMoedas.Visible = false;
                        rgMoedas.Rebind();
                        rwmMoeda.RadAlert("Moeda alterada com sucesso!", 400, 100, "Atenção", null);
                    }
                    else
                    {
                        rwmMoeda.RadAlert(aviso, 350, 100, "Atenção", null);
                    }
                }
                catch (Exception ex)
                {
                    rwmMoeda.RadAlert(ex.Message, 350, 100, "Atenção", null);
                }
            }
        }

        private bool Validacao(string Acao)
        {
            var sucesso = false;

            if (CamposPreenchidos())
                sucesso = true;
            else if (PesquisaMoeda(Acao))
                aviso = "Moeda já existente";
            else
                aviso = "Preencha todos os campos";

            return sucesso;
        }

        private bool CamposPreenchidos()
        {
            var sucesso = false;

            if (!string.IsNullOrEmpty(rtbSigla.Text) ||
                !string.IsNullOrEmpty(rtbDescricao.Text) ||
                rntbCotacao.Value == null)
                sucesso = true;
            else
                aviso = "Preencha todos os campos";

            return sucesso;
        }

        private bool PesquisaMoeda(string Acao)
        {
            var sucesso = false;

            try
            {
                using (var db = new BaseDataContext())
                {
                    var listaMoeda = db.ListaMoedas.Where(m => (!string.IsNullOrEmpty(rtbSigla.Text) && m.NM_SIGLA == rtbSigla.Text.ToUpper().Trim()) ||
                                                                 (!string.IsNullOrEmpty(rtbDescricao.Text) && m.NM_DESCRICAO == rtbDescricao.Text.ToUpper().Trim()));

                    if (Acao == "Editar")
                    { 
                        if (listaMoeda.Count(l => l.ID_MOEDA != int.Parse(hfID_Moeda.Value)) == 0)
                                sucesso = true;
                        else
                            aviso = "\"Sigla\" ou \"Moeda\" já existente";
                    }
                    else
                    {
                        if (listaMoeda.Count() == 0)
                            sucesso = true;
                        else
                            aviso = "\"Sigla\" ou \"Moeda\" já existente";
                    }
                }
            }
            catch (Exception ex)
            {
                rwmMoeda.RadAlert(ex.Message, 300, 50, "Atenção", null);
            }

            return sucesso;
        }
        protected void rgMoedas_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                if (rgMoedas.SelectedItems.Count == 1)
                {
                    hfID_Moeda.Value = (rgMoedas.SelectedItems[0] as GridDataItem).GetDataKeyValue("ID_MOEDA").ToString();
                    rwMoedas.VisibleOnPageLoad = true;

                    LimpaEdicaoMoeda();
                    CarregaDadosParaEdicaoMoeda();
                    rwMoedas.Visible = true;
                    rwMoedas.VisibleOnPageLoad = true;
                    rbSalvaEdicao.Visible = true;
                    rbIncluir.Visible = false;
                }
                else
                {
                    rwmMoeda.RadAlert("Selecione uma moeda!", 300, 50, "Atenção", null);
                    rwmMoeda.Visible = true;
                    rwMoedas.Visible = false;

                }
            }
            else if (e.CommandName == "Incluir")
            {
                LimpaEdicaoMoeda();
                rwMoedas.Visible = true;
                rwMoedas.VisibleOnPageLoad = true;
                rwmMoeda.Visible = true;
                rbSalvaEdicao.Visible = false;
                rbIncluir.Visible = true;
            }
        }

        private void LimpaEdicaoMoeda()
        {
            rtbSigla.Text = string.Empty;
            rtbDescricao.Text = string.Empty;
            rntbCotacao.Value = null;
            rcbFL_Habilita.Checked = false;
            rcbFL_Habilita.Enabled = false;
        }

        private void CarregaDadosParaEdicaoMoeda()
        {
            using (var db = new BaseDataContext())
            {
                var moeda = db.ListaMoedas.Single(u => u.ID_MOEDA == int.Parse(hfID_Moeda.Value));


                rtbSigla.Text = moeda.NM_SIGLA;
                rtbDescricao.Text = moeda.NM_DESCRICAO;
                rntbCotacao.Value = (Nullable<double>)moeda.VL_REAL;
                rcbFL_Habilita.Checked = false;
                rcbFL_Habilita.Checked = moeda.FL_HABILITA == 1 ? true : false;
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
                        var moeda = new ListaMoeda();

                        moeda.NM_SIGLA = rtbSigla.Text.ToUpper().Trim();
                        moeda.NM_DESCRICAO = rtbDescricao.Text.ToUpper().Trim();
                        moeda.VL_BASE = 1;
                        moeda.VL_REAL = Convert.ToDecimal(rntbCotacao.Value);
                        moeda.FL_HABILITA = 1;

                        db.ListaMoedas.InsertOnSubmit(moeda);
                        db.SubmitChanges();

                        rwMoedas.Visible = false;
                        rgMoedas.Rebind();
                        rwmMoeda.RadAlert("Moeda adicionada com sucesso!", 400, 100, "Atenção", null);
                    }
                    else
                    {
                        rwmMoeda.RadAlert(aviso, 350, 100, "Atenção", null);
                    }
                }
                catch (Exception ex)
                {
                    rwmMoeda.RadAlert(ex.Message, 350, 100, "Atenção", null);
                }
            }
        }

        protected void rbRelatorio_Click(object sender, EventArgs e)
        {
            var filtro = "RPT=ListaDeMoedas&Tipo=Excel";
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