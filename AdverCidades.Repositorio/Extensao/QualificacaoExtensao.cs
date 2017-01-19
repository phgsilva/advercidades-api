using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdverCidades.Domain;

namespace AdverCidades.Negocio
{
    public static class QualificacaoExtensao
    {
        internal static QualificacaoDTO PreencherQualificacao(this QualificacaoDTO aQualificacaoDto, Qualificacao aQualificacao)
        {
            aQualificacaoDto.Identificador = aQualificacao.Identificador;
            aQualificacaoDto.Descricao = aQualificacao.Descricao;

            return aQualificacaoDto;
        }
    }
}
