using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.WEB.Models
{
    public class TipoProposta
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string foto { get; set; }
        public int IdProposta { get; set; }
    
    }
}