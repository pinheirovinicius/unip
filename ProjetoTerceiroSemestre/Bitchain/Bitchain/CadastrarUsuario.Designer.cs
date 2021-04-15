namespace Bitchain
{
    partial class CadastrarUsuario
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
            this.lNome = new System.Windows.Forms.Label();
            this.lCPF = new System.Windows.Forms.Label();
            this.lEmail = new System.Windows.Forms.Label();
            this.lTelefone = new System.Windows.Forms.Label();
            this.lCelular = new System.Windows.Forms.Label();
            this.lPerfil = new System.Windows.Forms.Label();
            this.lLogin = new System.Windows.Forms.Label();
            this.pPanel1 = new System.Windows.Forms.Panel();
            this.cbPerfil = new System.Windows.Forms.ComboBox();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bCadastrar = new System.Windows.Forms.Button();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.tbCPF = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbTelefone = new System.Windows.Forms.TextBox();
            this.tbCelular = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.pPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lNome
            // 
            this.lNome.AutoSize = true;
            this.lNome.Location = new System.Drawing.Point(18, 23);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(35, 13);
            this.lNome.TabIndex = 0;
            this.lNome.Text = "Nome";
            // 
            // lCPF
            // 
            this.lCPF.AutoSize = true;
            this.lCPF.Location = new System.Drawing.Point(18, 53);
            this.lCPF.Name = "lCPF";
            this.lCPF.Size = new System.Drawing.Size(27, 13);
            this.lCPF.TabIndex = 1;
            this.lCPF.Text = "CPF";
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(18, 83);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(35, 13);
            this.lEmail.TabIndex = 2;
            this.lEmail.Text = "E-mail";
            // 
            // lTelefone
            // 
            this.lTelefone.AutoSize = true;
            this.lTelefone.Location = new System.Drawing.Point(18, 113);
            this.lTelefone.Name = "lTelefone";
            this.lTelefone.Size = new System.Drawing.Size(49, 13);
            this.lTelefone.TabIndex = 3;
            this.lTelefone.Text = "Telefone";
            // 
            // lCelular
            // 
            this.lCelular.AutoSize = true;
            this.lCelular.Location = new System.Drawing.Point(18, 143);
            this.lCelular.Name = "lCelular";
            this.lCelular.Size = new System.Drawing.Size(39, 13);
            this.lCelular.TabIndex = 4;
            this.lCelular.Text = "Celular";
            // 
            // lPerfil
            // 
            this.lPerfil.AutoSize = true;
            this.lPerfil.Location = new System.Drawing.Point(18, 173);
            this.lPerfil.Name = "lPerfil";
            this.lPerfil.Size = new System.Drawing.Size(30, 13);
            this.lPerfil.TabIndex = 5;
            this.lPerfil.Text = "Perfil";
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(18, 203);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(33, 13);
            this.lLogin.TabIndex = 6;
            this.lLogin.Text = "Login";
            // 
            // pPanel1
            // 
            this.pPanel1.Controls.Add(this.cbPerfil);
            this.pPanel1.Controls.Add(this.bCancelar);
            this.pPanel1.Controls.Add(this.bCadastrar);
            this.pPanel1.Controls.Add(this.tbNome);
            this.pPanel1.Controls.Add(this.tbCPF);
            this.pPanel1.Controls.Add(this.tbEmail);
            this.pPanel1.Controls.Add(this.tbTelefone);
            this.pPanel1.Controls.Add(this.tbCelular);
            this.pPanel1.Controls.Add(this.tbLogin);
            this.pPanel1.Location = new System.Drawing.Point(12, 13);
            this.pPanel1.Name = "pPanel1";
            this.pPanel1.Size = new System.Drawing.Size(510, 262);
            this.pPanel1.TabIndex = 9;
            // 
            // cbPerfil
            // 
            this.cbPerfil.FormattingEnabled = true;
            this.cbPerfil.Location = new System.Drawing.Point(65, 157);
            this.cbPerfil.Name = "cbPerfil";
            this.cbPerfil.Size = new System.Drawing.Size(147, 21);
            this.cbPerfil.TabIndex = 21;
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(259, 229);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 20;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bCadastrar
            // 
            this.bCadastrar.Location = new System.Drawing.Point(178, 229);
            this.bCadastrar.Name = "bCadastrar";
            this.bCadastrar.Size = new System.Drawing.Size(75, 23);
            this.bCadastrar.TabIndex = 19;
            this.bCadastrar.Text = "Cadastrar";
            this.bCadastrar.UseVisualStyleBackColor = true;
            this.bCadastrar.Click += new System.EventHandler(this.bCadastrar_Click);
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(65, 7);
            this.tbNome.MaxLength = 100;
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(426, 20);
            this.tbNome.TabIndex = 10;
            // 
            // tbCPF
            // 
            this.tbCPF.Location = new System.Drawing.Point(65, 37);
            this.tbCPF.MaxLength = 11;
            this.tbCPF.Name = "tbCPF";
            this.tbCPF.Size = new System.Drawing.Size(185, 20);
            this.tbCPF.TabIndex = 11;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(65, 67);
            this.tbEmail.MaxLength = 100;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(426, 20);
            this.tbEmail.TabIndex = 12;
            // 
            // tbTelefone
            // 
            this.tbTelefone.Location = new System.Drawing.Point(65, 97);
            this.tbTelefone.MaxLength = 11;
            this.tbTelefone.Name = "tbTelefone";
            this.tbTelefone.Size = new System.Drawing.Size(185, 20);
            this.tbTelefone.TabIndex = 13;
            // 
            // tbCelular
            // 
            this.tbCelular.Location = new System.Drawing.Point(65, 127);
            this.tbCelular.MaxLength = 11;
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(185, 20);
            this.tbCelular.TabIndex = 14;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(65, 187);
            this.tbLogin.MaxLength = 50;
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(254, 20);
            this.tbLogin.TabIndex = 16;
            // 
            // CadastrarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 286);
            this.Controls.Add(this.lLogin);
            this.Controls.Add(this.lPerfil);
            this.Controls.Add(this.lCelular);
            this.Controls.Add(this.lTelefone);
            this.Controls.Add(this.lEmail);
            this.Controls.Add(this.lCPF);
            this.Controls.Add(this.lNome);
            this.Controls.Add(this.pPanel1);
            this.Name = "CadastrarUsuario";
            this.Text = "Cadastrar usuário";
            this.Load += new System.EventHandler(this.CadastrarUsuario_Load);
            this.pPanel1.ResumeLayout(false);
            this.pPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lNome;
        private System.Windows.Forms.Label lCPF;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.Label lTelefone;
        private System.Windows.Forms.Label lCelular;
        private System.Windows.Forms.Label lPerfil;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.Panel pPanel1;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bCadastrar;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.TextBox tbCPF;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbTelefone;
        private System.Windows.Forms.TextBox tbCelular;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.ComboBox cbPerfil;
    }
}