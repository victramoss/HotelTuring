using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_turing.VO
{
    public class Login : BaseVO
    {
        public string id { get; set; }
        public string nome { get; set; }
        public int senha { get; set; }
    }
}
