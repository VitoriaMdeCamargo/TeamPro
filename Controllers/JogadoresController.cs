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
    public class JogadoresController : Controller
    {
        private readonly TeamProDbContext _context;

        public JogadoresController(TeamProDbContext context)
        {
            _context = context;
        }

        // GET: Jogadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jogadores.ToListAsync());
        }

        // GET: Jogadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogadores
                .FirstOrDefaultAsync(m => m.JogadorId == id);

            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // GET: Jogadores/Create
        public IActionResult Create()
        {
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome");
            return View();
        }

        // POST: Jogadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JogadorId,Nome,Posicao,Idade,Nacionalidade,Salario,EquipeId")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                // Verifica se a equipe com o ID fornecido existe
                var equipe = await _context.Equipes.FirstOrDefaultAsync(e => e.EquipeId == jogador.EquipeId);
                if (equipe == null)
                {
                    ModelState.AddModelError(string.Empty, "A equipe selecionada não existe.");
                    ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", jogador.EquipeId);
                    return View(jogador);
                }

                _context.Add(jogador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", jogador.EquipeId);
            return View(jogador);
        }

        // GET: Jogadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogadores.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", jogador.EquipeId);
            return View(jogador);
        }

        // POST: Jogadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JogadorId,Nome,Posicao,Idade,Nacionalidade,Salario,EquipeId")] Jogador jogador)
        {
            if (id != jogador.JogadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorExists(jogador.JogadorId))
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
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome", jogador.EquipeId);
            return View(jogador);
        }

        // GET: Jogadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogadores
                .FirstOrDefaultAsync(m => m.JogadorId == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // POST: Jogadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogador = await _context.Jogadores.FindAsync(id);
            if (jogador != null)
            {
                _context.Jogadores.Remove(jogador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorExists(int id)
        {
            return _context.Jogadores.Any(e => e.JogadorId == id);
        }
    }
}
