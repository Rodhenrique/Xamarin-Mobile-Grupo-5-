using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ws_Tower_WebApi.Domains;
using Ws_Tower_WebApi.Repositories;
using Ws_Tower_WebApi.ViewModel;

namespace Ws_Tower_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        UsuarioRepository repository = new UsuarioRepository();

        //Controller todos os usuários do sistema
        /// <summary>
        /// Retorna uma listar de usuários
        /// </summary>
        /// <response code="200">Retorna um ok e a listar de usuários</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListarUsuario()
        {
            return Ok(repository.ListarUsuarios());
        }

        //Controller atualizar um usuário
        /// <summary>
        /// Atualizar um usuário do sistema 
        /// </summary>       
        /// <response code="202">Retorna um aceito assim atualiza o sistema</response>
        /// <response code="400">Retornar um erro caso o usuário estiver nulo</response>  
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// <summary>
        /// Cadastro de um usuário no sistema 
        /// </summary>       
        /// <response code="201">Retorna um criado assim criar um usuário no sistema</response>
        /// <response code="404">Retornar um erro caso o algun campo estiver nulo</response>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        //Mudar senha do usuário 
        /// <summary>
        /// Alterar Senha do usuário através de um ID ou Apelido ou Email
        /// </summary>       
        /// <response code="201">Retorna um aceito assim mudar a senha de um usuário no sistema</response>
        /// <response code="400">Retornar um erro caso o senha e o Id Estiver nulos</response>  
        [HttpPut("EsquecirSenha")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AlterarSenha(AlterarSenhaViewModel user)
        {
            if (user != null)
            {
                repository.AtualizarSenha(user);
                return StatusCode(202, "Sua senha foi atualizado com sucesso!!!");
            }
            else
            {
                return StatusCode(400, "Digite uma senha para atualizar!!!");
            }
        }
    }
}