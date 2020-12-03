using Microsoft.EntityFrameworkCore;
using StudioMusica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioMusica.Data
{
    public class StudioContext : DbContext
    {
        public StudioContext(DbContextOptions<StudioContext> options): base(options)
        {

        }

        public DbSet <Musico> Musicos { get; set; }
        public DbSet <Instrumento> Instrumentos { get; set; }
        public DbSet  <Faixa> Faixas  { get; set; }
        public DbSet<Album>  Albuns { get; set; }
    }
}
