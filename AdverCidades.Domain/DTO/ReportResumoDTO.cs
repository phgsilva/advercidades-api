using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Domain
{
    public class ReportResumoDTO
    {
        public long Identificador { get; set; }
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Resolvido { get; set; }
    }
}
