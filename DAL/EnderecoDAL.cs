using ProjetoAspNet02_Tarde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNet02_Tarde
{
    public class EnderecoDAL
    {
        private readonly Context _context;

        public EnderecoDAL(Context context)
        {
            _context = context;
        }

        public void Cadastrar(Endereco endereco)
        {
            _context.Add(endereco);
            _context.SaveChanges();
        }

        public List<Endereco> Listar()
        {
            return _context.Enderecos.ToList();
        }

        public void Remover(Endereco endereco)
        {
            _context.Remove(endereco);
            _context.SaveChanges();
        }

        public void Alterar(Endereco endereco)
        {
            _context.Update(endereco);
            _context.SaveChanges();

        }
    }
}
