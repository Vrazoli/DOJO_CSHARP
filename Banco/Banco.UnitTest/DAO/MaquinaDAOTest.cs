using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banco.Model;
using Banco.Data;

namespace Banco.UnitTest
{
    [TestClass]
    public class MaquinaDAOTest
    {
         [TestMethod]
        public void TestAddMaquina()
        {
            Maquina maquina = new Maquina() { ValorDisponivel = 500.00M };
            MaquinaDAO maquinaDao = new MaquinaDAO();

            maquinaDao.Add(maquina);

            Assert.IsTrue(maquina.Id > 0);
        }

        [TestMethod]
        public void TestUpdateMaquina()
        {
            Maquina maquina = new Maquina() { ValorDisponivel = 700.00M };
            MaquinaDAO maquinaDao = new MaquinaDAO();

            maquinaDao.Add(maquina);

            maquina.ValorDisponivel = 100.39M;
            maquinaDao.Update(maquina);

            Assert.IsTrue(maquinaDao.Find(maquina).ValorDisponivel == maquina.ValorDisponivel);
        }

        [TestMethod]
        public void TestDeleteMaquina()
        {
            Maquina maquina = new Maquina() { ValorDisponivel = 700.00M };
            MaquinaDAO maquinaDao = new MaquinaDAO();

            maquinaDao.Add(maquina);
            Assert.IsTrue(maquinaDao.Find(maquina).Id > 0);

            maquinaDao.Delete(maquina);
            Assert.IsNull(maquinaDao.Find(maquina));
        }

        [TestMethod]
        public void TestFindMaquina()
        {
            Maquina maquina = new Maquina() { ValorDisponivel = 700.00M };
            MaquinaDAO maquinaDao = new MaquinaDAO();


            maquinaDao.Add(maquina);
            Assert.IsTrue(maquinaDao.Find(maquina).Id == maquina.Id);
        }
    }
}
