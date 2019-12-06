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

        public DbSet<MaisFII.Models.Usuario> Usuario { get; set; }

        public DbSet<MaisFII.Models.Carteira> Carteira { get; set; }

        public DbSet<MaisFII.Models.Fundo> Fundo { get; set; }

        public DbSet<MaisFII.Models.OperacaoCompraVenda> OperacaoCompraVenda { get; set; }

        public DbSet<MaisFII.Models.HistoricoFundo> HistoricoFundo { get; set; }
    }
}
