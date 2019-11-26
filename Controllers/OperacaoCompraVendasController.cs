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
        private readonly MaisFIIContext _context;

        public OperacaoCompraVendasController(MaisFIIContext context)
        {
            _context = context;
        }

        // GET: OperacaoCompraVendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.OperacaoCompraVenda.ToListAsync());
        }

        // GET: OperacaoCompraVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacaoCompraVenda = await _context.OperacaoCompraVenda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operacaoCompraVenda == null)
            {
                return NotFound();
            }

            return View(operacaoCompraVenda);
        }

        // GET: OperacaoCompraVendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OperacaoCompraVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataOperacao,QuantidadeCota,ValorDaCota,ValorTaxaDaOperadora")] OperacaoCompraVenda operacaoCompraVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operacaoCompraVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(operacaoCompraVenda);
        }

        // POST: OperacaoCompraVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataOperacao,QuantidadeCota,ValorDaCota,ValorTaxaDaOperadora")] OperacaoCompraVenda operacaoCompraVenda)
        {
            if (id != operacaoCompraVenda.Id)
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
                    if (!OperacaoCompraVendaExists(operacaoCompraVenda.Id))
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return _context.OperacaoCompraVenda.Any(e => e.Id == id);
        }
    }
}
