using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hotel_turing
{
    public partial class FrmCadastroReserva : Form
    {
        private VO.Reserva vo;
        private BE.ReservaBE be;

        public FrmCadastroReserva()
        {
            InitializeComponent();
            InicializarReserva();
            liberarEdicao(false);
            carregar();
            carregarHospedes();
            carregarHotel();
            carregarApartamento();
        }

        private void carregarHospedes()
        {
            BE.HospedesBE vo = new BE.HospedesBE(new VO.Hospedes());
            cmbHospede.DataSource = null;
            cmbHospede.DataSource = vo.listar();
            cmbHospede.ValueMember = "codigo";
            cmbHospede.DisplayMember = "nome";
            cmbHospede.Refresh();
        }

        private void carregarHotel()
        {
            BE.HotelBE vo = new BE.HotelBE(new VO.Hotel());
            cmbHotel.DataSource = null;
            cmbHotel.DataSource = vo.Listar();
            cmbHotel.ValueMember = "codigo";
            cmbHotel.DisplayMember = "nome";
            cmbHotel.Refresh();
        }
        private void carregarApartamento()
        {
            BE.ApartamentosBE vo = new BE.ApartamentosBE(new VO.Apartamentos());
        }

        private void InicializarReserva()
        {
            vo = new VO.Reserva();
        }

        private void InteractToObject()
        {
            if (!string.IsNullOrEmpty(txtCodreserva.Text))
            {
                vo.codigo = int.Parse(txtCodreserva.Text);
            }
            vo.data_entrada = DateTime.Parse(txtdataentrada.Text);
            vo.hotel = (VO.Hotel)cmbHotel.SelectedItem;
            vo.hospedes = (VO.Hospedes)cmbHospede.SelectedItem;
        }

        private void objecttoInterface()
        {
            txtCodreserva.Text = vo.codigo.ToString();
            txtdataentrada.Text = vo.data_entrada.ToString();
            int index = 0;
            foreach (VO.Hotel item in cmbHotel.Items)
            {
                if (item.codigo.Equals(vo.hotel.codigo))
                {
                    cmbHotel.SelectedIndex = index;
                    return;
                }
                index++;
            }
            foreach (VO.Hospedes item in cmbHospede.Items)
            {
                if (item.codigo.Equals(vo.hospedes.codigo))
                {
                    cmbHospede.SelectedIndex = index;
                    return;
                }
                index++;
            }
        }

        private void limpar()
        {
            txtCodreserva.Text = "";
            txtdataentrada.Text = "";
            txtdtreserva.Text = "";
            txtvalor.Text = "";
            txtdtsaida.Text = "";
            cmbHospede.SelectedIndex = -1;
            cmbHotel.SelectedIndex = -1;
        }

        private void carregar()
        {
            be = new BE.ReservaBE(this.vo);
            lstReserva.DataSource = null;
            lstReserva.DataSource = be.listar();
            lstReserva.ValueMember = "codigo";
            lstReserva.DisplayMember = "nome";
            lstReserva.Refresh();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
            liberarEdicao(false);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                vo = new VO.Reserva();
                InteractToObject();
                be = new BE.ReservaBE(this.vo);
                be.incluir();
                carregar();
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro No Aplicativo");

            }
        }

        private void btnselecionar_Click(object sender, EventArgs e)
        {
            be = new BE.ReservaBE(this.vo);
            vo = be.carregar(int.Parse(lstReserva.SelectedValue.ToString()));
            objecttoInterface();
            liberarEdicao(true);
        }

        private void liberarEdicao(bool habilita)
        {
            btnCadastrar.Enabled = !habilita;
            btneditar.Enabled = habilita;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            InteractToObject();
            be = new BE.ReservaBE(this.vo);
            be.alterar();
            carregar();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            be = new BE.ReservaBE(this.vo);
            vo = (VO.Reserva)lstReserva.SelectedItem;
            be.remover(vo.codigo);
            carregar();
        }

       
    }
}
