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
    public partial class ContaUsuario : Form
    {
        int idPerfilLogado;
        int idUsuario;
        bool alterarSenha;
        string aviso;

        public ContaUsuario()
        {
            InitializeComponent();
        }

        #region Ações
        private void ContaUsuario_Load(object sender, EventArgs e)
        {
            lConfirmaSenha.Visible = false;
            tbConfirmaSenha.Visible = false;
            alterarSenha = false;

            using (var db = new DataBaseDataContext())
            {
                var uL = db.Usuarios.FirstOrDefault(u => u.ID_USUARIO == db.UsuarioLogados.FirstOrDefault().ID_USUARIO);

                idPerfilLogado = uL.ID_PERFIL ?? 0;

                if (uL.ID_PERFIL == 1)
                {
                    bNovaPesquisa.Visible = true;
                    bPesquisar.Visible = true;
                    bEditar.Enabled = false;
                    cbHabilitado.Visible = true;
                }
                else
                {
                    idUsuario = uL.ID_USUARIO;
                    bNovaPesquisa.Visible = false;
                    bPesquisar.Visible = false;
                    PreencheCampos();
                }                
            }
        }

        private void PreencheCampos()
        {
            if (idUsuario > 0)
            {
                using (var db = new DataBaseDataContext())
                {
                    var usuario = db.Usuarios.SingleOrDefault(u => u.ID_USUARIO == idUsuario);
                    var perfil = db.Perfils.SingleOrDefault(p => p.ID_PERFIL == usuario.ID_PERFIL);

                    tbNome.Text = usuario.NM_NOME.ToUpper();
                    tbCPF.Text = usuario.NR_CPF;
                    tbEmail.Text = usuario.NM_EMAIL.ToLower();
                    tbTelefone.Text = usuario.NR_TELEFONE;
                    tbCelular.Text = usuario.NR_CELULAR;
                    tbPerfil.Text = perfil.NM_DESCRICAO;
                    tbLogin.Text = usuario.NM_LOGIN.ToUpper();
                    cbHabilitado.Checked = usuario.FL_HABILITA == 1 ? true : false;

                    if (usuario.FL_HABILITA == 1)
                    {
                        lTexto.Visible = (usuario.FL_TROCA_SENHA ?? 0) == 1 ? true : false;
                        bSim.Visible = (usuario.FL_TROCA_SENHA ?? 0) == 1 ? true : false;
                        bNao.Visible = (usuario.FL_TROCA_SENHA ?? 0) == 1 ? true : false;
                        bEditar.Enabled = (usuario.FL_TROCA_SENHA ?? 0) == 1 ? false : true;
                    }
                }
            }
        }

        private void LimpaCampos()
        {
            idUsuario = 0;

            tbNome.Text = string.Empty;
            tbCPF.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbTelefone.Text = string.Empty;
            tbCelular.Text = string.Empty;
            tbPerfil.Text = string.Empty;
            tbLogin.Text = string.Empty;
            tbSenha.Text = string.Empty;
            tbConfirmaSenha.Text = string.Empty;
            cbHabilitado.Checked = false;
            lSenha.Text = "Senha";
            bEditar.Text = "Editar";
            
            tbNome.Enabled = true;
            tbCPF.Enabled = true;
            tbEmail.Enabled = true;
            tbLogin.Enabled = true;
            bPesquisar.Enabled = true;
            cbHabilitado.Enabled = true;

            tbTelefone.Enabled = false;
            tbCelular.Enabled = false;
            tbSenha.Enabled = false;
            tbConfirmaSenha.Visible = false;
            lConfirmaSenha.Visible = false;
            bEditar.Enabled = false;
        }

        private void SalvarAlteracao(bool AlteraSenha)
        {
            //aviso = string.Empty;

            using (var db = new DataBaseDataContext())
            {
                var usuario = db.Usuarios.Single(u => u.ID_USUARIO == idUsuario);
                var usuarioLogado = db.Usuarios.Single(uL => uL.ID_USUARIO == db.UsuarioLogados.FirstOrDefault().ID_USUARIO);

                if (alterarSenha)
                {
                    if (!string.IsNullOrEmpty(tbLogin.Text))
                        usuario.NM_LOGIN = tbLogin.Text.ToUpper();
                    if (!string.IsNullOrEmpty(tbSenha.Text))
                        usuario.NM_SENHA = tbSenha.Text.Trim();
                    usuario.FL_TROCA_SENHA = 0;
                    usuario.DT_ALTERACAO = DateTime.Now;
                    usuario.NM_USUARIO_ALTERACAO = usuarioLogado.NM_LOGIN;

                    db.SubmitChanges();

                    tbLogin.Enabled = false;
                    tbSenha.Enabled = false;
                    cbHabilitado.Enabled = false;
                    lConfirmaSenha.Visible = false;
                    tbConfirmaSenha.Visible = false;
                    bEditar.Text = "Editar";
                    lSenha.Text = "Senha";

                    aviso = "Login e/ou Senha alterado(s) com sucesso";
                    DisparaAviso();
                }
                else if (ValidaEdicao())
                {
                    usuario.NM_NOME = tbNome.Text.ToUpper().Trim();
                    usuario.NR_CPF = tbCPF.Text.Trim();
                    usuario.NM_EMAIL = tbEmail.Text.ToLower().Trim();
                    usuario.NR_TELEFONE = tbTelefone.Text.Trim();
                    usuario.NR_CELULAR = tbCelular.Text.Trim();
                    if (!string.IsNullOrEmpty(tbLogin.Text))
                        usuario.NM_LOGIN = tbLogin.Text.ToUpper();
                    if (!string.IsNullOrEmpty(tbSenha.Text))
                        usuario.NM_SENHA = tbSenha.Text.Trim();
                    usuario.FL_HABILITA = (byte) (cbHabilitado.Checked == true ? 1 : 0);
                    usuario.DT_ALTERACAO = DateTime.Now;
                    usuario.NM_USUARIO_ALTERACAO = usuarioLogado.NM_LOGIN;

                    db.SubmitChanges();

                    tbNome.Enabled = false;
                    tbCPF.Enabled = false;
                    tbEmail.Enabled = false;
                    tbTelefone.Enabled = false;
                    tbCelular.Enabled = false;
                    tbLogin.Enabled = false;
                    tbSenha.Enabled = false;
                    cbHabilitado.Enabled = false;

                    lConfirmaSenha.Visible = false;
                    tbConfirmaSenha.Visible = false;
                    
                    bEditar.Text = "Editar";
                    lSenha.Text = "Senha";


                    aviso = "Dados alterados com sucesso";
                    DisparaAviso();
                }
                else
                {
                    DisparaAviso();
                }
            }
        }

        private void PesquisaUsuario()
        {
            if (ValidaPesquisa())
            {
                using (var db = new DataBaseDataContext())
                {
                    var usuario = db.Usuarios.Where(u => (!string.IsNullOrEmpty(tbNome.Text) && u.NM_NOME.Contains(tbNome.Text.Trim())) ||
                                                         (!string.IsNullOrEmpty(tbCPF.Text) && u.NR_CPF == tbCPF.Text.Trim()) ||
                                                         (!string.IsNullOrEmpty(tbEmail.Text) && u.NM_EMAIL == tbEmail.Text.Trim()) ||
                                                         (!string.IsNullOrEmpty(tbLogin.Text) && u.NM_LOGIN == tbLogin.Text.Trim())
                                                   ).FirstOrDefault();

                    if (usuario != null)
                    {
                        idUsuario = usuario.ID_USUARIO;
                        bEditar.Enabled = true;
                        PreencheCampos();
                    }
                    else
                    {
                        aviso = "usuário não encontrado";
                        DisparaAviso();
                    }
                }
            }
            else
            {
                DisparaAviso();
            }
        }

        private void DisparaAviso()
        {
            var alert = new RadDesktopAlert();
            alert.ContentText = $"{aviso}";
            alert.Show();
        }

        private bool ValidaPesquisa()
        {
            var sucesso = false;

            try
            {
                if (!string.IsNullOrEmpty(tbNome.Text) || !string.IsNullOrEmpty(tbCPF.Text) || !string.IsNullOrEmpty(tbEmail.Text) || !string.IsNullOrEmpty(tbLogin.Text))
                {
                    if (!string.IsNullOrEmpty(tbEmail.Text) && (!tbEmail.Text.Contains("@") || !tbEmail.Text.Contains(".com") || tbEmail.Text.Length < 6))
                        aviso = "E-mail inválido";
                    else
                        sucesso = true;
                }
                else
                    aviso = $"Informe o Nome ou CPF ou E-mail ou Login";
            }
            catch(Exception ex)
            {
                aviso = $"{ex.Message}";
            }

            return sucesso;
        }

        private bool ValidaEdicao()
        {
            var sucesso = false;

            if (ValidaPesquisa())
            {
                try
                {
                    aviso = string.Empty;

                    using (var db = new DataBaseDataContext())
                    {
                        var loginEmUso = db.Usuarios.Where(u => u.NM_LOGIN == tbLogin.Text && u.ID_USUARIO != idUsuario).Count();
                        var emailEmUso = db.Usuarios.Where(u => u.NM_EMAIL == tbEmail.Text && u.ID_USUARIO != idUsuario).Count();
                        var cpfEmUso = db.Usuarios.Where(u => u.NR_CPF == tbCPF.Text && u.ID_USUARIO != idUsuario).Count();
                        var celularEmUso = db.Usuarios.Where(u => u.NR_CELULAR == tbCelular.Text && u.ID_USUARIO != idUsuario).Count();

                        if (string.IsNullOrEmpty(tbNome.Text) || string.IsNullOrEmpty(tbCPF.Text) || string.IsNullOrEmpty(tbEmail.Text) ||
                            string.IsNullOrEmpty(tbCelular.Text) || string.IsNullOrEmpty(tbLogin.Text) || (string.IsNullOrEmpty(tbSenha.Text) && idPerfilLogado != 1)
                           )
                            aviso = "Preencha todos os campos";
                        if (loginEmUso > 0)
                            aviso = "Login duplicado";
                        if (emailEmUso > 0)
                            aviso = "E-mail duplicado";
                        if (cpfEmUso > 0)
                            aviso = "CPF duplicado";
                        if (celularEmUso > 0)
                            aviso = "Celular duplicado";
                        if (tbNome.Text.Length <= 3)
                            aviso = "Nome inexistente";
                        if (tbCelular.Text.Length != 11)
                            aviso = "número de celular inválido";
                        if (aviso == string.Empty)
                            sucesso = true;
                    }
                }
                catch (Exception ex)
                {
                    aviso = $"{ex.Message}";
                }
            }
            else
            {
                DisparaAviso();
            }

            if (sucesso)
            {
                if (!ValidaSenha())
                    sucesso = false;
            }

            return sucesso;
        }

        private bool ValidaSenha()
        {
            var sucesso = false;

            using (var db = new DataBaseDataContext())
            {
                var usuario = db.Usuarios.Single(u => u.ID_USUARIO == idUsuario);

                if (tbSenha.Text == tbConfirmaSenha.Text)
                {
                    if (idPerfilLogado != 1)
                    {
                        if (tbSenha.Text == usuario.NM_SENHA)
                            sucesso = true;
                        else
                            aviso = "senha incorreta";
                    }
                    else if (idPerfilLogado == 1)
                    {
                        if (idUsuario == db.UsuarioLogados.FirstOrDefault().ID_USUARIO)
                        {
                            if (tbSenha.Text == usuario.NM_SENHA)
                                sucesso = true;
                            else
                                aviso = "senhas não conferem";
                        }
                        else
                            sucesso = true;
                    }

                    if (alterarSenha)
                        bEditar.Text = "Alterar";
                }
                else
                    aviso = "senhas não conferem";
            }

            return sucesso;
        }

        private bool ValidaAlteraSenha()
        {
            var sucesso = false;

            using (var db = new DataBaseDataContext())
            {
                var usuario = db.Usuarios.Single(u => u.ID_USUARIO == idUsuario);
                var loginEmUso = db.Usuarios.Where(u => u.NM_LOGIN == tbLogin.Text && u.ID_USUARIO != idUsuario).Count();

                if (loginEmUso > 0)
                    aviso = "Login duplicado";
                if (tbSenha.Text != tbConfirmaSenha.Text)
                    aviso = "senhas não conferem";
                else
                    sucesso = true;
            }

            return sucesso;
        }
        #endregion

        #region Botões
        private void bEditar_Click(object sender, EventArgs e)
        {
            if (bEditar.Text == "Editar")
            {
                bEditar.Text = "Salvar";
                
                bPesquisar.Enabled = false;
                bNovaPesquisa.Enabled = false;
                tbNome.Enabled = true;
                tbCPF.Enabled = true;
                tbEmail.Enabled = true;
                tbTelefone.Enabled = true;
                tbCelular.Enabled = true;
                tbSenha.Enabled = true;
                tbConfirmaSenha.Enabled = true;
                cbHabilitado.Enabled = idPerfilLogado == 1 ? true : false;
                
                lConfirmaSenha.Visible = true;
                tbConfirmaSenha.Visible = true;

                tbSenha.Text = string.Empty;
                tbConfirmaSenha.Text = string.Empty;
            }
            else if (bEditar.Text == "Atualizar")
            {
                aviso = string.Empty;

                if (!ValidaSenha())
                    DisparaAviso();
                else
                {
                    lSenha.Text = "Nova senha";
                    tbSenha.Text = string.Empty;
                    tbConfirmaSenha.Text = string.Empty;
                }
            }
            else if (bEditar.Text == "Alterar")
            {
                if (ValidaAlteraSenha())
                    SalvarAlteracao(true);
                else
                    DisparaAviso();
            }
            else
            {
                SalvarAlteracao(false);
                bNovaPesquisa.Enabled = true;
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            if (bEditar.Text == "Salvar" && idPerfilLogado == 1)
            {
                LimpaCampos();
                bPesquisar.Enabled = true;
                bNovaPesquisa.Enabled = true;
                bEditar.Enabled = false;

            }
            else if (bEditar.Text == "Atualizar" || bEditar.Text == "Alterar")
            {
                LimpaCampos();
            }
            else
            {
                Close();

                Default telaInicial = new Default();
                telaInicial.Visible = true;
            }
        }

        private void bNovaPesquisa_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            bEditar.Enabled = false;
            bNovaPesquisa.Enabled = false;
            bPesquisar.Enabled = true;

            lTexto.Visible = false;
            bSim.Visible = false;
            bNao.Visible = false;
        }

        private void bPesquisar_Click(object sender, EventArgs e)
        {
            bNovaPesquisa.Enabled = true;
            PesquisaUsuario();
        }

        private void bNao_Click(object sender, EventArgs e)
        {
            lTexto.Visible = false;
            bSim.Visible = false;
            bNao.Visible = false;
            
            alterarSenha = false;

            bEditar.Enabled = true;
        }

        private void bSim_Click(object sender, EventArgs e)
        {
            alterarSenha = true;
            lSenha.Text = "Senha atual";
            bEditar.Text = "Atualizar";

            lTexto.Visible = false;
            bSim.Visible = false;
            bNao.Visible = false;
            lConfirmaSenha.Visible = true;
            tbConfirmaSenha.Visible = true;

            tbSenha.Enabled = true;
            tbConfirmaSenha.Enabled = true;
            bEditar.Enabled = true;
            bPesquisar.Enabled = false;
            bNovaPesquisa.Enabled = false;
            tbNome.Enabled = false;
            tbCPF.Enabled = false;
            tbEmail.Enabled = false;
        }
        #endregion
    }
}
