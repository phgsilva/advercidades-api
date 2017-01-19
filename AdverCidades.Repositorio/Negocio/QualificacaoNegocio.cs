using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdverCidades.Dados.DAO;
using AdverCidades.Domain;


namespace AdverCidades.Negocio
{
    public class QualificacaoNegocio : Negocio<Qualificacao>, IDisposable
    {
        /// <summary>
        /// Construtor que isntancia classe de repositorio
        /// </summary>
        public QualificacaoNegocio()
	    {
            Repositorio = new QualificacaoDados();            
	    }

        /// <summary>
        /// Metodo que salva qualificacao de um report no banco
        /// </summary>
        /// <param name="aQualificacao">Qualificacao a ser salva</param>
        public void SalvarQualificacao(Qualificacao aQualificacao)
        {
            Repositorio.Salvar(aQualificacao);
        }

        /// <summary>
        /// Metodo que busca todas qualificações de um report
        /// </summary>
        /// <param name="aIdentificadorReport">Identificador do report do qual deseja bucar as qualificacoes</param>
        /// <returns></returns>
        public IEnumerable<QualificacaoDTO> BuscarQualificacoes(long aIdentificadorReport)
        {
            var qualificacoes = Repositorio.Buscar().Where(q => q.ReportIdentificador == aIdentificadorReport).ToList();
            IEnumerable<QualificacaoDTO> qualificacoesDto = qualificacoes.Select(q => new QualificacaoDTO().PreencherQualificacao(q));

            return qualificacoesDto;
        }

        public void Dispose()
        {
            Repositorio.Dispose();
        }
    }
}
