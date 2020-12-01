using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioMusica.Models
{
<<<<<<< HEAD
    public class MusicoDao
    {
        private static IList<Musico> musicos = new List<Musico>()
        {
            new Musico()
            {
               MusicoID=0495,
               Nome = "João",
               Telefone = "(24) 998490239",
               Endereço = "Avenida Brasil",
               Numero = "248 / 2",
               Estado = "RJ",
               Cidade = "Volta Redonda",
               Bairro = "Retiro"
            }
        };

            public async Task<Musico> GravarMusico(Musico musico)
            {
                musico.Add(musico);
                return musico;
            }
            public IList<Musico> ObterTodos()
            {
                return musicos;
            }
    }
    
}
=======
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


>>>>>>> 1e3cf6aec4768ebd439f46879824ac25340168a1
