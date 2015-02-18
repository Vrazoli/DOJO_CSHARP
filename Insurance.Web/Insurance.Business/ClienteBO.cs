using Insurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Data;
namespace Insurance.Business
{
    class ClienteBO : IBusiness<Cliente>
    {
        ClienteDAO clienteDAO = new ClienteDAO();
        public void Add(Cliente obj)
        {
            try
            {
                clienteDAO.add(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Cliente obj)
        {
            try
            {
                clienteDAO.update(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cliente Find(Cliente obj)
        {
            try
            {
                return clienteDAO.Find(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static bool CpfValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public IList<Cliente> FindAll()
        {
            try
            {
                return clienteDAO.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Cliente obj)
        {
            try
            {
                clienteDAO.remove(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Cliente> FindAll(Cliente obj)
        {
            try
            {
                return clienteDAO.FindAll(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
