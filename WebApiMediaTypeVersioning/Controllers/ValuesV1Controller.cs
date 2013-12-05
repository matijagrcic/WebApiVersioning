using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMediaTypeVersioning.Controllers
{
    public class ValuesV1Controller : ApiController
    {
        public HttpResponseMessage Get()
        {
            var nonAttributeRoute = new List<string> { 
                "Non attribute 1",
                "Non attribute 2",
                "Non attribute 3",
            };

            return Request.CreateResponse(HttpStatusCode.OK, nonAttributeRoute);
        }
    }
}
