using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspNet02_Tarde.Models;

namespace ProjetoAspNet02_Tarde.Controllers
{
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
        [Route("Listar")]
        public List<Endereco> Listar()
        {
            return _enderecoDAL.Listar();
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Endereco endereco)
        {
            _enderecoDAL.Cadastrar(endereco);
            return Created("", endereco);

        }

        [HttpDelete]
        [Route("Remover")]
        public IActionResult Remover(Endereco endereco)
        {
            _enderecoDAL.Remover(endereco);
            return Accepted("", endereco); 
        }
    }
}