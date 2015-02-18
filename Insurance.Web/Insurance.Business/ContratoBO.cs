using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Data;
using Insurance.Model;
namespace Insurance.Business
{
    public class ContratoBO : IBusiness<Contrato>
    {



        private ContratoDAO contratoDAO = new ContratoDAO();

        public void Add(Contrato obj)
        {
            try
            {
               contratoDAO.add(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Contrato obj)
        {
            try
            {
                contratoDAO.update(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Contrato Find(Contrato obj)
        {
            try
            {
             return contratoDAO.Find(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Contrato> FindAll()
        {
            try
            {
                return contratoDAO.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Contrato obj)
        {
            try
            {
                contratoDAO.remove(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Contrato> FindAll(Contrato obj)
        {
            try
            {
                return contratoDAO.FindAll(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
