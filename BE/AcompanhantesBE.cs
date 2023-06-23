using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_turing.BE
{
    public class AcompanhantesBE : BaseBE
    {
        private VO.Acompanhantes vo;
        private DAO.AcompanhantesDAO dao;

        public AcompanhantesBE(VO.Acompanhantes vo)
        {
            this.vo = vo;
        }
        public void incluir()
        {
            if (string.IsNullOrEmpty(this.vo.descricao))
            {
                throw new Exception("Descrição do acompanhante obrigatório!!");
            }
            dao = new DAO.AcompanhantesDAO(this.vo);
            dao.incluir();  
        }
        public void alterar()
        {
            dao = new DAO.AcompanhantesDAO(this.vo);
            dao.alterar();
        }
        public VO.Acompanhantes carregar(int Id_ReservaTitular)
        {
            dao = new DAO.AcompanhantesDAO(this.vo);
            return dao.carregar(Id_ReservaTitular);
        }

        public void remover(int Id_ReservaTitular)
        {
            dao = new DAO.AcompanhantesDAO(this.vo);
            dao.remover(Id_ReservaTitular);
        }

        public List<VO.Acompanhantes> listar()
        {
            dao = new DAO.AcompanhantesDAO(this.vo);
            return dao.listar();
        } 
    }  
}
