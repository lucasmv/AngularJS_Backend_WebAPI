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
        public HttpResponseMessage GetContatos()
        {
            try
            {
                using (ISession session = FluentNHibernateHelper.OpenSession())
                {
                    var contatos = Mapper.Map<List<ContatoDTO>>(session.Query<Contato>());
                    return Request.CreateResponse(HttpStatusCode.OK, contatos);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Contatos/{id:int}")]
        public HttpResponseMessage GetContato(int id)
        {
            try
            {
                using (ISession session = FluentNHibernateHelper.OpenSession())
                {
                    var contato = Mapper.Map<ContatoDTO>(session.Get<Contato>(id));

                    if (contato == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contato não encontrado.");

                    return Request.CreateResponse(HttpStatusCode.OK, contato);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
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

                    if (contatoSalvar.Operadora != null)
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
