using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioMusica.Data;
using StudioMusica.Models;
using StudioMusica.Services;
using StudioMusica.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using Microsoft.AspNetCore.Hosting;

namespace StudioMusica.Controllers
{       
    public class AlbumController : Controller
    {
        private readonly StudioContext _context;
       // private readonly IWebHostEnvironment hostingEnvironment;
       // private readonly IFileService fileService;
      
        public AlbumController(StudioContext context, IWebHostEnvironment environment, IFileService fileService)
        {
            _context = context;
           // hostingEnvironment = environment;
           // this.fileService = fileService;
        }
       // public static string getpath;
        //=================== View  CRUD Album =======================
        public async Task<IActionResult> IndexAlbum()
        {
            return View(await _context.Albuns.OrderBy(i => i.Nome).ToListAsync());
        }
        [HttpGet]
        public IActionResult CreateAlbum()
        {
            //var album = new AlbumCreateVM();
            return View();
        }

        /*
        public async Task<IActionResult> CreateAlbum([Bind("AlbumID, Nome, DataAlbum, Formato,Foto,Genero")] AlbumCreateVM vm)
        {


            
                Album album = new Album()
                {
                    Foto = vm.Foto.FileName,
                    Nome = vm.Nome,
                    AlbumID = vm.AlbumID
                };
                if (ModelState.IsValid)
                {
                    var fileName = fileService.Upload(vm.Foto);
                    album.Foto = fileName;
                    getpath = fileName;

                    _context.Add(album);
                    await _context.SaveChangesAsync();
                    TempData["message"] = "Adicionado com sucesso";
                    return RedirectToAction(nameof(IndexAlbum));
                 }
                return View(album);
            
        }
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAlbum([Bind("AlbumID, Nome, DataAlbum, Formato,Foto,Genero")] Album album)
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



        //======================================= Details ====================
        public async Task<IActionResult> Details(long? id)
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

        public async Task<IActionResult> Edit(long? id)
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

        public async Task<IActionResult> Edit(long? id, [Bind("AlbumID, Nome, DataAlbum, Formato,Foto,Genero")] Album album)
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
        public async Task<IActionResult> Delete(long? id)
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
        [HttpPost, ActionName("Delete")]
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
