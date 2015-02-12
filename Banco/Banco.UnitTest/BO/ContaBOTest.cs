using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banco.Model;
using Banco.Business;

namespace Banco.UnitTest
{
    [TestClass]
    public class ContaBOTest
    {
        [TestMethod]
        public void TesteVerificaSaldoValido()
        {
            Conta conta = new Conta() { Saldo = 250.00M };
            ContaBO contaBO = new ContaBO();

            Assert.IsTrue(contaBO.VerificaSaldo(conta,200.00M));
        }

        [TestMethod]
        public void TesteVerificaSaldoInvalido()
        {
            Conta conta = new Conta() { Saldo = 250.00M };
            ContaBO contaBO = new ContaBO();

            Assert.IsFalse(contaBO.VerificaSaldo(conta, 300.00M));
        }

        [TestMethod]
        public void TesteSaque()
        {
            Conta conta = new Conta() { Saldo = 200.00M };
            ContaBO contaBO = new ContaBO();

            contaBO.Saque(conta,100.00M);
            Assert.IsTrue(conta.Saldo == 100.00M);
        }

        [TestMethod]
        public void TesteSaqueFail()
        {
            Conta conta = new Conta() { Saldo = 200.00M };
            ContaBO contaBO = new ContaBO();

            contaBO.Saque(conta, 100.00M);
            Assert.IsFalse(conta.Saldo == 150.00M);
        }

        [TestMethod]
        public void TesteDeposito()
        {
            Conta conta = new Conta() { Saldo = 200.00M };
            ContaBO contaBO = new ContaBO();

            contaBO.Deposito(conta, 100.00M);
            Assert.IsTrue(conta.Saldo == 300.00M);
        }

        [TestMethod]
        public void TesteDepositoFail()
        {
            Conta conta = new Conta() { Saldo = 200.00M };
            ContaBO contaBO = new ContaBO();

            contaBO.Deposito(conta, 100.00M);
            Assert.IsFalse(conta.Saldo == 350.00M);
        }


    }
}
