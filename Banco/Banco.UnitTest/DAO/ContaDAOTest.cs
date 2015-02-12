using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banco.Data;
using Banco.Model;

namespace Banco.UnitTest
{
    [TestClass]
    public class ContaDAOTest
    {
        [TestMethod]
        public void TestAddConta()
        {
            Conta conta = new Conta() { Saldo = 500.00M };
            ContaDAO contaDao = new ContaDAO();

            contaDao.Add(conta);

            Assert.IsTrue(conta.Id > 0);
        }

        [TestMethod]
        public void TestUpdateConta()
        {
            Conta conta = new Conta() { Saldo = 700.00M };
            ContaDAO contaDao = new ContaDAO();

            contaDao.Add(conta);

            conta.Saldo = 100.39M;
            contaDao.Update(conta);

            Assert.IsTrue(contaDao.Find(conta).Saldo == conta.Saldo);
        }

        [TestMethod]
        public void TestDeleteConta()
        {
            Conta conta = new Conta() { Saldo = 700.00M };
            ContaDAO contaDao = new ContaDAO();

            contaDao.Add(conta);
            Assert.IsTrue(contaDao.Find(conta).Id > 0);

            contaDao.Delete(conta);
            Assert.IsNull(contaDao.Find(conta));
        }

        [TestMethod]
        public void TestFindConta()
        {
            Conta conta = new Conta() { Saldo = 700.00M };
            ContaDAO contaDao = new ContaDAO();


            contaDao.Add(conta);
            Assert.IsTrue(contaDao.Find(conta).Id == conta.Id);
        }

    }
}
