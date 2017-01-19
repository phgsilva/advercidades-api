using AdverCidades.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Dados.Mapeamento
{
    public class ReportMap : EntityTypeConfiguration<Report>
    {
        public ReportMap()
        {
            ToTable("REPORT");

            HasKey(r => r.Identificador);

            Property(r => r.Titulo).HasMaxLength(45).IsRequired();
            Property(r => r.Descricao).IsRequired();
            Property(r => r.Latitude).HasMaxLength(45).IsRequired();
            Property(r => r.Longitude).HasMaxLength(45).IsRequired();
            Property(r => r.DataHora);
            Property(r => r.Foto64);

            HasRequired(r => r.Usuario).WithMany().WillCascadeOnDelete(false);
            HasRequired(r => r.Categoria);
        }
    }
}
