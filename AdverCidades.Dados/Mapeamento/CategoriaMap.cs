using AdverCidades.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Dados.Mapeamento
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("CATEGORIA");

            HasKey(c => c.Identificador);
            Property(c => c.DescricaoCat).IsRequired();
        }
    }
}
