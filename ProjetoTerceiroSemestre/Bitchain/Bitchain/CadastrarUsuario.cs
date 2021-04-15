using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Bitchain
{
    public partial class CadastrarUsuario : Form
    {
        string aviso;
        int idPerfil;
        public CadastrarUsuario()
        {
            InitializeComponent();
        }

        private void CadastrarUsuario_Load(object sender, EventArgs e)
        {
            using (var db = new DataBaseDataContext())
            {
                SqlConnection sqlConnection = null;

                try
                {
                    sqlConnection = new SqlConnection(@"Application Name=db_Bitchain;Data Source=.\SQLEXPRESS;Initial Catalog=db_Bitchain;Persist Security Info=True;Uid=sa;Pwd=admin1234;Encrypt=False;TrustServerCertificate=True");
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("Select * From Perfil;", sqlConnection);
                    sqlCommand.Connection = sqlConnection;
                    var dataTable = new DataTable();

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(dataTable);
                    }

                    cbPerfil.DisplayMember = "NM_DESCRICAO";
                    cbPerfil.SelectedValue = "ID_PERFIL";
                    cbPerfil.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    aviso = string.Empty;
                    aviso = ex.Message;
                }
            }
        }

        private bool ValidaCadastro()
        {
            var sucesso = false;

            using (var db = new DataBaseDataContext())
            {
                var login = db.Usuarios.Where(u => u.NM_LOGIN == tbLogin.Text).Count();
                var emailEmUso = db.Usuarios.Where(u => u.NM_EMAIL == tbEmail.Text).Count();
                var cpfEmUso = db.Usuarios.Where(u => u.NR_CPF == tbCPF.Text).Count();
                var celularEmUso = db.Usuarios.Where(u => u.NR_CELULAR == tbCelular.Text).Count();

                if (string.IsNullOrEmpty(tbNome.Text) || string.IsNullOrEmpty(tbCPF.Text) ||
                            string.IsNullOrEmpty(tbCelular.Text) || string.IsNullOrEmpty(tbEmail.Text) ||
                            string.IsNullOrEmpty(tbLogin.Text))
                {
                    aviso = string.Empty;
                    aviso = "Existem campos sem preenchimento";
                    sucesso = false;
                }
                else if (login > 0)
                {
                    aviso = string.Empty;
                    aviso = "Login duplicado";
                    sucesso = false;
                }
                else if (emailEmUso > 0)
                {
                    aviso = string.Empty;
                    aviso = "E-mail duplicado";
                    sucesso = false;
                }
                else if (cpfEmUso > 0)
                {
                    aviso = string.Empty;
                    aviso = "CPF duplicado";
                    sucesso = false;
                }
                else if (celularEmUso > 0)
                {
                    aviso = string.Empty;
                    aviso = "Celular duplicado";
                    sucesso = false;
                }
                else if (tbNome.Text.Length <= 3)
                {
                    aviso = string.Empty;
                    aviso = "Nome inexistente";
                    sucesso = false;
                }
                else if (tbCPF.Text.Length != 11)
                {
                    aviso = string.Empty;
                    aviso = "número de CPF inválido";
                    sucesso = false;
                }
                else if (!string.IsNullOrEmpty(tbEmail.Text) && (!tbEmail.Text.Contains("@") || !tbEmail.Text.Contains(".com") || tbEmail.Text.Length < 6))
                {
                    aviso = string.Empty;
                    aviso = "endereço de e-mail inválido";
                    sucesso = false;
                }
                else if (tbCelular.Text.Length != 11)
                {
                    aviso = string.Empty;
                    aviso = "número de celular inválido";
                    sucesso = false;
                }
                else
                {
                    sucesso = true;
                }
            }

            return sucesso;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            Close();

            Default telaInicial = new Default();
            telaInicial.Visible = true;
        }

        private void bCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidaCadastro())
            {
                try
                {
                    using (var db = new DataBaseDataContext())
                    {
                        var u = new Usuario();

                        var idPerfil = db.Perfils.Single(p => p.NM_DESCRICAO == cbPerfil.Text).ID_PERFIL;

                        u.NM_NOME = tbNome.Text.ToUpper();
                        u.NR_CPF = tbCPF.Text;
                        u.NR_TELEFONE = tbTelefone.Text;
                        u.NR_CELULAR = tbCelular.Text;
                        u.NM_EMAIL = tbEmail.Text.ToLower();
                        u.NM_LOGIN = tbLogin.Text.ToUpper();
                        u.NM_SENHA = tbCPF.Text.Substring(7, 4);
                        u.ID_PERFIL = idPerfil;
                        u.FL_HABILITA = 1;
                        u.FL_TROCA_SENHA = 0;
                        u.NR_ULTIMO_ACESSO = 0;
                        u.DT_CADASTRO = DateTime.Now;

                        db.Usuarios.InsertOnSubmit(u);
                        db.SubmitChanges();

                        Close();

                        var alert = new RadDesktopAlert();
                        alert.ContentText = $"Cadastro efetuado com sucesso! Sua senha são os 4 últimos dígitos do seu CPF";
                        alert.Show();
                    }
                }
                catch (Exception ex)
                {
                    var alert = new RadDesktopAlert();
                    alert.ContentText = $"Erro: {ex}";
                    alert.Show();
                }
            }
            else
            {
                var alert = new RadDesktopAlert();
                alert.ContentText = $"{aviso}";
                alert.Show();
            }
        }
    }
}
