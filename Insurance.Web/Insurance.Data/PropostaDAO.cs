using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Model;
namespace Insurance.Data
{
  public  class PropostaDAO : IData<Proposta>
    {

        private SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["InsuranceDatabase"].ConnectionString);
        private SqlDataReader consulta;

        public Proposta Find(Proposta obj)
        {

            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("SELECT IDCARRO,VALORBASE,ID FROM PROPOSTA WHERE ID=@ID");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@ID", obj.Id);
                consulta = comando.ExecuteReader();
                Proposta proposta = null;
                if (consulta.Read())
                {
                    proposta = new Proposta()
                    {
                        Id = consulta.GetInt32(2),
                        ValorBase = consulta.GetDecimal(1),
                        IdCarro = consulta.GetInt32(0),

                    };
                }
                return proposta;
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

        public IList<Proposta> FindAll()
        {

            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("SELECT IDCARRO,VALORBASE,ID FROM PROPOSTA");
                comando.Connection = Conexao;
                consulta = comando.ExecuteReader();
                IList<Proposta> propostas = new List<Proposta>();

                while (consulta.Read())
                {
                    propostas.Add(new Proposta()
                    {
                        Id = consulta.GetInt32(2),
                        ValorBase = consulta.GetDecimal(1),
                        IdCarro = consulta.GetInt32(0),

                    });
                }
                return propostas;
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

        public void add(Proposta obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO PROPOSTA (ID,IDCARRO,VALORBASE) VALUES (@ID,@IDCARRO,@VALORBASE) SET @ID= (Select @@identity)");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@ID", obj.Id);
                comando.Parameters.AddWithValue("@IDCARRO", obj.IdCarro);
                comando.Parameters.AddWithValue("@VALORBASE", obj.ValorBase);
                SqlParameter IDSaida = new SqlParameter();
                IDSaida.SqlDbType = System.Data.SqlDbType.Int;
                IDSaida.ParameterName = "@ID";
                IDSaida.Direction = System.Data.ParameterDirection.ReturnValue;
                comando.Parameters.Add(IDSaida);
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

        public void remove(Proposta obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM PROPOSTA WHERE ID=@ID");
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

        public void update(Proposta obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("UPDATE PROPOSTA SET IDCARRO=@IDCARRO,VALORBASE=@VALORBASE WHERE ID=@ID");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@IDCARRO", obj.IdCarro);
                comando.Parameters.AddWithValue("@VALORBASE", obj.ValorBase);
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



        public IList<Proposta> findAll()
        {

            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("SELECT IDCARRO,VALORBASE,ID FROM Proposta ");
                comando.Connection = Conexao;
                consulta = comando.ExecuteReader();
                IList<Proposta> propostas = new List<Proposta>();
                while (consulta.Read())
                {
                    propostas.Add(new Proposta()
                   {
                       Id = consulta.GetInt32(2),
                       ValorBase = consulta.GetDecimal(1),
                       IdCarro = consulta.GetInt32(0),
                   });
                }
                return propostas;
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

        public IList<Proposta> FindAll(Proposta obj)
        {
            IList<Proposta> propostas = new List<Proposta>();
            string consulta = "select ID,IDCARRO,VALORBASE ";
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

                if ( obj.ValorBase > 0)
                {
                    if (primeiro)
                    {
                        consulta += "Where VALORBASE=@VALORBASE ";
                        primeiro = false;
                    }
                    else
                    {
                        consulta += "and VALORBASE=@VALORBASE ";
                    }
                }
            }
                consulta += " FROM Proposta";
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

                        if (consulta.IndexOf("@VALORBASE") >= 0)
                        {
                            comando.Parameters.AddWithValue("@VALORBASE", obj.ValorBase);
                        }

                    }

                    this.consulta = comando.ExecuteReader();
                    while (this.consulta.Read())
                    {
                        propostas.Add(new Proposta()
                          {
                              Id = this.consulta.GetInt32(0),
                              ValorBase = this.consulta.GetDecimal(2),
                              IdCarro = this.consulta.GetInt32(1),
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

            

            return propostas;
        }
    }
}
