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
    public class SelecaoController : ControllerBase
    {
        SelecaoRepository repository = new SelecaoRepository();

        //Controller Mostra todos jogos
        [HttpGet]
        public IActionResult ListarSelecaos()
        {
            return Ok(repository.ListarSelecaos());
        }

    }
}