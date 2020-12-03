using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioMusica.Models
{
    public class Album
    {

        public long? AlbumID { get; set; }
        public string Nome { get; set; }
        public DateTime DataAlbum { get; set; }
        public string Formato { get; set; }
        public Album()
        {

        }

        internal void Add(Album albuns)
        {
            throw new NotImplementedException();
        }
    }
}

