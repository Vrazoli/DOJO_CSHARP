using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Model
{
    public class Contrato
    {

        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int IdCliente { get; set; }
        public int IdCarro { get; set; }



    }
}
