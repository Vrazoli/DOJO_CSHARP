using Banco.Data;
using Banco.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Business
{
    public class CartaoBO : IBusiness<Cartao>
    {

        public bool VerificaValidade(Cartao cartao)
        {
            return (cartao.Validade > DateTime.Now);
        }

        private CartaoDAO cartaoDao = new CartaoDAO();

        public void Add(Cartao obj)
        {
            cartaoDao.Add(obj);
        }

        public void Update(Cartao obj)
        {
            cartaoDao.Update(obj);
        }

        public Cartao Find(Cartao obj)
        {
            return cartaoDao.Find(obj);
        }

        public void Delete(Cartao obj)
        {
            cartaoDao.Delete(obj);
        }
    }
}
