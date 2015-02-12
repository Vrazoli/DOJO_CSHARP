using Banco.Data;
using Banco.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Business
{
    public class ContaBO : IBusiness<Conta>
    {
        public bool VerificaSaldo(Conta conta, decimal valor)
        {
            return (conta.Saldo >= valor);
        }

        private void AtualizaSaldo(Conta conta, decimal valor)
        {

            conta.Saldo += valor;

        }


        public void Saque(Conta conta, decimal valor)
        {

            this.AtualizaSaldo(conta, -valor);

        }



        public void Deposito(Conta conta, decimal valor)
        {
            this.AtualizaSaldo(conta,valor);
        }



        private ContaDAO contaDao = new ContaDAO();

        public void Add(Conta obj)
        {
            contaDao.Add(obj);
        }

        public void Update(Conta obj)
        {
            contaDao.Update(obj);
        }

        public Conta Find(Conta obj)
        {
            return contaDao.Find(obj);
        }

        public void Delete(Conta obj)
        {
            contaDao.Delete(obj);
        }
    }
}
