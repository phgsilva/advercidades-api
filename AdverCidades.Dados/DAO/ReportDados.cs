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
    public class ReportDados : IRepositorio<Report>
    {
        protected AdverCidadesDataContext contexto;

        public ReportDados()
        {
            contexto = new AdverCidadesDataContext();
        }

        public void Salvar(Report aEntidade)
        {
            contexto.Set<Report>().Add(aEntidade);
            contexto.SaveChanges();
        }

        public void Excluir(Report aEntidade)
        {
            contexto.Set<Report>().Remove(aEntidade);
            contexto.SaveChanges();
        }

        public void Editar(Report aEntidade)
        {
            contexto.Entry<Report>(aEntidade).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public Report BuscarPorId(long aIdentificador)
        {
            return contexto.Set<Report>().Find(aIdentificador);
        }

        public IQueryable<Report> Buscar()
        {
            return contexto.Set<Report>().Include(r => r.Usuario).Include(r => r.Categoria);
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
