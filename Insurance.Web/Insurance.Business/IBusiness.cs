using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Business
{
    interface IBusiness<T>
    {
        void Add(T obj);
        void Update(T obj);
        T Find(T obj);
        IList<T> FindAll();
        void Delete(T obj);
        IList<T> FindAll(T obj);
      
    }
}
