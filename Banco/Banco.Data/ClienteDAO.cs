using Banco.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data
{
    public class ClienteDAO : IData<Cliente>
    {
        Database db = new DatabaseProviderFactory().Create("Banco");

        public void Add(Cliente obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("INSERT INTO Cliente (Cpf, Rg, Nome, Sobrenome, Idade) VALUES (@Cpf,@Rg,@Nome,@Sobrenome,@Idade) set @Id = (Select @@identity)"))
            {
                db.AddInParameter(cmd, "@Cpf", System.Data.DbType.String, obj.CPF);
                db.AddInParameter(cmd, "@Rg", System.Data.DbType.String, obj.RG);
                db.AddInParameter(cmd, "@Nome", System.Data.DbType.String, obj.Nome);
                db.AddInParameter(cmd, "@Sobrenome", System.Data.DbType.String, obj.Sobrenome);
                db.AddInParameter(cmd, "@Idade", System.Data.DbType.Int32, obj.Idade);

                db.AddOutParameter(cmd, "@Id", System.Data.DbType.Int32, 4);

                db.ExecuteNonQuery(cmd);
                obj.Id = (int)cmd.Parameters["@Id"].Value;
            }
        }

        public void Update(Cliente obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("update cliente set nome=@NOME,sobrenome=@SOBRENOME,idade=@IDADE,cpf=@CPF,rg=@RG where id=@ID"))
            {
                db.AddInParameter(cmd, "@CPF", System.Data.DbType.String, obj.CPF);
                db.AddInParameter(cmd, "@RG", System.Data.DbType.String, obj.RG);
                db.AddInParameter(cmd, "@NOME", System.Data.DbType.String, obj.Nome);
                db.AddInParameter(cmd, "@SOBRENOME", System.Data.DbType.String, obj.Sobrenome);
                db.AddInParameter(cmd, "@IDADE", System.Data.DbType.Int32, obj.Idade);
                db.AddInParameter(cmd, "@ID", System.Data.DbType.Int32, obj.Id);
                db.ExecuteNonQuery(cmd);

            }
        }

        public void Delete(Cliente obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("DELETE FROM cliente where id = @id"))
            {
                db.AddInParameter(cmd, "@id", System.Data.DbType.Int32, obj.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public Cliente Find(Cliente obj)
        {
            Cliente cliente = null;
            using (DbCommand cmd = db.GetSqlStringCommand("SELECT Cpf, Rg, Nome, Sobrenome, Idade, Id FROM Cliente WHERE Id = @Id"))
            {
                db.AddInParameter(cmd, "@Id", System.Data.DbType.Int32, obj.Id);

                IDataReader reader = db.ExecuteReader(cmd);
                if (reader.Read())
                {
                    cliente = new Cliente
                    {
                        CPF = Convert.ToString(reader["Cpf"]),
                        RG = Convert.ToString(reader["Rg"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        Idade = Convert.ToInt32(reader["Idade"]),
                        Sobrenome = Convert.ToString(reader["Sobrenome"]),
                        Id = Convert.ToInt32(reader["Id"])
                    };
                }
                return cliente;
            }
        }

        public Cliente FindById(int id)
        {
            return this.Find(new Cliente() { Id = id });
        }
    }
}
