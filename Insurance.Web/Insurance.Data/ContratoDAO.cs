using Insurance.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Data
{


    public class ContratoDAO : IData<Contrato>
    {

        private SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["InsuranceDatabase"].ConnectionString);
        private SqlDataReader consulta;

        public Contrato Find(Contrato obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("SELECT ID,VALOR,IDCLIENTE,IDCARRO FROM CONTRATO WHERE ID=@ID ");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@ID", obj.Id);
                consulta = comando.ExecuteReader();
                Contrato contrato = null;
                if (consulta.Read())
                {
                    contrato = new Contrato()
                    {
                        Id = consulta.GetInt32(0),
                        Valor = consulta.GetDecimal(1),
                        IdCliente = consulta.GetInt32(2),
                        IdCarro = consulta.GetInt32(3)
                    };
                }
                return contrato;
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                consulta.Close();
                Conexao.Close();
            }
        }

        public IList<Contrato> FindAll()
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("SELECT ID,VALOR,IDCLIENTE,IDCARRO FROM CONTRATO  ");
                comando.Connection = Conexao;
                consulta = comando.ExecuteReader();
                IList<Contrato> contratos = new List<Contrato>();
                while (consulta.Read())
                {
                    contratos.Add(new Contrato()
                    {
                        Id = consulta.GetInt32(0),
                        Valor = consulta.GetDecimal(1),
                        IdCliente = consulta.GetInt32(2),
                        IdCarro = consulta.GetInt32(3)
                    });
                }
                return contratos;
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                consulta.Close();
                Conexao.Close();
            }
        }

        public void add(Contrato obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO CONTRATO (VALOR,IDCLIENTE,IDCARRO) VALUES (@VALOR,@IDCLIENTE,@IDCARRO) SET @ID= (Select @@identity)");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@ID", obj.Id);
                comando.Parameters.AddWithValue("@VALOR", obj.Valor);
                comando.Parameters.AddWithValue("@IDCARRO", obj.IdCarro);
                comando.Parameters.AddWithValue("@IDCLIENTE", obj.IdCliente);
                comando.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                obj.Id = (int)comando.Parameters["@ID"].Value;
            }


            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Conexao.Close();
            }
        }

        public void remove(Contrato obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM CADASTRO WHERE ID=@ID");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@ID", obj.Id);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Conexao.Close();
            }
        }

        public void update(Contrato obj)
        {

            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("UPDATE CADASTRO SET VALOR=@VALOR,IDCLIENTE=@IDCLIENTE,IDCARRO=@IDCARRO WHERE ID=@ID");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@IDCARRO", obj.IdCarro);
                comando.Parameters.AddWithValue("@VALOR", obj.Valor);
                comando.Parameters.AddWithValue("@ID", obj.Id);
                comando.Parameters.AddWithValue("@IDCLIENTE", obj.IdCliente);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Conexao.Close();
            }
        }

        public IList<Contrato> FindAll(Contrato obj)
        {
            IList<Contrato> contratos = new List<Contrato>();
            string consulta = "select ID,IDCARRO,VALOR,IDCLIENTE ";
            bool primeiro = true;
            if (obj.Id > 0)
            {
                consulta += "where ID=@ID ";
            }
            else
            {
                if (obj.IdCarro > 0)
                {
                    if (primeiro)
                    {
                        consulta += "Where IDCARRO=@IDCARRO ";
                        primeiro = false;
                    }
                    else
                    {
                        consulta += "and IDCARRO=@IDCARRO ";
                    }
                }

                if (obj.Valor > 0)
                {
                    if (primeiro)
                    {
                        consulta += "Where VALOR=@VALOR ";
                        primeiro = false;
                    }
                    else
                    {
                        consulta += "and VALOR=@VALOR ";
                    }
                }


                if (obj.IdCliente > 0)
                {
                    if (primeiro)
                    {
                        consulta += "Where IDCLIENTE=@IDCLIENTE ";
                        primeiro = false;
                    }
                    else
                    {
                        consulta += "and IDCLIENTE=@IDCLIENTE ";
                    }
                }

            }
            consulta += " FROM Contrato";
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand(consulta);
                comando.Connection = Conexao;
                if (consulta.IndexOf("@ID") >= 0)
                {
                    comando.Parameters.AddWithValue("@ID", obj.Id);
                }
                else
                {
                    if (consulta.IndexOf("@IDCARRO") >= 0)
                    {
                        comando.Parameters.AddWithValue("@IDCARRO", obj.IdCarro);
                    }

                    if (consulta.IndexOf("@VALOR") >= 0)
                    {
                        comando.Parameters.AddWithValue("@VALORBASE", obj.Valor);
                    }

                    if (consulta.IndexOf("@IDCLIENTE") >= 0)
                    {
                        comando.Parameters.AddWithValue("@IDCLIENTE", obj.IdCliente);
                    }


                }

                this.consulta = comando.ExecuteReader();
                while (this.consulta.Read())
                {
                    contratos.Add(new Contrato()
                     {
                         Id = this.consulta.GetInt32(0),
                         Valor = this.consulta.GetDecimal(1),
                         IdCliente = this.consulta.GetInt32(2),
                         IdCarro = this.consulta.GetInt32(3)
                     });
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            finally
            {
                this.consulta.Close();
                Conexao.Close();
            }



            return contratos;
        }
    }
}
