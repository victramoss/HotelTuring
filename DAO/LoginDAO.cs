using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using hotel_turing.DAO.DataAccess;

namespace hotel_turing.DAO
{
    public class LoginDAO : BaseDAO
    {


        private VO.Login vo;

        public LoginDAO(VO.Login vo)
        {

            if (DAO.listaLogin == null)
            {
                DAO.listaLogin = new List<VO.Login>();
            }
            this.vo = vo;
        }
        public void incluir()
        {
            try
            {
                string sql = "insert into usuario (nome,senha) " +
                    "values (@nome,@senha)";
                db.AddParameter("@nome", vo.nome, ParameterDirection.Input);
                db.AddParameter("@email", vo.senha, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }

        }

        public void alterar()
        {
            try
            {
                string sql = "update login set " +
                    "senha = @senha," +
                    "nome = @nome ," +
                    "where id = @id";
                db.AddParameter("@nome", vo.nome, ParameterDirection.Input);
                db.AddParameter("@senha", vo.senha, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        public void remover(int id)

        {
            try
            {
                string sql = $"delete from login where id = @id";
                db.AddParameter("@id", vo.id, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        public VO.Login carregar(int id)
        {
            string sql = $"SELECT id,nome,endereco,email from hotel where id=@id";
            db.AddParameter("@id", id, ParameterDirection.Input);
            try
            {
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        vo = LoadLogin(dr);
                    }
                    return vo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        private VO.Login LoadLogin(DbDataReader dr)
        {
            vo = new VO.Login();
            vo.nome = dr["nome"] != DBNull.Value ? dr["nome"].ToString() : "";
            vo.senha = dr["@senha"] != DBNull.Value ? int.Parse(dr["senha"].ToString()) : 0;

            return vo;
        }
    }   
}
