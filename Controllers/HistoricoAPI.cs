using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaisFII.Models;
using System.Collections;

namespace MaisFII.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoAPI : ControllerBase
    {
        private readonly Context _context;

        public HistoricoAPI(Context context)
        {
            _context = context;
        }

        // GET: api/HistoricoAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoFundo>>> GetHistoricoFundo()
        {
            return await _context.HistoricoFundo.Include(f => f.Fundo).ToListAsync();
        }

        [HttpGet("popular/{id}")]
        public List<string> Get(int id)
        {
                     
            DateTime start = new DateTime(id, 1, 1);
            int range = (DateTime.Today - start).Days;

            Fundo f;
            HistoricoFundo hf;
            DateTime d;
            List<string> dt = new List<string>();
            List<HistoricoFundo> fundos = new List<HistoricoFundo>();
            for (int i = 0; i < range; i++)
            {
                d = start.AddDays(i);
                hf = new HistoricoFundo();
                f =_context.Fundo.Find((int)GetRandomNumber(1d, 220d));
                hf.valor = (float)GetRandomNumber(1d, 150d);
                hf.Data = d;
                hf.Fundo = f;
                fundos.Add(hf);

                dt.Add(d.ToString());
            }
            _context.HistoricoFundo.AddRange(fundos);
            _context.SaveChanges();


            return dt;
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        // GET: api/HistoricoAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoFundo>> GetHistoricoFundo(int id)
        {
            var historicoFundo = await _context.HistoricoFundo.Include(f => f.Fundo).FirstOrDefaultAsync(m=> m.HistoricoFundoId == id);

            if (historicoFundo == null)
            {
                return NotFound();
            }

            return historicoFundo;
        }

        // PUT: api/HistoricoAPI/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricoFundo(int id, HistoricoFundo historicoFundo)
        {
            if (id != historicoFundo.HistoricoFundoId)
            {
                return BadRequest();
            }

            _context.Entry(historicoFundo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoFundoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HistoricoAPI
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HistoricoFundo>> PostHistoricoFundo(HistoricoFundo historicoFundo)
        {
            _context.HistoricoFundo.Add(historicoFundo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoricoFundo", new { id = historicoFundo.HistoricoFundoId }, historicoFundo);
        }

        // DELETE: api/HistoricoAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HistoricoFundo>> DeleteHistoricoFundo(int id)
        {
            var historicoFundo = await _context.HistoricoFundo.FindAsync(id);
            if (historicoFundo == null)
            {
                return NotFound();
            }

            _context.HistoricoFundo.Remove(historicoFundo);
            await _context.SaveChangesAsync();

            return historicoFundo;
        }

        private bool HistoricoFundoExists(int id)
        {
            return _context.HistoricoFundo.Any(e => e.HistoricoFundoId == id);
        }
    }
}
