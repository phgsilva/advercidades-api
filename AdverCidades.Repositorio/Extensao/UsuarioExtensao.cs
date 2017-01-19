using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdverCidades.Domain;

namespace AdverCidades.Negocio
{
    public static class UsuarioExtensao
    {
        internal static UsuarioPerfilDTO PreencherUsuarioPerfilDto(this UsuarioPerfilDTO aUsuarioPerfilDto, Usuario aUsuario)
        {
            aUsuarioPerfilDto.Identificador = aUsuario.Identificador;
            aUsuarioPerfilDto.Nome = aUsuario.Nome;
            aUsuarioPerfilDto.Foto = aUsuario.Foto64;

            return aUsuarioPerfilDto;
        }
    }
}
