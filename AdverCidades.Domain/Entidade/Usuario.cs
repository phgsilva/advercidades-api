using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdverCidades.Domain
{
    public class Usuario
    {
        public long Identificador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto64 { get; set; }
    }
}
