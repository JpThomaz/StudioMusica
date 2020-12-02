using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioMusica.Models
{
    public class Instrumento
    {
        public long? InstrumentoID { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        
        public Instrumento()
        {

        }

        internal void Add(Instrumento instrumentos)
        {
            throw new NotImplementedException();
        }
    }
}
