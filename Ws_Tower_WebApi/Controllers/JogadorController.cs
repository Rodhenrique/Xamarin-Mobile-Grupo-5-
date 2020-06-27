using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ws_Tower_WebApi.Domains;
using Ws_Tower_WebApi.Repositories;

namespace Ws_Tower_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        JogadorRepository repository = new JogadorRepository();

        //Controller Mostra um jogador pelo ID
        /// <summary>
        /// Buscar um jogador pelo ID 
        /// </summary>       
        /// <response code="202">Retorna um aceito assim retorna o jogador</response>
        /// <response code="404">Retornar um erro não caso acha o jogador pelo ID</response> 
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult MostraJogador(int Id)
        {
            var Buscar = repository.BuscarJogadorPorId(Id);
            if (Buscar == null)
            {
                return StatusCode(404, "Usuário não encontrado");
            }
            else
            {
                int IdadeOficial = Math.Abs(Buscar.Nascimento.Year - DateTime.Now.Year);
                if (DateTime.Now.DayOfYear < Buscar.Nascimento.DayOfYear)
                {
                    IdadeOficial = IdadeOficial - 1;
                }

                 var objeto = new { Nome = Buscar.Nome,
                    Nascimento = Buscar.Nascimento,
                    Posicao = Buscar.Posicao,
                    Qtdefaltas = Buscar.Qtdefaltas,
                    QtdecartoesAmarelo = Buscar.QtdecartoesAmarelo,
                    QtdecartoesVermelho = Buscar.QtdecartoesVermelho,
                    Qtdegols = Buscar.Qtdegols,
                    Informacoes = Buscar.Informacoes,
                    NumeroCamisa = Buscar.NumeroCamisa,
                    SelecaoId = Buscar.SelecaoId,
                    Selecao = Buscar.Selecao,
                    Idade = IdadeOficial,
                    Foto = Buscar.Foto
                };

               
                return StatusCode(202, objeto);
            }
        }

        //Controller Mostra um jogador pelo nome do jogador
        /// <summary>
        /// Buscar um jogador pelo nome 
        /// </summary>       
        /// <response code="202">Retorna um aceito assim retorna o jogador</response>
        /// <response code="404">Retornar um erro caso não acha o jogador pelo nome</response> 
        [HttpGet("BuscarNome/{Nome}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult MostraJogadorNome(string Nome)
        {
            var Buscar = repository.BuscarJogadorPorNome(Nome);
            if (Buscar == null)
            {
                return StatusCode(404, "Usuário não encontrado");
            }
            else
            {
                var objeto = new
                {
                    Nome = Buscar.Nome,
                    Nascimento = Buscar.Nascimento,
                    Posicao = Buscar.Posicao,
                    Qtdefaltas = Buscar.Qtdefaltas,
                    QtdecartoesAmarelo = Buscar.QtdecartoesAmarelo,
                    QtdecartoesVermelho = Buscar.QtdecartoesVermelho,
                    Qtdegols = Buscar.Qtdegols,
                    Informacoes = Buscar.Informacoes,
                    NumeroCamisa = Buscar.NumeroCamisa,
                    SelecaoId = Buscar.SelecaoId,
                    Selecao = Buscar.Selecao,
                    Idade = Math.Abs(Buscar.Nascimento.Year - DateTime.Now.Year),
                    Foto = Buscar.Foto
                }; 
               
                return StatusCode(202, objeto);
            }
        }

        //Controller buscar o jogador por uma seleção
        /// <summary>
        /// Buscar retorna os jogadores de uma seleção 
        /// </summary>       
        /// <response code="200">Retorna um aceito e uma listar jogadores de uma seleção</response>
        /// <response code="400">Retornar um erro não caso acha jogadores pela seleção</response> 
        [HttpGet("BuscarPorSelecao/{Nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult BuscarPorSelecao(string Nome)
        {
            var buscar = repository.BuscarPorSelecao(Nome);
            if (buscar == null)
            {
                return StatusCode(400, "Nenhum jogador encontrado nessa seleção!!!");
            }
            else
            {
                return StatusCode(200, buscar);
            }
        }

        //Controller Mostra todos os jogadores
        /// <summary>
        /// retorna uma listar de jogadores
        /// </summary>       
        /// <response code="200">Retorna um OK e uma listar de jogadores</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListarJogadores()
        {
            return Ok(repository.ListarJogadores());
        }
    }
}