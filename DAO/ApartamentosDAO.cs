using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using hotel_turing.DAO.DataAccess;

namespace hotel_turing.DAO
{
    public class ApartamentosDAO : BaseDAO
    {
        private VO.Apartamentos vo;
        public ApartamentosDAO(VO.Apartamentos vo)
        {
            if (DAO.listaApartamentos == null)
            {
                DAO.listaApartamentos = new List<VO.Apartamentos>();
            }
            this.vo = vo;
        }

        public void incluir()
        {
            try
            {
                string sql = "insert into apartamento (andar,numero) " +
                    "values (@andar,@numero)";
                db.AddParameter("@andar", vo.andar, ParameterDirection.Input);
                db.AddParameter("@numero", vo.numero, ParameterDirection.Input);
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
                string sql = "update apartamento set " +
                    "andar = @andar," +
                    "numero = @numero, " +
                    "where ID = @id";
                db.AddParameter("@andar", vo.andar, ParameterDirection.Input);
                db.AddParameter("@numero", vo.numero, ParameterDirection.Input);
                db.AddParameter("@id", vo.codigo, ParameterDirection.Input);
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
                string sql = $"delete from apartamento where id = @id";
                db.AddParameter("@id", vo.codigo, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        public VO.Apartamentos carregar(int id)
        {
            string sql = $"SELECT id,andar,numero from apartamento where id=@id";
            db.AddParameter("@id", id, ParameterDirection.Input);
            try
            {
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        vo = LoadApartamento(dr);
                    }
                    return vo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        private VO.Apartamentos LoadApartamento(DbDataReader dr)
        {
            vo = new VO.Apartamentos();
            vo.codigo = Convert.ToInt32(dr["id"]);
            vo.andar = dr["@andar"] != DBNull.Value ? int.Parse(dr["andar"].ToString()) : 0;
            vo.numero = dr["@numero"] != DBNull.Value ? int.Parse(dr["numero"].ToString()) : 0;

            return vo;
        }

        public List<VO.Apartamentos> listar()
        {
            try
            {
                string sql = "SELECT * FROM apartamento;";
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    var objResultado = new List<VO.Apartamentos>();

                    while (dr.Read())
                    {
                        vo = LoadApartamento(dr);
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
