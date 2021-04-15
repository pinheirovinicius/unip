using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Bitchain
{
    public partial class TelaMoeda : Form
    {
        string aviso;
        int idMoeda;
        public TelaMoeda()
        {
            InitializeComponent();
        }

        #region Botões
        private void bPesquisar_Click(object sender, EventArgs e)
        {
            if (bPesquisar.Text == "Pesquisar")
            {
                if (string.IsNullOrEmpty(tbSigla.Text) && string.IsNullOrEmpty(tbMoeda.Text))
                {
                    aviso = "Digite a \"Sigla\" ou a \"Moeda\" para pesquisar";
                    DisparaAviso();
                }
                else
                {
                    if (BuscaMoeda("Pesquisar"))
                    {
                        PreencheCampos();
                        bEditar.Enabled = true;
                        bPesquisar.Text = "Limpar";
                    }
                    else
                        DisparaAviso();
                }
            }
            else if (bPesquisar.Text == "Limpar")
            {
                Inicio();
            }
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            if (bEditar.Text == "Editar")
            {
                bEditar.Text = "Salvar";
                HabilitaEdicao(true);
            }
            else if (bEditar.Text == "Salvar")
            {
                bEditar.Text = "Editar";

                if (ValidaEdicao())
                {
                    HabilitaEdicao(false);
                    
                    try
                    {
                        using (var db = new DataBaseDataContext())
                        {
                            var moeda = db.ListaMoedas.Single(m => m.ID_MOEDA == idMoeda);

                            moeda.NM_SIGLA = tbSigla.Text.ToUpper().Trim();
                            moeda.NM_DESCRICAO = tbMoeda.Text.ToUpper().Trim();
                            moeda.VL_BASE = Convert.ToDecimal(tbVlrBase.Text);
                            moeda.VL_REAL = Convert.ToDecimal(tbVlrReal.Text);
                            moeda.FL_HABILITA = (byte) (cbHabilitado.Checked == true ? 1 : 0);

                            db.SubmitChanges();

                            aviso = "Edição concluída com sucesso";
                            DisparaAviso();
                        }
                    }
                    catch(Exception ex)
                    {
                        aviso = $"Erro: {ex.Message}";
                        DisparaAviso();
                    }
                }
                else
                    DisparaAviso();
            }
            else if (bEditar.Text == "Adicionar")
            {
                AdicionaMoeda();
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            Close();

            Default telaInicial = new Default();
            telaInicial.Visible = true;
        }

        private void llNovaMoeda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inicio();
            HabilitaEdicao(true);
            bPesquisar.Enabled = false;
            llNovaMoeda.Enabled = false;
            bEditar.Enabled = true;
            bEditar.Text = "Adicionar";
        }        
        #endregion

        #region Ações
        private void Moeda_Load(object sender, EventArgs e)
        {
            Inicio();
        }

        private void Inicio()
        {
            tbSigla.Enabled = true;
            tbMoeda.Enabled = true;
            tbVlrBase.Enabled = false;
            tbVlrReal.Enabled = false;
            cbHabilitado.Enabled = false;
            bEditar.Enabled = false;

            bPesquisar.Text = "Pesquisar";
            bEditar.Text = "Editar";
            tbSigla.Text = string.Empty;
            tbMoeda.Text = string.Empty;
            tbVlrBase.Text = string.Empty;
            tbVlrReal.Text = string.Empty;
            cbHabilitado.Checked = false;
        }

        private void DisparaAviso()
        {
            var alert = new RadDesktopAlert();
            alert.ContentText = $"{aviso}";
            alert.Show();
        }

        private bool BuscaMoeda(string Acao)
        {
            var sucesso = false;

            try
            {
                using (var db = new DataBaseDataContext())
                {
                    var listaMoeda = db.ListaMoedas.Where(m => (!string.IsNullOrEmpty(tbSigla.Text) && m.NM_SIGLA == tbSigla.Text.ToUpper().Trim()) ||
                                                               (!string.IsNullOrEmpty(tbMoeda.Text) && m.NM_DESCRICAO == tbMoeda.Text.ToUpper().Trim())
                                                          );

                    if (listaMoeda.Count() > 0 && Acao == "Pesquisar")
                    {
                        sucesso = true;
                        idMoeda = listaMoeda.FirstOrDefault().ID_MOEDA;
                    }
                    else if (listaMoeda.Count() > 0 && Acao == "Editar")
                    {
                        if (listaMoeda.FirstOrDefault(l => l.ID_MOEDA == idMoeda) != null)
                            sucesso = true;
                        else
                            aviso = "Registro duplicado, altere a \"Sigla\" ou a \"Moeda\"";
                    }
                    else
                        aviso = "Moeda não encontrada";
                }
            }
            catch(Exception ex)
            {
                aviso = $"Erro: {ex.Message}";
                DisparaAviso();
            }

            return sucesso;
        }

        private void PreencheCampos()
        {
            using (var db = new DataBaseDataContext())
            {
                var moeda = db.ListaMoedas.Single(m => m.ID_MOEDA == idMoeda);

                tbSigla.Text = moeda.NM_SIGLA;
                tbMoeda.Text = moeda.NM_DESCRICAO;
                tbVlrBase.Text = moeda.VL_BASE.ToString();
                tbVlrReal.Text = moeda.VL_REAL.ToString();
                cbHabilitado.Checked = moeda.FL_HABILITA == 1 ? true : false;
            }
        }

        private void HabilitaEdicao(bool bHabilita)
        {
            tbSigla.Enabled = bHabilita;
            tbMoeda.Enabled = bHabilita;
            tbVlrBase.Enabled = bHabilita;
            tbVlrReal.Enabled = bHabilita;
            cbHabilitado.Enabled = bHabilita;
        }
        
        private bool ValidaEdicao()
        {
            var sucesso = false;

            if (CamposPreenchidos() && !BuscaMoeda("Edicao"))
                sucesso = true;
            else if (BuscaMoeda("Edicao"))
                aviso = "Moeda já existente";
            else
                aviso = "Preencha todos os campos";

            return sucesso;
        }

        private bool CamposPreenchidos()
        {
            var sucesso = false;

            if (!string.IsNullOrEmpty(tbSigla.Text) ||
                !string.IsNullOrEmpty(tbMoeda.Text) ||
                !string.IsNullOrEmpty(tbVlrBase.Text) ||
                !string.IsNullOrEmpty(tbVlrReal.Text))
                sucesso = true;
            else
                aviso = "Preencha todos os campos";

            return sucesso;
        }

        private void AdicionaMoeda()
        {
            if (ValidaEdicao())
            {
                HabilitaEdicao(false);

                try
                {
                    using (var db = new DataBaseDataContext())
                    {
                        var moeda = new ListaMoeda();

                        moeda.NM_SIGLA = tbSigla.Text.ToUpper().Trim();
                        moeda.NM_DESCRICAO = tbMoeda.Text.ToUpper().Trim();
                        //moeda.VL_BASE = 
                        //moeda.VL_REAL = 
                        moeda.FL_HABILITA = (byte)(cbHabilitado.Checked == true ? 1 : 0);

                        db.ListaMoedas.InsertOnSubmit(moeda);
                        db.SubmitChanges();

                        aviso = "Moeda incluída com sucesso";
                        DisparaAviso();

                        bEditar.Text = "Editar";
                        HabilitaEdicao(false);
                    }
                }
                catch (Exception ex)
                {
                    aviso = $"Erro: {ex.Message}";
                    DisparaAviso();
                }
            }
            else
                DisparaAviso();
        }
        #endregion
    }
}
