using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioMusica.Data;
<<<<<<< HEAD
using StudioMusica.Models;
=======
>>>>>>> 1e3cf6aec4768ebd439f46879824ac25340168a1

namespace StudioMusica.Controllers
{
    public class StudioController : Controller
    {
<<<<<<< HEAD
        [HttpPost]
        [ValidateAntiForgeryToken]
=======
        private readonly StudioContext _context;

        public StudioController(StudioContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Musicos.OrderBy(a => a.Nome).ToListAsync());
        }
>>>>>>> 1e3cf6aec4768ebd439f46879824ac25340168a1
        public IActionResult RegistroMusico()
        {
            return View();
        }
        private readonly StudioContext _context;

        public StudioController(StudioContext context)
        {
            _context = context;
        }
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
        public async Task<IActionResult> Edit(long? id,[Bind(" MusicoId,Nome, Telefone, Endereço, Numero, Estado, Cidade, Bairro")] Musico musico)
        {
           
            
           /* if (id != musico.MusicoID)
            {
                return NotFound();
            }*/
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
        public async Task<IActionResult> Indexmusico()
        {
            return View(await _context.Musicos.OrderBy(i => i.Nome).ToListAsync());
        }
    }
}
