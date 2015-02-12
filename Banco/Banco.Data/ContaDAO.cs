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
    public class ContaDAO : IData<Conta>
    {
        Database db = new DatabaseProviderFactory().Create("Banco");

        public void Add(Conta obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("INSERT INTO Conta (Saldo) VALUES (@saldo) set @Id = (Select @@identity)"))
            {
                db.AddInParameter(cmd, "@saldo", System.Data.DbType.Decimal, obj.Saldo);

                db.AddOutParameter(cmd, "@Id", System.Data.DbType.Int32, 4);

                db.ExecuteNonQuery(cmd);
                obj.Id = (int)cmd.Parameters["@Id"].Value;
            }
        }

        public void Update(Conta obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("update conta set saldo=@SALDO where id=@ID"))
            {
                db.AddInParameter(cmd, "@SALDO", System.Data.DbType.Decimal, obj.Saldo);
                db.AddInParameter(cmd, "@ID", System.Data.DbType.Int32, obj.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(Conta obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("delete from conta where id=@ID"))
            {
                db.AddInParameter(cmd, "@ID", System.Data.DbType.Int32, obj.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        public Conta Find(Conta obj)
        {
            Conta conta = null;
            using (DbCommand cmd = db.GetSqlStringCommand("SELECT Saldo, Id FROM Conta WHERE Id = @Id"))
            {
                db.AddInParameter(cmd, "@Id", System.Data.DbType.Int32, obj.Id);

                IDataReader reader = db.ExecuteReader(cmd);

                if (reader.Read())
                {
                    conta = new Conta
                    {
                        Saldo = Convert.ToDecimal(reader["Saldo"]),
                        Id = Convert.ToInt32(reader["Id"])
                    };
                }

                return conta;
            }
        }

        public Conta FindById(int id)
        {
            return this.Find(new Conta() { Id = id });
        }
    }
}
