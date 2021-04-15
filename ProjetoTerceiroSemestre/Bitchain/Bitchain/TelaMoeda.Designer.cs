namespace Bitchain
{
    partial class TelaMoeda
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
            this.tbVlrReal = new System.Windows.Forms.TextBox();
            this.lVlrReal = new System.Windows.Forms.Label();
            this.bEditar = new System.Windows.Forms.Button();
            this.bPesquisar = new System.Windows.Forms.Button();
            this.llNovaMoeda = new System.Windows.Forms.LinkLabel();
            this.cbHabilitado = new System.Windows.Forms.CheckBox();
            this.tbVlrBase = new System.Windows.Forms.TextBox();
            this.tbMoeda = new System.Windows.Forms.TextBox();
            this.tbSigla = new System.Windows.Forms.TextBox();
            this.lVlrBase = new System.Windows.Forms.Label();
            this.lMoeda = new System.Windows.Forms.Label();
            this.lSigla = new System.Windows.Forms.Label();
            this.bCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bCancelar);
            this.panel1.Controls.Add(this.tbVlrReal);
            this.panel1.Controls.Add(this.lVlrReal);
            this.panel1.Controls.Add(this.bEditar);
            this.panel1.Controls.Add(this.bPesquisar);
            this.panel1.Controls.Add(this.llNovaMoeda);
            this.panel1.Controls.Add(this.cbHabilitado);
            this.panel1.Controls.Add(this.tbVlrBase);
            this.panel1.Controls.Add(this.tbMoeda);
            this.panel1.Controls.Add(this.tbSigla);
            this.panel1.Controls.Add(this.lVlrBase);
            this.panel1.Controls.Add(this.lMoeda);
            this.panel1.Controls.Add(this.lSigla);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 167);
            this.panel1.TabIndex = 0;
            // 
            // tbVlrReal
            // 
            this.tbVlrReal.Enabled = false;
            this.tbVlrReal.Location = new System.Drawing.Point(80, 101);
            this.tbVlrReal.Name = "tbVlrReal";
            this.tbVlrReal.Size = new System.Drawing.Size(100, 20);
            this.tbVlrReal.TabIndex = 3;
            // 
            // lVlrReal
            // 
            this.lVlrReal.AutoSize = true;
            this.lVlrReal.Location = new System.Drawing.Point(20, 104);
            this.lVlrReal.Name = "lVlrReal";
            this.lVlrReal.Size = new System.Drawing.Size(51, 13);
            this.lVlrReal.TabIndex = 7;
            this.lVlrReal.Text = "Valor real";
            // 
            // bEditar
            // 
            this.bEditar.Enabled = false;
            this.bEditar.Location = new System.Drawing.Point(132, 137);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(75, 23);
            this.bEditar.TabIndex = 6;
            this.bEditar.Text = "Editar";
            this.bEditar.UseVisualStyleBackColor = true;
            this.bEditar.Click += new System.EventHandler(this.bEditar_Click);
            // 
            // bPesquisar
            // 
            this.bPesquisar.Location = new System.Drawing.Point(51, 137);
            this.bPesquisar.Name = "bPesquisar";
            this.bPesquisar.Size = new System.Drawing.Size(75, 23);
            this.bPesquisar.TabIndex = 5;
            this.bPesquisar.Text = "Pesquisar";
            this.bPesquisar.UseVisualStyleBackColor = true;
            this.bPesquisar.Click += new System.EventHandler(this.bPesquisar_Click);
            // 
            // llNovaMoeda
            // 
            this.llNovaMoeda.AutoSize = true;
            this.llNovaMoeda.Location = new System.Drawing.Point(217, 14);
            this.llNovaMoeda.Name = "llNovaMoeda";
            this.llNovaMoeda.Size = new System.Drawing.Size(75, 13);
            this.llNovaMoeda.TabIndex = 7;
            this.llNovaMoeda.TabStop = true;
            this.llNovaMoeda.Text = "+ nova moeda";
            this.llNovaMoeda.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llNovaMoeda_LinkClicked);
            // 
            // cbHabilitado
            // 
            this.cbHabilitado.AutoSize = true;
            this.cbHabilitado.Enabled = false;
            this.cbHabilitado.Location = new System.Drawing.Point(232, 104);
            this.cbHabilitado.Name = "cbHabilitado";
            this.cbHabilitado.Size = new System.Drawing.Size(73, 17);
            this.cbHabilitado.TabIndex = 4;
            this.cbHabilitado.Text = "Habilitado";
            this.cbHabilitado.UseVisualStyleBackColor = true;
            // 
            // tbVlrBase
            // 
            this.tbVlrBase.Enabled = false;
            this.tbVlrBase.Location = new System.Drawing.Point(79, 71);
            this.tbVlrBase.Name = "tbVlrBase";
            this.tbVlrBase.Size = new System.Drawing.Size(100, 20);
            this.tbVlrBase.TabIndex = 2;
            // 
            // tbMoeda
            // 
            this.tbMoeda.Location = new System.Drawing.Point(80, 41);
            this.tbMoeda.Name = "tbMoeda";
            this.tbMoeda.Size = new System.Drawing.Size(225, 20);
            this.tbMoeda.TabIndex = 1;
            // 
            // tbSigla
            // 
            this.tbSigla.Location = new System.Drawing.Point(80, 11);
            this.tbSigla.Name = "tbSigla";
            this.tbSigla.Size = new System.Drawing.Size(100, 20);
            this.tbSigla.TabIndex = 0;
            // 
            // lVlrBase
            // 
            this.lVlrBase.AutoSize = true;
            this.lVlrBase.Location = new System.Drawing.Point(14, 74);
            this.lVlrBase.Name = "lVlrBase";
            this.lVlrBase.Size = new System.Drawing.Size(57, 13);
            this.lVlrBase.TabIndex = 2;
            this.lVlrBase.Text = "Valor base";
            // 
            // lMoeda
            // 
            this.lMoeda.AutoSize = true;
            this.lMoeda.Location = new System.Drawing.Point(31, 44);
            this.lMoeda.Name = "lMoeda";
            this.lMoeda.Size = new System.Drawing.Size(40, 13);
            this.lMoeda.TabIndex = 1;
            this.lMoeda.Text = "Moeda";
            // 
            // lSigla
            // 
            this.lSigla.AutoSize = true;
            this.lSigla.Location = new System.Drawing.Point(41, 14);
            this.lSigla.Name = "lSigla";
            this.lSigla.Size = new System.Drawing.Size(30, 13);
            this.lSigla.TabIndex = 0;
            this.lSigla.Text = "Sigla";
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(214, 136);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 8;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // TelaMoeda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 192);
            this.Controls.Add(this.panel1);
            this.Name = "TelaMoeda";
            this.Text = "Moeda";
            this.Load += new System.EventHandler(this.Moeda_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bEditar;
        private System.Windows.Forms.Button bPesquisar;
        private System.Windows.Forms.LinkLabel llNovaMoeda;
        private System.Windows.Forms.CheckBox cbHabilitado;
        private System.Windows.Forms.TextBox tbVlrBase;
        private System.Windows.Forms.TextBox tbMoeda;
        private System.Windows.Forms.TextBox tbSigla;
        private System.Windows.Forms.Label lVlrBase;
        private System.Windows.Forms.Label lMoeda;
        private System.Windows.Forms.Label lSigla;
        private System.Windows.Forms.TextBox tbVlrReal;
        private System.Windows.Forms.Label lVlrReal;
        private System.Windows.Forms.Button bCancelar;
    }
}