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
    public class MaquinaDAO : IData<Maquina>
    {
        Database db = new DatabaseProviderFactory().Create("Banco");

        public void Add(Maquina obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("INSERT INTO Maquina (ValorDisponivel) VALUES (@VALOR) set @Id = (Select @@identity)"))
            {
                db.AddInParameter(cmd, "@VALOR", System.Data.DbType.Decimal, obj.ValorDisponivel);

                db.AddOutParameter(cmd, "@Id", System.Data.DbType.Int32, 4);

                db.ExecuteNonQuery(cmd);
                obj.Id = (int)cmd.Parameters["@Id"].Value;
            }
        }

        public void Update(Maquina obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("update maquina set ValorDisponivel=@VALOR where id=@ID"))
            {
                db.AddInParameter(cmd, "@VALOR", System.Data.DbType.Decimal, obj.ValorDisponivel);
                db.AddInParameter(cmd, "@ID", System.Data.DbType.Int32, obj.Id);
                
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(Maquina obj)
        {
            using (DbCommand cmd = db.GetSqlStringCommand("DELETE FROM Maquina where id = @id"))
            {
                db.AddInParameter(cmd, "@id", System.Data.DbType.Int32, obj.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public Maquina Find(Maquina obj)
        {
            Maquina maquina = null;

            using (DbCommand cmd = db.GetSqlStringCommand("SELECT ValorDisponivel, Id FROM Maquina WHERE Id = @Id"))
            {
                db.AddInParameter(cmd, "@Id", System.Data.DbType.Int32, obj.Id);

                IDataReader reader = db.ExecuteReader(cmd);

                if (reader.Read())
                {
                    maquina = new Maquina
                    {
                        ValorDisponivel = Convert.ToDecimal(reader["ValorDisponivel"]),
                        Id = Convert.ToInt32(reader["Id"])
                    };
                }

                return maquina;
            }
        }
    }
}
