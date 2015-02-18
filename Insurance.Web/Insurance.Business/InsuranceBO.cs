using Insurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Business
{
    public class InsuranceBO
    {
        private ClienteBO clienteBO = new ClienteBO();
        private CarroBO carroBO = new CarroBO();
        private PropostaBO propostaBO = new PropostaBO();
        private ContratoBO contratoBO = new ContratoBO();
        public void addCliente(Cliente cliente)
        {
            try
            {
                if (!ClienteBO.CpfValido(cliente.CPF))
                {
                    throw new ApplicationException("O CPF Informado não existe");
                }

                if (cliente.Idade < 18)
                {
                    throw new ApplicationException("O Cliente nao Pode ser menor de idade");
                }

                clienteBO.Add(cliente);
            }

            catch (Exception e)
            {
                throw e;
            }
        }


        public Cliente FindCliente(Cliente cliente)
        {
            try
            {
                return clienteBO.Find(cliente);
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            try
            {
                clienteBO.Update(cliente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateContrato(Contrato contrato)
        {
            try
            {
                contratoBO.Update(contrato);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public IList<Contrato> TodosContratosPorFiltragem(Contrato contrato)
        {
            try
            {
                return contratoBO.FindAll(contrato);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IList<Contrato> TodosContratos()
        {
            try
            {
                return contratoBO.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void DeleteContrato(Contrato contrato)
        {

            try
            {
                contratoBO.Delete(contrato);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void AdicionarContrato(Contrato contrato)
        {
            try
            {
                contratoBO.Add(contrato);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Carro FindCarro(Carro carro)
        {

            try
            {
                return carroBO.Find(carro);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public void UpdateCarro(Carro carro)
        {

            try
            {
                carroBO.Update(carro);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IList<Proposta> Propostas() {

            try
            {
                return propostaBO.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    
    
    }
}
