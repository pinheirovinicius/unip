using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Bitchain
{
    public partial class Login : Form
    {
        string senha;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbUsuario.Focus();
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {
            ValidaLogin();
        }

        private void tbSenha_TextChanged(object sender, EventArgs e)
        {
            ValidaLogin();
        }

        private void bLogar_Click(object sender, EventArgs e)
        {
            ValidaLogin();

            if (!string.IsNullOrEmpty(tbUsuario.Text) && !string.IsNullOrEmpty(tbSenha.Text))
            {
                using (var db = new DataBaseDataContext())
                {
                    var usuarios = db.Usuarios.Where(u => u.NM_LOGIN == tbUsuario.Text.Trim() && u.NM_SENHA == senha.Trim() && u.FL_HABILITA == 1);

                    if (usuarios.Count() == 0)
                    {
                        var alert = new RadDesktopAlert();
                        alert.ContentText = "\"Usuário\" e/ou \"Senha\" inválido(s)";
                        alert.Show();
                    }
                    else
                    {
                        var usuario = usuarios.Single(u => u.ID_USUARIO == usuarios.First().ID_USUARIO);

                        if (usuario.ID_PERFIL != 3)
                        {
                            usuario.DT_ULTIMO_ACESSO = DateTime.Now;
                            usuario.NR_ULTIMO_ACESSO += 1;

                            db.SubmitChanges();

                            var usuarioLogado = db.UsuarioLogados.FirstOrDefault();

                            if (usuarioLogado == null)
                            {
                                var uL = new UsuarioLogado();

                                uL.ID_USUARIO = usuario.ID_USUARIO;

                                db.UsuarioLogados.InsertOnSubmit(uL);
                            }
                            else
                            {
                                usuarioLogado.ID_USUARIO = usuario.ID_USUARIO;
                            }

                            db.SubmitChanges();

                            tbUsuario.Text = string.Empty;
                            tbSenha.Text = string.Empty;

                            var alert = new RadDesktopAlert();
                            alert.ContentText = $"Bem-vindo {usuario.NM_LOGIN}!";
                            alert.Show();

                            Default telaInicial = new Default();
                            telaInicial.Show();

                            this.Visible = false;
                        }
                        else
                        {
                            var alert = new RadDesktopAlert();
                            alert.ContentText = "Perfil \"Cliente\" por favor, acesse o sistema via web";
                            alert.Show();
                        }
                    }
                }
            }
        }

        private void ValidaLogin()
        {
            if (tbSenha.Visible == true)
                senha = tbSenha.Text;

            if (string.IsNullOrEmpty(tbUsuario.Text) || string.IsNullOrEmpty(tbSenha.Text))
            {
                var alert = new RadDesktopAlert();
                alert.ContentText = "\"Usuário\" e/ou \"Senha\" não informado(s)";
                alert.Show();
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lEsqueciMinhaSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EsqueciSenha esqueciSenha = new EsqueciSenha();
            esqueciSenha.Show();
        }
    }
}
