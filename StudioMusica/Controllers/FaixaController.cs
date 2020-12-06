using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioMusica.Data;
using StudioMusica.Models;
using System.Data;

namespace StudioMusica.Controllers
{
    public class FaixaController : Controller
    {
        private readonly StudioContext _context;

        public FaixaController(StudioContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FaixaID, Nome, Autor, DataLancamento,Volume ")] Faixa faixa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(faixa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados.");
            }
            return View(faixa);
        }


        //=================== View  CRUD Faixa =======================
        public async Task<IActionResult> Index()
        {
            return View(await _context.Faixas.OrderBy(i => i.Nome).ToListAsync());
        }


        //======================================= Details ====================
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var faixa = await _context.Faixas.SingleOrDefaultAsync(a => a.FaixaID == id);
            if (faixa == null)
            {
                return NotFound();
            }
            return View(faixa);
        }



        //================================= Edit ==============================

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var faixa = await _context.Faixas.SingleOrDefaultAsync(a => a.FaixaID == id);
            if (faixa == null)
            {
                return NotFound();
            }
            return View(faixa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long? id, [Bind("FaixaID, Nome, Autor, DataLancamento,Volume ")] Faixa faixa)
        {


            if (id != faixa.FaixaID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faixa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaixaExists(faixa.FaixaID))
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
            return View(faixa);
        }
        public bool FaixaExists(long? id)
        {
            return _context.Faixas.Any(a => a.FaixaID == id);
        }
        //============ Delete ==========================
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var faixa = await _context.Faixas.SingleOrDefaultAsync(a => a.FaixaID == id);
            if (faixa == null)
            {
                return NotFound();
            }
            return View(faixa);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmedFaixa(long? id)
        {
            var faixa = await _context.Faixas.SingleOrDefaultAsync(a => a.FaixaID == id);
            _context.Faixas.Remove(faixa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
