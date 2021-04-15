using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bitchain
{
    public partial class Default : Form
    {
        public Default()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarUsuario cadastrarUsuario = new CadastrarUsuario();
            cadastrarUsuario.Show();

            this.Close();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContaUsuario contaUsuario = new ContaUsuario();
            contaUsuario.Show();

            this.Close();
        }

        private void moedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaMoeda moeda = new TelaMoeda();
            moeda.Show();

            this.Close();
        }

        private void bLogoff_Click(object sender, EventArgs e)
        {
            this.Close();

            Login login = new Login();
            login.Visible = true;
        }
    }
}
