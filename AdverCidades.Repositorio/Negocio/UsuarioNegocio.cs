using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdverCidades.Dados.DAO;
using AdverCidades.Domain;

namespace AdverCidades.Negocio
{
    public class UsuarioNegocio : Negocio<Usuario>, IDisposable
    {
        /// <summary>
        /// Contrutor instancia classe repositorio 
        /// </summary>
        public UsuarioNegocio()
        {
            Repositorio = new UsuarioDados();
        }

        /// <summary>
        /// Metodo para salvar entodade usuario   
        /// </summary>
        /// <param name="aUsuario">Usuario a ser salvo</param>
        public void SalvarUsuario(Usuario aUsuario)
        {
            Repositorio.Salvar(aUsuario);
        }

        /// <summary>
        /// Metodo para excluir usuario
        /// </summary>
        /// <param name="aUsuario">Usuario que será excluído</param>
        public void ExcluirUsuario(long aIdUsuario)
        {
            var usuario = Repositorio.BuscarPorId(aIdUsuario);
            Repositorio.Excluir(usuario);
        }

        /// <summary>
        /// Metodo que salva alterações em entidades usuario
        /// </summary>
        /// <param name="aUsuario">Usuario alterado</param>
        public void EditarUsuario(Usuario aUsuario)
        {
            Repositorio.Editar(aUsuario);
        }

        /// <summary>
        /// Buscar usuario por identificador
        /// </summary>
        /// <param name="aIdentificador">Identificador do usuario que deseja buscar</param>
        /// <returns>usuario encontrado</returns>
        public UsuarioPerfilDTO BuscarUsuarioPorId(long aIdentificador)
        {
            Usuario usuario = Repositorio.BuscarPorId(aIdentificador);
            UsuarioPerfilDTO usuarioPerfil = new UsuarioPerfilDTO().PreencherUsuarioPerfilDto(usuario); 

            return usuarioPerfil;
        }

        /// <summary>
        /// Busca todos usuarios
        /// </summary>
        /// <returns>coleção de usuarios</returns>
        public IEnumerable<UsuarioPerfilDTO> BuscarUsuarios()
        {
            var usuarios = Repositorio.Buscar().ToList();
            IEnumerable<UsuarioPerfilDTO> usuariosPerfil = usuarios.Select(u => new UsuarioPerfilDTO().PreencherUsuarioPerfilDto(u));

            return usuariosPerfil;
        }

        public void Dispose()
        {
            Repositorio.Dispose();
        }
    }
}
