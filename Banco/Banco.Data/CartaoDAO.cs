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
    public class CartaoDAO : IData<Cartao>
    {
        Database db = new DatabaseProviderFactory().Create("Banco");
        public void Add(Cartao obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("INSERT INTO Cartao (validade,idCliente,idConta) VALUES (@VALIDADE,@IDCLIENTE,@IDCONTA) set @ID = (Select @@identity)"))
            {
                db.AddInParameter(cmd, "@VALIDADE", System.Data.DbType.DateTime, obj.Validade);
                db.AddInParameter(cmd, "@IDCLIENTE", System.Data.DbType.Int32, obj.Cliente.Id);
                db.AddInParameter(cmd, "IDCONTA", System.Data.DbType.Int32, obj.Conta.Id);

                db.AddOutParameter(cmd, "@Id", System.Data.DbType.Int32, 4);
                db.ExecuteNonQuery(cmd);
                obj.Id = (int)cmd.Parameters["@Id"].Value;
            }
        }

        public void Update(Cartao obj)
        {

            using (DbCommand cmd = db.GetSqlStringCommand("update Cartao set validade=@validade where id=@ID"))
            {
                db.AddInParameter(cmd, "@validade", System.Data.DbType.DateTime, obj.Validade);
                db.AddInParameter(cmd, "@ID", System.Data.DbType.Int32, obj.Id);
                db.ExecuteNonQuery(cmd);

            }

        }

        public Cartao Find(Cartao obj)
        {
            Cartao cartao = null;

            ContaDAO contaDao = new ContaDAO();
            ClienteDAO clienteDao = new ClienteDAO();

            using (DbCommand cmd = db.GetSqlStringCommand("SELECT id, validade ,idConta ,idCliente FROM Cartao WHERE Id = @Id"))
            {
                db.AddInParameter(cmd, "@Id", System.Data.DbType.Int32, obj.Id);

                IDataReader reader = db.ExecuteReader(cmd);
                if (reader.Read())
                {
                    cartao = new Cartao
                    {
                        Validade = Convert.ToDateTime(reader["validade"]),
                        Id = Convert.ToInt32(reader["Id"]),
                        Conta = contaDao.FindById(Convert.ToInt32(reader["idConta"])),
                        Cliente = clienteDao.FindById(Convert.ToInt32(reader["idCliente"])),
                    };
                }
                return cartao;
            }
        }

        public void Delete(Cartao obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("DELETE FROM Cartao where id = @id"))
            {
                db.AddInParameter(cmd, "@id", System.Data.DbType.Int32, obj.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
