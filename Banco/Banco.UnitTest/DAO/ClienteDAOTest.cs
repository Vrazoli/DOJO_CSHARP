using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banco.Model;
using Banco.Data;

namespace Banco.UnitTest
{
    [TestClass]
    public class ClienteDAOTest
    {
        [TestMethod]
        public void TestAddCliente()
        {
            Cliente cliente = new Cliente() { CPF = "11111111111", Nome = "José", Idade = 20, RG = "222222222", Sobrenome = "Silva" };
            ClienteDAO clienteDao = new ClienteDAO();

            clienteDao.Add(cliente);

            Assert.IsTrue(cliente.Id > 0);
        }

        [TestMethod]
        public void TestFindCliente()
        {
            Cliente cliente = new Cliente() { CPF = "11111111111", Nome = "José", Idade = 20, RG = "222222222", Sobrenome = "Silva" };
            ClienteDAO clienteDao = new ClienteDAO();

            clienteDao.Add(cliente);
            Assert.IsTrue(clienteDao.Find(cliente).Id == cliente.Id);
        }

        [TestMethod]
        public void TestUpdateCliente()
        {
            Cliente cliente = new Cliente() { CPF = "11111111111", Nome = "José", Idade = 20, RG = "222222222", Sobrenome = "Silva" };
            ClienteDAO clienteDao = new ClienteDAO();

            clienteDao.Add(cliente);

            cliente.Sobrenome = "Jorge";
            clienteDao.Update(cliente);

            Assert.IsTrue(clienteDao.Find(cliente).Sobrenome == cliente.Sobrenome);
        }

        [TestMethod]
        public void TestDeleteCliente()
        {
            Cliente cliente = new Cliente() { CPF = "11111111111", Nome = "José", Idade = 20, RG = "222222222", Sobrenome = "Silva" };
            ClienteDAO clienteDao = new ClienteDAO();

            clienteDao.Add(cliente);
            Assert.IsTrue(clienteDao.Find(cliente).Id > 0);

            clienteDao.Delete(cliente);
            Assert.IsNull(clienteDao.Find(cliente));
        }

    }
}
