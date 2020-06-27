using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ws_Tower_WebApi.Repositories;

namespace Ws_Tower_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        JogoRepository repository = new JogoRepository();

        //Controller Mostra todos jogos
        /// <summary>
        /// Retorna os listar de todos os jogos
        /// </summary>       
        /// <response code="200">Retorna um ok e o uma listar de todos os jogos</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListarJogos()
        {
            return Ok(repository.ListarJogos());
        }

        //Controller listar um jogo com os jogadores de todos os times
        /// <summary>
        /// Retorna os jogo através do ID com os jogadores de cada time
        /// </summary>       
        /// <response code="200">Retorna um ok e o jogo seleciona com os jogadores de cada time</response>
        /// <response code="400">Retornar um erro caso o senha e o Id Estiver nulos</response> 
        [HttpGet("ListarComJogadores/{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarComJogadores(int ID)
        {
            var buscar = repository.BuscarPorJogadores(ID);
            if (buscar == null)
            {
                return StatusCode(400, "Nenhum jogo encontrado com esse ID!!!");
            }
            else
            {
                return Ok(buscar);
            }
        }

        //Controller listar todos jogos pelo estadio
        /// <summary>
        /// Retorna os jogos de um estadio
        /// </summary>       
        /// <response code="200">Retorna um ok e o os jogos da daquele estadio</response>
        /// <response code="400">Retornar um erro caso não tiver encontrado nenhum jogo no estadio selecionando</response> 
        [HttpGet("BuscarPorEstadio/{NomeEstadio}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorEstadio(string NomeEstadio)
        {
            var busca = repository.ListarJogosPorEstadio(NomeEstadio);

            if (busca != null)
            {
                return StatusCode(400, "Nenhum estadio encontrado com esse nome!!!");
            }
            else
            {
                return StatusCode(400, "Nenhum estadio encontrado com esse nome!!!");
            }
        }

        //Controller buscar por jogos de uma seleção
        /// <summary>
        /// Retorna os jogos de uma seleção
        /// </summary>       
        /// <response code="200">Retorna um ok e o os jogos da seleção selecionada</response>
        /// <response code="400">Retornar um erro caso não tiver encontrado com jogo com aquela seleção</response> 
        [HttpGet("BuscarPorSelecao/{NomeSelecao}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorSelecao(string NomeSelecao)
        {
            var busca = repository.BuscarPorSelecao(NomeSelecao);

            if (busca != null)
            {
                return Ok(busca);
            }
            else
            {
                return StatusCode(400, "Nenhum jogo encontrado com esse nome dessa seleção!!!");
            }
        }

        //Controller Mostra todos jogos por data
        /// <summary>
        /// Retorna os jogos de uma data especifica
        /// </summary>       
        /// <response code="200">Retorna um ok e o os jogos da daquele data</response>
        /// <response code="400">Retornar um erro caso não tiver encontrado com jogo com aquela data</response> 
        [HttpGet("ListarData/{Date}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorData(DateTime Date)
        {
            var busca = repository.ListarJogosPorData(Date);

            if (busca != null)
            {
                return Ok(busca);
            }
            else
            {
                return StatusCode(400, "Nenhum jogo encontrado nessa data!!!");
            }
        }

        //Controller buscar um jogo pelo ID
        /// <summary>
        /// Retorna buscar um jogo pelo ID
        /// </summary>       
        /// <response code="200">Retorna um ok e o os jogo selecionado pelo ID</response>
        /// <response code="400">Retornar um erro caso não tiver encontrado um jogo com aquele ID</response> 
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult BuscarPorId(int Id)
        {
            var busca = repository.BuscarJogoPorId(Id);

            if (busca != null)
            {
                return Ok(busca);
            }
            else
            {
                return StatusCode(400, "Nenhum jogo encontrado nessa por esse ID!!!");
            }
        }

    }
}