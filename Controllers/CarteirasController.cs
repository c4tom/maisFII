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
    public class CarteirasController : Controller
    {
        private readonly Context _context;

        public CarteirasController(Context context)
        {
            _context = context;
        }

        private async void ViewBagsBuild(Carteira c)
        {
            if (c != null)
            {
                ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Nome", c.UsuarioId);
            }
            else
            {
                ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Nome");
            }
        }

        // GET: Carteiras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carteira.Include(u => u.Usuario).ToListAsync());
        }

        // GET: Carteiras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteira = await _context.Carteira.Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.CarteiraId == id);
            if (carteira == null)
            {
                return NotFound();
            }

            return View(carteira);
        }

        // GET: Carteiras/Create
        public IActionResult Create()
        {
            ViewBagsBuild(null);
            return View();
        }

        // POST: Carteiras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarteiraId,Nome,Descricao,UsuarioId")] Carteira carteira)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carteira);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBagsBuild(carteira);
            return View(carteira);
        }

        // GET: Carteiras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteira = await _context.Carteira.FindAsync(id);
            if (carteira == null)
            {
                return NotFound();
            }
            ViewBagsBuild(carteira);
            return View(carteira);
        }

        // POST: Carteiras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarteiraId,Nome,Descricao,UsuarioId")] Carteira carteira)
        {
            if (id != carteira.CarteiraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carteira);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarteiraExists(carteira.CarteiraId))
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
            ViewBagsBuild(carteira);
            return View(carteira);
        }

        // GET: Carteiras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteira = await _context.Carteira
                .FirstOrDefaultAsync(m => m.CarteiraId == id);
            if (carteira == null)
            {
                return NotFound();
            }

            return View(carteira);
        }

        // POST: Carteiras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carteira = await _context.Carteira.FindAsync(id);
            _context.Carteira.Remove(carteira);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarteiraExists(int id)
        {
            return _context.Carteira.Any(e => e.CarteiraId == id);
        }
    }
}
