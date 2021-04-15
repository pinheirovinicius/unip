using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitchainWeb.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.rlCriaConta.Text = "<html><size=10><a href=CriaConta.aspx>Crie uma conta</a>";
        }

        protected void rbLogIn_Click1(object sender, EventArgs e)
        {
            if (VerificaLogin(rtbLogIn.Text, rtbSenha.Text))
            {
                using (var db = new BaseDataContext())
                {
                    var usuarios = db.Usuarios.Where(u => u.NM_LOGIN == rtbLogIn.Text.Trim() && u.NM_SENHA == rtbSenha.Text.Trim());

                    if (usuarios.Count() > 0)
                    {
                        var usuario = usuarios.Single();

                        Session["IDUsuario"] = usuario.ID_USUARIO;
                        Session["Usuario_DT_UA"] = usuario.DT_ULTIMO_ACESSO;
                        Session["UsuarioLogin"] = usuario.NM_LOGIN;
                        Session["Perfil"] = usuario.ID_PERFIL;
                        
                        Response.Redirect(@"~\Pages\PaginaInicial.aspx");

                        usuario = null;
                    }
                    usuarios = null;
                }
            }
            else
                rwmLogin.RadAlert("Usuário não autorizado.<Br />Entre em contato com a área de suporte.", 400, 160, "Erro no acesso", null);
        }

        private bool VerificaLogin(string Login, string Senha)
        {
            var sucesso = false;

            try
            {
                if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Senha))
                {
                    using (var db = new BaseDataContext())
                    {
                        var usuarios = db.Usuarios.Where(u => u.NM_LOGIN == Login.Trim() && u.NM_SENHA == Senha.Trim() && u.FL_HABILITA == 1);

                        if (usuarios.Count() > 0)
                            sucesso = true;

                        usuarios = null;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return sucesso;
        }
    }
}