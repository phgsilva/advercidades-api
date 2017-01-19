using AdverCidades.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdverCidades.Dados.Mapeamento;

namespace AdverCidades.Dados.DataContexts
{
    public class AdverCidadesDataContext : DbContext 
    {
        public AdverCidadesDataContext() : base("AdverCidadesConnectionString")
        {
            //Database.SetInitializer<AdverCidadesDataContext>(new AdverCidadesDataContextInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        static AdverCidadesDataContext()
        {
            Database.SetInitializer<AdverCidadesDataContext>(new AdverCidadesDataContextInitializer());
        }

        public IDbSet<Report> Reports { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<Comentario> Comentarios { get; set; }
        public IDbSet<Categoria> Categorias { get; set; }
        public IDbSet<Qualificacao> Qualificacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReportMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new ComentarioMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new QualificacaoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
