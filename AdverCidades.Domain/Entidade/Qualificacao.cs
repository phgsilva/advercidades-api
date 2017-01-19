using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Domain
{
    public class Qualificacao
    {
        public long Identificador { get; set; }
        public string Descricao { get; set; }
        public long ReportIdentificador { get; set; }
        public virtual Report Report { get; set; }
        public long UsuarioIdentificador { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
