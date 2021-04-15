namespace Bitchain
{
    partial class EsqueciSenha
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
            this.pPanel1 = new System.Windows.Forms.Panel();
            this.bNao = new System.Windows.Forms.Button();
            this.bSim = new System.Windows.Forms.Button();
            this.lLogin = new System.Windows.Forms.Label();
            this.bAvancar = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCPF = new System.Windows.Forms.TextBox();
            this.lCPF = new System.Windows.Forms.Label();
            this.pPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pPanel1
            // 
            this.pPanel1.Controls.Add(this.bNao);
            this.pPanel1.Controls.Add(this.bSim);
            this.pPanel1.Controls.Add(this.lLogin);
            this.pPanel1.Controls.Add(this.bAvancar);
            this.pPanel1.Controls.Add(this.tbEmail);
            this.pPanel1.Controls.Add(this.label1);
            this.pPanel1.Controls.Add(this.tbCPF);
            this.pPanel1.Controls.Add(this.lCPF);
            this.pPanel1.Location = new System.Drawing.Point(17, 10);
            this.pPanel1.Name = "pPanel1";
            this.pPanel1.Size = new System.Drawing.Size(505, 219);
            this.pPanel1.TabIndex = 0;
            // 
            // bNao
            // 
            this.bNao.Location = new System.Drawing.Point(255, 180);
            this.bNao.Name = "bNao";
            this.bNao.Size = new System.Drawing.Size(75, 23);
            this.bNao.TabIndex = 7;
            this.bNao.Text = "Não";
            this.bNao.UseVisualStyleBackColor = true;
            this.bNao.Click += new System.EventHandler(this.bNao_Click);
            // 
            // bSim
            // 
            this.bSim.Location = new System.Drawing.Point(173, 181);
            this.bSim.Name = "bSim";
            this.bSim.Size = new System.Drawing.Size(75, 23);
            this.bSim.TabIndex = 6;
            this.bSim.Text = "Sim";
            this.bSim.UseVisualStyleBackColor = true;
            this.bSim.Click += new System.EventHandler(this.bSim_Click);
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(16, 145);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(63, 13);
            this.lLogin.TabIndex = 5;
            this.lLogin.Text = "Seu login é:";
            // 
            // bAvancar
            // 
            this.bAvancar.Location = new System.Drawing.Point(216, 97);
            this.bAvancar.Name = "bAvancar";
            this.bAvancar.Size = new System.Drawing.Size(75, 23);
            this.bAvancar.TabIndex = 4;
            this.bAvancar.Text = "Avançar";
            this.bAvancar.UseVisualStyleBackColor = true;
            this.bAvancar.Click += new System.EventHandler(this.bAvancar_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(176, 62);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(308, 20);
            this.tbEmail.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Informe seu e-mail";
            // 
            // tbCPF
            // 
            this.tbCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCPF.Location = new System.Drawing.Point(176, 19);
            this.tbCPF.MaxLength = 11;
            this.tbCPF.Name = "tbCPF";
            this.tbCPF.Size = new System.Drawing.Size(208, 21);
            this.tbCPF.TabIndex = 1;
            // 
            // lCPF
            // 
            this.lCPF.AutoSize = true;
            this.lCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCPF.Location = new System.Drawing.Point(13, 19);
            this.lCPF.Name = "lCPF";
            this.lCPF.Size = new System.Drawing.Size(127, 17);
            this.lCPF.TabIndex = 0;
            this.lCPF.Text = "Informe seu CPF";
            // 
            // EsqueciSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 239);
            this.Controls.Add(this.pPanel1);
            this.Name = "EsqueciSenha";
            this.Text = "Esqueci minha senha";
            this.Load += new System.EventHandler(this.EsqueciSenha_Load);
            this.pPanel1.ResumeLayout(false);
            this.pPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pPanel1;
        private System.Windows.Forms.Button bAvancar;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCPF;
        private System.Windows.Forms.Label lCPF;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.Button bSim;
        private System.Windows.Forms.Button bNao;
    }
}