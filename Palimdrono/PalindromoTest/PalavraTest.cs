using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromoLib;
using System.IO;

namespace PalindromoTest
{
    [TestClass]
    public class PalavraTest
    {
        [TestMethod]
        public void VerificaPalavraAna()
        {
            string PalavraTest = "Ana";
            Assert.IsTrue(Palavra.VerificaPalindrome(PalavraTest));
        }

        [TestMethod]
        public void VerificaPalavraana()
        {
            string PalavraTest = "ana";
            Assert.IsTrue(Palavra.VerificaPalindrome(PalavraTest));
        }

        [TestMethod]
        public void VerificaPalavraananaganana()
        {
            string PalavraTest = "ananaganana";
            Assert.IsTrue(Palavra.VerificaPalindrome(PalavraTest));
        }


        [TestMethod]
        public void VerificaPalavraananaganana2()
        {
            string PalavraTest = "ananagananá ";
            Assert.IsTrue(Palavra.VerificaPalindrome(PalavraTest));
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void VerificaAbrirArquivoNotFound()
        {
            string CaminhoTest = @"C:\Users\ricardors\Documents\Palindrome.txt";
            TratadorDeArquivo arquivo = new TratadorDeArquivo(CaminhoTest);
        }

        [TestMethod]
        public void VerificaAbrirArquivo()
        {
            string CaminhoTest = @"C:\Users\ricardors\Documents\Palindromes.txt";
            TratadorDeArquivo arquivo = new TratadorDeArquivo(CaminhoTest);
        }

        [TestMethod]
        public void VerificaLerLinhaArquivo()
        {
            string CaminhoTest = @"C:\Users\ricardors\Documents\Palindromes.txt";
            TratadorDeArquivo arquivo = new TratadorDeArquivo(CaminhoTest);
            Assert.IsTrue(arquivo.LerLinha() != null);
        }


        [TestMethod]
        public void VerificaLinhaPalindromo()
        {
            string CaminhoTest = @"C:\Users\ricardors\Documents\Palindromes.txt";
            TratadorDeArquivo arquivo = new TratadorDeArquivo(CaminhoTest);
            Assert.IsTrue(Palavra.VerificaPalindrome(arquivo.LerLinha()));
        }

        [TestMethod]
        public void VerificaArquivoSaida()
        {
            string CaminhoTest = @"C:\Users\ricardors\Documents\Palindromes.txt";
            string Caminhosaida = @"C:\Users\ricardors\Documents\Palindromessaida.txt";
            Palavra.ArquivoPalindromo(CaminhoTest, Caminhosaida);
            Assert.IsTrue(File.Exists(Caminhosaida));
        }
    }
}
