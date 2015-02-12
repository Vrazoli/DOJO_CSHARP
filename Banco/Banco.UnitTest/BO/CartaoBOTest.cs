using System;
using Banco.Business;
using Banco.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Banco.UnitTest
{
    [TestClass]
    public class CartaoBOTest
    {
        [TestMethod]
        public void TestaValidadeCartao()
        {
            Cartao cartao = new Cartao() { Validade = DateTime.Now.AddDays(30) };
            CartaoBO cartaoBO = new CartaoBO();

            Assert.IsTrue(cartaoBO.VerificaValidade(cartao));
        }

        [TestMethod]
        public void TestaCartaoInvalido()
        {
            Cartao cartao = new Cartao() { Validade = DateTime.Now.AddDays(-30) };
            CartaoBO cartaoBO = new CartaoBO();

            Assert.IsFalse(cartaoBO.VerificaValidade(cartao));
        }

    }
}
