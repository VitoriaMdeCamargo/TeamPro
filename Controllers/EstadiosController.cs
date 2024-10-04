using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamPro.Models;
using TeamPro.Persistence;

namespace TeamPro.Controllers
{
    public class EstadiosController : Controller
    {
        private readonly TeamProDbContext _context;

        public EstadiosController(TeamProDbContext context)
        {
            _context = context;
        }

        // GET: Estadios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estadios.ToListAsync());
        }

        // GET: Estadios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadios
                .FirstOrDefaultAsync(m => m.EstadioId == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // GET: Estadios/Create
        public IActionResult Create()
        {
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome");
            return View();
        }

        // POST: Estadios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadioId,Nome,Localizacao,Capacidade,AnoConstrucao,EquipeId")] Estadio estadio)
        {
            if (ModelState.IsValid)
            {
                // Verifica se a equipe com o ID fornecido existe
                var equipe = await _context.Equipes.FirstOrDefaultAsync(e => e.EquipeId == estadio.EquipeId);
                if (equipe == null)
                {
                    ModelState.AddModelError(string.Empty, "A equipe selecionada não existe.");
                    ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", estadio.EquipeId);
                    return View(estadio);
                }

                _context.Add(estadio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", estadio.EquipeId);
            return View(estadio);
        }

        // GET: Estadios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadios.FindAsync(id);
            if (estadio == null)
            {
                return NotFound();
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", estadio.EquipeId);
            return View(estadio);
        }

        // POST: Estadios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadioId,Nome,Localizacao,Capacidade,AnoConstrucao,EquipeId")] Estadio estadio)
        {
            if (id != estadio.EstadioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadioExists(estadio.EstadioId))
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
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", estadio.EquipeId);
            return View(estadio);
        }

        // GET: Estadios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadios
                .FirstOrDefaultAsync(m => m.EstadioId == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // POST: Estadios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadio = await _context.Estadios.FindAsync(id);
            if (estadio != null)
            {
                _context.Estadios.Remove(estadio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadioExists(int id)
        {
            return _context.Estadios.Any(e => e.EstadioId == id);
        }
    }
}
