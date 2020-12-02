using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioMusica.Models
{
    public class Musico
    {
        public long? MusicoID { get; set; }
        public string Nome { get; set; }
        public string Telefone{ get; set; }
        public string Endereço { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public Musico()
        {

        }

        internal void Add(Musico musicos)
        {
            throw new NotImplementedException();
        }
    }
}
