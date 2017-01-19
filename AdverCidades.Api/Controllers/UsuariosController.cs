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
using System.Threading.Tasks;
using AdverCidades.Dados.DataContexts;
using AdverCidades.Domain;
using AdverCidades.Negocio;

namespace AdverCidades.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/adverCidades")]
    public class UsuariosController : ApiController
    {
        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        #region .:GET:.

        [Route("usuarios")]
        public HttpResponseMessage GetUsuario()
        {
            //var usuarios = db.Usuarios.ToList();
            using (var usuarioNegocio = new UsuarioNegocio())
            {
                var usuarios = usuarioNegocio.BuscarUsuarios();

                return Request.CreateResponse(HttpStatusCode.OK, usuarios);
            }
        }

        [Route("usuarios/{aIdUsuario}")]
        public HttpResponseMessage GetUsuario(long aIdUsuario)
        {
            //var usuario = db.Usuarios.Find(aIdUsuario); //FirstOrDefault(); // db.Usuarios.Find(aIdUsuario); //Where(u => u.Identificador == aIdUsuario)
            using (var usuarioNegocio = new UsuarioNegocio())
            {
                var usuario = usuarioNegocio.BuscarUsuarioPorId(aIdUsuario);

                return Request.CreateResponse(HttpStatusCode.OK, usuario);
            }
        }
        
        #endregion

        #region .:POST:.

        //[HttpPost]
        //[Route("uploadImageUsuario")]
        //public async Task<HttpResponseMessage> UploadImage()
        //{
        //    // criar calsse herdando de MultipartFormDataStreamProvider, para salvar com nome melhor 
        //    if (!Request.Content.IsMimeMultipartContent("form-data"))
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    try
        //    {
        //        var streamProvider = new MultipartFormDataStreamProvider("~/Images");
        //        await Request.Content.ReadAsMultipartAsync(streamProvider);

        //        return new HttpResponseMessage(HttpStatusCode.Created);
        //    }
        //    catch (Exception)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Falha ao Salvar imagem!");
        //    }
        //}

        [HttpPost]
        [Route("usuarios")]
        public HttpResponseMessage PostUsuario(Usuario aUsuario)
        {
            if (aUsuario == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                //db.Usuarios.Add(aUsuario);
                //db.SaveChanges();
                using (var usuarioNegocio = new UsuarioNegocio())
                {
                    usuarioNegocio.SalvarUsuario(aUsuario);
                    var novoUsuario = aUsuario;

                    return Request.CreateResponse(HttpStatusCode.OK, novoUsuario);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, string.Format("Falha ao cadastrar usuario! {0}", e.Message));
            }
        }
    
        #endregion

        #region .:PUT:.

        [HttpPut]
        [Route("usuario")]
        public HttpResponseMessage PutUsuario(Usuario aUsuario)
        {
            if (aUsuario == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                //db.Entry<Usuario>(aUsuario).State = EntityState.Modified;
                //db.SaveChanges();
                using (var usuarioNegocio = new UsuarioNegocio())
                {
                    usuarioNegocio.EditarUsuario(aUsuario);
                    var usuarioAlterado = aUsuario;

                    return Request.CreateResponse(HttpStatusCode.OK, usuarioAlterado);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, string.Format("Falha ao alterar usuario! {0}", e.Message));
            }
        }

        #endregion

        #region .:DELETE:.

        [HttpDelete]
        [Route("usuarios")]
        public HttpResponseMessage DeleteUsuario(long aIdUsuario)
        {
            if (aIdUsuario <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                //db.Usuarios.Remove(db.Usuarios.Find(aIdUsuario));
                //db.SaveChanges();
                using (var usuarioNegocio = new UsuarioNegocio())
                {
                    usuarioNegocio.ExcluirUsuario(aIdUsuario);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, string.Format("Falha ao deletar usuario! {0}", e.Message));
            }
        }

        #endregion  

        protected override void Dispose(bool disposing)
        {
        }
    }
} 