using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using AdverCidades.Domain;

namespace AdverCidades.Dados.Mapeamento
{
    public class QualificacaoMap : EntityTypeConfiguration<Qualificacao>
    {
        public QualificacaoMap()
        {
            ToTable("QUALIFICACAO");

            HasKey(q => q.Identificador);

            Property(q => q.Descricao).HasMaxLength(45).IsRequired();

            HasRequired(q => q.Report);
            HasRequired(q => q.Usuario);
        }
    }
}
