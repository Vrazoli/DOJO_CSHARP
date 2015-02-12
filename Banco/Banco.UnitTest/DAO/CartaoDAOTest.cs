using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banco.Model;
using Banco.Data;

namespace Banco.UnitTest.DAO
{
    [TestClass]
    public class CartaoDAOTest
    {
        [TestMethod]
        public void TestAddCartao()
        {
            Cliente cliente = new Cliente() { CPF = "11111111111", Nome = "José", Idade = 20, RG = "222222222", Sobrenome = "Silva" };
            ClienteDAO clienteDao = new ClienteDAO();

            clienteDao.Add(cliente);

            Assert.IsTrue(cliente.Id > 0);


            Conta conta = new Conta() { Saldo = 500.00M };
            ContaDAO contaDao = new ContaDAO();

            contaDao.Add(conta);

            Assert.IsTrue(conta.Id > 0);


            Cartao cartao = new Cartao() { Validade = DateTime.Now.AddYears(5), Conta = conta, Cliente = cliente };
            CartaoDAO cartaoDao = new CartaoDAO();

            cartaoDao.Add(cartao);

            Assert.IsTrue(cartao.Id > 0);

        }
    }
}
