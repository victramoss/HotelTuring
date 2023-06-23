using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using hotel_turing.DAO.DataAccess;

namespace hotel_turing.DAO
{
    public class HotelDAO : BaseDAO
    {
        private VO.Hotel vo;

        public HotelDAO(VO.Hotel vo)
        {

            if (DAO.listaHotel == null)
            {
                DAO.listaHotel = new List<VO.Hotel>();
            }
            this.vo = vo;
        }
        public void incluir()
        {
            try
            {
                string sql = "insert into hotel (nome,email,endereco) " +
                    "values (@nome,@email,@endereco)";
                db.AddParameter("@nome", vo.nome, ParameterDirection.Input);
                db.AddParameter("@email", vo.email, ParameterDirection.Input);
                db.AddParameter("@endereco", vo.endereco, ParameterDirection.Input);
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
                string sql = "update hotel set " +
                    "endereco = @endereco," +
                    "nome = @nome ," +
                    "email = @email " +
                    "where id = @id";
                db.AddParameter("@id", vo.codigo, ParameterDirection.Input);
                db.AddParameter("@nome", vo.nome, ParameterDirection.Input);
                db.AddParameter("@email", vo.email, ParameterDirection.Input);
                db.AddParameter("@endereco", vo.endereco, ParameterDirection.Input);
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
                string sql = $"delete from hotel where id = @id";
                db.AddParameter("@id", vo.codigo, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        public VO.Hotel carregar(int id)
        {
            string sql = $"SELECT id,nome,endereco,email from hotel where id=@id";
            db.AddParameter("@id", id, ParameterDirection.Input);
            try
            {
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        vo = LoadHotel(dr);
                    }
                    return vo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        private VO.Hotel LoadHotel(DbDataReader dr)
        {
            vo = new VO.Hotel();
            vo.codigo =  int.Parse(dr["id"].ToString());
            vo.nome = dr["nome"] != DBNull.Value ? dr["nome"].ToString() : "";
            vo.endereco = dr["endereco"] != DBNull.Value ? dr["endereco"].ToString() : "";
            vo.email = dr["email"] != DBNull.Value ? dr["email"].ToString() : "";

            return vo;
        }

        public List<VO.Hotel> listar()
        {
            try
            {
                string sql = "SELECT * FROM hotel;";
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    var objResultado = new List<VO.Hotel>();

                    while (dr.Read())
                    {
                        vo = LoadHotel(dr);
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
