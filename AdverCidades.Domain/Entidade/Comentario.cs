using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdverCidades.Domain
{
    public class Comentario
    {
        public long Identificador { get; set; }
        public string ConteudoComentario { get; set; }
        public DateTime DataComentario { get; set; }
        public long UsuarioIdentificador { get; set; }
        public virtual Usuario Usuario { get; set; }
        public long ReportIdentificador { get; set; }
        public virtual Report Report { get; set; }
    }
}
