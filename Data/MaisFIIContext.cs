using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using maisFII.Models;
using MaisFII.Models;

namespace MaisFII.Models
{
    public class MaisFIIContext : DbContext
    {
        public MaisFIIContext (DbContextOptions<MaisFIIContext> options)
            : base(options)
        {
        }

        public DbSet<maisFII.Models.Usuario> Usuario { get; set; }

        public DbSet<MaisFII.Models.Carteira> Carteira { get; set; }

        public DbSet<MaisFII.Models.Fundo> Fundo { get; set; }

        public DbSet<MaisFII.Models.HistoricoFundo> HistoricoFundo { get; set; }

        public DbSet<MaisFII.Models.OperacaoCompraVenda> OperacaoCompraVenda { get; set; }
    }
}
