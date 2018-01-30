using AutoMapper;
using DataModel.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteWebAPI.Models;

namespace TesteWebAPI.Controllers.Api
{
    public class ContatosController : ApiController
    {
        [HttpGet]
        [Route("api/Contatos")]
        public IEnumerable<ContatoDTO> GetContatos()
        {
            try
            {
                using (ISession session = FluentNHibernateHelper.OpenSession())
                {
                    var contatos = Mapper.Map<List<ContatoDTO>>(session.Query<Contato>());
                    return contatos;
                }
            }
            catch (Exception ex)
            {
                Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return null;
            }
        }

        [HttpPost]
        [Route("api/Contatos")]
        public HttpResponseMessage PostContatos(ContatoDTO contato)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                try
                {
                    var contatoSalvar = Mapper.Map<Contato>(contato);
                    contatoSalvar.OperadoraId = contatoSalvar.Operadora.Id;

                    session.SaveOrUpdate(contatoSalvar);
                    session.Flush();

                    return Request.CreateResponse(HttpStatusCode.OK, "Adicionado com sucesso"); ;
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message); ;
                }
            }
        }

        [HttpPost]
        [Route("api/deleteContatos")]
        public HttpResponseMessage DeleteContatos(List<ContatoDTO> contatosExcluir)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                try
                {
                    foreach (var item in contatosExcluir)
                    {
                        var contatoExcluir = Mapper.Map<Contato>(item);
                        session.Delete(contatoExcluir);
                    }

                    session.Flush();

                    return Request.CreateResponse(HttpStatusCode.OK, "Deletados com sucesso"); ;
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message); ;
                }
            }
        }
    }
}
