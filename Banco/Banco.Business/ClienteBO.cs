using Banco.Model;
using Banco.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Business
{
    public class ClienteBO : IBusiness<Cliente>
    {
        private ClienteDAO clienteDao = new ClienteDAO();

        public void Add(Cliente obj)
        {
            clienteDao.Add(obj);
        }

        public void Update(Cliente obj)
        {
            clienteDao.Update(obj);
        }

        public Cliente Find(Cliente obj)
        {
            return clienteDao.Find(obj);
        }

        public void Delete(Cliente obj)
        {
            clienteDao.Delete(obj);
        }
    }
}
