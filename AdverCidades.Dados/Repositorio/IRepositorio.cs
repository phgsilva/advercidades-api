using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Dados.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        void Salvar(T aEntidade);
        void Excluir(T aEntidade);
        void Editar(T aEntidade);

        T BuscarPorId(long aIdentificador);
        IQueryable<T> Buscar();
        
        void Dispose();
    }
}
