using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudioMusica.Models
{
    public class Album
    {
        public long? AlbumID { get; set; }

        public string Nome { get; set; }
        public DateTime DataAlbum { get; set; }
        public string Formato { get; set; }

        public string Genero { get; set; }

        public string Foto { get; set; }
        
       
    }
    
       
    
}

