using System;
using System.Net.Http;
using System.Web.Http.Routing;
using WebApiMediaTypeVersioning.Models.People;
using WebApiMediaTypeVersioning.Repositories;

namespace WebApiMediaTypeVersioning.Factories
{
    public class PeopleFactory
    {
        private UrlHelper _UrlHelper;
        private IPeopleRepository _PeopleRepository;
        public PeopleFactory(HttpRequestMessage request, IPeopleRepository peopleRepository)
        {
            _UrlHelper = new UrlHelper(request);
            _PeopleRepository = peopleRepository;
        }

        public PeopleVM Create(PeopleVM person)
        {
            return new PeopleVM()
            {
                Id = person.Id,
                Url = _UrlHelper.Link("GetPersonByIdV1", new { id = person.Id }),
                FirstName = person.FirstName,
                LastName = person.LastName
            };
        }


        //If you don't set the RouteName property, Web API generates the name. 
        //The default route name is "ControllerName.ActionName". 
        public PeopleVM2 Create(PeopleVM2 person)
        {
            return new PeopleVM2()
            {
                Id = person.Id,
                Url = _UrlHelper.Link("GetPersonByIdV2", new { id = person.Id }),
                FirstName = person.FirstName,
                LastName = person.LastName,
                Mobile = person.Mobile,
                Telephone = person.Telephone,
                Website = person.Website
            };
        }
    }
}