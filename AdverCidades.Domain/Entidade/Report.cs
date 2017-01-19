using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Domain
{
    public class Report
    {
        public long Identificador { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime DataHora { get; set; }
        public string Foto64 { get; set; }
        public bool Resolvido { get; set; }

        public long UsuarioIdentificador { get; set; }
        public Usuario Usuario { get; set; }
        public long CategoriaIdentificador { get; set; }
        public Categoria Categoria { get; set; }

        //public virtual ICollection<Qualificacao> Qualificacoes { get; set; }
        //public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
