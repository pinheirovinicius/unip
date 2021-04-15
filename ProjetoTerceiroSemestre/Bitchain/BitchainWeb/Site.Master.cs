using System;
using System.IO;
using System.Linq;
using System.Web;

namespace SegOn
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public bool MenuVisible
        {
            get
            {
                return rmSVG.Visible;
            }
            set
            {
                rmSVG.Visible = value;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var idUsuario = int.Parse((Session["IDUsuario"] ?? "0").ToString()); ;

            if (idUsuario != 0)
            {
                using (var db = new BitchainWeb.BaseDataContext())
                {
                    var user = db.Usuarios.Single(u => u.ID_USUARIO == idUsuario);

                    if (!Request.Url.ToString().ToUpper().Contains("LOCALHOST"))
                    {
                        var page = Request.Url.LocalPath.ToUpper();
                        page = page.Substring(1, page.Length - 1);

                        if (!user.Menu_Web_Permissaos.Any(m => (m.Menu_Web.NM_URL ?? string.Empty).ToUpper().Contains(page)))
                        {
                            RedicionaLogin();
                        }
                    }

                    lTitulo.Text = $"Olá {user.NM_NOME}!";
                    lTitulo2.Text = "Seja bem vindo(a)";
                    lSubTituloR.Text = $"Último acesso foi em {user.DT_ULTIMO_ACESSO}. Acesso Nº: {user.NR_ULTIMO_ACESSO}";
                }
            }
            else
            {
                RedicionaLogin();
            }

            lSubTituloL.Text = DateTime.Now.ToString(@"dddd, dd \de MMMM \de yyyy - HH:mm").ToUpperFirstLetter();
        }

        private void RedicionaLogin()
        {
            lTitulo.Text = "Seja bem vindo(a)!";
            lTitulo2.Text = string.Empty;
            lSubTituloR.Text = string.Empty;
            if (!Page.AppRelativeVirtualPath.ToUpper().Contains("LOGIN") && !Page.AppRelativeVirtualPath.ToUpper().Contains("DPS"))
                Response.Redirect(@"~\Login.aspx");
        }
    }

    public static class StringExtension
    {
        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            char[] letters = source.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }
    }
}
