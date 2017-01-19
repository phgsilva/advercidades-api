using AdverCidades.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Dados.Mapeamento
{
    public class ComentarioMap : EntityTypeConfiguration<Comentario>
    {
        public ComentarioMap()
        {
            ToTable("COMENTARIO");

            HasKey(c => c.Identificador);

            Property(c => c.ConteudoComentario).IsRequired();
            Property(c => c.DataComentario);

            HasRequired(c => c.Report);
            HasRequired(c => c.Usuario);
        }
    }
}
