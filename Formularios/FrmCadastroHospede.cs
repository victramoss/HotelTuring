using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hotel_turing
{
    public partial class FrmCadastroHospede : Form
    {

        private VO.Hospedes vo;
        private BE.HospedesBE be;

        public FrmCadastroHospede()
        {
            InitializeComponent();
            InicializarReserva();
            liberarEdicao(false);
            carregar();
        }

        private void InicializarReserva()
        {
            vo = new VO.Hospedes();
        }

        private void InteractToObject()
        {
            if (!string.IsNullOrEmpty(txt_cod.Text))
            {
                vo.codigo = int.Parse(txt_cod.Text);
            }
            vo.nome = txtnome.Text;
            vo.cep = txtcep.Text;
            vo.endereco = txtendereco.Text;
            vo.cpf = txtcpf.Text;
            vo.data_nascimento = DateTime.Parse(txt_dtnascimento.Text);
            vo.rg = txtrg.Text;
            vo.telefone = txtnumero.Text;
        }

        private void objecttoInterface()
        {
            txt_cod.Text = vo.codigo.ToString();
            txtnome.Text = vo.nome.ToString();
            txtcpf.Text = vo.cpf.ToString();
            txtendereco.Text = vo.endereco.ToString();
            txtnumero.Text = vo.telefone.ToString();
            txtrg.Text = vo.rg.ToString();
            txtcep.Text = vo.cep.ToString();
            txt_dtnascimento.Text = vo.data_nascimento.ToString();
            int index = 0;

        }

        private void limpar()
        {
            txt_cod.Text = "";
            txtcep.Text = "";
            txtnome.Text = "";
            txtcpf.Text = "";
            txt_dtnascimento.Text = "";
            txtendereco.Text = "";
            txtnumero.Text = "";
            txtrg.Text = "";
        }

        private void carregar()
        {
            be = new BE.HospedesBE(this.vo);
            lst_hospede.DataSource = null;
            lst_hospede.DataSource = be.listar();
            lst_hospede.ValueMember = "codigo";
            lst_hospede.DisplayMember = "nome";
            lst_hospede.Refresh();
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
                vo = new VO.Hospedes();
                InteractToObject();
                be = new BE.HospedesBE(this.vo);
                be.incluir();
                carregar();
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro No Aplicativo");

            }
        }

       
        private void liberarEdicao(bool habilita)
        {
            btn_cadastrar.Enabled = !habilita;
            btn_editar.Enabled = habilita;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            InteractToObject();
            be = new BE.HospedesBE(this.vo);
            be.alterar();
            carregar();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            be = new BE.HospedesBE(this.vo);
            vo = be.carregar(int.Parse(lst_hospede.SelectedValue.ToString()));
            objecttoInterface();
            liberarEdicao(true);
        }
    }
}
