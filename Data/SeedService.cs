using MaisFII.Models;
using System;

namespace MaisFII.Data
{
    public class SeedService
    {
        private MaisFIIContext _context;

        // Injeção de Dependencia
        public SeedService(MaisFIIContext ctx)
        {
            _context = ctx;
        }

        public void Seed()
        {
            Console.WriteLine("Seeding...");
        }
    }
}
