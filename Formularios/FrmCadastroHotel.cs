using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hotel_turing
{
    public partial class FrmCadastroHotel : Form
    {
        private VO.Hotel hot;
        private BE.HotelBE be;

        public FrmCadastroHotel()
        {
            InitializeComponent();
            InicializarReserva();
            liberarEdicao(false);
            carregar();
        }
        private void InicializarReserva()
        {
            hot = new VO.Hotel();
        }
        private void InteractToObject()
        {
            if (!string.IsNullOrEmpty(txtcod.Text))
            {
                hot.codigo = int.Parse(txtcod.Text);
            }
            hot.nome = txtnome.Text;
            hot.email = txtemail.Text;
            hot.endereco = txtendereco.Text;
        }
        private void objecttoInterface()
        {
            txtnome.Text = hot.nome.ToString();
            txtendereco.Text = hot.endereco.ToString();
            txtemail.Text = hot.email.ToString();
            txtcod.Text = hot.codigo.ToString();
        }
        private void limpar()
        {
            txtemail.Text = "";
            txtnome.Text = "";
            txtendereco.Text = "";
        }
        private void carregar()
        {
            be = new BE.HotelBE(this.hot);
            lstHotel.DataSource = null;
            lstHotel.DataSource = be.Listar();
            lstHotel.ValueMember = "codigo";
            lstHotel.DisplayMember = "nome";
            lstHotel.Refresh();
        }

        

        private void btn_limpar_Click(object sender, EventArgs e)
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
                hot = new VO.Hotel();
                InteractToObject();
                be = new BE.HotelBE(this.hot);
                be.incluir();
                carregar();
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro No Aplicativo");

            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            be = new BE.HotelBE(this.hot);
            hot = ((VO.Hotel)lstHotel.SelectedItem);
            hot = be.carregar(hot.codigo);
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
            be = new BE.HotelBE(this.hot);
            be.alterar();
            carregar();
            
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            be = new BE.HotelBE(this.hot);
            hot = (VO.Hotel)lstHotel.SelectedItem;
            be.remover(hot.codigo);
            carregar();
        }
    }
}
