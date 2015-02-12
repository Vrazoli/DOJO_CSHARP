using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data
{
    interface IData <T>
    {
        void Add(T obj);
        void Update(T obj);
        T Find(T obj);
        void Delete(T obj);
    }
}
