using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamPro.Models;
using TeamPro.Persistence;

namespace TeamPro.Controllers
{
    public class PartidasController : Controller
    {
        private readonly TeamProDbContext _context;

        public PartidasController(TeamProDbContext context)
        {
            _context = context;
        }

        // GET: Partidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partidas.ToListAsync());
        }

        // GET: Partidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas
                .FirstOrDefaultAsync(m => m.PartidaId == id);

            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // GET: Partidas/Create
        public IActionResult Create()
        {
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome");
            return View();
        }

        // POST: Partidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartidaId,DataHora,Estadio,EquipeId")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                // Verifica se a equipe com o ID fornecido existe
                var equipe = await _context.Equipes.FirstOrDefaultAsync(e => e.EquipeId == partida.EquipeId);
                if (equipe == null)
                {
                    ModelState.AddModelError(string.Empty, "A equipe selecionada não existe.");
                    ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", partida.EquipeId);
                    return View(partida);
                }

                _context.Add(partida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", partida.EquipeId);
            return View(partida);
        }

        // GET: Partidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas.FindAsync(id);
            if (partida == null)
            {
                return NotFound();
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", partida.EquipeId);
            return View(partida);
        }

        // POST: Partidas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartidaId,DataHora,Estadio,EquipeId")] Partida partida)
        {
            if (id != partida.PartidaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidaExists(partida.PartidaId))
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
            return View(partida);
        }

        // GET: Partidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas
                .FirstOrDefaultAsync(m => m.PartidaId == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // POST: Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partida = await _context.Partidas.FindAsync(id);
            if (partida != null)
            {
                _context.Partidas.Remove(partida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidaExists(int id)
        {
            return _context.Partidas.Any(e => e.PartidaId == id);
        }
    }
}
