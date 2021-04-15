using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace BitchainWeb.Pages
{
    public partial class Usuarios : System.Web.UI.Page
    {
        string aviso = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void rgUsuarios_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "EditarUsuario")
            {
                if (rgUsuarios.SelectedItems.Count == 1)
                {
                    hfID_Usuario.Value = (rgUsuarios.SelectedItems[0] as GridDataItem).GetDataKeyValue("ID_USUARIO").ToString();
                    rwUsuarios.VisibleOnPageLoad = true;

                    LimpaEdicao();
                    CarregaDadosParaEdicaoUsuario();
                    rwUsuarios.Visible = true;
                    rwUsuarios.VisibleOnPageLoad = true;
                    rbSalvaEdicao.Visible = true;
                    rbIncluir.Visible = false;
                }
                else
                    rwmUsuario.RadAlert("Selecione um usuário!", 300, 50, "Atenção", null);
            }
            else if (e.CommandName == "Incluir")
            {
                LimpaEdicao();
                rtbLogin.Enabled = true;
                rtbPerfil.Enabled = false;
                rwUsuarios.Visible = true;
                rwUsuarios.VisibleOnPageLoad = true;
                rwmUsuario.Visible = true;
                rbSalvaEdicao.Visible = false;
                rbIncluir.Visible = true;
            }
        }

        private void LimpaEdicao()
        {
            rtbNome.Text = string.Empty;
            rtbEmail.Text = string.Empty;
            rmtbCPF.Text = string.Empty;
            rmtbTelefone.Text = string.Empty;
            rmtbCelular.Text = string.Empty;
            rtbPerfil.Text = string.Empty;
            rtbLogin.Text = string.Empty;
            rcbFL_Habilita.Checked = false;
            rcbFL_Habilita.Enabled = false;
        }

        private void CarregaDadosParaEdicaoUsuario()
        {
            using (var db = new BaseDataContext())
            {
                var usuario = db.Usuarios.Single(u => u.ID_USUARIO == int.Parse(hfID_Usuario.Value));

                rtbNome.Text = usuario.NM_NOME;
                rtbEmail.Text = usuario.NM_EMAIL;
                rmtbCPF.Text = usuario.NR_CPF;
                rmtbTelefone.Text = usuario.NR_TELEFONE;
                rmtbCelular.Text = usuario.NR_CELULAR;
                rtbPerfil.Enabled = false;
                rtbPerfil.Text = usuario.Perfil.NM_DESCRICAO;
                rtbLogin.Text = usuario.NM_LOGIN;
                rcbFL_Habilita.Checked = usuario.FL_HABILITA == 1 ? true : false;
                //rcbFL_Habilita.Enabled = false;
            }
        }

        protected void rbFechaEdicao_Click(object sender, EventArgs e)
        {
            rwUsuarios.VisibleOnPageLoad = false;
        }

        protected void rbSalvaEdicao_Click(object sender, EventArgs e)
        {
            using (var db = new BaseDataContext())
            {
                try
                {
                    if (Validacao("Editar"))
                    {
                        var usuario = db.Usuarios.Single(u => u.ID_USUARIO == int.Parse(hfID_Usuario.Value));

                        usuario.NM_NOME = rtbNome.Text.ToUpper().Trim();
                        usuario.NM_EMAIL = rtbEmail.Text.ToLower().Trim();
                        usuario.NR_CPF = rmtbCPF.Text;
                        usuario.NR_TELEFONE = rmtbTelefone.Text;
                        usuario.NR_CELULAR = rmtbCelular.Text;
                        usuario.NM_LOGIN = rtbLogin.Text.ToLower().Trim();
                        usuario.FL_HABILITA = (byte)(rcbFL_Habilita.Checked == true ? 1 : 0);

                        db.SubmitChanges();

                        rwUsuarios.Visible = false;
                        rgUsuarios.Rebind();
                        rwmUsuario.RadAlert("Usuário alterado com sucesso!", 400, 100, "Atenção", null);
                    }
                    else
                    {
                        rwmUsuario.RadAlert(aviso, 350, 100, "Atenção", null);
                    }
                }
                catch (Exception ex)
                {
                    rwmUsuario.RadAlert(ex.Message, 350, 100, "Atenção", null);
                }
            }
        }

        private bool Validacao(string Acao)
        {
            var sucesso = false;

            if (CamposPreenchidos() && Pesquisa(Acao))
                sucesso = true;

            return sucesso;
        }

        private bool CamposPreenchidos()
        {
            var sucesso = false;

            if (!string.IsNullOrEmpty(rtbNome.Text) || !string.IsNullOrEmpty(rmtbCPF.Text) || !string.IsNullOrEmpty(rtbEmail.Text) ||
                !string.IsNullOrEmpty(rmtbCelular.Text) || !string.IsNullOrEmpty(rtbLogin.Text))
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
                    var lstUsuarios = db.Usuarios.ToList();
                    var loginEmUso = lstUsuarios.Where(u => u.NM_LOGIN == rtbLogin.Text);
                    var emailEmUso = lstUsuarios.Where(u => u.NM_EMAIL == rtbEmail.Text);
                    var cpfEmUso = lstUsuarios.Where(u => u.NR_CPF == rmtbCPF.Text);
                    var celularEmUso = lstUsuarios.Where(u => u.NR_CELULAR == rmtbCelular.Text);

                    if (Acao == "Editar")
                    {
                        var usuario = db.Usuarios.Single(u => u.ID_USUARIO == int.Parse(hfID_Usuario.Value));
                        
                        if (loginEmUso.Count(u => u.ID_USUARIO != usuario.ID_USUARIO) > 0)
                            aviso = "Login duplicado";
                        if (emailEmUso.Count(u => u.ID_USUARIO != usuario.ID_USUARIO) > 0)
                            aviso = "E-mail duplicado";
                        if (cpfEmUso.Count(u => u.ID_USUARIO != usuario.ID_USUARIO) > 0)
                            aviso = "CPF duplicado";
                        if (celularEmUso.Count(u => u.ID_USUARIO != usuario.ID_USUARIO) > 0)
                            aviso = "Celular duplicado";
                        if (rtbNome.Text.Length <= 3)
                            aviso = "Nome inválido";
                        if (rmtbCelular.Text.Length != 11)
                            aviso = "número de celular inválido";
                        if (aviso == string.Empty)
                            sucesso = true;

                        usuario = null;
                    }
                    else if (Acao == "Incluir")
                    {
                        if (loginEmUso.Count() > 0)
                            aviso = "Login duplicado";
                        if (emailEmUso.Count() > 0)
                            aviso = "E-mail duplicado";
                        if (cpfEmUso.Count() > 0)
                            aviso = "CPF duplicado";
                        if (celularEmUso.Count() > 0)
                            aviso = "Celular duplicado";
                        if (rtbNome.Text.Length <= 3)
                            aviso = "Nome inválido";
                        if (rmtbCelular.Text.Length != 11)
                            aviso = "número de celular inválido";
                        if (aviso == string.Empty)
                            sucesso = true;
                    }

                    lstUsuarios = null;
                    loginEmUso = null;
                    emailEmUso = null;
                    cpfEmUso = null;
                    celularEmUso = null;
                }
            }
            catch (Exception ex)
            {
                aviso = $"{ex.Message}";
            }

            return sucesso;
        }

        protected void rbTelaInicial_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Pages\PaginaInicial.aspx");
        }

        protected void rbIncluir_Click(object sender, EventArgs e)
        {
            using (var db = new BaseDataContext())
            {
                try
                {
                    if (Validacao("Incluir"))
                    {
                        var usuario = new Usuario();

                        usuario.NM_NOME = rtbNome.Text.ToUpper().Trim();
                        usuario.NR_CPF = rmtbCPF.Text;
                        usuario.NM_EMAIL = rtbEmail.Text.ToLower().Trim();
                        usuario.NR_TELEFONE = rmtbTelefone.Text;
                        usuario.NR_CELULAR = rmtbCelular.Text;
                        usuario.NM_LOGIN = rtbLogin.Text.ToLower().Trim();
                        usuario.NM_SENHA = rmtbCPF.Text.Substring(7, 4);
                        usuario.ID_PERFIL = 2; //corrigir
                        usuario.FL_HABILITA = (byte)(rcbFL_Habilita.Checked == true ? 1 : 0);
                        usuario.FL_TROCA_SENHA = 0;
                        usuario.NR_ULTIMO_ACESSO = 0;
                        usuario.DT_CADASTRO = DateTime.Now;

                        db.Usuarios.InsertOnSubmit(usuario);
                        db.SubmitChanges();

                        rwUsuarios.Visible = false;
                        rgUsuarios.Rebind();
                        rwmUsuario.RadAlert("Cadastro efetuado com sucesso! Sua senha são os 4 últimos dígitos do seu CPF!", 590, 100, "Atenção", null);
                    }
                    else
                    {
                        rwmUsuario.RadAlert(aviso, 350, 100, "Atenção", null);
                    }
                }
                catch (Exception ex)
                {
                    rwmUsuario.RadAlert(ex.Message, 350, 100, "Atenção", null);
                }
            }
        }

        protected void rbRelatorio_Click(object sender, EventArgs e)
        {
            var filtro = "RPT=ListaDeUsuarios&Tipo=Excel";
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