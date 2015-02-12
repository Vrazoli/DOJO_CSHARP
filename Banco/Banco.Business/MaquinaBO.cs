using Banco.Business.Exceptions;
using Banco.Data;
using Banco.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Business
{
    public class MaquinaBO : IBusiness<Maquina>
    {
        public void Saque(Maquina maquina, Cartao cartao, decimal valor)
        {
            if (maquina.ValorDisponivel < valor)
                throw new CustomException("Maquina não possui dinheiro suficiente para a transação.");

            CartaoBO cartaobo = new CartaoBO();

            if (!cartaobo.VerificaValidade(cartao))
                throw new CustomException("Cartão invalido.");

            ContaBO contaBO = new ContaBO();

            if (!contaBO.VerificaSaldo(cartao.Conta, valor))
                throw new CustomException("Cliente não possui saldo para a transação.");

            this.AtualizaValorDisponivel(maquina, valor);
            contaBO.Saque(cartao.Conta, valor);
        }

        public void AtualizaValorDisponivel(Maquina maquina, decimal valor)
        {
            maquina.ValorDisponivel -= valor;
        }

        private MaquinaDAO maquinaDao = new MaquinaDAO();

        public void Add(Maquina obj)
        {
            maquinaDao.Add(obj);
        }

        public void Update(Maquina obj)
        {
            maquinaDao.Update(obj);
        }

        public Maquina Find(Maquina obj)
        {
            return maquinaDao.Find(obj);
        }

        public void Delete(Maquina obj)
        {
            maquinaDao.Delete(obj);
        }
    }
}
