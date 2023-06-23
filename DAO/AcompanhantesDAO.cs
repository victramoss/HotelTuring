using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using hotel_turing.DAO.DataAccess;

namespace hotel_turing.DAO
{
    public class AcompanhantesDAO : BaseDAO
    {
        private VO.Acompanhantes vo;

        public AcompanhantesDAO(VO.Acompanhantes vo)
        {

            if (DAO.listaAcompanhantes == null)
            {
                DAO.listaAcompanhantes = new List<VO.Acompanhantes>();
            }
            this.vo = vo;
        }

        public void incluir()
        {
            try
            {
                string sql = "insert into hospede_reserva (id_reserva,id_hospede,descricao) " +
                    "values (@id_reserva,@id_hospede,@descricao)";
                db.AddParameter("@id_reserva", vo.id_reservatitular, ParameterDirection.Input);
                db.AddParameter("@id_hospede", vo.id_hospedetitular, ParameterDirection.Input);
                db.AddParameter("@descricao", vo.descricao, ParameterDirection.Input);
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
                string sql = "update hospede_reserva set " +
                    "id_reserva = @id_reserva," +
                    "id_hospede = @id_hospede ," +
                    "descricao = @descricao " +
                    "where id = @id";
                db.AddParameter("@id_reserva", vo.id_reservatitular, ParameterDirection.Input);
                db.AddParameter("@id_hospede", vo.id_hospedetitular, ParameterDirection.Input);
                db.AddParameter("@descricao", vo.descricao, ParameterDirection.Input);
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
                string sql = $"delete from hospede_reserva where id = @id";
                db.AddParameter("@id", vo.id_hospedetitular, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        public VO.Acompanhantes carregar(int id)
        {
            string sql = $"SELECT id,id_hospede,id_reserva,descricao, from hospede_reserva where id=@id";
            db.AddParameter("@id", id, ParameterDirection.Input);
            try
            {
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        vo = LoadAcompanhantes(dr);
                    }
                    return vo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        private VO.Acompanhantes LoadAcompanhantes(DbDataReader dr)
        {
            vo = new VO.Acompanhantes();
            vo.codigo = Convert.ToInt32(dr["id"]);
            vo.id_hospedetitular = dr["@id_hospede"] != DBNull.Value ? int.Parse(dr["id_hospede"].ToString()) : 0;
            vo.id_reservatitular = dr["@id_reserva"] != DBNull.Value ? int.Parse(dr["id_reserva"].ToString()) : 0;
            vo.descricao = dr["descricao"] != DBNull.Value ? dr["descricao"].ToString() : "";




            return vo;
        }

        public List<VO.Acompanhantes> listar()
        {
            try
            {
                string sql = "SELECT * FROM hospede_reserva;";
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    var objResultado = new List<VO.Acompanhantes>();

                    while (dr.Read())
                    {
                        vo = LoadAcompanhantes(dr);
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
