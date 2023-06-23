using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using hotel_turing.DAO.DataAccess;

namespace hotel_turing.DAO
{
    public class HospedesDAO : BaseDAO
    {
        
        private VO.Hospedes vo;

        public HospedesDAO(VO.Hospedes vo)
        {

            if (DAO.listaHospedes == null)
            {
                DAO.listaHospedes = new List<VO.Hospedes>();
            }
            this.vo = vo;
        }

        public void incluir()
        {
            try
            {
                string sql = "insert into hospede (nome,cpf,telefone,rg,cep,endereco,dt_nascimento) " +
                    "values (@nome,@cpf,@telefone,@rg,@cep,@endereco,@dt_nascimento)";
                db.AddParameter("@nome", vo.nome, ParameterDirection.Input);
                db.AddParameter("@cpf", vo.cpf, ParameterDirection.Input);
                db.AddParameter("@telefone", vo.telefone, ParameterDirection.Input);
                db.AddParameter("@rg", vo.rg, ParameterDirection.Input);
                db.AddParameter("@cep", vo.cep, ParameterDirection.Input);
                db.AddParameter("@endereco", vo.endereco, ParameterDirection.Input);
                db.AddParameter("@dt_nascimento", vo.data_nascimento, ParameterDirection.Input); 
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
                string sql = "update hospede set " +
                    "nome = @nome," +
                    "cpf = @cpf ," +
                    "telefone = @telefone " +
                    "rg = @rg" +
                    "cep = @cep" +
                    "dt_nascimento = @dt_nascimento" +
                    "endereco = @endereco" +
                    "where id = @id";
                db.AddParameter("@nome", vo.nome, ParameterDirection.Input);
                db.AddParameter("@cpf", vo.cpf, ParameterDirection.Input);
                db.AddParameter("@telefone", vo.telefone, ParameterDirection.Input);
                db.AddParameter("@rg", vo.rg, ParameterDirection.Input);
                db.AddParameter("@cep", vo.cep, ParameterDirection.Input);
                db.AddParameter("@endereco", vo.endereco, ParameterDirection.Input);
                db.AddParameter("@dt_nascimento", vo.data_nascimento, ParameterDirection.Input);
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
                string sql = $"delete from hospede where id = @id";
                db.AddParameter("@id", vo.codigo, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        public VO.Hospedes carregar(int id)
        {
            string sql = $"SELECT id,nome,cpf,telefone,rg,cep,endereco,dt_nascimento from hospede where id=@id";
            db.AddParameter("@id", id, ParameterDirection.Input);
            try
            {
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        vo = LoadHospedes(dr);
                    }
                    return vo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        private VO.Hospedes LoadHospedes(DbDataReader dr)
        {
            vo = new VO.Hospedes();
            vo.cpf = Convert.ToString(dr["id"]);
            vo.data_nascimento = Convert.ToDateTime(dr["dt_nascimento"]);
            vo.nome = dr["nome"] != DBNull.Value ? dr["nome"].ToString() : "";
            vo.telefone = dr["telefone"] != DBNull.Value ? dr["telefone"].ToString() : "";
            vo.endereco = dr["endereco"] != DBNull.Value ? dr["endereco"].ToString() : "";
            vo.rg = dr["rg"] != DBNull.Value ? dr["rg"].ToString() : "";
            vo.cep = dr["cep"] != DBNull.Value ? dr["cep"].ToString() : "";
            



            return vo;
        }

        public List<VO.Hospedes> listar()
        {
            try
            {
                string sql = "SELECT * FROM hospede;";
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    var objResultado = new List<VO.Hospedes>();

                    while (dr.Read())
                    {
                        vo = LoadHospedes(dr);
                        objResultado.Add(vo);
                    }
                    return objResultado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }
    }
}
