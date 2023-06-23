using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_turing.BE
{
    public class ApartamentosBE : BaseBE
    {
        private VO.Apartamentos vo;
        private DAO.ApartamentosDAO dao;

        public ApartamentosBE(VO.Apartamentos vo)
        {
            this.vo = vo;
        }
        public void incluir()
        {
         
            dao = new DAO.ApartamentosDAO(this.vo);
            dao.incluir();
        }
        public void alterar()
        {
            dao = new DAO.ApartamentosDAO(this.vo);
            dao.alterar();
        }
        public VO.Apartamentos carregar(int id)
        {
            dao = new DAO.ApartamentosDAO(this.vo);
            return dao.carregar(id);
        }

        public void remover(int id)
        {
            dao = new DAO.ApartamentosDAO(this.vo);
            dao.remover(id);
        }

        public List<VO.Apartamentos> listar()
        {
            dao = new DAO.ApartamentosDAO(this.vo);
            return dao.listar();
        }
    }
}
