using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_turing.BE
{
    public class HotelBE : BaseBE
    {
        private VO.Hotel vo;
        private DAO.HotelDAO dao;

        public HotelBE(VO.Hotel vo)
        {
            this.vo = vo;
        }
        public void incluir()
        {
            if (string.IsNullOrEmpty(this.vo.nome))
            {
                throw new Exception("Nome do hotel obrigatório!!");
            }
            dao = new DAO.HotelDAO(this.vo);
            dao.incluir();
        }
        public void alterar()
        {
            dao = new DAO.HotelDAO(this.vo);
            dao.alterar();
        }
        public VO.Hotel carregar(int Id)
        {
            dao = new DAO.HotelDAO(this.vo);
            return dao.carregar(Id);
        }
      
        public void remover(int Id)
        {
            dao = new DAO.HotelDAO(this.vo);
            dao.remover(Id);
        }
      
        
        public List<VO.Hotel> Listar()
        {
            dao = new DAO.HotelDAO(this.vo);
            return dao.listar();
        }
    }
}

