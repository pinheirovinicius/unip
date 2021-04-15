namespace Bitchain
{
    partial class ContaUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.bNao = new System.Windows.Forms.Button();
            this.bSim = new System.Windows.Forms.Button();
            this.lTexto = new System.Windows.Forms.Label();
            this.tbConfirmaSenha = new System.Windows.Forms.TextBox();
            this.lConfirmaSenha = new System.Windows.Forms.Label();
            this.bPesquisar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bEditar = new System.Windows.Forms.Button();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPerfil = new System.Windows.Forms.TextBox();
            this.tbCelular = new System.Windows.Forms.TextBox();
            this.tbTelefone = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbCPF = new System.Windows.Forms.TextBox();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.lSenha = new System.Windows.Forms.Label();
            this.lLogin = new System.Windows.Forms.Label();
            this.lPerfil = new System.Windows.Forms.Label();
            this.lCelular = new System.Windows.Forms.Label();
            this.lTelefone = new System.Windows.Forms.Label();
            this.lEmail = new System.Windows.Forms.Label();
            this.lCPF = new System.Windows.Forms.Label();
            this.lNome = new System.Windows.Forms.Label();
            this.bNovaPesquisa = new System.Windows.Forms.Button();
            this.cbHabilitado = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbHabilitado);
            this.panel1.Controls.Add(this.bNao);
            this.panel1.Controls.Add(this.bSim);
            this.panel1.Controls.Add(this.lTexto);
            this.panel1.Controls.Add(this.tbConfirmaSenha);
            this.panel1.Controls.Add(this.lConfirmaSenha);
            this.panel1.Controls.Add(this.bPesquisar);
            this.panel1.Controls.Add(this.bCancelar);
            this.panel1.Controls.Add(this.bEditar);
            this.panel1.Controls.Add(this.tbSenha);
            this.panel1.Controls.Add(this.tbLogin);
            this.panel1.Controls.Add(this.tbPerfil);
            this.panel1.Controls.Add(this.tbCelular);
            this.panel1.Controls.Add(this.tbTelefone);
            this.panel1.Controls.Add(this.tbEmail);
            this.panel1.Controls.Add(this.tbCPF);
            this.panel1.Controls.Add(this.tbNome);
            this.panel1.Controls.Add(this.lSenha);
            this.panel1.Controls.Add(this.lLogin);
            this.panel1.Controls.Add(this.lPerfil);
            this.panel1.Controls.Add(this.lCelular);
            this.panel1.Controls.Add(this.lTelefone);
            this.panel1.Controls.Add(this.lEmail);
            this.panel1.Controls.Add(this.lCPF);
            this.panel1.Controls.Add(this.lNome);
            this.panel1.Location = new System.Drawing.Point(13, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 336);
            this.panel1.TabIndex = 0;
            // 
            // bNao
            // 
            this.bNao.Location = new System.Drawing.Point(433, 252);
            this.bNao.Name = "bNao";
            this.bNao.Size = new System.Drawing.Size(75, 23);
            this.bNao.TabIndex = 17;
            this.bNao.Text = "Não";
            this.bNao.UseVisualStyleBackColor = true;
            this.bNao.Visible = false;
            this.bNao.Click += new System.EventHandler(this.bNao_Click);
            // 
            // bSim
            // 
            this.bSim.Location = new System.Drawing.Point(352, 252);
            this.bSim.Name = "bSim";
            this.bSim.Size = new System.Drawing.Size(75, 23);
            this.bSim.TabIndex = 16;
            this.bSim.Text = "Sim";
            this.bSim.UseVisualStyleBackColor = true;
            this.bSim.Visible = false;
            this.bSim.Click += new System.EventHandler(this.bSim_Click);
            // 
            // lTexto
            // 
            this.lTexto.AutoSize = true;
            this.lTexto.ForeColor = System.Drawing.Color.Red;
            this.lTexto.Location = new System.Drawing.Point(3, 257);
            this.lTexto.Name = "lTexto";
            this.lTexto.Size = new System.Drawing.Size(336, 13);
            this.lTexto.TabIndex = 15;
            this.lTexto.Text = "Seu usuário está habilitado para alterar a senha, deseja alterar agora?";
            this.lTexto.Visible = false;
            // 
            // tbConfirmaSenha
            // 
            this.tbConfirmaSenha.Enabled = false;
            this.tbConfirmaSenha.Location = new System.Drawing.Point(352, 220);
            this.tbConfirmaSenha.MaxLength = 11;
            this.tbConfirmaSenha.Name = "tbConfirmaSenha";
            this.tbConfirmaSenha.PasswordChar = '*';
            this.tbConfirmaSenha.Size = new System.Drawing.Size(177, 20);
            this.tbConfirmaSenha.TabIndex = 13;
            // 
            // lConfirmaSenha
            // 
            this.lConfirmaSenha.AutoSize = true;
            this.lConfirmaSenha.Location = new System.Drawing.Point(249, 223);
            this.lConfirmaSenha.Name = "lConfirmaSenha";
            this.lConfirmaSenha.Size = new System.Drawing.Size(100, 13);
            this.lConfirmaSenha.TabIndex = 12;
            this.lConfirmaSenha.Text = "Confirme sua senha";
            // 
            // bPesquisar
            // 
            this.bPesquisar.Location = new System.Drawing.Point(107, 308);
            this.bPesquisar.Name = "bPesquisar";
            this.bPesquisar.Size = new System.Drawing.Size(75, 23);
            this.bPesquisar.TabIndex = 12;
            this.bPesquisar.Text = "Pesquisar";
            this.bPesquisar.UseVisualStyleBackColor = true;
            this.bPesquisar.Click += new System.EventHandler(this.bPesquisar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(269, 308);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 14;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bEditar
            // 
            this.bEditar.Location = new System.Drawing.Point(188, 308);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(75, 23);
            this.bEditar.TabIndex = 13;
            this.bEditar.Text = "Editar";
            this.bEditar.UseVisualStyleBackColor = true;
            this.bEditar.Click += new System.EventHandler(this.bEditar_Click);
            // 
            // tbSenha
            // 
            this.tbSenha.Enabled = false;
            this.tbSenha.Location = new System.Drawing.Point(66, 220);
            this.tbSenha.MaxLength = 10;
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.PasswordChar = '*';
            this.tbSenha.Size = new System.Drawing.Size(177, 20);
            this.tbSenha.TabIndex = 8;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(66, 188);
            this.tbLogin.MaxLength = 50;
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(249, 20);
            this.tbLogin.TabIndex = 6;
            // 
            // tbPerfil
            // 
            this.tbPerfil.Enabled = false;
            this.tbPerfil.Location = new System.Drawing.Point(66, 158);
            this.tbPerfil.MaxLength = 50;
            this.tbPerfil.Name = "tbPerfil";
            this.tbPerfil.Size = new System.Drawing.Size(112, 20);
            this.tbPerfil.TabIndex = 5;
            // 
            // tbCelular
            // 
            this.tbCelular.Enabled = false;
            this.tbCelular.Location = new System.Drawing.Point(66, 128);
            this.tbCelular.MaxLength = 11;
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(177, 20);
            this.tbCelular.TabIndex = 4;
            // 
            // tbTelefone
            // 
            this.tbTelefone.Enabled = false;
            this.tbTelefone.Location = new System.Drawing.Point(66, 98);
            this.tbTelefone.MaxLength = 11;
            this.tbTelefone.Name = "tbTelefone";
            this.tbTelefone.Size = new System.Drawing.Size(177, 20);
            this.tbTelefone.TabIndex = 3;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(66, 68);
            this.tbEmail.MaxLength = 100;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(449, 20);
            this.tbEmail.TabIndex = 2;
            // 
            // tbCPF
            // 
            this.tbCPF.Location = new System.Drawing.Point(66, 38);
            this.tbCPF.MaxLength = 11;
            this.tbCPF.Name = "tbCPF";
            this.tbCPF.Size = new System.Drawing.Size(177, 20);
            this.tbCPF.TabIndex = 1;
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(66, 8);
            this.tbNome.MaxLength = 100;
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(449, 20);
            this.tbNome.TabIndex = 0;
            // 
            // lSenha
            // 
            this.lSenha.AutoSize = true;
            this.lSenha.Location = new System.Drawing.Point(3, 223);
            this.lSenha.Name = "lSenha";
            this.lSenha.Size = new System.Drawing.Size(38, 13);
            this.lSenha.TabIndex = 7;
            this.lSenha.Text = "Senha";
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(3, 191);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(33, 13);
            this.lLogin.TabIndex = 6;
            this.lLogin.Text = "Login";
            // 
            // lPerfil
            // 
            this.lPerfil.AutoSize = true;
            this.lPerfil.Location = new System.Drawing.Point(3, 161);
            this.lPerfil.Name = "lPerfil";
            this.lPerfil.Size = new System.Drawing.Size(30, 13);
            this.lPerfil.TabIndex = 5;
            this.lPerfil.Text = "Perfil";
            // 
            // lCelular
            // 
            this.lCelular.AutoSize = true;
            this.lCelular.Location = new System.Drawing.Point(3, 131);
            this.lCelular.Name = "lCelular";
            this.lCelular.Size = new System.Drawing.Size(39, 13);
            this.lCelular.TabIndex = 4;
            this.lCelular.Text = "Celular";
            // 
            // lTelefone
            // 
            this.lTelefone.AutoSize = true;
            this.lTelefone.Location = new System.Drawing.Point(3, 101);
            this.lTelefone.Name = "lTelefone";
            this.lTelefone.Size = new System.Drawing.Size(49, 13);
            this.lTelefone.TabIndex = 3;
            this.lTelefone.Text = "Telefone";
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(3, 71);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(35, 13);
            this.lEmail.TabIndex = 2;
            this.lEmail.Text = "E-mail";
            // 
            // lCPF
            // 
            this.lCPF.AutoSize = true;
            this.lCPF.Location = new System.Drawing.Point(3, 41);
            this.lCPF.Name = "lCPF";
            this.lCPF.Size = new System.Drawing.Size(27, 13);
            this.lCPF.TabIndex = 1;
            this.lCPF.Text = "CPF";
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Location = new System.Drawing.Point(3, 11);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(35, 13);
            this.lNome.TabIndex = 0;
            this.lNome.Text = "Nome";
            // 
            // bNovaPesquisa
            // 
            this.bNovaPesquisa.Enabled = false;
            this.bNovaPesquisa.Location = new System.Drawing.Point(435, 11);
            this.bNovaPesquisa.Name = "bNovaPesquisa";
            this.bNovaPesquisa.Size = new System.Drawing.Size(110, 23);
            this.bNovaPesquisa.TabIndex = 1;
            this.bNovaPesquisa.Text = "Nova Pesquisa";
            this.bNovaPesquisa.UseVisualStyleBackColor = true;
            this.bNovaPesquisa.Click += new System.EventHandler(this.bNovaPesquisa_Click);
            // 
            // cbHabilitado
            // 
            this.cbHabilitado.AutoSize = true;
            this.cbHabilitado.Enabled = false;
            this.cbHabilitado.Location = new System.Drawing.Point(374, 190);
            this.cbHabilitado.Name = "cbHabilitado";
            this.cbHabilitado.Size = new System.Drawing.Size(73, 17);
            this.cbHabilitado.TabIndex = 19;
            this.cbHabilitado.Text = "Habilitado";
            this.cbHabilitado.UseVisualStyleBackColor = true;
            this.cbHabilitado.Visible = false;
            // 
            // ContaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 388);
            this.Controls.Add(this.bNovaPesquisa);
            this.Controls.Add(this.panel1);
            this.Name = "ContaUsuario";
            this.Text = "Usuário";
            this.Load += new System.EventHandler(this.ContaUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bEditar;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPerfil;
        private System.Windows.Forms.TextBox tbCelular;
        private System.Windows.Forms.TextBox tbTelefone;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbCPF;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.Label lSenha;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.Label lPerfil;
        private System.Windows.Forms.Label lCelular;
        private System.Windows.Forms.Label lTelefone;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.Label lCPF;
        private System.Windows.Forms.Label lNome;
        private System.Windows.Forms.Button bNovaPesquisa;
        private System.Windows.Forms.Button bPesquisar;
        private System.Windows.Forms.TextBox tbConfirmaSenha;
        private System.Windows.Forms.Label lConfirmaSenha;
        private System.Windows.Forms.Label lTexto;
        private System.Windows.Forms.Button bNao;
        private System.Windows.Forms.Button bSim;
        private System.Windows.Forms.CheckBox cbHabilitado;
    }
}