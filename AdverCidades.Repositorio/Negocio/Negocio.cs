using AdverCidades.Dados.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Negocio
{
    public abstract class Negocio<T> where T : class
    {
        protected static IRepositorio<T> Repositorio { get; set; } 
    }
}
