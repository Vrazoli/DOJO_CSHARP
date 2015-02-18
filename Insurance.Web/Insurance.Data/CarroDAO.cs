using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Model;
using System.Data;
namespace Insurance.Data
{
  public  class CarroDAO : IData<Carro>
    {

        private SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["InsuranceDatabase"].ConnectionString);
        private SqlDataReader consulta;


        public Carro Find(Carro obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("SELECT ID,ANO,FOTO,MARCA,MODELO FROM CARRO WHERE ID=@ID");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@ID", obj.Id);
                consulta = comando.ExecuteReader();
                Carro carro = null;
                if (consulta.Read())
                {
                    carro = new Carro()
                    {
                        Id = consulta.GetInt32(0),
                        Ano = consulta.GetInt32(1),
                        Foto = consulta.GetString(2),
                        Marca = consulta.GetString(3),
                        Modelo = consulta.GetString(4)
                    };
                }
                return carro;
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

        public IList<Carro> FindAll()
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("SELECT ID,ANO,FOTO,MARCA,MODELO FROM CARRO ");
                comando.Connection = Conexao;
                consulta = comando.ExecuteReader();
                IList<Carro> Carros = new List<Carro>();
                while (consulta.Read())
                {
                    Carros.Add(new Carro()
                    {
                        Id = consulta.GetInt32(0),
                        Ano = consulta.GetInt32(1),
                        Foto = consulta.GetString(2),
                        Marca = consulta.GetString(3),
                        Modelo = consulta.GetString(4)
                    });
                }
                return Carros;
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




        public void add(Carro obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO CARRO (ANO,FOTO,MARCA,MODELO) VALUES (@ANO,@FOTO,@MARCA,@MODELO) SET @ID= (Select @@identity)");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@ANO", obj.Ano);
                comando.Parameters.AddWithValue("@FOTO", obj.Foto);
                comando.Parameters.AddWithValue("@MARCA", obj.Marca);
                comando.Parameters.AddWithValue("@MODELO", obj.Modelo);
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

        public void remove(Carro obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM CARRO WHERE ID=@ID");
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

        public void update(Carro obj)
        {

            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("UPDATE CARRO SET ANO=@ANO,FOTO=@FOTO,MARCA=@MARCA,MODELO=@MODELO WHERE ID=@ID");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@ANO", obj.Ano);
                comando.Parameters.AddWithValue("@FOTO", obj.Foto);
                comando.Parameters.AddWithValue("@MARCA", obj.Marca);
                comando.Parameters.AddWithValue("@MODELO", obj.Modelo);
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

        public IList<Carro> FindAll(Carro obj)
        {

            IList<Carro> Carros = new List<Carro>();
            string consulta = "select ANO,FOTO,MARCA,MODELO,ID ";
            bool primeiro = true;
            if (obj.Id > 0)
            {
                consulta += "where ID=@ID ";
            }
            else
            {
                if (obj.Ano > 0)
                {
                    consulta += "where ANO=@ANO ";
                    primeiro = false;
                }

                if (obj.Marca != null && obj.Marca != "")
                {
                    if (primeiro)
                    {
                        consulta += "Where MARCA=@MARCA ";
                        primeiro = false;
                    }
                    else
                    {
                        consulta += "and MARCA=@MARCA ";
                    }
                }
                if (obj.Modelo != null && obj.Modelo != "")
                {
                    if (primeiro)
                    {
                        consulta += "Where MODELO=@MODELO";
                    }
                    else
                    {
                        consulta += "and MODELO=@MODELO";
                    }
                }
            }
            consulta += " FROM Carro";
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
                    if (consulta.IndexOf("@ANO") >= 0)
                    {
                        comando.Parameters.AddWithValue("@ANO", obj.Ano);
                    }

                    if (consulta.IndexOf("@MARCA") >= 0)
                    {
                        comando.Parameters.AddWithValue("@MARCA", obj.Marca);
                    }
                    if (consulta.IndexOf("@MODELO") >= 0)
                    {
                        comando.Parameters.AddWithValue("@MODELO", obj.Modelo);
                    }
                }

                this.consulta = comando.ExecuteReader();
                while (this.consulta.Read())
                {

                    Carros.Add(new Carro()
                    {
                        Id = this.consulta.GetInt32(0),
                        Ano = this.consulta.GetInt32(1),
                        Foto = this.consulta.GetString(2),
                        Marca = this.consulta.GetString(3),
                        Modelo = this.consulta.GetString(4)
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

            return Carros;
        }
    }
}
