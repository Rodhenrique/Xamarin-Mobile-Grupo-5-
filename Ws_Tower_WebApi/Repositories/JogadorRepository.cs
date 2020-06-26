using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_Tower_WebApi.Domains;

namespace Ws_Tower_WebApi.Repositories
{
    public class JogadorRepository
    {
        //Esse método buscar jogador pelo id 
        public Jogador BuscarJogadorPorId(int Id)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                Jogador jogador = new Jogador();
                jogador = context.Jogador.FirstOrDefault(J => J.Id == Id);

                if (jogador.Posicao == "Tecnico")
                {
                    jogador.NumeroCamisa = 0;
                }
                return jogador;
            }
        }

        //Esse método buscar jogador pelo nome 
        public Jogador BuscarJogadorPorNome(string Nome)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                Jogador jogador = new Jogador();
                jogador = context.Jogador.Where(Jg => Jg.Nome == Nome)
                    .Include(jg => jg.Selecao)
                    .FirstOrDefault();

                if(jogador.Posicao == "Tecnico")
                {
                    jogador.NumeroCamisa = 0;
                }
                return jogador;
            }
        }

        //Listar todos os jogadores do banco de dados
        public List<Jogador> ListarJogadores()
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Jogador.ToList();
            }
        }

        //Excluir um jogador pelo id
        public void DeletarJogador(int id)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                Jogador jogador = context.Jogador.FirstOrDefault(Jg => Jg.Id == id);
                context.Jogador.Remove(jogador);
                context.SaveChanges();
            }
        }

        //Atualizar um jogador pelo id
        public void AtualizarPorId(Jogador jogadorAtualizado)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                Jogador jogador = context.Jogador.FirstOrDefault(Jg => Jg.Id == jogadorAtualizado.Id);
                jogador.Informacoes = jogadorAtualizado.Informacoes;
                jogador.Nascimento = jogadorAtualizado.Nascimento;
                jogador.Nome = jogadorAtualizado.Nome;
                jogador.Qtdefaltas = jogadorAtualizado.Qtdegols;
                jogador.SelecaoId = jogadorAtualizado.SelecaoId;
                jogador.QtdecartoesAmarelo = jogadorAtualizado.QtdecartoesAmarelo;
                jogador.QtdecartoesVermelho = jogadorAtualizado.QtdecartoesVermelho;
                jogador.Qtdegols = jogadorAtualizado.Qtdegols;
                jogador.Posicao = jogadorAtualizado.Posicao;
                jogador.NumeroCamisa = jogadorAtualizado.NumeroCamisa;
                
                context.Jogador.Update(jogador);
                context.SaveChanges();
            }
        }
    }
}
