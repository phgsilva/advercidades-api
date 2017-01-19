using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdverCidades.Domain;
using AdverCidades.Dados.DAO;

namespace AdverCidades.Negocio
{
    public class ComentarioNegocio : Negocio<Comentario>, IDisposable
    {
        /// <summary>
        /// Construtor que instancia classe de repositorio
        /// </summary>
        public ComentarioNegocio()
        {
            Repositorio = new ComentarioDados();
        }

        /// <summary>
        /// Metodo para salvar entidade Comentario
        /// </summary>
        /// <param name="aComentario">Entidade a ser salva</param>
        public void SalvarComentario(Comentario aComentario)
        {
            Repositorio.Salvar(aComentario);
        }

        /// <summary>
        /// Metodo que busca comentarios a partir do identificador de Report
        /// </summary>
        /// <returns>Lista de comentarios</returns>
        public IEnumerable<ComentarioDTO> BuscarComentarios(long aIdentificadorReport)
        {
            var comentarios = Repositorio.Buscar().Where(c => c.ReportIdentificador == aIdentificadorReport).ToList();
            IEnumerable<ComentarioDTO> comentariosDTO = comentarios.Select(c => new ComentarioDTO().PreencherComentarioDto(c));

            return comentariosDTO;
        }

        public void Dispose()
        {
            Repositorio.Dispose();
        }
    }
}
