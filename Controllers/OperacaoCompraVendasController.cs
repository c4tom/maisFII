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
    public class OperacaoCompraVendasController : Controller
    {
        private readonly Context _context;
        public OperacaoCompraVendasController(Context context)
        {
            _context = context;
        }

        private async void ViewBagsBuild(OperacaoCompraVenda ocv)
        {
            if (ocv != null)
            {
                ViewBag.Carteira = new SelectList(_context.Carteira, "CarteiraId", "Nome", ocv.CarteiraId);
                ViewBag.Fundo = new SelectList(_context.Fundo, "FundoId", "Sigla", ocv.FundoId);
            } else
            {
                ViewBag.Carteira = new SelectList(_context.Carteira, "CarteiraId", "Nome");
                ViewBag.Fundo = new SelectList(_context.Fundo, "FundoId", "Sigla");
            }
        }

        // GET: OperacaoCompraVendas
        public async Task<IActionResult> Index()
        {
            var context = _context.OperacaoCompraVenda.Include(o => o.Carteira).Include(o => o.Fundo);

            
            return View(await context.ToListAsync());
        }

        // GET: OperacaoCompraVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacaoCompraVenda = await _context.OperacaoCompraVenda
                .Include(o => o.Carteira)
                .Include(o => o.Fundo)
                .FirstOrDefaultAsync(m => m.OperacaoCompraVendaId == id);
            if (operacaoCompraVenda == null)
            {
                return NotFound();
            }

            return View(operacaoCompraVenda);
        }

        // GET: OperacaoCompraVendas/Create
        public IActionResult Create()
        {
            ViewBagsBuild(null);
            return View();
        }

        // POST: OperacaoCompraVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OperacaoCompraVendaId,DataOperacao,QuantidadeCota,ValorDaCota,ValorTaxaDaOperadora,tipo,Carteira,Fundo")] OperacaoCompraVenda operacaoCompraVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operacaoCompraVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBagsBuild(operacaoCompraVenda);
            return View(operacaoCompraVenda);
        }

        // GET: OperacaoCompraVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacaoCompraVenda = await _context.OperacaoCompraVenda.FindAsync(id);

            if (operacaoCompraVenda == null)
            {
                return NotFound();
            }
            
            ViewBagsBuild(operacaoCompraVenda);
            return View(operacaoCompraVenda);
        }

        // POST: OperacaoCompraVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OperacaoCompraVendaId,DataOperacao,QuantidadeCota,ValorDaCota,ValorTaxaDaOperadora,tipo,Carteira,Fundo")] OperacaoCompraVenda operacaoCompraVenda)
        {
            if (id != operacaoCompraVenda.OperacaoCompraVendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operacaoCompraVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperacaoCompraVendaExists(operacaoCompraVenda.OperacaoCompraVendaId))
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
            ViewBagsBuild(operacaoCompraVenda);
            return View(operacaoCompraVenda);
        }

        // GET: OperacaoCompraVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacaoCompraVenda = await _context.OperacaoCompraVenda
                .Include(o => o.Carteira)
                .Include(o => o.Fundo)
                .FirstOrDefaultAsync(m => m.OperacaoCompraVendaId == id);
            if (operacaoCompraVenda == null)
            {
                return NotFound();
            }

            return View(operacaoCompraVenda);
        }

        // POST: OperacaoCompraVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operacaoCompraVenda = await _context.OperacaoCompraVenda.FindAsync(id);
            _context.OperacaoCompraVenda.Remove(operacaoCompraVenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperacaoCompraVendaExists(int id)
        {
            return _context.OperacaoCompraVenda.Any(e => e.OperacaoCompraVendaId == id);
        }
    }
}
