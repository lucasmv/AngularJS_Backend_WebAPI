using AutoMapper;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Web.Http;
using TesteWebAPI.Models;

namespace TesteWebAPI.Controllers.Api
{
    public class OperadorasController : ApiController
    {
        [HttpGet]
        [Route("api/Operadoras")]
        public IEnumerable<OperadoraDTO> Get()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var operadoras = Mapper.Map<List<OperadoraDTO>>(session.Query<DataModel.Entities.Operadora>());
                return operadoras;
            }
        }
    }
}
