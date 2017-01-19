using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AdverCidades.Domain;
using AdverCidades.Dados.Repositorio;
using AdverCidades.Dados.DataContexts;

namespace AdverCidades.Dados.DAO
{
    public class ComentarioDados : IRepositorio<Comentario>
    {
        protected AdverCidadesDataContext contexto;

        public ComentarioDados()
        {
            contexto = new AdverCidadesDataContext();
        }

        public void Salvar(Comentario aEntidade)
        {
            contexto.Set<Comentario>().Add(aEntidade);
            contexto.SaveChanges();
        }

        public void Excluir(Comentario aEntidade)
        {
            contexto.Set<Comentario>().Remove(aEntidade);
            contexto.SaveChanges();
        }

        public void Editar(Comentario aEntidade)
        {
            contexto.Entry<Comentario>(aEntidade).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public Comentario BuscarPorId(long aIdentificador)
        {
            return contexto.Set<Comentario>().Find(aIdentificador);
        }

        public IQueryable<Comentario> Buscar()
        {
            return contexto.Set<Comentario>().Include(c => c.Usuario).Include(c => c.Report);
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
