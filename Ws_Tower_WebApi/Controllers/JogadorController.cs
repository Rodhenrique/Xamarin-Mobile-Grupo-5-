using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ws_Tower_WebApi.Domains;
using Ws_Tower_WebApi.Repositories;

namespace Ws_Tower_WebApi.Controllers
{
    public class JogadorController : ControllerBase
    {
        JogadorRepository repository = new JogadorRepository();
        //Controller Mostra um jogador pelo ID
        [HttpGet]
        public IActionResult MostraJogador(int id)
        {
            var Buscar = repository.BuscarJogadorPorId(id);
            if (Buscar == null)
            {
                return StatusCode(404, "Usuário não encontrado");
            }
            else
            {
                Buscar.Idade = Buscar.Nascimento.Year - DateTime.Now.Year;
                if(DateTime.Now.DayOfYear < Buscar.Nascimento.DayOfYear)
                {
                    Buscar.Idade = Buscar.Idade - 1;
                }
                return StatusCode(202, Buscar);
            }
        }

        //Controller Mostra um jogador pelo nome do jogador
        [HttpGet]
        public IActionResult MostraJogadorNome(string Nome)
        {
            var Buscar = repository.BuscarJogadorPorNome(Nome);
            if (Buscar == null)
            {
                return StatusCode(404, "Usuário não encontrado");
            }
            else
            {
                Buscar.Idade = Buscar.Nascimento.Year - DateTime.Now.Year;
                if (DateTime.Now.DayOfYear < Buscar.Nascimento.DayOfYear)
                {
                    Buscar.Idade = Buscar.Idade - 1;
                }
                return StatusCode(202, Buscar);
            }
        }
    }
}