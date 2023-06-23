using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_turing.BE
{
    
    
        public class ReservaBE : BaseBE
        {
            private VO.Reserva vo;
            private DAO.ReservaDAO dao;

            public ReservaBE(VO.Reserva vo)
            {
                this.vo = vo;
            }
            public void incluir()
            {
                if (this.vo.numero_reserva==0) 
                {
                    throw new Exception("Nome do hóspede obrigatório!!");
                }
                dao = new DAO.ReservaDAO(this.vo);
                dao.incluir();
            }
            public void alterar()
            {
                dao = new DAO.ReservaDAO(this.vo);
                dao.alterar();
            }
            public VO.Reserva carregar(int Id)
            {
                dao = new DAO.ReservaDAO(this.vo);
                return dao.carregar(Id);
            }

            public void remover(int Id)
            {
                dao = new DAO.ReservaDAO(this.vo);
                dao.remover(Id);
            }

            public List<VO.Reserva> listar()
            {
                dao = new DAO.ReservaDAO(this.vo);
                return dao.listar();
            }
        }
    
}
