using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaisFII.Models;

namespace MaisFII.Controllers
{
    public class HistoricoFundosController : Controller
    {
        private readonly Context _context;

        public HistoricoFundosController(Context context)
        {
            _context = context;
        }

        // GET: HistoricoFundos
        public async Task<IActionResult> Index()
        {
            return View(await _context.HistoricoFundo.ToListAsync());
        }

        // GET: HistoricoFundos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoFundo = await _context.HistoricoFundo
                .FirstOrDefaultAsync(m => m.HistoricoFundoId == id);
            if (historicoFundo == null)
            {
                return NotFound();
            }

            return View(historicoFundo);
        }

        // GET: HistoricoFundos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistoricoFundos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricoFundoId,valor,Data")] HistoricoFundo historicoFundo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historicoFundo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historicoFundo);
        }

        // GET: HistoricoFundos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoFundo = await _context.HistoricoFundo.FindAsync(id);
            if (historicoFundo == null)
            {
                return NotFound();
            }
            return View(historicoFundo);
        }

        // POST: HistoricoFundos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricoFundoId,valor,Data")] HistoricoFundo historicoFundo)
        {
            if (id != historicoFundo.HistoricoFundoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicoFundo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoFundoExists(historicoFundo.HistoricoFundoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(historicoFundo);
        }

        // GET: HistoricoFundos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoFundo = await _context.HistoricoFundo
                .FirstOrDefaultAsync(m => m.HistoricoFundoId == id);
            if (historicoFundo == null)
            {
                return NotFound();
            }

            return View(historicoFundo);
        }

        // POST: HistoricoFundos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historicoFundo = await _context.HistoricoFundo.FindAsync(id);
            _context.HistoricoFundo.Remove(historicoFundo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoFundoExists(int id)
        {
            return _context.HistoricoFundo.Any(e => e.HistoricoFundoId == id);
        }
    }
}
