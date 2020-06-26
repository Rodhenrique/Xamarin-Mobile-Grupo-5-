using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Ws_Tower_WebApi.Repositories;
using Ws_Tower_WebApi.Domains;
using Ws_Tower_WebApi.Interfaces;
using Ws_Tower_WebApi.ViewModels;

namespace Ws_Tower_WebApi.Controllers
{

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class LoginController : ControllerBase
    {

        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>

        private IUsuarioRepository usuarioRepository { get; set; }

	    /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>

        public LoginController()
        {
            usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="Login">Objeto login que contém o e-mail/apelido e a senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        /// <response code="200">Retorna o token gerado</response>
        /// <response code="400">Retorna o erro gerado com uma mensagem personalizada</response>
        /// dominio/api/Login


        public Usuario buscarPorEmailSenha(LoginViewModel loginViewModel)
        {
            using(campeonatoContext ctx = new CampeonatoContext())
            {
            return ctx.Usuario.FirstOrDefault(x => (x.Email == loginViewModel.email || x.apelido == loginViewModel.email) && x.Senha == loginViewModel.Senha);
            }
        }

        
        public IActionResult Post(LoginViewModel Login)
        {
            Usuarios usuarioBuscado = usuarioRepository.BuscarEmailSenha((Login.Email || Login.apelido) , Login.Senha);
		
            if (usuarioBuscado == null)
            {
                // Retorna NotFound com uma mensagem de erro
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Ws_Tower_WebApi-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "WsTower.WebApi",
                audience: "WsTower.WebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }
    }
}



