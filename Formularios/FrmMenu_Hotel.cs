using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel_turing
{
    public partial class FrmMenu_Hotel : Form
    {
        public FrmMenu_Hotel()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            FrmCadastroLogin FCL = new
                FrmCadastroLogin();
            FCL.Show();
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {

            FrmCadastroHospede FCH = new
                FrmCadastroHospede();
            FCH.Show();
        }

        private void btn_reserva_Click(object sender, EventArgs e)
        {
            FrmCadastroReserva FCR = new
                FrmCadastroReserva();
            FCR.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCadastroHotel FRHT = new
                FrmCadastroHotel();
            FRHT.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCadastroAcompanhante FRCA = new
                FrmCadastroAcompanhante();
            FRCA.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmCadastroApartamentos FRAP = new
                FrmCadastroApartamentos();
            FRAP.Show();
        }
    }
}
