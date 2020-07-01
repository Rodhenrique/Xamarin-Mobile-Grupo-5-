using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_Tower_WebApi.Domains;

namespace Ws_Tower_WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogo> ListarJogos()
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Jogo.Include(J => J.SelecaoVisitanteNavigation)
                    .Include(J => J.SelecaoCasaNavigation).ToList();
            }
        }

        public List<Jogo> ListarJogosPorData(DateTime Date)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Jogo.ToList().FindAll(J => J.Data.Value.DayOfYear == Date.DayOfYear);
            }
        }

        public List<Jogo> ListarJogosPorEstadio(string NomeEstadio)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Jogo.OrderBy(J => J.Data).ToList().FindAll(J => J.Estadio == NomeEstadio);
            }
        }

        public Jogo BuscarJogoPorId(int Id)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Jogo.Include(J => J.SelecaoVisitanteNavigation)
                    .Include(J => J.SelecaoCasaNavigation)
                    .FirstOrDefault(J => J.Id == Id);
            }
        }

        public Jogo BuscarPorJogadores(int Id)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Jogo.Include(J => J.SelecaoVisitanteNavigation.Jogador)
                    .Include(J => J.SelecaoCasaNavigation.Jogador)
                    .FirstOrDefault(J => J.Id == Id);
            }
        }

        public List<Jogo> BuscarPorSelecao(string NomeSelecao)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Jogo.Include(J => J.SelecaoCasaNavigation)
                    .Include(J => J.SelecaoVisitanteNavigation)
                    .ToList().FindAll(J => J.SelecaoCasaNavigation.Nome == NomeSelecao);
            }
        }
    }
}
