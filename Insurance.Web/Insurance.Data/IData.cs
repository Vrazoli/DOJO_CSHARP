using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Data
{
    interface IData<T>
    {

        T Find(T obj);
        IList<T> FindAll();
        void add(T obj);
        void remove(T obj);
        void update(T obj);
        IList<T> FindAll(T obj);


    }
}
