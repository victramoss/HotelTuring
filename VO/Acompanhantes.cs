using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_turing.VO
{
    public class Acompanhantes : BaseVO
    {
        public int id_reservatitular {get; set; }
        public int id_hospedetitular { get; set; }
        public string descricao { get; set; }
    }
}
