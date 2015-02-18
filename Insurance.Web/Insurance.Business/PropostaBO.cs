using Insurance.Data;
using Insurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Business
{
   public  class PropostaBO : IBusiness<Proposta>
    {

        PropostaDAO propostaDAO = new PropostaDAO();

        public void Add(Proposta obj)
        {
            try
            {
                propostaDAO.add(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Proposta obj)
        {
            try
            {
                propostaDAO.update(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Proposta Find(Proposta obj)
        {
            try
            {
                return propostaDAO.Find(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Proposta> FindAll()
        {
            try
            {
                return propostaDAO.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Proposta obj)
        {
            try
            {
                propostaDAO.remove(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Proposta> FindAll(Proposta obj)
        {
            try
            {
                return propostaDAO.FindAll(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
