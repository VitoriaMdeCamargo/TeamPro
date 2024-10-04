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
    public class TreinadoresController : Controller
    {
        private readonly TeamProDbContext _context;

        public TreinadoresController(TeamProDbContext context)
        {
            _context = context;
        }

        // GET: Treinadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Treinadores.ToListAsync());
        }

        // GET: Treinadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinador = await _context.Treinadores
                .FirstOrDefaultAsync(m => m.TreinadorId == id);

            if (treinador == null)
            {
                return NotFound();
            }

            return View(treinador);
        }

        // GET: Treinadores/Create
        public IActionResult Create()
        {
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome");
            return View();
        }

        // POST: Treinadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreinadorId,Nome,Idade,Nacionalidade,Salario,EquipeId")] Treinador treinador)
        {
            if (ModelState.IsValid)
            {
                // Verifica se a equipe com o ID fornecido existe
                var equipe = await _context.Equipes.FirstOrDefaultAsync(e => e.EquipeId == treinador.EquipeId);
                if (equipe == null)
                {
                    ModelState.AddModelError(string.Empty, "A equipe selecionada não existe.");
                    ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", treinador.EquipeId);
                    return View(treinador);
                }

                _context.Add(treinador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", treinador.EquipeId);
            return View(treinador);
        }

        // GET: Treinadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinador = await _context.Treinadores.FindAsync(id);
            if (treinador == null)
            {
                return NotFound();
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", treinador.EquipeId);
            return View(treinador);
        }

        // POST: Treinadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreinadorId,Nome,Idade,Nacionalidade,Salario,EquipeId")] Treinador treinador)
        {
            if (id != treinador.TreinadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treinador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinadorExists(treinador.TreinadorId))
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
            return View(treinador);
        }

        // GET: Treinadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinador = await _context.Treinadores
                .FirstOrDefaultAsync(m => m.TreinadorId == id);
            if (treinador == null)
            {
                return NotFound();
            }

            return View(treinador);
        }

        // POST: Treinadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treinador = await _context.Treinadores.FindAsync(id);
            if (treinador != null)
            {
                _context.Treinadores.Remove(treinador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinadorExists(int id)
        {
            return _context.Treinadores.Any(e => e.TreinadorId == id);
        }
    }
}
