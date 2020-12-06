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
    public class InstrumentoController : Controller
    {
        private readonly StudioContext _context;

        public InstrumentoController(StudioContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstrumentoID, Nome, Marca, Modelo, Serie, Cor ")] Instrumento instrumento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instrumento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(IndexInstrumento));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados.");
            }
            return View(instrumento);
        }


        //=================== View  CRUD Instrumento =======================
        public async Task<IActionResult> IndexInstrumento()
        {
            return View(await _context.Instrumentos.OrderBy(i => i.Nome).ToListAsync());
        }


        //======================================= Details ====================
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instrumento = await _context.Instrumentos.SingleOrDefaultAsync(a => a.InstrumentoID == id);
            if (instrumento == null)
            {
                return NotFound();
            }
            return View(instrumento);
        }



        //================================= Edit ==============================

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instrumento = await _context.Instrumentos.SingleOrDefaultAsync(a => a.InstrumentoID == id);
            if (instrumento == null)
            {
                return NotFound();
            }
            return View(instrumento);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long? id, [Bind("InstrumentoID, Nome, Marca, Modelo, Serie, Cor ")] Instrumento instrumento)
        {


            if (id != instrumento.InstrumentoID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentoExists(instrumento.InstrumentoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexInstrumento));
            }
            return View(instrumento);
        }
        public bool InstrumentoExists(long? id)
        {
            return _context.Instrumentos.Any(a => a.InstrumentoID == id);
        }
        //============ Delete ==========================
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instrumento = await _context.Instrumentos.SingleOrDefaultAsync(a => a.InstrumentoID == id);
            if (instrumento == null)
            {
                return NotFound();
            }
            return View(instrumento);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmedInstrumento(long? id)
        {
            var instrumento = await _context.Instrumentos.SingleOrDefaultAsync(a => a.InstrumentoID == id);
            _context.Instrumentos.Remove(instrumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexInstrumento));

        }

    }
}
