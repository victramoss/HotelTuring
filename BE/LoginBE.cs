using System;
using System.Collections.Generic;
using System.Text;

namespace hotel_turing.BE
{
    public class LoginBE : BaseBE
    {
        private VO.Login vo;
        private DAO.LoginDAO dao;

        public LoginBE(VO.Login vo)
        {
            this.vo = vo;
        }
        public void incluir()
        {
            if (string.IsNullOrEmpty(this.vo.nome))
            {
                throw new Exception("Nome do usuário obrigatório!!");
            }
            else
            {
                throw new Exception("Senha obrigatória!");
            }

            dao = new DAO.LoginDAO(this.vo);
            dao.incluir();
        }
        
        public void alterar()
        {
            dao = new DAO.LoginDAO(this.vo);
            dao.alterar();
        }
        public VO.Login carregar(int Id)
        {
            dao = new DAO.LoginDAO(this.vo);
            return dao.carregar(Id);
        }

        public void remover(int Id)
        {
            dao = new DAO.LoginDAO(this.vo);
            dao.remover(Id);
        }


    }
}
