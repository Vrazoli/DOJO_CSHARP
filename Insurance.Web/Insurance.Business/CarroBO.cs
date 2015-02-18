using Insurance.Data;
using Insurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Business
{
   public class CarroBO : IBusiness<Carro>
    {


        private CarroDAO carroDAO = new CarroDAO();



        public void Add(Carro obj)
        {
            try
            {
                carroDAO.add(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Carro obj)
        {
            try
            {
                carroDAO.update(obj);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Carro Find(Carro obj)
        {
            try
            {
                return carroDAO.Find(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Carro> FindAll()
        {
            try
            {
                return carroDAO.FindAll();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Carro obj)
        {

            try
            {
                carroDAO.remove(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Carro> FindAll(Carro obj)
        {
            try
            {
                return carroDAO.FindAll(obj);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
