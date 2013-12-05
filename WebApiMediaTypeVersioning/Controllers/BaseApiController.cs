using System.Web.Http;
using WebApiMediaTypeVersioning.Factories;
using WebApiMediaTypeVersioning.Repositories;

namespace WebApiMediaTypeVersioning.Controllers
{
    public class BaseApiController : ApiController
    {
        private IPeopleRepository _PeopleRepository;
        private PeopleFactory _PeopleFactory { get; set; }  

        public BaseApiController(IPeopleRepository peopleRepository)
        {
            _PeopleRepository = peopleRepository;
        }

        protected IPeopleRepository PeopleRepository
        {
            get { return _PeopleRepository; }
        }

        protected PeopleFactory PeopleFactory
        {
            get
            {
                if (_PeopleFactory == null)
                {
                    _PeopleFactory = new PeopleFactory(this.Request, PeopleRepository);
                }
                return _PeopleFactory;
            }
        }
    }
}
