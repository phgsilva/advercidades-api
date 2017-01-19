using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdverCidades.Domain;
using AdverCidades.Dados.DAO;
using AdverCidades.Dados.DataContexts;

namespace AdverCidades.Negocio
{
    public class ReportNegocio : Negocio<Report>, IDisposable
    {        
        /// <summary>
        /// Construtor que instancia classe de repositorio
        /// </summary>
        public ReportNegocio()
        {
            Repositorio = new ReportDados();
        }

        /// <summary>
        /// Metodo que salva report no banco
        /// </summary>
        /// <param name="aReport">Report a ser salvo</param>
        public void SalvarReport(Report aReport)
        {
            Repositorio.Salvar(aReport);
        }

        /// <summary>
        /// Metodo que exclui report do bacno
        /// </summary>
        /// <param name="aReport">Identificador do report que será excluído</param>
        public void ExcluirReport(long aIdReport)
        {
            var report = Repositorio.BuscarPorId(aIdReport);
            Repositorio.Excluir(report);
        }

        /// <summary>
        /// Metodo que salva alterações na entidade report no banco
        /// </summary>
        /// <param name="aReport">Entidade report alterada</param>
        public void EditarReport(Report aReport)
        {
            Repositorio.Editar(aReport);
        }

        /// <summary>
        /// Metodo que busca entidade report por identificador
        /// </summary>
        /// <param name="aIdentificador">Identificador do report que deseja buscar</param>
        /// <returns>Entidade report encontrada</returns>
        public ReportDetalhadoDTO BuscarReportPorId(long aIdentificador)
        {
            var report = Repositorio.Buscar().Where(r => r.Identificador == aIdentificador).FirstOrDefault();
            ReportDetalhadoDTO reportDetalhado = null;
            if (report != null)
                reportDetalhado = new ReportDetalhadoDTO().PreencherReportDetalhadoDto(report); 

            return reportDetalhado;
        }

        /// <summary>
        /// Busca todos reports no banco
        /// </summary>
        /// <returns>Coleção de reports</returns>
        public IEnumerable<ReportResumoDTO> BuscarReports()
        {
            var reports = Repositorio.Buscar().ToList();

            IEnumerable<ReportResumoDTO> reportsResumo = reports.Select(r => new ReportResumoDTO().PreencherReportResumoDto(r));

            return reportsResumo;
        }

        /// <summary>
        /// Metodo que pesquisa reports por termo, que esteja na descrição ou titulo
        /// </summary>
        /// <param name="aTermo">Termo pelo qual deseja fazer pesquisa</param>
        /// <returns>Coleção de reports encontados</returns>
        public IEnumerable<ReportResumoDTO> PesquisarReports(string aTermo)
        {
            var reports = Repositorio.Buscar().Where(r => r.Titulo.Contains(aTermo)
                                                    || r.Descricao.Contains(aTermo)).ToList();
            IEnumerable<ReportResumoDTO> reportsResumo = reports.Select(r => new ReportResumoDTO().PreencherReportResumoDto(r));

            return reportsResumo;
        }

        public void Dispose()
        {
            Repositorio.Dispose();
        }
    }
}
