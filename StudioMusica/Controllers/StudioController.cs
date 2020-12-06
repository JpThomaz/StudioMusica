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
 
    public class StudioController : Controller
    {

        

        private readonly StudioContext _context;

        public StudioController(StudioContext context)
        {
            _context = context;
        }
        public IActionResult IndexPrincipal()
        {
            return View();
        }
    }
}
