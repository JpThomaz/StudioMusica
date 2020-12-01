using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioMusica.Models
{

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

  



