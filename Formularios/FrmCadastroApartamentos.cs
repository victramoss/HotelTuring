using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hotel_turing
{
    public partial class FrmCadastroApartamentos : Form
    {
        private VO.Apartamentos apto;
        private BE.ApartamentosBE be;

        public FrmCadastroApartamentos()
        {
            InitializeComponent();
            InicializarReserva();
            liberarEdicao(false);
            carregar();
        }
        private void InicializarReserva()
        {
            apto = new VO.Apartamentos();
        }
        private void InteractToObject()
        {
            if (!string.IsNullOrEmpty(txtAndar.Text))
            {
                apto.codigo = int.Parse(txtcod.Text);
            }
            apto.numero = int.Parse (txtNumero.Text);
            apto.andar = int.Parse(txtAndar.Text);
        }
        private void objecttoInterface()
        {
            txtAndar.Text = apto.andar.ToString();
            txtNumero.Text = apto.numero.ToString();
            txtcod.Text = apto.codigo.ToString();
        }
        private void limpar()
        {
            txtAndar.Text = "";
            txtNumero.Text = "";
        }
        private void carregar()
        {
            be = new BE.ApartamentosBE(this.apto);
            lstApartamentos.DataSource = null;
            lstApartamentos.DataSource = be.listar();
            lstApartamentos.ValueMember = "codigo";
            lstApartamentos.DisplayMember = "andar";
            lstApartamentos.Refresh();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            {
                limpar();
                liberarEdicao(false);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                apto = new VO.Apartamentos();
                InteractToObject();
                be = new BE.ApartamentosBE(this.apto);
                be.incluir();
                carregar();
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro no Aplicativo");
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            be = new BE.ApartamentosBE(this.apto);
            apto = be.carregar(int.Parse(lstApartamentos.SelectedValue.ToString()));
            objecttoInterface();
            liberarEdicao(true);
        }
        
        private void liberarEdicao(bool habilita)
        {
            btnCadastrar.Enabled = !habilita;
            btn_editar.Enabled = habilita;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            InteractToObject();
            be = new BE.ApartamentosBE(this.apto);
            be.alterar();
            carregar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            be = new BE.ApartamentosBE(this.apto);
            apto = (VO.Apartamentos)lstApartamentos.SelectedItem;
            be.remover(apto.codigo);
            carregar();
        }
    }
}
