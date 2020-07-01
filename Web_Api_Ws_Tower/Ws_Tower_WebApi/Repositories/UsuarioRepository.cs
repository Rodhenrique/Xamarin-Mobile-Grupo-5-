using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_Tower_WebApi.Domains;
using Ws_Tower_WebApi.ViewModel;

namespace Ws_Tower_WebApi.Repositories
{
    public class UsuarioRepository
    {
        //Listar todos os usuários do banco de dados
        public List<Usuario> ListarUsuarios()
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Usuario.ToList();
            }
        }

        //Esse método buscar um usuário pelo
        public Usuario BuscarPorId(int Id)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Usuario.FirstOrDefault(U => U.Id == Id);
            }
        }

        //Esse método atualizar um usuário pelo id
        public void AtualizarUsuario(Usuario UsuarioAtualizado)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                Usuario UsuarioAtual = context.Usuario.FirstOrDefault(U => U.Id == UsuarioAtualizado.Id);

                if(UsuarioAtualizado.Apelido == null)               
                    UsuarioAtual.Apelido = UsuarioAtual.Apelido;
                else 
                UsuarioAtual.Apelido = UsuarioAtualizado.Apelido;

                if (UsuarioAtualizado.Nome == null)
                UsuarioAtual.Nome = UsuarioAtual.Nome;
                else
                    UsuarioAtual.Nome = UsuarioAtualizado.Nome;

                if (UsuarioAtualizado.Email == null)
                    UsuarioAtual.Email = UsuarioAtual.Email;
                else
                    UsuarioAtual.Email = UsuarioAtualizado.Email;

                if (UsuarioAtualizado.Foto == null)
                    UsuarioAtual.Foto = UsuarioAtual.Foto;
                else
                UsuarioAtual.Foto = UsuarioAtualizado.Foto;

                context.Usuario.Update(UsuarioAtual);
                context.SaveChanges();
            }
        }

        //Esse método deletar um usuário pelo id
        public void DeletarPorId(int Id)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                Usuario usuario = context.Usuario.FirstOrDefault(U => U.Id == Id);
                context.Usuario.Remove(usuario);
                context.SaveChanges();
            }
        }

        //Esse método listar todos os Usuários do banco de dados
        public void CadastraUsuario(Usuario NovoUsuario)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                context.Usuario.Add(NovoUsuario);
                context.SaveChanges();
            }
        }

        //Esse método buscar um usuário Através do apelido ou email
        public bool UsuarioExiste(string NomeDeBuscar)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                Usuario usuario = context.Usuario.FirstOrDefault(U =>
                U.Email == NomeDeBuscar || U.Apelido == NomeDeBuscar);

                if (usuario != null)
                    return true;
                else
                    return false;
            }
        }

        public Usuario Login(string Nome, string Senha)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                return context.Usuario.FirstOrDefault(U => U.Nome == Nome || U.Email == Nome && U.Senha == Senha);
            }
        }

        public void AtualizarSenha(AlterarSenhaViewModel usuario)
        {
            using (WsTowerContext context = new WsTowerContext())
            {
                Usuario atual = context.Usuario.FirstOrDefault(U => U.Id == usuario.ID || 
                U.Nome == usuario.Nome || U.Email == usuario.Nome);
                atual.Senha = usuario.Senha;
                context.Usuario.Update(atual);
                context.SaveChanges();
            }
        }
    }
}
