using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiMediaTypeVersioning.Models.People;
using WebApiMediaTypeVersioning.Repositories;

namespace WebApiMediaTypeVersioning.Controllers
{
    [RoutePrefix("api/people")]
    public class PeopleV1Controller : BaseApiController
    {
        public PeopleV1Controller(IPeopleRepository repository)
            : base(repository)
        {

        }

       
        [Route("")]
        [ResponseType(typeof(IEnumerable<PeopleVM>))]
        public HttpResponseMessage GetPeople()
        {
            var people = PeopleRepository
                .FindPeople()
                .Select(p => PeopleFactory.Create(p));

            if (people == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { people = people });
        }

        [Route("identifier/{id}", Name = "GetPersonByIdV1")]
        [ResponseType(typeof(PeopleVM))]
        public HttpResponseMessage GetPersonById(int id)
        {
            var person = PeopleRepository.FindPeopleById(id);
            if (person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { person = PeopleFactory.Create(person) });
        }
    }
}
