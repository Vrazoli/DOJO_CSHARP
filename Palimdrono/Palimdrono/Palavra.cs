using PalindromoLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromoLib
{
    public class Palavra
    {
        public static Boolean VerificaPalindrome(string palavra2)
        {
           string palavra = palavra2.ToUpper().Replace(" ", "") ;
            byte[] array = Encoding.GetEncoding("iso-8859-8").GetBytes(palavra);
            palavra = Encoding.UTF8.GetString(array);

            for (int i = 0; i < palavra.Length / 2; i++)
            {
                if (palavra[i] != palavra[palavra.Length - 1 - i])
                    return false;
            }
            return true;
        }

        public static void ArquivoPalindromo(string caminho,string saida)
        {
            TratadorDeArquivo tratador = new TratadorDeArquivo(caminho);
            string linha;
            tratador.CriarArquivo(saida);
            while ((linha = tratador.LerLinha()) != null)
            {
                
                    tratador.EscreverLinha(String.Format("{0}-Palindrome:{1}",linha,VerificaPalindrome(linha)));
                    
                
                
            }
        }
    }
}
