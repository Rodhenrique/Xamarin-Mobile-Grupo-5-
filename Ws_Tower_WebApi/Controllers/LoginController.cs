using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpPost]
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