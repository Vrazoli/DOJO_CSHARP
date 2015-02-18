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
    public class ClienteDAO : IData<Cliente>
    {

        private SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["InsuranceDatabase"].ConnectionString);
        private SqlDataReader consulta;


        public Cliente Find(Cliente obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("SELECT NOME,SOBRENOME,RG,CPF,SEXO,IDADE,ID FROM CLIENTE WHERE ID=@ID");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@ID", obj.Id);
                consulta = comando.ExecuteReader();
                Cliente cliente = null;
                if (consulta.Read())
                {
                    cliente = new Cliente()
                    {
                        Nome = consulta.GetString(0),
                        Sobrenome = consulta.GetString(1),
                        RG = consulta.GetString(2),
                        CPF = consulta.GetString(3),
                        Sexo = consulta.GetString(4)[0],
                        Idade = consulta.GetInt32(5),
                        Id = consulta.GetInt32(6)
                    };
                }
                return cliente;
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


        public IList<Cliente> FindAll()
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("SELECT NOME,SOBRENOME,RG,CPF,SEXO,IDADE,ID FROM CLIENTE");
                comando.Connection = Conexao;
                consulta = comando.ExecuteReader();
                IList<Cliente> Clientes = new List<Cliente>();
                while (consulta.Read())
                {
                    Clientes.Add(new Cliente()
                    {
                        Nome = consulta.GetString(0),
                        Sobrenome = consulta.GetString(1),
                        RG = consulta.GetString(2),
                        CPF = consulta.GetString(3),
                        Sexo = consulta.GetString(4)[0],
                        Idade = consulta.GetInt32(5),
                        Id = consulta.GetInt32(6)
                    });
                }
                return Clientes;
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

        public void add(Cliente obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO CLIENTE (NOME,SOBRENOME,RG,CPF,SEXO,IDADE) VALUES (@NOME,@SOBRENOME,@RG,@CPF,@SEXO,@IDADE) SET @ID= (Select @@identity)");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@NOME", obj.Nome);
                comando.Parameters.AddWithValue("@SOBRENOME", obj.Sobrenome);
                comando.Parameters.AddWithValue("@RG", obj.RG);
                comando.Parameters.AddWithValue("@CPF", obj.CPF);
                comando.Parameters.AddWithValue("@SEXO", obj.Sexo);
                comando.Parameters.AddWithValue("@IDADE", obj.Idade);
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

        public void remove(Cliente obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM CLIENTE WHERE ID=@ID");
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

        public void update(Cliente obj)
        {
            try
            {
                Conexao.Open();
                SqlCommand comando = new SqlCommand("UPDATE CLIENTE SET NOME=@NOME,SOBRENOME=@SOBRENOME,RG=@RG,CPF=@CPF,SEXO=@SEXO,IDADE=@IDADE WHERE ID=@ID");
                comando.Connection = Conexao;
                comando.Parameters.AddWithValue("@NOME", obj.Nome);
                comando.Parameters.AddWithValue("@SOBRENOME", obj.Sobrenome);
                comando.Parameters.AddWithValue("@RG", obj.RG);
                comando.Parameters.AddWithValue("@CPF", obj.CPF);
                comando.Parameters.AddWithValue("@SEXO", obj.Sexo);
                comando.Parameters.AddWithValue("@IDADE", obj.Idade);

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

        public IList<Cliente> FindAll(Cliente obj)
        {

            IList<Cliente> clientes = new List<Cliente>();
            string consulta = "select ID,NOME,SOBRENOME,RG,CPF,SEXO,IDADE ";
            bool primeiro = true;
            if (obj.Id > 0)
            {
                consulta += "where ID=@ID ";
            }
            else
            {
                if (obj.CPF != null && obj.CPF != "")
                {
                    consulta += "where CPF=@CPF";
                }

                else
                {

                    if (obj.Idade > 0)
                    {


                        if (primeiro)
                        {

                            consulta += "where IDADE=@IDADE ";
                            primeiro = false;
                        }

                        else
                        {

                            consulta += "and IDADE=@IDADE ";

                        }
                    }

                    if (obj.RG != null && obj.RG != "")
                    {
                        if (primeiro)
                        {
                            consulta += "Where RG=@RG ";
                            primeiro = false;
                        }
                        else
                        {
                            consulta += "and RG=@RG ";
                        }
                    }
                    if (obj.Sexo == 'M' || obj.Sexo == 'H')
                    {
                        if (primeiro)
                        {
                            consulta += "WHERE SEXO=@SEXO ";
                            primeiro = false;

                        }
                        else
                        {
                            consulta += "and SEXO=@SEXO ";
                        }
                    }

                    if (obj.Nome != null && obj.Nome != "")
                    {
                        if (primeiro)
                        {
                            consulta += "WHERE NOME=@NOME ";
                            primeiro = false;
                        }
                        else
                        {
                            consulta += "and NOME=@NOME ";
                        }
                    }

                    if (obj.Sobrenome != null && obj.Sobrenome != "")
                    {
                        if (primeiro)
                        {
                            consulta += "WHERE SOBRENOME=@SOBRENOME";
                            primeiro = false;
                        }
                        else
                        {
                            consulta += "and SOBRENOME=@SOBRENOME";
                        }
                    }

                }
            }
            consulta += " FROM Cliente";
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
                    if (consulta.IndexOf("@CPF") >= 0)
                    {
                        comando.Parameters.AddWithValue("@CPF", obj.CPF);
                    }

                    else
                    {
                        if (consulta.IndexOf("@RG") >= 0)
                        {
                            comando.Parameters.AddWithValue("@RG", obj.RG);
                        }

                        if (consulta.IndexOf("@IDADE") >= 0)
                        {
                            comando.Parameters.AddWithValue("@IDADE", obj.Idade);
                        }
                        if (consulta.IndexOf("@NOME") >= 0)
                        {
                            comando.Parameters.AddWithValue("@NOME", obj.Nome);
                        }

                        if (consulta.IndexOf("@SOBRENOME") >= 0)
                        {
                            comando.Parameters.AddWithValue("@SOBRENOME", obj.Sobrenome);
                        }

                        if (consulta.IndexOf("@SEXO") >= 0)
                        {
                            comando.Parameters.AddWithValue("@SEXO", obj.Sexo);
                        }

                    }

                this.consulta = comando.ExecuteReader();
                while (this.consulta.Read())
                {

                    clientes.Add(new Cliente()
                    {
                        Nome = this.consulta.GetString(0),
                        Sobrenome = this.consulta.GetString(1),
                        RG = this.consulta.GetString(2),
                        CPF = this.consulta.GetString(3),
                        Sexo = this.consulta.GetString(4)[0],
                        Idade = this.consulta.GetInt32(5),
                        Id = this.consulta.GetInt32(6)
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

            return clientes;
        }

    }
}



