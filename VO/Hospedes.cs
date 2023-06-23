using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_turing.VO
{
    public class Hospedes : BaseVO
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string cep { get; set; }
        public DateTime data_nascimento { get; set; }
        public string rg { get; set; }


    }
}
