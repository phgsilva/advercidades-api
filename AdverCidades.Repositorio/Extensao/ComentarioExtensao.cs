using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdverCidades.Domain;

namespace AdverCidades.Negocio
{
    public static class ComentarioExtensao
    {
        internal static ComentarioDTO PreencherComentarioDto(this ComentarioDTO aComentarioDto, Comentario aComentario)
        {
            aComentarioDto.Comentario = aComentario.ConteudoComentario;
            aComentarioDto.Data = aComentario.DataComentario;
            aComentarioDto.NomeUsuario = aComentario.Usuario.Nome;

            return aComentarioDto;
        }
    }
}
