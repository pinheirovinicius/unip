using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Bitchain
{
    public partial class EsqueciSenha : Form
    {
        int idUsuario;
        public EsqueciSenha()
        {
            InitializeComponent();
        }

        private void EsqueciSenha_Load(object sender, EventArgs e)
        {
            lLogin.Visible = false;
            bSim.Visible = false;
            bNao.Visible = false;
        }

        private void bAvancar_Click(object sender, EventArgs e)
        {
            using (var db = new DataBaseDataContext())
            {
                var usuarios = db.Usuarios.Where(u => u.NR_CPF == tbCPF.Text.Trim() && u.NM_EMAIL == tbEmail.Text.Trim());
                lLogin.Visible = true;

                if (usuarios.Count() > 0)
                {
                    var usuario = usuarios.FirstOrDefault();

                    idUsuario = usuario.ID_USUARIO;
                    lLogin.Text = "Encontramos o seu cadastro no sistema, deseja redefinir o seu login e/ou senha?";
                    bSim.Visible = true;
                    bNao.Visible = true;
                }
                else
                {
                    lLogin.Text = "usuário não encontrado";

                    var alert = new RadDesktopAlert();
                    alert.ContentText = "usuário não encontrado";
                    alert.Show();
                }
            }
        }

        private void bSim_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DataBaseDataContext())
                {
                    var usuario = db.Usuarios.Single(u => u.ID_USUARIO == idUsuario);

                    usuario.FL_TROCA_SENHA = 1;

                    db.SubmitChanges();

                    var alert = new RadDesktopAlert();
                    alert.ContentText = "Acione o administrador do sistema para redefinir seu login e/ou senha";
                    alert.Show();

                    this.Close();
                }
            }
            catch(Exception ex)
            {
                var alert = new RadDesktopAlert();
                alert.ContentText = $"Erro: {ex.Message}";
                alert.Show();
            }            
        }

        private void bNao_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
