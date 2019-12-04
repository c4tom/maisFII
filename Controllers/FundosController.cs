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
    public class FundosController : Controller
    {
        private readonly Context _context;

        public FundosController(Context context)
        {
            _context = context;
        }

        // GET: Fundos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fundo.ToListAsync());
        }

        // GET: Fundos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundo = await _context.Fundo
                .FirstOrDefaultAsync(m => m.FundoId == id);
            if (fundo == null)
            {
                return NotFound();
            }

            return View(fundo);
        }

        // GET: Fundos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fundos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FundoId,RazaoSocial,Sigla,Segmento,LinkBMF")] Fundo fundo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fundo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fundo);
        }

        // GET: Fundos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundo = await _context.Fundo.FindAsync(id);
            if (fundo == null)
            {
                return NotFound();
            }
            return View(fundo);
        }

        // POST: Fundos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FundoId,RazaoSocial,Sigla,Segmento,LinkBMF")] Fundo fundo)
        {
            if (id != fundo.FundoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fundo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundoExists(fundo.FundoId))
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
            return View(fundo);
        }

        // GET: Fundos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundo = await _context.Fundo
                .FirstOrDefaultAsync(m => m.FundoId == id);
            if (fundo == null)
            {
                return NotFound();
            }

            return View(fundo);
        }

        // POST: Fundos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fundo = await _context.Fundo.FindAsync(id);
            _context.Fundo.Remove(fundo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundoExists(int id)
        {
            return _context.Fundo.Any(e => e.FundoId == id);
        }
    }
}
