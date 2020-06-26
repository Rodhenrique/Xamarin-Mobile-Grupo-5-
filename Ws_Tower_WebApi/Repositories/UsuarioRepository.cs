using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws_Tower_WebApi.Domains;

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

                UsuarioAtual.Nome = UsuarioAtualizado.Nome;
                UsuarioAtual.Email = UsuarioAtualizado.Email;
                UsuarioAtual.Apelido = UsuarioAtualizado.Apelido;
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
    }
}
