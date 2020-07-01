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
    public class SelecaoController : ControllerBase
    {
        SelecaoRepository repository = new SelecaoRepository();

        //Controller Mostra todos jogos
        /// <summary>
        /// Listar as seleções do sistema
        /// </summary>
        /// <response code="200">Retorna um ok é uma listar de seleções</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListarSelecaos()
        {
            return Ok(repository.ListarSelecaos());
        }

    }
}