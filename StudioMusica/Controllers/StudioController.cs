using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioMusica.Data;
using StudioMusica.Models;

namespace StudioMusica.Controllers
{
    public class StudioController : Controller
    {

        

        private readonly StudioContext _context;

        public StudioController(StudioContext context)
        {
            _context = context;
        }
        
        

        public IActionResult RegistroMusico()
        {
            return View();
        }
       

        /*              ============================================
             ======================= CRUD Classe *Musico*=============================
             ========================================================================= */
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(" MusicoId,Nome, Telefone, Endereço, Numero, Estado, Cidade, Bairro")] Musico musico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(musico);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Indexmusico));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados.");
            }
            return View(musico);
        }
        //======================================= Details ====================
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var musico = await _context.Musicos.SingleOrDefaultAsync(a => a.MusicoID == id);
            if (musico == null)
            {
                return NotFound();
            }
            return View(musico);
        }
        //================================= Edit ==============================
        
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var musicos = await _context.Musicos.SingleOrDefaultAsync(a => a.MusicoID == id);
            if (musicos == null)
            {
                return NotFound();
            }
            return View(musicos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long? id,[Bind("MusicoId,Nome, Telefone, Endereço, Numero, Estado, Cidade, Bairro")] Musico musicos)
        {


            if (id != musicos.MusicoID)
            {
                return NotFound();
            }
           if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicoExists(musicos.MusicoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Indexmusico));
            }
            return View(musicos);
        }
        public bool MusicoExists (long? id)
        {
            return _context.Musicos.Any(a => a.MusicoID == id);
        }
        //============ Delete ==========================
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var musico = await _context.Musicos.SingleOrDefaultAsync(a => a.MusicoID == id);
            if (musico == null)
            {
                return NotFound();
            }
            return View(musico);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var musico = await _context.Musicos.SingleOrDefaultAsync(a => a.MusicoID == id);
            _context.Musicos.Remove(musico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Indexmusico));

        }
        //=================== View  CRUD Musico =======================
        public async Task<IActionResult> Indexmusico()
        {
            return View(await _context.Musicos.OrderBy(i => i.Nome).ToListAsync());
        }







        /*              ============================================
            ======================= CRUD Classe *Instrumento*=============================
            ========================================================================= */
        public IActionResult CreateInstrumento()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInstrumento([Bind("InstrumentoID, Nome, Marca, Modelo, Serie, Cor ")] Instrumento instrumento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instrumento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Indexistrumento));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados.");
            }
            return View(instrumento);
        }


        //=================== View  CRUD Instrumento =======================
        public async Task<IActionResult> Indexistrumento()
        {
            return View(await _context.Instrumentos.OrderBy(i => i.Nome).ToListAsync());
        }


        //======================================= Details ====================
        public async Task<IActionResult> DetailsInstrumento(long? id)
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

        public async Task<IActionResult> EditInstrumento(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instrumentos = await _context.Instrumentos.SingleOrDefaultAsync(a => a.InstrumentoID == id);
            if (instrumentos == null)
            {
                return NotFound();
            }
            return View(instrumentos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditInstrumento(long? id, [Bind("InstrumentoID, Nome, Marca, Modelo, Serie, Cor ")] Instrumento instrumento)
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
                return RedirectToAction(nameof(Indexistrumento));
            }
            return View(instrumento);
        }
        public bool InstrumentoExists(long? id)
        {
            return _context.Instrumentos.Any(a => a.InstrumentoID == id);
        }
        //============ Delete ==========================
        public async Task<IActionResult> DeleteInstrumento(long? id)
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
            return RedirectToAction(nameof(Indexistrumento));

        }
       
    }
}
