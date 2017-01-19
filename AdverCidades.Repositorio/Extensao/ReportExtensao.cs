using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdverCidades.Domain;

namespace AdverCidades.Negocio
{
    public static class ReportExtensao
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aResumoReport"></param>
        /// <param name="aReport"></param>
        /// <returns></returns>
        internal static ReportResumoDTO PreencherReportResumoDto(this ReportResumoDTO aResumoReport, Report aReport)
        {
            aResumoReport.Identificador = aReport.Identificador;
            aResumoReport.Titulo = aReport.Titulo;
            aResumoReport.Data = aReport.DataHora.Date;
            aResumoReport.Latitude = aReport.Latitude;
            aResumoReport.Longitude = aReport.Longitude;
            aResumoReport.Resolvido = aReport.Resolvido;

            return aResumoReport;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aReportDetalhado"></param>
        /// <param name="aReport"></param>
        /// <returns></returns>
        public static ReportDetalhadoDTO PreencherReportDetalhadoDto(this ReportDetalhadoDTO aReportDetalhado, Report aReport)
        {
            aReportDetalhado.Identificador = aReport.Identificador;
            aReportDetalhado.Titulo = aReport.Titulo;
            aReportDetalhado.Descricao = aReport.Descricao;
            aReportDetalhado.Latitude = aReport.Latitude;
            aReportDetalhado.Longitude = aReport.Longitude;
            aReportDetalhado.Data = aReport.DataHora;
            aReportDetalhado.IdentificadorUsuario = aReport.UsuarioIdentificador;
            aReportDetalhado.NomeUsuario = aReport.Usuario.Nome;
            aReportDetalhado.IdentificadorCategoria = aReport.CategoriaIdentificador;
            aReportDetalhado.DescricaoCategoria = aReport.Categoria.DescricaoCat;
            aReportDetalhado.Resovido = aReport.Resolvido;
            aReportDetalhado.Foto = aReport.Foto64;

            return aReportDetalhado;
        }
    }
}
