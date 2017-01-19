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
    public class QualificacaoDados : IRepositorio<Qualificacao> 
    {
        protected AdverCidadesDataContext contexto;

        public QualificacaoDados()
        {
            contexto = new AdverCidadesDataContext();
        }

        public void Salvar(Qualificacao aEntidade)
        {
            contexto.Set<Qualificacao>().Add(aEntidade);
            contexto.SaveChanges();
        }

        public void Excluir(Qualificacao aEntidade)
        {
            contexto.Set<Qualificacao>().Remove(aEntidade);
            contexto.SaveChanges();
        }

        public void Editar(Qualificacao aEntidade)
        {
            contexto.Entry<Qualificacao>(aEntidade).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public Qualificacao BuscarPorId(long aIdentificador)
        {
            return contexto.Set<Qualificacao>().Find(aIdentificador);
        }

        public IQueryable<Qualificacao> Buscar()
        {
            return contexto.Set<Qualificacao>().Include(c => c.Usuario);
        }

        public void Dispose()
        {
            contexto.Dispose();
        } 
    }
}
