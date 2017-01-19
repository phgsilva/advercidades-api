using AdverCidades.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Dados.Mapeamento
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("USUARIO");

            HasKey(u => u.Identificador);

            Property(u => u.Nome).HasMaxLength(45).IsRequired();
            Property(u => u.Email).HasMaxLength(45).IsRequired();
            Property(u => u.Senha).HasMaxLength(45).IsRequired();
            Property(u => u.Foto64);
        }
    }
}
