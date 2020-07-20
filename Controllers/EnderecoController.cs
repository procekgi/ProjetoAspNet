using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoAspNet02_Tarde.Models;

namespace ProjetoAspNet02_Tarde.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoDAL _enderecoDal;

        public EnderecoController(EnderecoDAL enderecoDal)
        {
            _enderecoDal = enderecoDal;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarCep(string txtCep)
        {
            string url = $@"http://viacep.com.br/ws/{txtCep}/json/";
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);
            return RedirectToAction("Index");

        }

        public IActionResult DeserializarJson()
        {
            if (TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
                _enderecoDal.Cadastrar(endereco);
                return View(endereco);
            }
            return View();
        }
    }
}