using Insurance.Business;
using Insurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.WEB.Models
{
    public class PropostaController : Controller
    {
        InsuranceBO insuranceBO = new InsuranceBO();



        public ActionResult SelecionarProposta(TipoProposta proposta)
        {
            Session["idProposta"] = proposta.IdProposta;
            return RedirectToAction("SelecionaCliente", "Cliente");
        }




        public ActionResult Index()
        {

            IList<TipoProposta> TipoPropostas = new List<TipoProposta>();

            IList<Proposta> Propostas = insuranceBO.Propostas(); ;

            foreach (Proposta proposta in Propostas)
            {

                Carro carro = insuranceBO.FindCarro(new Carro { Id = proposta.IdCarro });
                if (carro.Id > 0)
                {
                    TipoPropostas.Add(new TipoProposta() { Ano = carro.Ano, foto = carro.Foto, Marca = carro.Marca, Modelo = carro.Modelo, IdProposta = proposta.Id });
                }
            }

            return View("Proposta", TipoPropostas);
        }

    }
}
