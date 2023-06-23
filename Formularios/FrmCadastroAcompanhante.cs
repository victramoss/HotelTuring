using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hotel_turing
{
    public partial class FrmCadastroAcompanhante : Form
    {
        private VO.Acompanhantes acomp;
        private BE.AcompanhantesBE be;

        public FrmCadastroAcompanhante()
        {
            InitializeComponent();
            InicializarReserva();
            liberarEdicao(false);
            carregar();
        }
        private void InicializarReserva()
        {
            acomp = new VO.Acompanhantes();
        }
        private void InteractToObject()
        {
            if (!string.IsNullOrEmpty(txtcod.Text))
            {
                acomp.codigo = int.Parse(txtcod.Text);
            }
            acomp.descricao = txtDescricao.Text;
             = (VO.Reserva)cmbReservaTitular.SelectedItem;
        }
        private void objecttoInterface()
        {
            txtDescricao.Text = acomp.descricao.ToString();
        }
        private void limpar()
        {
            txtDescricao.Text = "";
        }
        private void carregar()
        {
            be = new BE.AcompanhantesBE(this.acomp);
            lst_acompanhantes.DataSource = null;
            lst_acompanhantes.DataSource = be.listar();
            lst_acompanhantes.ValueMember = "codigo";
            lst_acompanhantes.DisplayMember = "nome";
            lst_acompanhantes.Refresh();
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
                acomp = new VO.Acompanhantes();
                InteractToObject();
                be = new BE.AcompanhantesBE(this.acomp);
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
            be = new BE.AcompanhantesBE(this.acomp);
            acomp = ((VO.Acompanhantes)lst_acompanhantes.SelectedItem);
            acomp = be.carregar(acomp.codigo);
            objecttoInterface();
            liberarEdicao(true);
        }
        private void liberarEdicao(bool habilita)
        {
            btnCadastrar.Enabled = !habilita;
            btn_Editar.Enabled = habilita;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

            InteractToObject();
            be = new BE.AcompanhantesBE(this.acomp);
            be.alterar();
            carregar();

        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            be = new BE.AcompanhantesBE(this.acomp);
            acomp = (VO.Acompanhantes)lst_acompanhantes.SelectedItem;
            be.remover(acomp.codigo);
            carregar();
        }
    }
}
