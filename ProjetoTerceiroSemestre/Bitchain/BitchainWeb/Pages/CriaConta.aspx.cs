using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace BitchainWeb.Pages
{
    public partial class CriaConta : System.Web.UI.Page
    {
        string aviso = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            rwmUsuario.VisibleOnPageLoad = true;
        }

        private void LimpaEdicao()
        {
            rtbNome.Text = string.Empty;
            rtbEmail.Text = string.Empty;
            rmtbCPF.Text = string.Empty;
            rmtbTelefone.Text = string.Empty;
            rmtbCelular.Text = string.Empty;
            rtbLogin.Text = string.Empty;
            rcbFL_Habilita.Checked = false;
            rcbFL_Habilita.Enabled = false;
        }

        protected void rbFechaEdicao_Click(object sender, EventArgs e)
        {
            rwUsuarios.VisibleOnPageLoad = false;
            Response.Redirect(@"~\Pages\Login.aspx");
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

                     if (Acao == "Incluir")
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
                        usuario.FL_HABILITA = 1;
                        usuario.FL_TROCA_SENHA = 0;
                        usuario.NR_ULTIMO_ACESSO = 0;
                        usuario.DT_CADASTRO = DateTime.Now;

                        db.Usuarios.InsertOnSubmit(usuario);
                        db.SubmitChanges();

                        rwSucesso.Visible = true;
                        //rwmUsuario.RadAlert("Cadastro efetuado com sucesso! Sua senha são os 4 últimos dígitos do seu CPF!", 590, 100, "Atenção", null);
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

        protected void rbSucesso_Click(object sender, EventArgs e)
        {
            rwmUsuario.VisibleOnPageLoad = false;
            rwmUsuario.Visible = false;
            rwUsuarios.Visible = false;
            LimpaEdicao();
            Response.Redirect(@"~\Pages\Login.aspx");
        }
    }
}