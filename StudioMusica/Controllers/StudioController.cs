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
            var musico = await _context.Musicos.SingleOrDefaultAsync(a => a.MusicoID == id);
            if (musico == null)
            {
                return NotFound();
            }
            return View(musico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long? id,[Bind("MusicoId,Nome, Telefone, Endereço, Numero, Estado, Cidade, Bairro")] Musico musico)
        {


            if (id != musico.MusicoID)
            {
                return NotFound();
            }
           if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicoExists(musico.MusicoID))
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
            return View(musico);
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
                    return RedirectToAction(nameof(Indexinstrumento));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados.");
            }
            return View(instrumento);
        }


        //=================== View  CRUD Instrumento =======================
        public async Task<IActionResult> Indexinstrumento()
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
            var instrumento = await _context.Instrumentos.SingleOrDefaultAsync(a => a.InstrumentoID == id);
            if (instrumento == null)
            {
                return NotFound();
            }
            return View(instrumento);
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
                return RedirectToAction(nameof(Indexinstrumento));
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
        [HttpPost, ActionName("DeleteInstrumento")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmedInstrumento(long? id)
        {
            var instrumento = await _context.Instrumentos.SingleOrDefaultAsync(a => a.InstrumentoID == id);
            _context.Instrumentos.Remove(instrumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Indexinstrumento));

        }



        /*              ============================================
           ======================= CRUD Classe Faixa =============================
           ========================================================================= */
        public IActionResult CreateFaixa()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFaixa([Bind("FaixaID, Nome, Autor, DataLancamento,Volume ")] Faixa faixa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(faixa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(IndexFaixa));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados.");
            }
            return View(faixa);
        }


        //=================== View  CRUD Faixa =======================
        public async Task<IActionResult> IndexFaixa()
        {
            return View(await _context.Faixas.OrderBy(i => i.Nome).ToListAsync());
        }


        //======================================= Details ====================
        public async Task<IActionResult> DetailsFaixa(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var faixa = await _context.Faixas.SingleOrDefaultAsync(a => a.FaixaId == id);
            if (faixa == null)
            {
                return NotFound();
            }
            return View(faixa);
        }



        //================================= Edit ==============================

        public async Task<IActionResult> EditFaixa(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var faixa = await _context.Faixas.SingleOrDefaultAsync(a => a.FaixaId == id);
            if (faixa == null)
            {
                return NotFound();
            }
            return View(faixa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditFaixa(long? id, [Bind("FaixaID, Nome, Autor, DataLancamento,Volume ")] Faixa faixa)
        {


            if (id != faixa.FaixaId)
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
                    if (!FaixaExists(faixa.FaixaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexFaixa));
            }
            return View(faixa);
        }
        public bool FaixaExists(long? id)
        {
            return _context.Faixas.Any(a => a.FaixaId == id);
        }
        //============ Delete ==========================
        public async Task<IActionResult> DeleteFaixa(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var faixa = await _context.Faixas.SingleOrDefaultAsync(a => a.FaixaId == id);
            if (faixa == null)
            {
                return NotFound();
            }
            return View(faixa);
        }
        [HttpPost, ActionName("DeleteFaixa")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmedFaixa(long? id)
        {
            var faixa = await _context.Faixas.SingleOrDefaultAsync(a => a.FaixaId == id);
            _context.Faixas.Remove(faixa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexFaixa));

        }


                  
        /*              ============================================
          ======================= CRUD Classe Album =============================
          ========================================================================= */
        public IActionResult CreateAlbum()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAlbum([Bind("AlbumID, Nome, DataAlbum, Formato")] Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(album);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(IndexAlbum));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados.");
            }
            return View(album);
        }


        //=================== View  CRUD Faixa =======================
        public async Task<IActionResult> IndexAlbum()
        {
            return View(await _context.Albuns.OrderBy(i => i.Nome).ToListAsync());
        }


        //======================================= Details ====================
        public async Task<IActionResult> DetailsAlbum(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var album = await _context.Albuns.SingleOrDefaultAsync(a => a.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }



        //================================= Edit ==============================

        public async Task<IActionResult> EditAlbum(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var album = await _context.Albuns.SingleOrDefaultAsync(a => a.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditAlbum(long? id, [Bind("AlbumID, Nome, DataAlbum, Formato")] Album album)
        {


            if (id != album.AlbumID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexAlbum));
            }
            return View(album);
        }
        public bool AlbumExists(long? id)
        {
            return _context.Albuns.Any(a => a.AlbumID == id);
        }
        //============ Delete ==========================
        public async Task<IActionResult> DeleteAlbum(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var album = await _context.Albuns.SingleOrDefaultAsync(a => a.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }
        [HttpPost, ActionName("DeleteAlbum")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmedAlbum(long? id)
        {
            var album = await _context.Albuns.SingleOrDefaultAsync(a => a.AlbumID == id);
            _context.Albuns.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexAlbum));

        }

    }
}
