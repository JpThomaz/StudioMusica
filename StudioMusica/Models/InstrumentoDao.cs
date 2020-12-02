using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioMusica.Models
{
    public class InstrumentoDAO
    {
        private static IList<Instrumento> instrumentos = new List<Instrumento>()
        {
            new Instrumento()
            {
               InstrumentoID=0495,
               Nome = "Teclado",
               Marca = "Rolland",
               Modelo = "Tx-500",
               Serie = "248 / 2",
            }
        };

        public async Task<Instrumento> GravarInstrumento(Instrumento instrumento)
        {
            instrumento.Add(instrumento);
            return instrumento;
        }
        public IList<Instrumento> ObterTodos()
        {
            return instrumentos;
        }
    }
}
