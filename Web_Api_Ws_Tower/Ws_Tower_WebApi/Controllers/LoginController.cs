using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ws_Tower_WebApi.Repositories;
using Ws_Tower_WebApi.ViewModel;

namespace Ws_Tower_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //Logar com um usuário
        UsuarioRepository repository = new UsuarioRepository();

        /// <summary>
        /// Fazer o login no sistema
        /// </summary>
        /// <response code="200">Retorna um ok assim você logar no sistema</response>
        /// <response code="400">Retornar um erro caso o usuário for invalido</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Logar(Login User)
        {
            var buscar = repository.Login(User.Email, User.Senha);
            if (buscar == null)
            {
                return StatusCode(400,"Usuário invalido confirar os campos novamente!!!");
            }
            else
            {
                return StatusCode(200,buscar);
            }
        }
    }
}