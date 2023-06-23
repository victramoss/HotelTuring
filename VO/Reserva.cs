using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_turing.VO
{
    public class Reserva : BaseVO
    {
        public int id_apartamento { get; set; }
        public int id_usuario { get; set; }
        public int data_reserva { get; set; }
        public DateTime data_entrada { get; set; }
        public DateTime data_saida { get; set; }
        public int numero_reserva { get; set; }
        public int valor { get; set; }
        public Hotel hotel { get; set; }
        public Hospedes hospedes { get; set; }
    }
}
