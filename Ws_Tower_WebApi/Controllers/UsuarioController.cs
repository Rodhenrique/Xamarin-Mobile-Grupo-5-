using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ws_Tower_WebApi.Domains;
using Ws_Tower_WebApi.Repositories;

namespace Ws_Tower_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        UsuarioRepository repository = new UsuarioRepository();

        //Controller todos os usuários do sistema
        [HttpGet]
        public IActionResult ListarUsuario()
        {
            return Ok(repository.ListarUsuarios());
        }

        //Controller atualizar um usuário
        [HttpPut]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
            if(usuario != null)
            {
                repository.AtualizarUsuario(usuario);
                return StatusCode(202, "Seu usuário foi atualizado com sucesso!!!");
            }
            else
            {
                return StatusCode(400, "Digite um usuário para atualizar!!!");
            }
        }

        //Esse controllers cadastra um usuário no sistema
        [HttpPost]
        public IActionResult Cadastro(Usuario NovoUsuario)
        {
            if (NovoUsuario != null)
            {
                if (NovoUsuario.Apelido.Length < 3)
                {
                    return StatusCode(404, "O apelido deve tem no mínimo 3 caracteres!!!");
                }
                else if (NovoUsuario.Nome.Length < 3)
                {
                    return StatusCode(404, "O nome deve tem no mínimo 3 caracteres!!!");
                }
                else if (NovoUsuario.Senha.Length < 3)
                {
                    return StatusCode(404, "A senha deve tem no mínimo 3 caracteres!!!");
                }

                if (repository.UsuarioExiste(NovoUsuario.Apelido))
                {
                    return StatusCode(404, "Apelido já existe no sistema cadastre outro!!!");
                }
                else if (repository.UsuarioExiste(NovoUsuario.Email))
                {
                    return StatusCode(404, "Email já Cadastrado no sistema!!!");
                }
                else if (NovoUsuario.Foto == null)
                {
                    return StatusCode(404, "Coloque uma foto para prosseguir!!!");
                }

                repository.CadastraUsuario(NovoUsuario);
                return StatusCode(201, "Seu usuário foi criado com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Algun campo não foi preenchido!!!");
            }
        }
    }
}