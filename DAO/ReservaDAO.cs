using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using hotel_turing.DAO.DataAccess;

namespace hotel_turing.DAO
{
    public class ReservaDAO : BaseDAO
    {
        private VO.Reserva vo;

        public ReservaDAO(VO.Reserva vo)
        {

            if (DAO.listaReserva == null)
            {
                DAO.listaReserva = new List<VO.Reserva>();
            }
            this.vo = vo;
        }
        public void incluir()
        {
            try
            {
                string sql = "insert into reserva (id_apartamento, id_usuario, data_reserva, data_entrada, data_saida, numero_reserva, valor) " +
                    "values (@id_apartamento, @id_usuario, @data_reserva, @data_entrada, @data_saida, @numero_reserva, @valor)";
                db.AddParameter("@id_apartamento", vo.id_apartamento, ParameterDirection.Input);
                db.AddParameter("@id_usuario", vo.id_usuario, ParameterDirection.Input);
                db.AddParameter("@data_entrada", vo.data_entrada, ParameterDirection.Input);
                db.AddParameter("@data_saida", vo.data_saida, ParameterDirection.Input);
                db.AddParameter("@numero_reserva", vo.data_reserva, ParameterDirection.Input);
                db.AddParameter("@valor", vo.valor, ParameterDirection.Input);
                db.AddParameter("@data_reserva", vo.data_reserva, ParameterDirection.Input);
                db.AddParameter("@hospede", vo.hospedes.codigo, ParameterDirection.Input);
                db.AddParameter("@hotel", vo.hotel.codigo, ParameterDirection.Input);
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
                string sql = "update reserva set " +
                    "id_apartamento = @id_apartamento," +
                    "id_usuario = @id_usuario ," +
                    "data_entrada = @data_entrada" +
                    "data_saida = @data_saida" +
                    "numero_reserva = @numero_reserva" +
                    "valor = @valor" +
                    "data_reserva = @data_reserva" +
                    "where id = @id";
                db.AddParameter("@id_apartamento", vo.id_apartamento, ParameterDirection.Input);
                db.AddParameter("@id_usuario", vo.id_usuario, ParameterDirection.Input);
                db.AddParameter("@data_entrada", vo.data_entrada, ParameterDirection.Input);
                db.AddParameter("@data_saida", vo.data_saida, ParameterDirection.Input);
                db.AddParameter("@numero_reserva", vo.data_reserva, ParameterDirection.Input);
                db.AddParameter("@valor", vo.valor, ParameterDirection.Input);
                db.AddParameter("@data_reserva", vo.data_reserva, ParameterDirection.Input);
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
                string sql = $"delete from reserva where id = @id";
                db.AddParameter("@id", vo.codigo, ParameterDirection.Input);
                db.Execute(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        public VO.Reserva carregar(int id)
        {
            string sql = $"SELECT id,id_apartamento, id_usuario, data_reserva, data_entrada, data_saida, numero_reserva, valor from reserva where id=@id";
            db.AddParameter("@id", id, ParameterDirection.Input);
            try
            {
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        vo = LoadReserva(dr);
                    }
                    return vo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Código : " + ex.Message);
            }
        }

        private VO.Reserva LoadReserva(DbDataReader dr)
        {
            vo = new VO.Reserva();
            vo.data_entrada = Convert.ToDateTime(dr["data_entrada"]);
            vo.data_saida = Convert.ToDateTime(dr["data_saida"]);
            vo.data_reserva = dr["data_reserva"] != DBNull.Value ? int.Parse(dr["data_reserva"].ToString()) : 0;
            vo.id_apartamento = dr["@id_apartamento"] != DBNull.Value ? int.Parse(dr["id_apartamento"].ToString()) : 0;
            vo.id_usuario = dr["id_usuraio"] != DBNull.Value ? int.Parse(dr["id_usuario"].ToString()) : 0;
            vo.valor = dr["valor"] != DBNull.Value ? int.Parse(dr["valor"].ToString()) : 0;
            vo.numero_reserva = dr["numero_reserva"] != DBNull.Value ? int.Parse(dr["numero_reserva"].ToString()) : 0;
            
            vo.hospedes = new VO.Hospedes();
            vo.hospedes.codigo = dr["id"] != DBNull.Value ? int.Parse(dr["id"].ToString()) : 0;

            vo.hotel = new VO.Hotel();
            vo.hotel.codigo = dr["id"] != DBNull.Value ? int.Parse(dr["id"].ToString()) : 0;
            return vo;
        }
        public List<VO.Reserva> listar()
        {
            try
            {
                string sql = "SELECT * FROM reserva;";
                using (var dr = db.ExecuteReader(sql, CommandType.Text))
                {
                    var objResultado = new List<VO.Reserva>();

                    while (dr.Read())
                    {
                        vo = LoadReserva(dr);
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
