namespace Bitchain
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pPanel1 = new System.Windows.Forms.Panel();
            this.bLogar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.lUsuario = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.lSenha = new System.Windows.Forms.Label();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.lEsqueciMinhaSenha = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pPanel1
            // 
            this.pPanel1.Controls.Add(this.lEsqueciMinhaSenha);
            this.pPanel1.Controls.Add(this.bCancelar);
            this.pPanel1.Controls.Add(this.tbSenha);
            this.pPanel1.Controls.Add(this.bLogar);
            this.pPanel1.Controls.Add(this.lSenha);
            this.pPanel1.Controls.Add(this.tbUsuario);
            this.pPanel1.Controls.Add(this.lUsuario);
            this.pPanel1.Location = new System.Drawing.Point(286, 12);
            this.pPanel1.Name = "pPanel1";
            this.pPanel1.Size = new System.Drawing.Size(223, 203);
            this.pPanel1.TabIndex = 1;
            // 
            // bLogar
            // 
            this.bLogar.Location = new System.Drawing.Point(27, 154);
            this.bLogar.Name = "bLogar";
            this.bLogar.Size = new System.Drawing.Size(75, 23);
            this.bLogar.TabIndex = 2;
            this.bLogar.Text = "Logar";
            this.bLogar.UseVisualStyleBackColor = true;
            this.bLogar.Click += new System.EventHandler(this.bLogar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(108, 154);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 3;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // lUsuario
            // 
            this.lUsuario.AutoSize = true;
            this.lUsuario.Location = new System.Drawing.Point(3, 24);
            this.lUsuario.Name = "lUsuario";
            this.lUsuario.Size = new System.Drawing.Size(33, 13);
            this.lUsuario.TabIndex = 4;
            this.lUsuario.Text = "Login";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(6, 40);
            this.tbUsuario.MaxLength = 100;
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(204, 20);
            this.tbUsuario.TabIndex = 4;
            // 
            // lSenha
            // 
            this.lSenha.AutoSize = true;
            this.lSenha.Location = new System.Drawing.Point(3, 78);
            this.lSenha.Name = "lSenha";
            this.lSenha.Size = new System.Drawing.Size(53, 13);
            this.lSenha.TabIndex = 4;
            this.lSenha.Text = "Password";
            // 
            // tbSenha
            // 
            this.tbSenha.Location = new System.Drawing.Point(6, 94);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.PasswordChar = '*';
            this.tbSenha.Size = new System.Drawing.Size(204, 20);
            this.tbSenha.TabIndex = 5;
            // 
            // lEsqueciMinhaSenha
            // 
            this.lEsqueciMinhaSenha.AutoSize = true;
            this.lEsqueciMinhaSenha.Location = new System.Drawing.Point(52, 123);
            this.lEsqueciMinhaSenha.Name = "lEsqueciMinhaSenha";
            this.lEsqueciMinhaSenha.Size = new System.Drawing.Size(107, 13);
            this.lEsqueciMinhaSenha.TabIndex = 3;
            this.lEsqueciMinhaSenha.TabStop = true;
            this.lEsqueciMinhaSenha.Text = "esqueci minha senha";
            this.lEsqueciMinhaSenha.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lEsqueciMinhaSenha_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 233);
            this.Controls.Add(this.pPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pPanel1.ResumeLayout(false);
            this.pPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pPanel1;
        private System.Windows.Forms.Button bLogar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.Label lSenha;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label lUsuario;
        private System.Windows.Forms.LinkLabel lEsqueciMinhaSenha;
    }
}