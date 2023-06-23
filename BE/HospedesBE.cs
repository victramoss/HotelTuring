using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_turing.BE
{
    public class HospedesBE : BaseBE
    {
        private VO.Hospedes vo;
        private DAO.HospedesDAO dao;

        public HospedesBE(VO.Hospedes vo)
        {
            this.vo = vo;
        }
        public void incluir()
        {
            if (string.IsNullOrEmpty(this.vo.nome))
            {
                throw new Exception("Nome do hóspede obrigatório!!");
            }
            dao = new DAO.HospedesDAO(this.vo);
            dao.incluir();
        }
        public void alterar()
        {
            dao = new DAO.HospedesDAO(this.vo);
            dao.alterar();
        }
        public VO.Hospedes carregar(int Id)
        {
            dao = new DAO.HospedesDAO(this.vo);
            return dao.carregar(Id);
        }

        public void remover(int Id)
        {
            dao = new DAO.HospedesDAO(this.vo);
            dao.remover(Id);
        }

        public List<VO.Hospedes> listar()
        {
            dao = new DAO.HospedesDAO(this.vo);
            return dao.listar();
        }
    }
}

