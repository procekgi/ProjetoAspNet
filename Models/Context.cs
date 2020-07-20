using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNet02_Tarde.Models
{
    public class Context: DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
