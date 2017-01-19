using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdverCidades.Dados.Repositorio;
using AdverCidades.Domain;
using AdverCidades.Dados.DataContexts;
using System.Data.Entity;

namespace AdverCidades.Dados.DAO
{
    public class UsuarioDados : IRepositorio<Usuario>
    {
        protected AdverCidadesDataContext contexto;

        public UsuarioDados()
        {
            contexto = new AdverCidadesDataContext();
        }

        public void Salvar(Usuario aEntidade)
        {
            contexto.Set<Usuario>().Add(aEntidade);
            contexto.SaveChanges();
        }

        public void Excluir(Usuario aEntidade)
        {
            contexto.Set<Usuario>().Remove(aEntidade);
            contexto.SaveChanges();
        }

        public void Editar(Usuario aEntidade)
        {
            contexto.Entry<Usuario>(aEntidade).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public Usuario BuscarPorId(long aIdentificador)
        {
            return contexto.Set<Usuario>().Find(aIdentificador);
        }

        public IQueryable<Usuario> Buscar()
        {
            return contexto.Set<Usuario>();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
