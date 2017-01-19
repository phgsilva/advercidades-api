using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using System.Web;
using System.Threading.Tasks;
using AdverCidades.Dados.DataContexts;
using AdverCidades.Domain;
using AdverCidades.Negocio;

namespace AdverCidades.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/adverCidades")]
    public class ReportsController : ApiController
    {
        // advercidadesapiv1.azurewebsites.net url da api na nuvem 
        #region .:GET:.

        [Route("reports")]
        public HttpResponseMessage GetReports()
        {
            //var reports = db.Reports.Include("Usuario")
            //                        .Include("Categoria");
            using (var reportNegocio = new ReportNegocio())
            {
                var reports = reportNegocio.BuscarReports();

                return Request.CreateResponse(HttpStatusCode.OK, reports);
            }
        }

        [Route("reports/{aIdReport}")]
        public HttpResponseMessage GetReports(long aIdReport)
        {
            // db.Reports.Find(aIdReport);
            //var reports = db.Reports.Where(r => r.Identificador == aIdReport)
            //                        .Include("Categoria")
            //                        .Include("Usuario")
            //                        .FirstOrDefault(); //.ToList();
 
            using (var reportNegocio = new ReportNegocio())
            {
                var report = reportNegocio.BuscarReportPorId(aIdReport);
                //report.Foto = @"data:image/gif;base64,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";

                return Request.CreateResponse(HttpStatusCode.OK, report);
            }
        }

        [Route("comentarios/{aIdReport}")]
        public HttpResponseMessage GetComents(long aIdReport)
        {
            //var comentarios = db.Comentarios.Where(c => c.ReportIdentificador == aIdReport)
            //                                .Include("Usuario")
            //                                .Include("Report")
            //                                .ToList();
            using (var comentarioNegocio = new ComentarioNegocio())
            {
                var comentarios = comentarioNegocio.BuscarComentarios(aIdReport);

                return Request.CreateResponse(HttpStatusCode.OK, comentarios);
            }
        }

        [Route("qualificacoes/{aIdReport}")]
        public HttpResponseMessage GetQualificacoes(long aIdReport)
        {
            //var qualificacoes = db.Qualificacoes.Where(q => q.ReportIdentificador == aIdReport)
            //                                    .Include("Report").ToList();
            using (var qualificacaoNegocio = new QualificacaoNegocio())
            {
                var qualificacoes = qualificacaoNegocio.BuscarQualificacoes(aIdReport);

                return Request.CreateResponse(HttpStatusCode.OK, qualificacoes);
            }
        }

        [Route("pesquisaReport/{aTermo}")]
        public HttpResponseMessage GetPesquisaReports(string aTermo)
        {
            //var resultadoReports = db.Reports.Where(r => r.Titulo.Contains(aTermo) ||
            //                                        r.Descricao.Contains(aTermo));
            using (var reportNegocio = new ReportNegocio())
            {
                var resultadoReports = reportNegocio.PesquisarReports(aTermo);

                return Request.CreateResponse(HttpStatusCode.OK, resultadoReports);
            }
        }
        #endregion

        #region .:POST:.

        [HttpPost]
        [Route("reports")]
        public HttpResponseMessage PostReport(Report aReport)
        {
            if (aReport == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
             
            try
            {
                //db.Reports.Add(aReport);
                //db.SaveChanges();
                //var novoReport = aReport;
                using (var reportNegocio = new ReportNegocio())
                {
                    reportNegocio.SalvarReport(aReport);
                    var novoReport = aReport;

                    return Request.CreateResponse(HttpStatusCode.OK, novoReport);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("comentarios")]
        public HttpResponseMessage PostComentario(Comentario aComentario)
        {
            if (aComentario == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                //db.Comentarios.Add(aComentario);
                //db.SaveChanges();
                using (var comentarioNegocio = new ComentarioNegocio())
                {
                    comentarioNegocio.SalvarComentario(aComentario);
                    var novoComentario = aComentario;

                    return Request.CreateResponse(HttpStatusCode.OK, novoComentario);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, string.Format("Falha ao postar comentario! {0}", e.Message));
            }
        }

        [HttpPost]
        [Route("qualificacoes")]
        public HttpResponseMessage PostQualificacao(Qualificacao aQualificacao)
        {
            if (aQualificacao == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                //db.Comentarios.Add(aQualificacao);
                //db.SaveChanges();
                using (var qualificacaoNegocio = new QualificacaoNegocio())
                {
                    qualificacaoNegocio.SalvarQualificacao(aQualificacao);
                    var novaQualificacao = aQualificacao;

                    return Request.CreateResponse(HttpStatusCode.OK, novaQualificacao);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, string.Format("Falha ao qualificar report! {0}", e.Message));
            }
        }

        #endregion

        #region  .:PUT:.

        [HttpPut]
        [Route("reports")]
        public HttpResponseMessage PutReport(Report aReport)
        {
            if (aReport == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                //db.Entry<Report>(aReport).State = EntityState.Modified;
                //db.SaveChanges();
                using (var reportNegocio = new ReportNegocio())
                {
                    reportNegocio.EditarReport(aReport);
                    var reportAlterado = aReport;

                    return Request.CreateResponse(HttpStatusCode.OK, reportAlterado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, string.Format("Falha ao alterar report! {0}", e.Message));
            }
        }

        #endregion

        #region .:DELETE:.

        [HttpDelete]
        [Route("reports")]
        public HttpResponseMessage DeleteReport(long aIdReport)
        {
            if (aIdReport <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                //db.Reports.Remove(db.Reports.Find(aIdReport));
                //db.SaveChanges();
                using (var reportNegocio = new ReportNegocio())
                {
                    reportNegocio.ExcluirReport(aIdReport);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, string.Format("Falha ao deletar report! {0}", e.Message));
            }
        } 

        #endregion  

        protected override void Dispose(bool disposing)
        {
        }
    }
}