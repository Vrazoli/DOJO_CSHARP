using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banco.Model;
using Banco.Business;
using Banco.Business.Exceptions;

namespace Banco.UnitTest
{
    [TestClass]
    public class MaquinaBOTest
    {
        [TestMethod]
        public void TesteSaque()
        {
            MaquinaBO maquinaBO = new MaquinaBO();
            Maquina maquina = new Maquina() { ValorDisponivel = 1000.0M };
            Conta conta = new Conta() { Saldo = 500.0M };
            Cartao cartao = new Cartao() { Validade = DateTime.Now.AddDays(30), Conta = conta };

            maquinaBO.Saque(maquina, cartao, 400.0M);
            Assert.IsTrue(maquina.ValorDisponivel == 600.0M);
        }

        [TestMethod]
        [ExpectedException(typeof(CustomException))]
        public void TesteSaqueValorInsuficiente()
        {
            MaquinaBO maquinaBO = new MaquinaBO();
            Maquina maquina = new Maquina() { ValorDisponivel = 100.0M };
            Conta conta = new Conta() { Saldo = 500.0M };
            Cartao cartao = new Cartao() { Validade = DateTime.Now.AddDays(30), Conta = conta };

            maquinaBO.Saque(maquina, cartao, 400.0M);
        }


        [TestMethod]
        public void TestaAtualizarValorDisponivel()
        {
            MaquinaBO maquinaBO = new MaquinaBO();
            Maquina maquina = new Maquina() { ValorDisponivel = 1000.0M };
            Conta conta = new Conta() { Saldo = 500.0M };
            Cartao cartao = new Cartao() { Validade = DateTime.Now.AddDays(30), Conta = conta };

            maquinaBO.Saque(maquina, cartao, 400.0M);

            Assert.IsTrue(maquina.ValorDisponivel == 600.0M);
        
        }

    
    }
}
