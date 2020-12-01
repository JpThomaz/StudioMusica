using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioMusica.Models
{
    public class StudioDao
    {

        public StudioDao()
        {
        }

        private static IList<Musico> musicos = new List<Musico>()
        {

            new Musico()
            {
                Nome = "Amanda",
                Telefone = "amanda@amanda.com",
                Endereço = "34455445"

            }
        };

        public async Task<Musico> GravarMusico(Musico musico)
        {
            musicos.Add(musico);
            return musico;
        }

        public IList<Musico> ObterTodos()
        {
            return musicos;
        }
    }
}


