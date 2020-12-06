using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StudioMusica.Models;


namespace StudioMusica.ViewModels
{
    public class AlbumCreateVM
    {
        public long? AlbumID { get; set; }
        public string Nome { get; set; }
        public DateTime DataAlbum { get; set; }
        public string Formato { get; set; }
        public string Genero { get; set; }
        public IFormFile Foto { get; set; }
        public string EditImagePath { get; set; }
    }
}
