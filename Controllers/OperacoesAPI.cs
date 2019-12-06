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
    public class OperacoesAPI : ControllerBase
    {
        private readonly Context _context;

        public OperacoesAPI(Context context)
        {
            _context = context;
        }

        // GET: api/OperacoesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperacaoCompraVenda>>> GetOperacaoCompraVenda()
        {
            return await _context.OperacaoCompraVenda.ToListAsync();
        }

        // GET: api/OperacoesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperacaoCompraVenda>> GetOperacaoCompraVenda(int id)
        {
            var operacaoCompraVenda = await _context.OperacaoCompraVenda.FindAsync(id);

            if (operacaoCompraVenda == null)
            {
                return NotFound();
            }

            return operacaoCompraVenda;
        }

        // PUT: api/OperacoesAPI/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperacaoCompraVenda(int id, OperacaoCompraVenda operacaoCompraVenda)
        {
            if (id != operacaoCompraVenda.OperacaoCompraVendaId)
            {
                return BadRequest();
            }

            _context.Entry(operacaoCompraVenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacaoCompraVendaExists(id))
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

        // POST: api/OperacoesAPI
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OperacaoCompraVenda>> PostOperacaoCompraVenda(OperacaoCompraVenda operacaoCompraVenda)
        {
            _context.OperacaoCompraVenda.Add(operacaoCompraVenda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperacaoCompraVenda", new { id = operacaoCompraVenda.OperacaoCompraVendaId }, operacaoCompraVenda);
        }

        // DELETE: api/OperacoesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperacaoCompraVenda>> DeleteOperacaoCompraVenda(int id)
        {
            var operacaoCompraVenda = await _context.OperacaoCompraVenda.FindAsync(id);
            if (operacaoCompraVenda == null)
            {
                return NotFound();
            }

            _context.OperacaoCompraVenda.Remove(operacaoCompraVenda);
            await _context.SaveChangesAsync();

            return operacaoCompraVenda;
        }

        private bool OperacaoCompraVendaExists(int id)
        {
            return _context.OperacaoCompraVenda.Any(e => e.OperacaoCompraVendaId == id);
        }
    }
}
