using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_Tower_WebApi.Domains;

namespace Ws_Tower_WebApi.Repositories
{
    public class SelecaoRepository
    {
        public List<Selecao> ListarSelecaos()
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Selecao.ToList();
            }
        }

        public List<Selecao> Pontuacao()
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Selecao.ToList();
            }
        }
    }
}
