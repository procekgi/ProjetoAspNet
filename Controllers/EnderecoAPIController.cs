using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoAspNet02_Tarde.Models;
using ProjetoAspNet02_Tarde.ViewModel;

namespace ProjetoAspNet02_Tarde.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoAPIController : ControllerBase
    {
        private readonly EnderecoDAL _enderecoDAL;


        public EnderecoAPIController(EnderecoDAL enderecoDal)
        {
            _enderecoDAL = enderecoDal;

        }
        [HttpGet]
        [Route("ListarCep")]
        public IActionResult ListarCep(string cep)
        {
            string url = $"http://viacep.com.br/ws/{cep}/json/";
            WebClient client = new WebClient();
            var resultado = client.DownloadString(url);
            return Ok(resultado);
        }

        [HttpGet]
        [Route("Listar")]
        public List<Endereco> Listar()
        {
            return _enderecoDAL.Listar();
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(string cep)
        {
            string url = $"http://viacep.com.br/ws/{cep}/json/";
            WebClient client = new WebClient();
            var resultado = client.DownloadString(url);
            EnderecoViewModel enderecoView = JsonConvert.DeserializeObject<EnderecoViewModel>(resultado);

            Endereco endereco = new Endereco();
            endereco.Bairro = enderecoView.bairro;
            endereco.Cep = enderecoView.cep;
            endereco.Localidade = enderecoView.localidade;
            endereco.Uf = enderecoView.uf;
            endereco.Logradouro = enderecoView.logradouro;
            endereco.Complemento = enderecoView.complemento;

            var c = _enderecoDAL.Cadastrar(endereco);

            if (c >= 1)
                return Ok(endereco);
            else
                return BadRequest();

        }

        [HttpDelete]
        [Route("Remover")]
        public IActionResult Remover(int id)
        {
            Endereco endereco = _enderecoDAL.BuscarEndereco(id);
            _enderecoDAL.Remover(endereco);
            return Ok(endereco);
        }

        [HttpPut]
        [Route("Alterar")]
        public IActionResult Alterar(int id)
        {
            Endereco endereco = _enderecoDAL.BuscarEndereco(id);
            _enderecoDAL.Alterar(endereco);
            return Ok(endereco);
        }

    }
}