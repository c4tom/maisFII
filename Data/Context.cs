using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MaisFII.Models;

namespace MaisFII.Models
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Carteira> Carteira { get; set; }

        public DbSet<Fundo> Fundo { get; set; }

        public DbSet<HistoricoFundo> HistoricoFundo { get; set; }
         
        public DbSet<OperacaoCompraVenda> OperacaoCompraVenda { get; set; }

        public DbSet<Fundo> Fundos { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }

    }
}
