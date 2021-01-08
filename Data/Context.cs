using CadastroCedulas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCedulas.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<CaixaEletronico> CaixaEletronico { get; set; }
        public DbSet<Cedula> Cedulas { get; set; }

    }
}
