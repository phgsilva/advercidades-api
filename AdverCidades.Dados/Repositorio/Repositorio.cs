using AdverCidades.Dados.DataContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdverCidades.Dados.Repositorio
{
    /// <summary>
    /// Classe repositorio generica. Utilizar somente caso nescessario, preferencialmente criar classes de dados 
    /// da entidade especifica implementando IRepositorio
    /// </summary>
    /// <typeparam name="T">Classe de entidade</typeparam>
    internal class Repositorio<T> : IDisposable, IRepositorio<T> where T : class
    {
        protected AdverCidadesDataContext contexto;

        public Repositorio()
        {
            contexto = new AdverCidadesDataContext();
        }

        public void Salvar(T aEntidade)
        {
            contexto.Set<T>().Add(aEntidade);
            contexto.SaveChanges();
        }

        public void Excluir(T aEntidade)
        {
            contexto.Set<T>().Remove(aEntidade);
            contexto.SaveChanges();
        }

        public void Editar(T aEntidade)
        {
            contexto.Entry<T>(aEntidade).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public T BuscarPorId(long aIdentificador)
        {
            return contexto.Set<T>().Find(aIdentificador);
        }

        public IQueryable<T> Buscar()
        {
            return contexto.Set<T>();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
