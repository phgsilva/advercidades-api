using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Domain
{
    public class ReportDetalhadoDTO
    {
        public long Identificador { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Data { get; set; }
        public string Foto { get; set; }
        public bool Resovido { get; set; }
        public long IdentificadorUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public long IdentificadorCategoria { get; set; }
        public string DescricaoCategoria { get; set; }
    }
}
