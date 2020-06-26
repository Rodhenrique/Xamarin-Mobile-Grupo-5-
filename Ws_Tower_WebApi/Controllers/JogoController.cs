using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public IActionResult ListarJogos()
        {
            return Ok(repository.ListarJogos());
        }

        //Controller listar um jogo com os jogadores de todos os times
        [HttpGet("ListarComJogadores/{ID}")]
        public IActionResult ListarComJogadores(int ID)
        {
            return Ok(repository.BuscarPorJogadores(ID));
        }

        //Controller listar todos jogos pelo estadio
        [HttpGet("BuscarPorEstadio/{NomeEstadio}")]
        public IActionResult ListarPorEstadio(string NomeEstadio)
        {
            var busca = repository.ListarJogosPorEstadio(NomeEstadio);

            if (busca != null)
            {
                return Ok(busca);
            }
            else
            {
                return StatusCode(400, "Nenhum estadio encontrado com esse nome!!!");
            }
        }

        //Controller buscar por jogos de uma seleção
        [HttpGet("BuscarPorSelecao/{NomeSelecao}")]
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
        [HttpGet("ListarData/{Date}")]
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
        [HttpGet("{Id}")]
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