using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromoLib
{
    public class TratadorDeArquivo
    {
        private StreamReader file;
        private StreamWriter saida;
        public TratadorDeArquivo(String caminho)
        {
            if (!File.Exists(caminho))
            {
                throw new ApplicationException("caminho invalido");
            }
            this.file = new StreamReader(caminho, Encoding.GetEncoding("ISO-8859-1"));
        }

        public String LerLinha()
        {
            return file.ReadLine();
        }

        public void CriarArquivo(string caminho)
        {

            saida = new StreamWriter(caminho);

        }

        public void EscreverLinha(string linha)
        {
            saida.WriteLine(linha);
        }
    }
}
