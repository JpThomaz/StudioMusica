using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioMusica.Models
{
    public class Faixa
    {
        public long? FaixaId { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Volume { get; set; }
        public Faixa()
        {

        }

        internal void Add(Faixa faixas)
        {
            throw new NotImplementedException();
        }
    }
}
