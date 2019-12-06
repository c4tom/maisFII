using System;
using System.Linq;
using MaisFII.Models;

namespace MaisFII.Data
{
    public class SeedService
    {
        private Context _context;

        // Injeção de Dependencia
        public SeedService(Context ctx)
        {
            _context = ctx;
        }

        public void Seed()
        {
            Console.WriteLine("Seeding...");

            if (!_context.Usuario.Any())
            {
                
            }
        }
    }
}
