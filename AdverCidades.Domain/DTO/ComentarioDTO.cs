using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Domain
{
    public class ComentarioDTO
    {
        public string Comentario { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime Data { get; set; }
    }
}
