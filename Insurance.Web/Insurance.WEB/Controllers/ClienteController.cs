using Insurance.Business;
using Insurance.Data;
using Insurance.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurance.Model;
using System.Web.Script.Serialization;
namespace Insurance.WEB.Controllers
{














    public class ClienteController : Controller
    {

        InsuranceBO insuranceBO = new InsuranceBO();

        public ActionResult SelecionarCliente()
        {

            return View("SelecionaCliente");
        }

        public String Cadastrar(CadastroModel dado)
        {
            ResultModel result = new ResultModel();

            try
            {
                insuranceBO.addCliente(new Cliente()
                {
                    Nome = dado.Nome,
                    CPF = dado.CPF,
                    Sobrenome = dado.Sobrenome,
                    RG = dado.RG,
                    Sexo = dado.Sexo,
                    Idade = dado.Idade
                });

                result.sucess = true;
                result.message = "Operção bem sucedida";
            }
            catch (Exception e)
            {
                result.sucess = false;
                result.message = e.Message;
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();
            return jsSerialize.Serialize(result);
        }





        public ActionResult SelecionaCliente()
        {
            if (Session["idProposta"] != null)
            {
                return View("SelecionaCliente");
            }
            return View("PaginaNaoPermitida", new CadastroModel {Nome="",CPF="",RG="",Sobrenome=""});
        }


        //public ActionResult ConfirmaCliente


        [HttpGet]
        public ActionResult Index()
        {

            return View("Cadastro");
        }
        public class ResultModel
        {
            public bool sucess { get; set; }
            public string message { get; set; }
        }


    }
}
