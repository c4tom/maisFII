using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaisFII.Models;

namespace MaisFII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundosAPI : ControllerBase
    {
        private readonly MaisFIIContext _context;

        public FundosAPI(MaisFIIContext context)
        {
            _context = context;
        }

        // GET: api/FundosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fundo>>> GetFundo()
        {
            return await _context.Fundo.ToListAsync();
        }

        // GET: api/FundosAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fundo>> GetFundo(int id)
        {
            var fundo = await _context.Fundo.FindAsync(id);

            if (fundo == null)
            {
                return NotFound();
            }

            return fundo;
        }

        // PUT: api/FundosAPI/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundo(int id, Fundo fundo)
        {
            if (id != fundo.Id)
            {
                return BadRequest();
            }

            _context.Entry(fundo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundoExists(id))
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

        // POST: api/FundosAPI
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Fundo>> PostFundo(Fundo fundo)
        {
            _context.Fundo.Add(fundo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundo", new { id = fundo.Id }, fundo);
        }

        // DELETE: api/FundosAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fundo>> DeleteFundo(int id)
        {
            var fundo = await _context.Fundo.FindAsync(id);
            if (fundo == null)
            {
                return NotFound();
            }

            _context.Fundo.Remove(fundo);
            await _context.SaveChangesAsync();

            return fundo;
        }

        private bool FundoExists(int id)
        {
            return _context.Fundo.Any(e => e.Id == id);
        }
    }
}
