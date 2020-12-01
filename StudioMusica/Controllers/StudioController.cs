using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioMusica.Data;

namespace StudioMusica.Controllers
{
    public class StudioController : Controller
    {
        private readonly StudioContext _context;

        public StudioController(StudioContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Musicos.OrderBy(a => a.Nome).ToListAsync());
        }
        public IActionResult RegistroMusico()
        {
            return View();
        }
    }
}
